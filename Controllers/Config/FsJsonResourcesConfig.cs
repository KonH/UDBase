using System;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Common;
using UDBase.Utils.Json.Fullserializer;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.ConfigSystem {
	public sealed class FsJsonResourcesConfig : IConfig {
		readonly string                   _fileName;
		readonly Dictionary<Type, string> _nodeNames = new Dictionary<Type, string>();
		readonly Dictionary<Type, string> _listNames = new Dictionary<Type, string>();
		
		FsJsonNodeContainer _nodeContainer;
		FsJsonListContainer _listContainer;
		string              _configContent;

		public FsJsonResourcesConfig() {
			_fileName = UDBaseConfig.JsonConfigName;
		}

		public FsJsonResourcesConfig(string fileName) {
			_fileName = fileName;
		}

		public void Init() {
			var config = Resources.Load(_fileName) as TextAsset;
			if( config ) {
				_configContent = config.text;
				_nodeContainer = new FsJsonNodeContainer(_configContent, _nodeNames);
				_listContainer = new FsJsonListContainer(_nodeContainer, _listNames);
			} else {
				// LogSystem not ready yet
				Debug.LogErrorFormat(
					"JsonResourcesConfig: Can't read config file from Resources/{0}", 
					_fileName);
			}
		}

		public void PostInit() {
			Log.MessageFormat("Config content: \"{0}\"", LogTags.Config, _configContent);
		}

		public void Reset() {}

		public FsJsonResourcesConfig AddNode<T>(string name) {
			if( _nodeContainer == null ) {
				var type = typeof(T);
				if( !_nodeNames.ContainsKey(type) ) {
					_nodeNames.Add(type, name);
				} else {
					// LogSystem not ready yet
					Debug.LogErrorFormat("Config: node already added: {0}!", type);
				}
			} else {
				_nodeContainer.Add<T>(name);
			}
			return this;
		}

		public FsJsonResourcesConfig AddList<T>(string name) {
			if( _listContainer == null ) {
				var type = typeof(T);
				if( !_listNames.ContainsKey(type) ) {
					_listNames.Add(type, name);
				} else {
					// LogSystem not ready yet
					Debug.LogErrorFormat("Config: list node already added: {0}!", type);
				}
			} else {
				_listContainer.Add<T>(name);
			}
			return this;
		}

		public T GetNode<T>() {
			return (_nodeContainer != null) ? _nodeContainer.LoadNode<T>(false) : default(T);
		}

		public T GetItem<T>(string name) {
			return (_listContainer != null) ? _listContainer.LoadItem<T>(name, false) : default(T);
		}

		public Dictionary<string, T> GetItems<T>() {
			return (_listContainer != null) ? _listContainer.LoadDict<T>() : null;
		}
	}
}