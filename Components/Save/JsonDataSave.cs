using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UDBase.Common;
using UDBase.Components;
using UDBase.Utils;
using UDBase.Utils.Json;

namespace UDBase.Components.Save {
	public class JsonDataSave:ISave {

		bool                 _prettyJson    = false;
		string               _fileName      = "";
		string               _filePath      = "";
		JsonNodeContainer    _container     = null;

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
				_container = new JsonNodeContainer(saveContent);
			} else {
				Debug.LogWarningFormat(
					"JsonDataSave: Can't read save file from {0}, re-create it.", 
					_fileName);
				IOTool.CreateFile(_filePath);
			}
		}

		public T GetNode<T>() where T : class, IJsonNode, new() {
			if( _container != null ) {
				return _container.LoadNode<T>();
			}
			return null;
		}

		public void SaveNode<T>(T node) where T : class, IJsonNode, new() {
			if( _container != null ) {
				_container.SaveNode(node, _prettyJson);
				var content = _container.GetNodesContent();
				IOTool.WriteAllLines(_filePath, content);
			}
		}
			
		public void Clear() {
			IOTool.DeleteFile(_filePath);
		}
	}
}
