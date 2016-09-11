using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UDBase.Common;
using UDBase.Components;
using UDBase.Utils;

namespace UDBase.Components.Save {
	public class JsonDataSave:ISave {

		class SaveNodeHolder {
			public string Name    {get; private set;}
			public string Content {get; private set;}

			StringBuilder _builder = new StringBuilder(1000);

			public SaveNodeHolder(string name) {
				Name = name;
			}

			// Read
			public void AddContent(string item) {
				_builder.Append(item);
			}

			public void FillContent() {
				Content = _builder.ToString();
			}

			// Write
			public void Write(string content) {
				Content = content;
			}
		}

		bool                 _prettyJson    = false;
		string               _fileName      = "";
		string               _filePath      = "";
		List<SaveNodeHolder> _nodes         = new List<SaveNodeHolder>();

		public JsonDataSave():this(false, UDBaseConfig.JsonSaveName) {}

		public JsonDataSave(bool prettyJson):this(prettyJson, UDBaseConfig.JsonSaveName) {}

		public JsonDataSave(bool prettyJson, string fileName) {
			_prettyJson = prettyJson;
			_fileName   = fileName;
		}

		// TODO: Multiplatform load?
		public void Init() {
			_filePath = IOTool.GetPath(Application.persistentDataPath, _fileName);
			var saveContent = IOTool.ReadAllLines(_filePath, true);
			if( saveContent != null ) {
				LoadNodes(saveContent);
			} else {
				Debug.LogWarningFormat(
					"JsonDataSave: Can't read save file from {0}, re-create it.", 
					_fileName);
				IOTool.CreateFile(_filePath);
			}
		}

		void LoadNodes(string[] splittedContent) {
			SaveNodeHolder holder = null;
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
						holder = new SaveNodeHolder(splittedContent[i]);
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

		SaveNodeHolder GetHolder(string name) {
			for( int i = 0; i < _nodes.Count; i++ ) {
				if( _nodes[i].Name == name ) {
					return _nodes[i];
				}
			}
			return null;
		}

		public T GetNode<T>() where T:class, ISaveNode, new()
		{
			T node = new T();
			var holder = GetHolder(node.Name);
			if( holder != null ) {
				var content = holder.Content;
				JsonUtility.FromJsonOverwrite(content, node);
				return node;
			}
			return null;
		}

		public void SaveNode<T>(T node) where T : class, ISaveNode, new()
		{
			var content = JsonUtility.ToJson(node, _prettyJson);
			var holder = GetHolder(node.Name);
			if( holder == null ) {
				holder = new SaveNodeHolder(node.Name);
				_nodes.Add(holder);
			}
			holder.Write(content);
			SaveAllNodes();
		}

		void SaveAllNodes() {
			var lines = new List<string>(100);
			for( int i = 0; i < _nodes.Count; i++ ) {
				var node = _nodes[i];
				lines.Add(node.Name);
				lines.Add(node.Content);
				lines.Add("");
			}
			IOTool.WriteAllLines(_filePath, lines);
		}

		public void Clear() {
			IOTool.DeleteFile(_filePath);
		}
	}
}
