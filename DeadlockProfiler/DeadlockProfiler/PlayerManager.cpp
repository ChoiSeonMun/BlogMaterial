#include "DeadlockProfiler.h"
#include "PlayerManager.h"
#include "AccountManager.h"

PlayerManager g_playerManager;

void PlayerManager::PlayerThenAccount()
{
	SafeLockGuard g(_lock);

	g_accountManager.Lock();
}

void PlayerManager::Lock()
{
	SafeLockGuard g(_lock);
}