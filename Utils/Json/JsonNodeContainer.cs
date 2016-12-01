using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UDBase.Utils.Json {
	public sealed class JsonNodeContainer {
		Dictionary<string, JObject> _nodes = null;
		Dictionary<Type, string>    _names = new Dictionary<Type, string>();
		Dictionary<Type, object>    _cache = new Dictionary<Type, object>();

		public JsonNodeContainer(string content) {
			_nodes = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(content);
			if( _nodes == null ) {
				_nodes = new Dictionary<string, JObject>();
			}
		}

		public JsonNodeContainer(string content, Dictionary<Type, string> names):this(content) {
			_names = names;
		}

		public void Add<T>(string name) {
			_names.Add(typeof(T), name);
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
			JObject value;
			_nodes.TryGetValue(name, out value);
			if( value != null ) {
				return value.ToObject<T>();
			}
			return default(T);
		}

		public void SaveNode<T>(T node) {
			var type = typeof(T);
			SaveNode(node, _names[type]);
		}

		public void SaveNode<T>(T node, string name) {
			var jObject = JObject.FromObject(node);
			_nodes.Remove(name);
			_nodes.Add(name, jObject);
			var type = typeof(T);
			_cache.Remove(type);
			_cache.Add(type, node);
		}

		public string GetNodesContent(bool prettyJson) {
			var format = prettyJson ? Formatting.Indented : Formatting.None;
			return JsonConvert.SerializeObject(_nodes, format);
		}
	}
}
