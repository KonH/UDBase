using System;
using System.Linq;
using System.Collections.Generic;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.LeaderboardSystem {

	/// <summary>
	/// Leaderboard without network interactions (can be used as mock).
	/// Works only in current session and doesn't save data after relaunch.
	/// </summary>
	public class LocalLeaderboard : ILeaderboard, ILogContext {
		
		public string Version { get; set; }

		ULogger _log;

		List<LeaderboardItem> _items = new List<LeaderboardItem>();

		public LocalLeaderboard(ILog log) {
			_log = log.CreateLogger(this);
		}

		public void GetScores(int max, string parameter, Action<List<LeaderboardItem>> callback) {
			var filteredData = new List<LeaderboardItem>();
			foreach ( var item in _items ) {
				if ( item.Param == parameter ) {
					filteredData.Add(item);
				}
			}
			var result = filteredData.Take(max).OrderByDescending(i => i.Score).ToList();
			_log.MessageFormat("Retrieve {0} items for parameter '{1}'", result.Count, parameter);
			callback?.Invoke(result);
		}

		public void PostScore(string parameter, string playerName, int score, Action<bool> callback) {
			_items.Add(new LeaderboardItem(string.Empty, string.Empty, parameter, playerName,  score));
			_log.MessageFormat(
				"Add item: param: '{0}', playerName: '{1}', score = {2}",
				parameter, playerName, score);
			callback?.Invoke(true);
		}
	}
}
