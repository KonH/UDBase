﻿using System;
using System.Collections.Generic;
using UDBase.Utils.Json.Fullserializer;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.ConfigSystem {
	
	/// <summary>
	/// Base fsJson config class for code reusage purposes
	/// </summary>
	public abstract class FsJsonBaseConfig : IConfig, ILogContext {
		readonly Dictionary<Type, string> _nodeNames = new Dictionary<Type, string>();
		
		FsJsonNodeContainer _nodeContainer;

		protected ILog    _log;
		protected ULogger _logger;

		public FsJsonBaseConfig(ILog log) {
			_log    = log;
			_logger = log.CreateLogger(this);
		}

		protected void InitNodes(List<Config.ConfigItem> nodes) {
			foreach ( var node in nodes ) {
				AddNode(node.Type, node.Name);
			}
		}

		protected void LoadContent(string configContent) {
			_nodeContainer = new FsJsonNodeContainer(configContent, _nodeNames, _log);
			_logger.MessageFormat("Config content: \"{0}\"", configContent);
		}

		protected void AddNode(Type type, string name) {
			if( _nodeContainer == null ) {
				if( !_nodeNames.ContainsKey(type) ) {
					_nodeNames.Add(type, name);
				} else {
					_logger.ErrorFormat("Config: node already added: {0}!", type);
				}
			} else {
				_nodeContainer.Add(type, name);
			}
		}

		public virtual bool IsReady() => true;

		public virtual T GetNode<T>() where T:IConfigSource {
			return (_nodeContainer != null) ? _nodeContainer.LoadNode<T>(false) : default(T);
		}
	}
}