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
				_log.ErrorFormat(
					LogTags.Config,
					"Can't read config file from Resources/{0}", 
					_fileName);
			}
			_log.MessageFormat(LogTags.Config, "Config content: \"{0}\"", _configContent);
			foreach ( var item in settings.Items ) {
				AddNode(item.Type, item.Name);
			}
		}

		FsJsonResourcesConfig AddNode(Type type, string name) {
			if( _nodeContainer == null ) {
				if( !_nodeNames.ContainsKey(type) ) {
					_nodeNames.Add(type, name);
				} else {
					_log.ErrorFormat(LogTags.Config, "Config: node already added: {0}!", type);
				}
			} else {
				_nodeContainer.Add(type, name);
			}
			return this;
		}

		public T GetNode<T>() where T:IConfigSource {
			return (_nodeContainer != null) ? _nodeContainer.LoadNode<T>(false) : default(T);
		}
	}
}