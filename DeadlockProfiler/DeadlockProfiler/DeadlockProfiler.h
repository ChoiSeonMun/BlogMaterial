#pragma once

#include <map>
#include <set>
#include <stack>
#include <mutex>
#include <unordered_map>
#include <vector>

#define CRASH(cause)			\
{								\
	uint32_t* crash = nullptr;	\
	*crash = 0xDEADBEEF;		\
}

using namespace std;

using lock_id = int32_t;

class DeadlockProfiler
{
	mutex	_lock;

public:
	void	PushLock(mutex* const lock);
	void	PopLock(mutex* const lock);

private:
	lock_id	getOrCreateId(mutex* const lock);
	bool	isNewLock(lock_id id);
	void	checkDeadlock();
	void	checkCycle(lock_id id);
private:
	unordered_map<mutex*, lock_id>			_lockToId;
	unordered_map<lock_id, set<lock_id>>	_neighbors;
	vector<int32_t>							_visitOrder;
	int32_t									_visitOrderNumber;
	vector<bool>							_hasFinishedToCheckCycle;
};

class SafeLockGuard
{
	static DeadlockProfiler s_deadlockProfiler;
public:
	explicit SafeLockGuard(mutex& lock)
		: _lock{ lock }
	{
		s_deadlockProfiler.PushLock(&lock);
	}
	~SafeLockGuard()
	{
		s_deadlockProfiler.PopLock(&_lock);
	}
private:
	mutex& _lock;
};