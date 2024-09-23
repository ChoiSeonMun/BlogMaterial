#pragma once

#include <mutex>

class AccountManager
{
public:
	void AccountThenPlayer();
	void Lock();
private:
	std::mutex _lock;
};

extern AccountManager g_accountManager;