using System;
using UnityEngine;
using UDBase.Utils;

namespace UDBase.Controllers.ContentSystem {
	public sealed class AssetBundleContentController:IContent {
		public class Settings {
			public AssetBundleMode Mode = AssetBundleMode.StreamingAssets;
			public string Path = "";
		}

		readonly string _streamingAssetsPath;
		readonly string _baseUrl;
		
		AssetBundleHelper _helper;

		public AssetBundleContentController(AssetBundleHelper helper, Settings settings) {
			if( settings.Mode == AssetBundleMode.StreamingAssets ) {
				_streamingAssetsPath = settings.Path;
			} else {
				if( string.IsNullOrEmpty(settings.Path) ) {
					Debug.LogError("For WebServer mode you need to provide path!");
				}
				_baseUrl = settings.Path;
			}
			_helper = helper;
			if( _helper ) {
				_helper.Init(_streamingAssetsPath, _baseUrl);
			}
		}

		public bool CanLoad(ContentId id) {
			return id && (id.LoadType == ContentLoadType.AssetBundle);
		}

		public void LoadAsync<T>(ContentId id, Action<T> callback) where T:UnityEngine.Object {
			_helper.StartLoadAsync(id.BundleName, id.AssetName, callback);
		}
	}
}