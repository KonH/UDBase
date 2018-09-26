﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Utils;
using Rotorz.Games.Reflection;
using OneLine;

namespace UDBase.Controllers.SaveSystem {

	/// <summary>
	/// Interface for savable items
	/// </summary>
	public interface ISaveSource { }

	public static class Save {

		/// <summary>
		/// Save item definition
		/// </summary>
		[Serializable]
		public class SaveItem {

			/// <summary>
			/// What class you need to save
			/// </summary>
			[Tooltip("What class you need to save")]
			[ClassImplements(typeof(ISaveSource))]
			public ClassTypeReference Type;

			/// <summary>
			/// Name of the instance in save file
			/// </summary>
			[Tooltip("Name of the instance in save file")]
			public string Name;

			public SaveItem() { }

			public SaveItem(Type type, string name) {
				Type = type;
				Name = name;
			}
		}

		/// <summary>
		/// Basic save settings
		/// </summary>
		[Serializable]
		public class Settings {

			/// <summary>
			/// Set of items to save
			/// </summary>
			[Tooltip("Set of items to save")]
			[OneLine]
			public List<SaveItem> Items;
		}

		/// <summary>
		/// FsJsonDataSave settings
		/// </summary>
		[Serializable]
		public class JsonSettings : Settings {

			/// <summary>
			/// Filename in Application.persistentDataPath
			/// </summary>
			[Tooltip("Filename in Application.persistentDataPath")]
			public string FileName;

			/// <summary>
			/// Do you need human-readable JSON file?
			/// </summary>
			[Tooltip("Do you need human-readable JSON file?")]
			public bool PrettyJson;

			/// <summary>
			/// Do you need SaveInfoNode in your save?
			/// </summary>
			[Tooltip("Do you need SaveInfoNode in your save?")]
			public bool Versioning;

			/// <summary>
			/// Do you need to flush changes to file after each SaveNode call?
			/// </summary>
			[Tooltip("Do you need to flush changes to file after each SaveNode call?")]
			public bool AutoFlush = true;
		}

		/// <summary>
		/// Opens the saves directory
		/// </summary>
		public static void OpenDirectory() {
			IOTool.Open(Application.persistentDataPath);
		}
	}
}
