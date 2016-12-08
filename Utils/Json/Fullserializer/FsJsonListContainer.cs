using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using FullSerializer;

namespace UDBase.Utils.Json.Fullserializer {
	public sealed class FsJsonListContainer {

		FsJsonNodeContainer      _nodeContainer = null;
		Dictionary<Type, string> _names         = new Dictionary<Type, string>();

		fsSerializer _serializer = new fsSerializer();

		Dictionary<string, Dictionary<string, object>> _nodeCache 
			= new Dictionary<string, Dictionary<string, object>>();

		public FsJsonListContainer(FsJsonNodeContainer nodeContainer) {
			_nodeContainer = nodeContainer;
		}

		public FsJsonListContainer(FsJsonNodeContainer nodeContainer, Dictionary<Type, string> names):
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
					var nodeContent = node.AsDictionary;
					CacheContent<T>(nodeName, nodeContent);
					if( nodeContent != null ) {
						fsData fsValue;
						nodeContent.TryGetValue(itemName, out fsValue);
						T value = default(T);
						_serializer.TryDeserialize(fsValue, ref value);
						return value;
					}
				}
			}
			return default(T);
		}

		void CacheContent<T>(string nodeName, Dictionary<string, fsData> nodeContent) {
			var nodeContentCache = new Dictionary<string, object>();
			var nodeContentIter = nodeContent.GetEnumerator();
			while( nodeContentIter.MoveNext() ) {
				var current = nodeContentIter.Current;
				T value = default(T);	
				_serializer.TryDeserialize(current.Value, ref value);
				nodeContentCache.Add(current.Key, value);
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
