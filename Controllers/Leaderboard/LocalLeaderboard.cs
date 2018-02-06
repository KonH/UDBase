using System;
using System.Linq;
using System.Collections.Generic;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.LeaderboardSystem {
	public class LocalLeaderboard : ILeaderboard {
		
		public string Version { get; set; }

		ILog _log;

		List<LeaderboardItem> _items = new List<LeaderboardItem>();

		public LocalLeaderboard(ILog log) {
			_log = log;
		}

		public void GetScores(int max, string parameter, Action<List<LeaderboardItem>> callback) {
			var filteredData = new List<LeaderboardItem>();
			foreach ( var item in _items ) {
				if ( item.Param == parameter ) {
					filteredData.Add(item);
				}
			}
			var result = filteredData.Take(max).OrderByDescending(i => i.Score).ToList();
			_log.MessageFormat(LogTags.Leaderboard, "Retrieve {0} items for parameter '{1}'", result.Count, parameter);
			if ( callback != null ) {
				callback(result);
			}
		}

		public void PostScore(string param, string userName, int score, Action<bool> callback) {
			_items.Add(new LeaderboardItem(string.Empty, string.Empty, param, userName,  score));
			_log.MessageFormat(
				LogTags.Leaderboard,
				"Add item: param: '{0}', userName: '{1}', score = {2}",
				param, userName, score);
			if ( callback != null ) {
				callback(true);
			}
		}
	}
}
