using System;
using UnityEngine;
using UDBase.Utils;

namespace UDBase.Controllers.ContentSystem {
	public sealed class AssetBundleContentController:IContent {
		readonly string _streamingAssetsPath;
		readonly string _baseUrl;
		
		AssetBundleHelper _helper;

		public AssetBundleContentController(AssetBundleMode mode, string path = "") {
			if( mode == AssetBundleMode.StreamingAssets ) {
				_streamingAssetsPath = path;
			} else {
				if( string.IsNullOrEmpty(path) ) {
					Debug.LogError("For WebServer mode you need to provide path!");
				}
				_baseUrl = path;
			}
		}

		public void Init() {
			_helper = UnityHelper.AddPersistant<AssetBundleHelper>();
			if( _helper ) {
				_helper.Init(_streamingAssetsPath, _baseUrl);
			}
		}

		public void PostInit() {}

		public void Reset() {}

		public bool LoadAsync<T>(ContentId id, Action<T> callback) where T:UnityEngine.Object {
			if( !id || id.LoadType != ContentLoadType.AssetBundle ) {
				return false;
			}
			_helper.StartLoadAsync(id.BundleName, id.AssetName, callback);
			return true;
		}
	}
}