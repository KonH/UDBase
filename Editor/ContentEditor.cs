using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UDBase.Controllers.ContentSystem;

namespace UDBase.EditorTools {
	[CustomEditor(typeof(ContentConfig))]
	public class ContentEditor : Editor {

		const string CacheSuffix    = "_Cache";
		const string AssetsLine     = "Assets/";
		const string AssetExtension = ".asset";


		string     _prevConfigPath = null;
		List<bool> _selection      = new List<bool>();

		public override void OnInspectorGUI() {
			DrawDefaultInspector();
			var config = target as ContentConfig;
			CheckRename(config);
			var cache = GetCacheFor(config);
			if( !cache ) {
				GUILayout.Label("Not found '_Cache' asset!");
				return;
			}
			GUILayout.BeginVertical();
			if( GUILayout.Button("Add") ) {
				AddNewContentId(config, cache);
				return;
			}
			for( int i = 0; i < config.Items.Count; i++ ) {
				GUILayout.BeginHorizontal();
				var currentItem = config.Items[i];
				if ( currentItem ) {
					var cacheItem = cache.GetOrCreate(currentItem);

					UpdateSelection(i);
					ProcessName(config, currentItem);
					ProcessAsset(cache, currentItem, cacheItem);
					ProcessLoadType(config, currentItem, cacheItem);
					UpdateAsset(config, currentItem, cacheItem);
					ShowAssetProperties(currentItem, cacheItem);
					UpdateAssetProperties(config, currentItem, cacheItem);

					if( GUILayout.Button("Remove") ) {
						RemoveContentId(config, cache, currentItem);
						return;
					}
				}
				GUILayout.EndHorizontal();
			}
			GUILayout.BeginHorizontal();
			ProcessSelection(config, cache);
			GUILayout.EndHorizontal();
			GUILayout.EndVertical();
		}

		void CheckRename(ContentConfig config) {
			var currentPath = AssetDatabase.GetAssetPath(config);
			if( string.IsNullOrEmpty(_prevConfigPath) ) {
				_prevConfigPath = currentPath;
				return;
			}
			if( _prevConfigPath != currentPath ) {
				var oldCache = GetCacheFor(_prevConfigPath);
				if( oldCache ) {
					UpdateCacheName(config, oldCache);
				}
				_prevConfigPath = currentPath;
			}
		}

		ContentConfigCache GetCacheFor(ContentConfig config) {
			var configPath = AssetDatabase.GetAssetPath(config);
			return GetCacheFor(configPath);

		}

		ContentConfigCache GetCacheFor(string configPath) {
			var cachePath = configPath.Replace(AssetExtension, CacheSuffix + AssetExtension);
			var cache = AssetDatabase.LoadAssetAtPath<ContentConfigCache>(cachePath);
			return cache;
		}

		void UpdateSelection(int index) {
			while( index >= _selection.Count ) {
				_selection.Add(false);
			}
			_selection[index] = GUILayout.Toggle(_selection[index],"");
		}

		void ProcessName(ContentConfig config, ContentId item) {
			var prevName = item.name;
			var newName = GUILayout.TextField(prevName);
			if( newName != prevName) {
				item.name = newName;
				Save(config);
			}
		}


		void ProcessAsset(ContentConfigCache cache, ContentId contentId, ContentDescription desc) {
			if( contentId.LoadType == ContentLoadType.None ) {
				return;
			}
			var prevObj = desc.Asset;
			var newObj = EditorGUILayout.ObjectField(prevObj, prevObj ? prevObj.GetType() : typeof(Object), false);
			if( newObj != prevObj) {
				desc.Asset = newObj;
				Save(cache);
			}
		}

		void ProcessLoadType(ContentConfig config, ContentId item, ContentDescription desc) {
			var prevType = item.LoadType;
			var newType = (ContentLoadType)EditorGUILayout.EnumPopup(prevType);
			if( newType != prevType ) {
				item.LoadType = newType;
				Save(config);
			}
		}

		void UpdateAsset(ContentConfig config, ContentId item, ContentDescription desc) {
			Object wantedObject = null;
			if( item.LoadType == ContentLoadType.Direct ) {
				wantedObject = desc.Asset;
			}
			if( item.Asset != wantedObject ) {
				item.Asset = wantedObject;
				Save(config);
			}
		}

