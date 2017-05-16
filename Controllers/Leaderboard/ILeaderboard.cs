using System;
using System.Collections.Generic;

namespace UDBase.Controllers.LeaderboardSystem {
	public interface ILeaderboard : IController {

		string Version { get; set; }

		void GetScores(int max, string parameter, Action<List<LeaderboardItem>> callback);
	}
}
