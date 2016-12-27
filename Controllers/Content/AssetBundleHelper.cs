using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetBundles;
using UDBase.Utils;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.ContentSystem {
	public class AssetBundleHelper : MonoBehaviour {

		public bool Ready { get; private set; }

		string _streamingAssetsPath = null;
		string _baseUrl             = null;

		public void Init(string streamingAssetsPath, string baseUrl) {
			_streamingAssetsPath = streamingAssetsPath;
			_baseUrl = baseUrl;
			Log.MessageFormat(
				"Init AssetBundle helper: '{0}', '{1}'", 
				LogTags.Content,
				_streamingAssetsPath, _baseUrl);
		}

		IEnumerator Start() {
			yield return StartCoroutine(InitializeManager());
		}

		protected void InitializeSourceURL() {
			#if ENABLE_IOS_ON_DEMAND_RESOURCES
			if (UnityEngine.iOS.OnDemandResources.enabled) {
				AssetBundleManager.SetSourceAssetBundleURL("odr://");
				return;
			}
			#else
			if( _streamingAssetsPath != null ) {
				AssetBundleManager.SetSourceAssetBundleDirectory(_streamingAssetsPath);
			} else if ( _baseUrl != null ) {
				AssetBundleManager.SetSourceAssetBundleURL(_baseUrl);
			} else {
				Log.Error("You need to set streaming asset path or base url!", LogTags.Content);
			}
			return;
			#endif
		}

		protected IEnumerator InitializeManager() {
			InitializeSourceURL();
			UnityHelper.AddPersistant<AssetBundleManager>();
			var request = AssetBundleManager.Initialize();			
			if (request != null) {
				yield return StartCoroutine(request);
				Ready = true;
			}
		}

		public void StartLoadAsync<T>(
			string assetBundleName, string assetName, Action<T> callback) where T:UnityEngine.Object {
			StartCoroutine(LoadAsync<T>(assetBundleName, assetName, callback));
		}

		public IEnumerator LoadAsync<T>(
			string assetBundleName, string assetName, Action<T> callback) where T:UnityEngine.Object {
			var startTime = Time.realtimeSinceStartup;
			var request = AssetBundleManager.LoadAssetAsync(assetBundleName, assetName, typeof(T));
			if (request == null) {
				yield break;
			}
			yield return StartCoroutine(request);
			T asset = request.GetAsset<T>();
			var elapsedTime = Time.realtimeSinceStartup - startTime;
			Log.MessageFormat(
				"Asset '{0}' {1} loaded in {2} seconds", 
				LogTags.Content,
				assetName, asset ? "was" : "was not", elapsedTime);
			if( callback != null ) {
				callback(asset);
			}
		}
	}
}