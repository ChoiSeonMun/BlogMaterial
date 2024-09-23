#pragma once

#include <mutex>

class PlayerManager
{
public:
	void PlayerThenAccount();
	void Lock();
private:
	std::mutex _lock;
};

extern PlayerManager g_playerManager;

