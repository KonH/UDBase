using System;
using System.Collections.Generic;
using UnityEngine;
using Rotorz.Games.Reflection;
using OneLine;

namespace UDBase.Controllers.ConfigSystem {

	/// <summary>
	/// Basic interface for config node.
	/// Used only for ClassTypeReference filtering.
	/// </summary>
	public interface IConfigSource { }

	/// <summary>
	/// Common classes for IConfig
	/// </summary>
	public class Config {

		/// <summary>
		/// Config item.
		/// </summary>
		[Serializable]
		public class ConfigItem {
			/// <summary>
			/// The type.
			/// </summary>
			[ClassImplements(typeof(IConfigSource))]
			public ClassTypeReference Type;

			/// <summary>
			/// The name.
			/// </summary>
			public string Name;
		}

		/// <summary>
		/// Common config settings
		/// </summary>
		[Serializable]
		public class Settings {

			/// <summary>
			/// Items, which presented in config
			/// </summary>
			[Tooltip("Items, which presented in config")]
			[OneLine]
			public List<ConfigItem> Items;
		}

		/// <summary>
		/// FsJsonResourcesConfig settings
		/// </summary>
		[Serializable]
		public class JsonSettings : Settings {

			/// <summary>
			/// Name of asset with json-config in Resources
			/// </summary>
			[Tooltip("Name of asset with json-config in Resources")]
			public string FileName;
		}

		/// <summary>
		/// FsJsonNetworkConfig settings
		/// </summary>
		[Serializable]
		public class JsonNetworkSettings : JsonSettings {

			/// <summary>
			/// Url of web server
			/// </summary>
			[Tooltip("Url of web server")]
			public string Url;

			/// <summary>
			/// File name on web server
			/// </summary>
			[Tooltip("File name on web server")]
			public string WebFileName;

			/// <summary>
			/// Get full url to config based on current Url
			/// (can be overrided in your child settings class to use version/platform specific separation)
			/// </summary>
			public virtual string GetFullConfigUrl() {
				return string.Format("{0}/{1}", Url, WebFileName);
			}
		}
	}
}
