using System;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.ContentSystem {
	public class Content:ControllerHelper<IContent> {
		public static bool LoadAsync<T>(ContentId id, Action<T> callback) where T:UnityEngine.Object {
			for( var i = 0; i < Instances.Count; i++ ) {
				var result = Instances[i].LoadAsync(id, callback);
				if( result ) {
					return true;
				}
			}
			var name = id ? id.name : "null";
			var type = id ? id.LoadType.ToString() : "-";
			Log.ErrorFormat("Can't load asset '{0}' with '{1}' type.", LogTags.Content, name, type);
			return false;
		}
	}
}
