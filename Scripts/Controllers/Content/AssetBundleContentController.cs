using System;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.ContentSystem {
	public sealed class AssetBundleContentController:IContent {
		
		[Serializable]
		public class Settings {
			public AssetBundleMode Mode = AssetBundleMode.StreamingAssets;
			public string Path;
		}

		readonly AssetBundleHelper _helper;

		readonly string _streamingAssetsPath;
		readonly string _baseUrl;

		public AssetBundleContentController(Settings settings, AssetBundleHelper helper, ILog log) {
			if( settings.Mode == AssetBundleMode.StreamingAssets ) {
				_streamingAssetsPath = settings.Path;
			} else {
				if( string.IsNullOrEmpty(settings.Path) ) {
					log.Error(LogTags.Content, "For WebServer mode you need to provide path!");
				}
				_baseUrl = settings.Path;
			}
			_helper = helper;
			if( _helper ) {
				_helper.Init(log, _streamingAssetsPath, _baseUrl);
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