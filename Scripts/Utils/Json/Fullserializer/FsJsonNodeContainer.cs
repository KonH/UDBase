using System;
using System.Collections.Generic;
using FullSerializer;
using UDBase.Controllers.LogSystem;

namespace UDBase.Utils.Json.Fullserializer {
	sealed class FsJsonNodeContainer : ILogContext {
		readonly Dictionary<string, fsData>  _nodes;
		readonly Dictionary<Type, string>    _names      = new Dictionary<Type, string>();
		readonly Dictionary<Type, object>    _cache      = new Dictionary<Type, object>();
		readonly fsSerializer                _serializer = new fsSerializer();

		ULogger _log;

		public FsJsonNodeContainer(string content, Dictionary<Type, string> names, ILog log) {
			_log = log.CreateLogger(this);
			if (!string.IsNullOrEmpty(content)) {
				var data = fsJsonParser.Parse(content);
				_nodes = data.AsDictionary;
			}
			if (_nodes == null) {
				_nodes = new Dictionary<string, fsData>();
			}
			_names = names;
		}

		public void Add(Type type, string name) {
			if( !_names.ContainsKey(type) ) {
				_names.Add(type, name);
			} else {
				_log.ErrorFormat("Type already exist: {0}!", type);  
			}
		}

		public fsData LoadNode(string name) {
			fsData value;
			_nodes.TryGetValue(name, out value);
			if( value != null ) {
				return value;
			}
			return null;
		}

		public T LoadNode<T>(bool autoFill) {
			var type = typeof(T);
			object value;
			if( !_cache.TryGetValue(type, out value) ) {
				string key;
				if( _names.TryGetValue(type, out key) ) {
					value = LoadNode<T>(key, autoFill);
					if ( value != null ) {
						_cache.Add(type, value);
					}
				} else {
					_log.ErrorFormat("NodeContainer.LoadNode: Can't find node: {0}!", type);
				}
			}
			return (T)value;
		}

		public T LoadNode<T>(string name, bool autoFill) {
			var node = LoadNode(name);
			if( node != null ) {
				T instance = default(T); 
				_serializer.TryDeserialize(node, ref instance);
				return instance;
			}
			return autoFill ? Activator.CreateInstance<T>() : default(T);
		}

		public bool SaveNode<T>(T node) {
			var type = typeof(T);
			string name;
			if( _names.TryGetValue(type, out name) ) { 
				SaveNode(node, name);
				return true;
			}
			return false;
		}

		public void SaveNode<T>(T node, string name) {
			fsData data;
			_serializer.TrySerialize(node, out data);
			_nodes.Remove(name);
			_nodes.Add(name, data);
			var type = typeof(T);
			_cache.Remove(type);
			_cache.Add(type, node);
		}

		public string GetNodesContent(bool prettyJson) {
			var data = new fsData(_nodes);
			return prettyJson ? fsJsonPrinter.PrettyJson(data) : fsJsonPrinter.CompressedJson(data);
		}
	}
}
