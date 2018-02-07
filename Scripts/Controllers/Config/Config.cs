using System;
using System.Collections.Generic;
using Rotorz.Games.Reflection;

namespace UDBase.Controllers.ConfigSystem {
	public interface IConfigSource { }

	public class Config {
		
		[Serializable]
		public class ConfigItem {
			[ClassImplements(typeof(IConfigSource))]
			public ClassTypeReference Type;
			public string Name;
		}

		[Serializable]
		public class Settings {
			public List<ConfigItem> Items;
		}

		[Serializable]
		public class JsonSettings : Settings {
			public string FileName;
		}
	}
}
