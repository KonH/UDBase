using System;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Common;
using UDBase.Controllers.LogSystem;
using UDBase.Utils;
using UDBase.Utils.Json.Fullserializer;

namespace UDBase.Controllers.SaveSystem {
	public sealed class FsJsonDataSave:ISave {
		readonly bool                     _prettyJson;
		readonly string                   _fileName;
		readonly bool                     _versioning;
		readonly Dictionary<Type, string> _names = new Dictionary<Type, string>();
		
		string              _saveContent = "";
		string              _filePath    = "";
		FsJsonNodeContainer _container;

		public FsJsonDataSave(Save.JsonSettings settings) {
			_prettyJson = settings.PrettyJson;
			_fileName   = settings.FileName;
			_versioning = settings.Versioning;
			if( _versioning ) {
				AddNode(typeof(SaveInfoNode), "_info");
			}
			foreach ( var item in settings.Items ) {
				AddNode(item.Type, item.Name);
			}
			_filePath = IOTool.GetPath(Application.persistentDataPath, _fileName);
			if( !TryLoadContainer() ) {
				// LogSystem not ready yet
				Debug.LogFormat(
					"JsonDataSave: Can't read save file from {0}, re-create it.", 
					_fileName);
				IOTool.CreateFile(_filePath);
				TryLoadContainer();
			}
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
			}
			return true;
		}

		FsJsonDataSave AddNode(Type type, string name) {
			if( _container == null ) {
				if( !_names.ContainsKey(type) ) {
					_names.Add(type, name);
				} else {
					// LogSystem not ready yet
					Debug.LogErrorFormat("FsJsonDataSave: node already added: {0}!", type);
				}
			} else {
				_container.Add(type, name);
			}
			return this;
		}

		public T GetNode<T>(bool autoFill) where T:ISaveSource {
			if( TryLoadContainer() ) {
				return _container.LoadNode<T>(autoFill);
			}
			var type = typeof(T);
			if( !_names.ContainsKey(type) ) {
				Log.ErrorFormat("GetNode: node is not added: {0}!", LogTags.Save, type);
			}
			return Activator.CreateInstance<T>();
		}

		public void SaveNode<T>(T node) where T:ISaveSource {
			if( TryLoadContainer() ) {
				if( _container.SaveNode(node) ) {
					if( _versioning ) {
						var saveInfo = _container.LoadNode<SaveInfoNode>(true);
						saveInfo.Update();
						_container.SaveNode(saveInfo);
					}
					_saveContent = _container.GetNodesContent(_prettyJson);
					IOTool.WriteAllText(_filePath, _saveContent);
					Log.MessageFormat("New save content: \"{0}\"", LogTags.Save, _saveContent);
				} else {
					Log.ErrorFormat("SaveNode: node is not added: {0}!", LogTags.Save, typeof(T));
				}
			} else {
				Log.Error("SaveNode: could not load container!", LogTags.Save);
			}
		}
	}
}
