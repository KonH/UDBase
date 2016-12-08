using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.LogSystem {
	public class LogTags {
		public const int Common    = 1;
		public const int UI        = 2;
		public const int Scene     = 3;
		public const int Inventory = 4;
		public const int Config    = 5;
		public const int Save      = 6;

		string[] _names = new string[]{
			"Common", 
			"UI", 
			"Scene", 
			"Inventory", 
			"Config",
		    "Save"};

		public virtual string GetName(int index) {
			switch( index ) {
				case Common    : return "Common";
				case UI        : return "UI";
				case Scene     : return "Scene";
				case Inventory : return "Inventory";
				case Config    : return "Config";
				case Save      : return "Save";
			}
			return "Unknown";
		}

		public virtual string[] GetNames() {
			return _names;
		}
	}
}