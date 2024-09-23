#include "DeadlockProfiler.h"
#include "AccountManager.h"
#include "PlayerManager.h"

AccountManager g_accountManager;

void AccountManager::AccountThenPlayer()
{
	SafeLockGuard g(_lock);

	g_playerManager.Lock();
}

void AccountManager::Lock()
{
	SafeLockGuard g(_lock);
}