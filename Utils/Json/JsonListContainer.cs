using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UDBase.Utils.Json {
	public sealed class JsonListContainer {

		JsonNodeContainer        _nodeContainer = null;
		Dictionary<Type, string> _names         = new Dictionary<Type, string>();

		Dictionary<string, Dictionary<string, object>> _nodeCache 
			= new Dictionary<string, Dictionary<string, object>>();

		public JsonListContainer(JsonNodeContainer nodeContainer) {
			_nodeContainer = nodeContainer;
		}

		public JsonListContainer(JsonNodeContainer nodeContainer, Dictionary<Type, string> names):
			this(nodeContainer) {
			_names = names;
		}

		public void Add<T>(string name) {
			_names.Add(typeof(T), name);
		}

		public T LoadItem<T>(string nodeName, string itemName) {
			Dictionary<string, object> cachedNode;
			if( _nodeCache.TryGetValue(nodeName, out cachedNode) ) {
				object value;
				cachedNode.TryGetValue(itemName, out value);
				return (T)value;
			} else {
				var node = _nodeContainer.LoadNode(nodeName);
				if( node != null ) {
					var nodeContent = node.ToObject<Dictionary<string, T>>();
					CacheContent(nodeName, nodeContent);
					if( nodeContent != null ) {
						T value;
						nodeContent.TryGetValue(itemName, out value);
						return value;
					}
				}
			}
			return default(T);
		}

		void CacheContent<T>(string nodeName, Dictionary<string, T> nodeContent) {
			var nodeContentCache = new Dictionary<string, object>();
			var nodeContentIter = nodeContent.GetEnumerator();
			while( nodeContentIter.MoveNext() ) {
				var current = nodeContentIter.Current;
				nodeContentCache.Add(current.Key, current.Value);
			}
			_nodeCache.Add(nodeName, nodeContentCache);
		}

		public T LoadItem<T>(string itemName) {
			string nodeName;
			if( _names.TryGetValue(typeof(T), out nodeName) ) {
				return LoadItem<T>(nodeName, itemName);
			}
			return default(T);
		}
	}
}
