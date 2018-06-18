using UnityEngine;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.ConfigSystem {

	/// <summary>
	/// Config controller, which uses JSON file (located in Resources) serialization via Fullserializer
	/// </summary>
	public sealed class FsJsonResourcesConfig : FsJsonBaseConfig, ILogContext {

		public FsJsonResourcesConfig(Config.JsonSettings settings, ILog log) : base(log) {
			var fileName = settings.FileName;
			var config = Resources.Load(fileName) as TextAsset;
			if( config ) {
				LoadContent(config.text);
			} else {
				_logger.ErrorFormat("Can't read config file from Resources/{0}",  fileName);
			}
			InitNodes(settings.Items);
		}
	}
}