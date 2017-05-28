namespace UDBase.Controllers.LogSystem {
	public class LogTags {
		public const int Common      = 1;
		public const int UI          = 2;
		public const int Scene       = 3;
		public const int Inventory   = 4;
		public const int Config      = 5;
		public const int Save        = 6;
		public const int Json        = 7;
		public const int Event       = 8;
		public const int Content     = 9;
		public const int Time        = 10;
		public const int Network     = 11;
		public const int Leaderboard = 12;
		public const int Audio       = 13;

		protected string[] _defaultNames = new string[]{
			"Untagged",
			"Common", 
			"UI", 
			"Scene", 
			"Inventory", 
			"Config",
		    "Save",
			"Json",
			"Event",
			"Content",
			"Time",
		    "Network",
			"Leaderboard",
			"Audio"};

		public virtual string GetName(int index) {
			if( (index >= 0) && (index < _defaultNames.Length) ) {
				return _defaultNames[index];
			}
			return "?";
		}

		public virtual string[] GetNames() {
			return _defaultNames;
		}
	}
}