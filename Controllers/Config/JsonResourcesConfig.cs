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
		string                   _fileName      = "";
		JsonNodeContainer        _nodeContainer = null;
		JsonListContainer        _listContainer = null;
		Dictionary<Type, string> _nodeNames     = new Dictionary<Type, string>();
		Dictionary<Type, string> _listNames     = new Dictionary<Type, string>();

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
				_nodeContainer = new JsonNodeContainer(configContent, _nodeNames);
				_listContainer = new JsonListContainer(_nodeContainer, _listNames);
			} else {
				Debug.LogErrorFormat(
					"JsonResourcesConfig: Can't read config file from Resources/{0}", 
					_fileName);
			}
		}

		public void PostInit() {}

		public JsonResourcesConfig Add<T>(string name) {
			if( _nodeContainer == null ) {
				_nodeNames.Add(typeof(T), name);
			} else {
				_nodeContainer.Add<T>(name);
			}
			return this;
		}

		public JsonResourcesConfig AddList<T>(string name) {
			if( _listContainer == null ) {
				_listNames.Add(typeof(T), name);
			} else {
				_listContainer.Add<T>(name);
			}
			return this;
		}

		public T GetNode<T>() {
			if( _nodeContainer != null ) {
				return _nodeContainer.LoadNode<T>();
			}
			return default(T);
		}

		public T GetItem<T>(string name) {
			if( _listContainer != null ) {
				return _listContainer.LoadItem<T>(name);
			}
			return default(T);
		}
	}
}