using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UDBase.Common;
using UDBase.Controllers;
using UDBase.Utils.Json;

namespace UDBase.Controllers.ConfigSystem {
	public sealed class JsonResourcesConfig : IConfig {
		string               _fileName  = "";
		JsonNodeContainer    _container = null;

		public JsonResourcesConfig() {
			_fileName = UDBaseConfig.JsonConfigName;
		}

		public JsonResourcesConfig(string fileName) {
			_fileName = fileName;
		}

		public void Init() {
			var config = Resources.Load(_fileName) as TextAsset;
			if( config ) {
				var configContent = config.text;
				var configContentSplit = SplitContent(configContent);
				_container = new JsonNodeContainer(configContentSplit);
			} else {
				Debug.LogErrorFormat(
					"JsonResourcesConfig: Can't read config file from Resources/{0}", 
					_fileName);
			}
		}

		public void PostInit() {}

		string[] SplitContent(string content) {
			return content.Split('\n');
		}

		public T GetNode<T>() where T:class, IJsonNode, new() {
			if( _container != null ) {
				return _container.LoadNode<T>();
			}
			return null;
		}
	}
}