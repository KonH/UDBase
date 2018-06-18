﻿using System;
using System.Collections;
using UnityEngine;
using AssetBundles;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.ContentSystem {

	/// <summary>
	/// Helper utility for AssetBundleContentController
	/// </summary>
	public class AssetBundleHelper : MonoBehaviour, ILogContext {

		public bool Ready { get; private set; }

		string _streamingAssetsPath;
		string _baseUrl;

		ULogger            _log;
		AssetBundleManager _manager;

		public void Init(ILog log, AssetBundleManager manager, string streamingAssetsPath, string baseUrl) {
			_log = log.CreateLogger(this);
			_manager = manager;
			_streamingAssetsPath = streamingAssetsPath;
			_baseUrl = baseUrl;
			_log.MessageFormat(
				"Init AssetBundle helper: '{0}', '{1}'",
				_streamingAssetsPath, _baseUrl);
		}

		IEnumerator Start() {
			yield return StartCoroutine(InitializeManager(_manager));
		}

		protected void InitializeSourceUrl() {
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
				_log.Error("You need to set streaming asset path or base url!");
			}
			#endif
		}

		protected IEnumerator InitializeManager(AssetBundleManager manager) {
			InitializeSourceUrl();
			var request = AssetBundleManager.Initialize();			
			if (request != null) {
				yield return StartCoroutine(request);
				Ready = true;
			}
		}

		public void StartLoadAsync<T>(
			string assetBundleName, string assetName, Action<T> callback) where T:UnityEngine.Object {
			StartCoroutine(LoadAsync(assetBundleName, assetName, callback));
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
			_log.MessageFormat(
				"Asset '{0}' {1} loaded in {2} seconds",
				assetName, asset ? "was" : "was not", elapsedTime);
			if( callback != null ) {
				callback(asset);
			}
		}

		public override string ToString() {
			return "AssetBundleHelper";
		}
	}
}