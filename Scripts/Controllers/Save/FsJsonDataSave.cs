using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.LogSystem;
using UDBase.Utils;
using UDBase.Utils.Json.Fullserializer;

namespace UDBase.Controllers.SaveSystem {

	/// <summary>
	/// ISave implementation, which used JSON file with FullSerializer.
	/// File with name from settings is saved to Application.persistantDataPath.
	/// </summary>
	public sealed class FsJsonDataSave:ISave, ILogContext {
		readonly bool                     _prettyJson;
		readonly string                   _fileName;
		readonly bool                     _versioning;
		readonly bool                     _autoFlush;
		readonly Dictionary<Type, string> _names = new Dictionary<Type, string>();
		
		string              _saveContent = "";
		string              _filePath    = "";
		FsJsonNodeContainer _container;

		ILog    _log;
		ULogger _logger;

		public FsJsonDataSave(Save.JsonSettings settings, ILog log) {
			_log = log;
			_logger = log.CreateLogger(this);
			_prettyJson = settings.PrettyJson;
			_fileName   = settings.FileName;
			_versioning = settings.Versioning;
			_autoFlush  = settings.AutoFlush;
			if( _versioning ) {
				AddNode(typeof(SaveInfoNode), "_info");
			}
			foreach ( var item in settings.Items ) {
				AddNode(item.Type, item.Name);
			}
			_filePath = Path.Combine(Application.persistentDataPath, _fileName);
			if( !TryLoadContainer() ) {
				_logger.MessageFormat("JsonDataSave: Can't read save file from {0}, re-create it.", _fileName);
				IOTool.CreateFile(_filePath);
				TryLoadContainer();
			}
			_logger.MessageFormat("Save content: \"{0}\"", _saveContent);
		}

		bool TryLoadContainer() {
			if( _container == null ) {
				_saveContent = IOTool.ReadAllText(_filePath, true);
				if( _saveContent != null ) {
					_container = new FsJsonNodeContainer(_saveContent, _names, _log );
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
					_logger.ErrorFormat("FsJsonDataSave: node already added: {0}!", type);
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
				_logger.ErrorFormat("GetNode: node is not added: {0}!", type);
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
					if ( _autoFlush ) {
						Flush();
					}
				} else {
					_logger.ErrorFormat("SaveNode: node is not added: {0}!", typeof(T));
				}
			} else {
				_logger.Error("SaveNode: could not load container!");
			}
		}

		public void Flush() {
			IOTool.WriteAllText(_filePath, _saveContent);
			_logger.MessageFormat("New save content: \"{0}\"", _saveContent);
		}
	}
}
