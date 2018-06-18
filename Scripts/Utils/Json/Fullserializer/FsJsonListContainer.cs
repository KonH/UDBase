﻿using System;
using System.Collections.Generic;
using FullSerializer;
using UDBase.Controllers.LogSystem;

namespace UDBase.Utils.Json.Fullserializer {
	sealed class FsJsonListContainer : ILogContext {
		class NodeCache : Dictionary<string, Dictionary<string, object>> { }
		
		readonly FsJsonNodeContainer      _nodeContainer;
		readonly Dictionary<Type, string> _names      = new Dictionary<Type, string>();
		readonly fsSerializer             _serializer = new fsSerializer();
		readonly NodeCache                _nodeCache  = new NodeCache();

		ULogger _log;

		public FsJsonListContainer(FsJsonNodeContainer nodeContainer, ILog log) {
			_nodeContainer = nodeContainer;
			_log = log.CreateLogger(this);
		}

		public void Add<T>(string name) {
			var type = typeof(T);
			if( !_names.ContainsKey(type) ) {
				_names.Add(type, name);
			} else {
				_log.ErrorFormat("Type already exist: {0}!", type);  
			}
		}

		public T LoadItem<T>(string nodeName, string itemName, bool autoFill) {
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
			_log.ErrorFormat("ListContainer.LoadItem: Can't find node: {0}!", typeof(T));
			return autoFill ? Activator.CreateInstance<T>() : default(T);
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

		public T LoadItem<T>(string itemName, bool autoFill) {
			string nodeName;
			if( _names.TryGetValue(typeof(T), out nodeName) ) {
				return LoadItem<T>(nodeName, itemName, autoFill);
			}
			return autoFill ? Activator.CreateInstance<T>() : default(T);
		}

		public Dictionary<string, T> LoadDict<T>() {
			string nodeName;
			if( _names.TryGetValue(typeof(T), out nodeName) ) {
				var node = _nodeContainer.LoadNode(nodeName);
				if( node != null ) {
					var nodeContent = node.AsDictionary;
					if( nodeContent != null ) {
						var dict = new Dictionary<string, T>();
						foreach( var itemName in nodeContent.Keys ) {
							fsData fsValue;
							nodeContent.TryGetValue(itemName, out fsValue);
							T value = default(T);
							_serializer.TryDeserialize(fsValue, ref value);
							dict.Add(itemName, value);
						}
						return dict;
					}
				}
			}
			return null;
		}
	}
}
