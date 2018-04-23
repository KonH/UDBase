using System;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Utils.Json.Fullserializer;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.ConfigSystem {

	/// <summary>
	/// Config controller, which uses JSON file serialization via Fullserializer
	/// </summary>
	public sealed class FsJsonResourcesConfig : IConfig, ILogContext {
		readonly string                   _fileName;
		readonly Dictionary<Type, string> _nodeNames = new Dictionary<Type, string>();
		
		FsJsonNodeContainer _nodeContainer;
		string              _configContent;

		ILog _log;

		public FsJsonResourcesConfig(Config.JsonSettings settings, ILog log) {
			_log = log;
			_fileName = settings.FileName;
			var config = Resources.Load(_fileName) as TextAsset;
			if( config ) {
				_configContent = config.text;
				_nodeContainer = new FsJsonNodeContainer(_configContent, _nodeNames, _log);
			} else {
				_log.ErrorFormat(this, "Can't read config file from Resources/{0}",  _fileName);
			}
			_log.MessageFormat(this, "Config content: \"{0}\"", _configContent);
			foreach ( var item in settings.Items ) {
				AddNode(item.Type, item.Name);
			}
		}

		FsJsonResourcesConfig AddNode(Type type, string name) {
			if( _nodeContainer == null ) {
				if( !_nodeNames.ContainsKey(type) ) {
					_nodeNames.Add(type, name);
				} else {
					_log.ErrorFormat(this, "Config: node already added: {0}!", type);
				}
			} else {
				_nodeContainer.Add(type, name);
			}
			return this;
		}

		public void Reload() {
			// Isn't used
		}

		public bool IsReady() => true;

		public T GetNode<T>() where T:IConfigSource {
			return (_nodeContainer != null) ? _nodeContainer.LoadNode<T>(false) : default(T);
		}
	}
}