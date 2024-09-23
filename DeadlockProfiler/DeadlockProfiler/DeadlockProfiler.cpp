#include <format>

#include "DeadlockProfiler.h"

DeadlockProfiler SafeLockGuard::s_deadlockProfiler;

thread_local stack<int32_t>t_lockSequence;

void DeadlockProfiler::PushLock(mutex* const lock)
{
	lock_guard<mutex> guard(_lock);

	lock_id id = getOrCreateId(lock);

	if (t_lockSequence.size() > 0 && isNewLock(id))
	{
		lock_id prevId = t_lockSequence.top();
		_neighbors[prevId].insert(id);
		checkDeadlock();
	}

	t_lockSequence.push(id);
	lock->lock();
}

void DeadlockProfiler::PopLock(mutex* const lock)
{
	lock_guard<mutex> guard(_lock);

	/*lock_id prev = t_lockSequence.top();
	lock_id current = getOrCreateId(lock);
	if (prev != current)
	{
		CRASH("INVALID");
	}*/

	t_lockSequence.pop();
	lock->unlock();
}

lock_id DeadlockProfiler::getOrCreateId(mutex* const lock)
{
	if (false == _lockToId.contains(lock))
	{
		lock_id newId = static_cast<lock_id>(_lockToId.size());
		_lockToId[lock] = newId;
	}

	return _lockToId[lock];
}

bool DeadlockProfiler::isNewLock(lock_id id)
{
	lock_id prevId = t_lockSequence.top();

	if (prevId == id)
	{
		return false;
	}

	if (_neighbors[prevId].contains(id))
	{
		return false;
	}

	return true;
}

static constexpr int32_t NOT_VISIT = -1;
static constexpr lock_id INVALID_ID = -1;
void DeadlockProfiler::checkDeadlock()
{
	int32_t lockCount = static_cast<int32_t>(_lockToId.size());
	_visitOrder = vector(lockCount, NOT_VISIT);
	_visitOrderNumber = 0;
	_hasFinishedToCheckCycle = vector(lockCount, false);

	for (lock_id id = 0; id < lockCount; ++id)
	{
		checkCycle(id);
	}

	_visitOrder.clear();
	_hasFinishedToCheckCycle.clear();
}

void DeadlockProfiler::checkCycle(lock_id id)
{
	if (_visitOrder[id] != NOT_VISIT)
	{
		return;
	}

	_visitOrder[id] = _visitOrderNumber++;

	for (lock_id neighbor : _neighbors[id])
	{
		if (_visitOrder[neighbor] == NOT_VISIT)
		{
			checkCycle(neighbor);
			continue;
		}

		if (_visitOrder[id] < _visitOrder[neighbor])
		{
			continue;
		}

		if (_hasFinishedToCheckCycle[id] == false)
		{
			CRASH("DEADLOCK_DETECTED");
		}
	}

	_hasFinishedToCheckCycle[id] = true;
}
