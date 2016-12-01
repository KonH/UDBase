﻿using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UDBase.Common;
using UDBase.Controllers;
using UDBase.Utils;
using UDBase.Utils.Json;

namespace UDBase.Controllers.SaveSystem {
	public sealed class JsonDataSave:ISave {

		bool                     _prettyJson = false;
		string                   _fileName   = "";
		string                   _filePath   = "";
		JsonNodeContainer        _container  = null;
		Dictionary<Type, string> _names      = new Dictionary<Type, string>();

		public JsonDataSave():this(false, UDBaseConfig.JsonSaveName) {}

		public JsonDataSave(bool prettyJson):this(prettyJson, UDBaseConfig.JsonSaveName) {}

		public JsonDataSave(string fileName):this(false, UDBaseConfig.JsonSaveName) {}

		public JsonDataSave(bool prettyJson, string fileName) {
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

		public void PostInit() {}

		bool TryLoadContainer() {
			if( _container == null ) {
				var saveContent = IOTool.ReadAllText(_filePath, true);
				if( saveContent != null ) {
					_container = new JsonNodeContainer(saveContent, _names);
					return true;
				}
				return false;
			} else {
				return true;
			}
		}

		public JsonDataSave Add<T>(string name) {
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
				var content = _container.GetNodesContent(_prettyJson);
				IOTool.WriteAllText(_filePath, content);
			}
		}
			
		public void Clear() {
			IOTool.DeleteFile(_filePath);
		}
	}
}
