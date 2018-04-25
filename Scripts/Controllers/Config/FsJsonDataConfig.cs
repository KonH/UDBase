using System.IO;
using UnityEngine;
using UDBase.Controllers.LogSystem;
using UDBase.Utils;

namespace UDBase.Controllers.ConfigSystem {

	/// <summary>
	/// Config fallback controller, which uses JSON file (located in Application.persistentDataPath) serialization via Fullserializer
	/// </summary>
	public sealed class FsJsonDataConfig : FsJsonBaseConfig, ILogContext {

		bool _isReady = false;

		public FsJsonDataConfig(Config.JsonSettings settings, ILog log) : base(log) {
			var filePath = Path.Combine(Application.persistentDataPath, settings.FileName + ".json");
			var configFileContents = IOTool.ReadAllText(filePath, true);
			if( !string.IsNullOrEmpty(configFileContents) ) {
				LoadContent(configFileContents);
				_isReady = true;
			} else {
				_log.MessageFormat(this, "Can't read config file from '{0}'",  filePath);
			}
			InitNodes(settings.Items);
		}

		public override bool IsReady() => _isReady;
	}
}