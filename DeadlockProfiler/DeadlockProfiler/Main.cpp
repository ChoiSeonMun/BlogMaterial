#include <thread>
#include <iostream>

#include "DeadlockProfiler.h"
#include "PlayerManager.h"
#include "AccountManager.h"

using namespace std;

int main()
{
	jthread t1([&]
		{
			while (true)
			{
				cout << "Task1 Run\n";
				g_playerManager.PlayerThenAccount();
				this_thread::sleep_for(100ms);
			}
		});

	jthread t2([&]
		{
			while (true)
			{
				cout << "Task2 Run\n";
				g_accountManager.AccountThenPlayer();
				this_thread::sleep_for(100ms);
			}
		});
}