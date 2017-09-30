using FullSerializer;

namespace UDBase.Controllers.LeaderboardSystem {
	public class LeaderboardItem {
		[fsProperty("game")]
		public string Game     { get; private set; }
		[fsProperty("version")]
		public string Version  { get; private set; }
		[fsProperty("param")]
		public string Param    { get; private set; }
		[fsProperty("user")]
		public string UserName { get; private set; }
		[fsProperty("score")]
		public int    Score    { get; private set; }

		public LeaderboardItem() {}

		public LeaderboardItem(string userName, int score) {
			UserName = userName;
			Score    = score;
		}

		public LeaderboardItem(string game, string version, string param, string userName, int score):
			this(userName, score) {
			Game    = game;
			Version = version;
			Param   = param;
		}
	}
}
