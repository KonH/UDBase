using System;
using System.Collections.Generic;

namespace UDBase.Controllers.LeaderboardSystem {

	/// <summary>
	/// Leaderboard interface.
	/// With ILeaderboard you can send your player scores, collect it and pull in ordered and filtered format.
	/// You can use two filters: parameter (such as Level or GameType) and version (like 1.0.0 and so on).
	/// Also, you can combine or skip it.
	/// </summary>
	public interface ILeaderboard {

		/// <summary>
		/// Gets or sets the game version, which can be used to filtering, may be empty
		/// </summary>
		string Version { get; set; }

		/// <summary>
		/// Gets the scores, returns null to callback if can't retrieve data.
		/// max - maximum result rows.
		/// parameter - filtering condition (like level name, game type etc), can be empty.
		/// returns data only for current game and version (if specified).
		/// </summary>
		void GetScores(int max, string parameter, Action<List<LeaderboardItem>> callback);

		/// <summary>
		/// Posts the score, returns operation result to callback.
		/// parameter - current level name, game type etc, can be empty.
		/// playerName/scores - current player info.
		/// Version is also used in request.
		/// </summary>
		void PostScore(string parameter, string playerName, int score, Action<bool> callback);
	}
}
