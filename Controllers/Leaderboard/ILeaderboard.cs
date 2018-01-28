using System;
using System.Collections.Generic;

namespace UDBase.Controllers.LeaderboardSystem {
	public interface ILeaderboard {
		string Version { get; set; }

		void GetScores(int max, string parameter, Action<List<LeaderboardItem>> callback);
		void PostScore(string param, string userName, int score, Action<bool> callback);
	}
}
