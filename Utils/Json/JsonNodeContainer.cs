using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Utils.Json {
	public sealed class JsonNodeContainer {
		List<JsonNodeHolder> _holders = new List<JsonNodeHolder>();
		List<string>         _content = new List<string>(100);

		public JsonNodeContainer(string[] content) {
			LoadNodes(content);
		}

		void LoadNodes(string[] content) {
			JsonNodeHolder holder = null;
			for(int i = 0; i < content.Length; i++) {
				var current = content[i]; 
				if( string.IsNullOrEmpty(current) )
				{
					if( holder != null ) {
						holder.FillContent();
						_holders.Add(holder);
						holder = null;
					}
				} else {
					if( holder == null ) {
						holder = new JsonNodeHolder(content[i]);
					} else {
						holder.AddContent(current);
					}
				}
			}
			if( holder != null ) {
				holder.FillContent();
				_holders.Add(holder);
			}
		}

		public JsonNodeHolder GetHolder(string name) {
			for( int i = 0; i < _holders.Count; i++ ) {
				if( _holders[i].Name == name ) {
					return _holders[i];
				}
			}
			return null;
		}

		public T LoadNode<T>() where T:class, IJsonNode, new() {
			T node = new T();
			var holder = GetHolder(node.Name);
			if (holder != null ) {
				var content = holder.Content;
				JsonUtility.FromJsonOverwrite(content, node);
				return node;
			}
			return null;
		}

		public void SaveNode<T>(T node, bool prettyJson) where T : class, IJsonNode, new() {
			var content = JsonUtility.ToJson(node, prettyJson);
			var holder = GetHolder(node.Name);
			if( holder == null ) {
				holder = new JsonNodeHolder(node.Name);
				_holders.Add(holder);
			}
			holder.Write(content);
		}

		public List<string> GetNodesContent() {
			_content.Clear();
			for( int i = 0; i < _holders.Count; i++ ) {
				var holder = _holders[i];
				_content.Add(holder.Name);
				_content.Add(holder.Content);
				_content.Add("");
			}
			return _content;
		}
	}
}
