using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using FullSerializer;

namespace UDBase.Utils.Json.Fullserializer {
	public sealed class FsJsonNodeContainer {
		Dictionary<string, fsData>  _nodes = null;
		Dictionary<Type, string>    _names = new Dictionary<Type, string>();
		Dictionary<Type, object>    _cache = new Dictionary<Type, object>();

		fsSerializer _serializer = new fsSerializer();

		public FsJsonNodeContainer(string content) {
			if( !string.IsNullOrEmpty(content) ) {
				var data = fsJsonParser.Parse(content);
				_nodes = data.AsDictionary;
			}
			if( _nodes == null ) {
				_nodes = new Dictionary<string, fsData>();
			}
		}

		public FsJsonNodeContainer(string content, Dictionary<Type, string> names):this(content) {
			_names = names;
		}

		public void Add<T>(string name) {
			_names.Add(typeof(T), name);
		}

		public fsData LoadNode(string name) {
			fsData value;
			_nodes.TryGetValue(name, out value);
			if( value != null ) {
				return value;
			}
			return null;
		}

		public T LoadNode<T>() {
			var type = typeof(T);
			object value;
			if( !_cache.TryGetValue(type, out value) ) {
				string key;
				if( _names.TryGetValue(type, out key) ) {
					value = LoadNode<T>(key);
					_cache.Add(type, value);
				}
			}
			return (T)value;
		}

		public T LoadNode<T>(string name) {
			var node = LoadNode(name);
			if( node != null ) {
				T instance = default(T); 
				_serializer.TryDeserialize(node, ref instance);
				return instance;
			}
			return default(T);
		}

		public void SaveNode<T>(T node) {
			var type = typeof(T);
			SaveNode(node, _names[type]);
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
