using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UDBase.Common;
using UDBase.Components;

namespace UDBase.Components.Config {
	public class JsonResourcesConfig : IConfig {
		// TODO: Caching
		// TODO: Common class

		class ConfigNodeHolder {
			public string Name    {get; private set;}
			public string Content {get; private set;}

			StringBuilder _builder = new StringBuilder(1000);

			public ConfigNodeHolder(string name) {
				Name = name;
			}

			public void AddContent(string item) {
				_builder.Append(item);
			}

			public void FillContent() {
				Content = _builder.ToString();
			}
		}

		string                 _fileName      = "";
		List<ConfigNodeHolder> _nodes         = new List<ConfigNodeHolder>();

		public JsonResourcesConfig() {
			_fileName = UDBaseConfig.JsonConfigName;
		}

		public JsonResourcesConfig(string fileName) {
			_fileName = fileName;
		}

		public void Init() {
			var config = Resources.Load(_fileName) as TextAsset;
			if( config ) {
				var configContent = config.text;
				LoadNodes(configContent);
			} else {
				Debug.LogErrorFormat(
					"JsonResourcesConfig: Can't read config file from Resources/{0}", 
					_fileName);
			}
		}

		void LoadNodes(string content) {
			var splittedContent = SplitContent(content);
			ConfigNodeHolder holder = null;
			for(int i = 0; i < splittedContent.Length; i++) {
				var current = splittedContent[i]; 
				if( string.IsNullOrEmpty(current) )
				{
					if( holder != null ) {
						holder.FillContent();
						_nodes.Add(holder);
						holder = null;
					}
				} else {
					if( holder == null ) {
						holder = new ConfigNodeHolder(splittedContent[i]);
					} else {
						holder.AddContent(current);
					}
				}
			}
			if( holder != null ) {
				holder.FillContent();
				_nodes.Add(holder);
			}
		}

		string[] SplitContent(string content) {
			return content.Split('\n');
		}

		public T GetNode<T>() where T:class, IConfigNode, new()
		{
			T node = new T();
			for( int i = 0; i < _nodes.Count; i++ ) {
				if( _nodes[i].Name == node.Name ) {
					var content = _nodes[i].Content;
					JsonUtility.FromJsonOverwrite(content, node);
					return node;
				}
			}
			return null;
		}
	}
}