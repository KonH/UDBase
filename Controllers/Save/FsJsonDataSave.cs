using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UDBase.Common;
using UDBase.Controllers;
using UDBase.Controllers.LogSystem;
using UDBase.Utils;
using UDBase.Utils.Json.Fullserializer;

namespace UDBase.Controllers.SaveSystem {
	public sealed class FsJsonDataSave:ISave {

		bool                     _prettyJson  = false;
		string                   _fileName    = "";
		string                   _saveContent = "";
		string                   _filePath    = "";
		FsJsonNodeContainer      _container   = null;
		Dictionary<Type, string> _names       = new Dictionary<Type, string>();

		public FsJsonDataSave():this(false, UDBaseConfig.JsonSaveName) {}

		public FsJsonDataSave(bool prettyJson):this(prettyJson, UDBaseConfig.JsonSaveName) {}

		public FsJsonDataSave(string fileName):this(false, UDBaseConfig.JsonSaveName) {}

		public FsJsonDataSave(bool prettyJson, string fileName) {
			_prettyJson = prettyJson;
			_fileName   = fileName;
		}

		public void Init() {
			_filePath = IOTool.GetPath(Application.persistentDataPath, _fileName);
			if( !TryLoadContainer() ) {
				Debug.LogWarningFormat(
					"JsonDataSave: Can't read save file from {0}, re-create it.", 
					_fileName);
				IOTool.CreateFile(_filePath);
				TryLoadContainer();
			}
		}

		public void PostInit() {
			Log.MessageFormat("Save content: \"{0}\"", LogTags.Save, _saveContent); 
		}

		bool TryLoadContainer() {
			if( _container == null ) {
				_saveContent = IOTool.ReadAllText(_filePath, true);
				if( _saveContent != null ) {
					_container = new FsJsonNodeContainer(_saveContent, _names);
					return true;
				}
				return false;
			} else {
				return true;
			}
		}

		public FsJsonDataSave AddNode<T>(string name) {
			if( _container == null ) {
				_names.Add(typeof(T), name);
			} else {
				_container.Add<T>(name);
			}
			return this;
		}

		public T GetNode<T>() {
			TryLoadContainer();
			if( _container != null ) {
				return _container.LoadNode<T>();
			}
			return default(T);
		}

		public void SaveNode<T>(T node) {
			TryLoadContainer();
			if( _container != null ) {
				_container.SaveNode(node);
				_saveContent = _container.GetNodesContent(_prettyJson);
				IOTool.WriteAllText(_filePath, _saveContent);
				Log.MessageFormat("New save content: \"{0}\"", LogTags.Save, _saveContent);
			}
		}
			
		public void Clear() {
			IOTool.DeleteFile(_filePath);
		}
	}
}
