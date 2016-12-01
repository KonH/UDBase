using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UDBase.Common;
using UDBase.Controllers;
using UDBase.Utils.Json;

namespace UDBase.Controllers.ConfigSystem {
	public sealed class JsonResourcesConfig : IConfig {
		string                   _fileName  = "";
		JsonNodeContainer        _container = null;
		Dictionary<Type, string> _names     = new Dictionary<Type, string>();

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
				_container = new JsonNodeContainer(configContent, _names);
			} else {
				Debug.LogErrorFormat(
					"JsonResourcesConfig: Can't read config file from Resources/{0}", 
					_fileName);
			}
		}

		public void PostInit() {}

		public JsonResourcesConfig Add<T>(string name) {
			if( _container == null ) {
				_names.Add(typeof(T), name);
			} else {
				_container.Add<T>(name);
			}
			return this;
		}

		public T GetNode<T>() {
			if( _container != null ) {
				return _container.LoadNode<T>();
			}
			return default(T);
		}
	}
}