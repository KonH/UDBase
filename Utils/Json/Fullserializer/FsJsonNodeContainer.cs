using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using FullSerializer;
using UDBase.Controllers.LogSystem;

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
			var type = typeof(T);
			if( !_names.ContainsKey(type) ) {
				_names.Add(type, name);
			} else {
				Log.ErrorFormat("Type already exist: {0}!", LogTags.Json, type);  
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
					_cache.Add(type, value);
				} else {
					Log.ErrorFormat("NodeContainer.LoadNode: Can't find node: {0}!", LogTags.Json, type);
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
