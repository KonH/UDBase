using FullSerializer;

namespace UDBase.Controllers.LeaderboardSystem {
	public class LeaderboardItem {

		[fsProperty("user")]
		public string UserName { get; private set; }
		[fsProperty("score")]
		public int    Score    { get; private set; }

		public LeaderboardItem() {}

		public LeaderboardItem(string userName, int score) {
			UserName = userName;
			Score    = score;
		}
	}
}