		void ShowAssetProperties(ContentId item, ContentDescription desc) {
			if( item.LoadType != ContentLoadType.AssetBundle ) {
				return;
			}
			var info = "";
			var hasAssetBundle = false;
			var hasAsset = false;
			if( desc.Asset ) {
				hasAsset = true;
				var itemBundle = item.BundleName;
				var itemName = item.AssetName;
				if( !string.IsNullOrEmpty(itemBundle) ) {
					hasAssetBundle = true;
					info = string.Format("{0}/{1}", itemBundle, itemName);
				} else {
					info = "AssetBundle is not set!";
				}
			} else {
				info = "No Asset!";
			}
			GUILayout.Label(info);
			if( hasAsset && !hasAssetBundle ) {
				if( GUILayout.Button("Fix") ) {
					Selection.activeObject = desc.Asset;
				}
			}
		}

		void UpdateAssetProperties(ContentConfig config, ContentId item, ContentDescription desc) {
			if( item.LoadType != ContentLoadType.AssetBundle ) {
				return;
			}
			if( desc.Asset ) {
				var path = AssetDatabase.GetAssetPath(desc.Asset);
				var assetImporter = AssetImporter.GetAtPath(path);
				var assetName = desc.Asset.name;
				var bundleName = assetImporter.assetBundleName;
				if( (item.AssetName != assetName) || (item.BundleName != bundleName) ) {
					item.AssetName = assetName;
					item.BundleName = bundleName;
					Save(config);
				}
			}
		}

		bool HasAnySelection() {
			for( int i = 0; i < _selection.Count; i++) {
				if( _selection[i] ) {
					return true;
				}
			}
			return false;
		}

		void ProcessSelection(ContentConfig config, ContentConfigCache cache) {
			if( HasAnySelection() ) {
				GUILayout.Label("For selection:");
				if( GUILayout.Button("None") ) {
					SetLoadTypeForSelection(config, cache, ContentLoadType.None);
				}
				if( GUILayout.Button("Direct") ) {
					SetLoadTypeForSelection(config, cache, ContentLoadType.Direct);
				}
				if( GUILayout.Button("AssetBundle") ) {
					SetLoadTypeForSelection(config, cache, ContentLoadType.AssetBundle);
				}
			}
		}

		void SetLoadTypeForSelection(ContentConfig config, ContentConfigCache cache, ContentLoadType type) {
			for( int i = 0; i < config.Items.Count; i++ ) {
				var selected = _selection[i];
				if( selected ) {
					var item = config.Items[i];
					var cacheItem = cache.Items[i];
					item.LoadType = type;
					UpdateAsset(config, item, cacheItem);
				}
			}
			Save(config, cache);
		}

		void AddNewContentId(ContentConfig config, ContentConfigCache cache) {
			var item = CreateContentId(config);
			item.name = "Item" + config.Items.Count;
			item.LoadType = ContentLoadType.Direct;
			config.Add(item);
			cache.Add(item);
			Save(config, cache);
		}

		void RemoveContentId(ContentConfig config, ContentConfigCache cache, ContentId item) {
			config.Remove(item);
			cache.Remove(item);
			AssetUtility.RemoveSubAsset(item);
		}

		ContentId CreateContentId(ContentConfig config) {
			return AssetUtility.AddSubAsset<ContentId>(config, false);
		}

		void Save(ContentConfig config) {
			Save(config, null);
		}

		void Save(ContentConfigCache cache) {
			Save(null, cache);
		}

		void Save(ContentConfig config, ContentConfigCache cache) {
			if( config ) { 
				EditorUtility.SetDirty(config);
			}
			if( cache ) {
				EditorUtility.SetDirty(cache);
			}
			Save();
		}

		static void Save() {
			AssetDatabase.SaveAssets();
		}
			
		public static void CreateContentConfig() {
			var config = AssetUtility.CreateAsset<ContentConfig>();
			var cache = AssetUtility.CreateAsset<ContentConfigCache>(false);
			UpdateCacheName(config, cache);
		}

		static void UpdateCacheName(ContentConfig config, ContentConfigCache cache) {
			var configName = AssetDatabase.GetAssetPath(config);
			var lenShorten = AssetsLine.Length + AssetExtension.Length;
			var configNameShort = configName.Substring(AssetsLine.Length, configName.Length - lenShorten);
			var oldCacheName = AssetDatabase.GetAssetPath(cache);
			var newCacheName = configNameShort + CacheSuffix;
			AssetDatabase.RenameAsset(oldCacheName, newCacheName);
			Save();
		}
	}
}
