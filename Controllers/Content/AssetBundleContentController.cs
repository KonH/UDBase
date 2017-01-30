using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UDBase.Common;
using UDBase.Controllers;
using UDBase.Utils;

namespace UDBase.Controllers.ContentSystem {
	public sealed class AssetBundleContentController:IContent {
	 
		string            _streamingAssetsPath = null; 
		string            _baseUrl             = null;
		AssetBundleHelper _helper              = null;

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

		public bool LoadAsync<T>(ContentId id, Action<T> callback) where T:UnityEngine.Object {
			if( !id || id.LoadType != ContentLoadType.AssetBundle ) {
				return false;
			}
			_helper.StartLoadAsync<T>(id.BundleName, id.AssetName, callback);
			return true;
		}
	}
}