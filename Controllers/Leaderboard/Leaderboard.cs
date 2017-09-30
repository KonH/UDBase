using System;
using System.Collections.Generic;

namespace UDBase.Controllers.LeaderboardSystem {
	public class Leaderboard : ControllerHelper<ILeaderboard> {
		public static string Version {
			get {
				if ( Instance != null ) {
					return Instance.Version;
				}
				return null;
			}
			set {
				if ( Instance != null ) {
					Instance.Version = value;
				}
			}
		}

		public static void GetScores(int max, string parameter, Action<List<LeaderboardItem>> callback) {
			if ( Instance != null ) {
				Instance.GetScores(max, parameter, callback);
			}
		}

		public static void PostScore(string param, string userName, int score, Action<bool> callback) {
			if ( Instance != null ) {
				Instance.PostScore(param, userName, score, callback);
			}
		}
	}
}
