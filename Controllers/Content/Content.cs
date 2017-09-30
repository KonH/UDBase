using System;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.ContentSystem {
	public class Content:ControllerHelper<IContent> {
		public static string GetTypeString(Type type) {
			return type.FullName;
		}

		public static string GetAssetType(Object asset) {
			return GetTypeString(asset.GetType());
		}

		public static bool LoadAsync<T>(ContentId id, Action<T> callback) where T:UnityEngine.Object {
			var savedAssetType = id ? id.Type : "null";
			var name = id ? id.name : "null";
			var wantedAssetType = GetTypeString(typeof(T));
			if ( savedAssetType != wantedAssetType ) {
				Log.ErrorFormat("Can't load asset '{0}' with type '{1}' (actual type: '{2}').", LogTags.Content, name, wantedAssetType, savedAssetType);
				return false;
			}
			for ( var i = 0; i < Instances.Count; i++ ) {
				var result = Instances[i].LoadAsync(id, callback);
				if( result ) {
					return true;
				}
			}
			var loadType = id ? id.LoadType.ToString() : "-";
			Log.ErrorFormat("Can't load asset '{0}' with '{1}' load type.", LogTags.Content, name, loadType);
			return false;
		}
	}
}
