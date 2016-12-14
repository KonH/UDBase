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
		public const int Json      = 7;
		public const int Event     = 8;

		protected string[] _defaultNames = new string[]{
			"Untagged",
			"Common", 
			"UI", 
			"Scene", 
			"Inventory", 
			"Config",
		    "Save",
			"Json",
			"Event"};

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