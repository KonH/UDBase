using UnityEngine;
using System;
using System.Collections;
using UDBase.Controllers;
using UDBase.Common;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.ContentSystem {
	public class Content:ControllerHelper<IContent> {

		public static bool LoadAsync<T>(ContentId id, Action<T> callback) where T:UnityEngine.Object {
			var result = false;
			for( int i = 0; i < Instances.Count; i++ ) {
				result = Instances[i].LoadAsync<T>(id, callback);
				if( result ) {
					return result;
				}
			}
			var name = id ? id.name : "null";
			var type = id ? id.LoadType.ToString() : "-";
			Log.ErrorFormat("Can't load asset '{0}' with '{1}' type.", LogTags.Content, name, type);
			return result;
		}
	}
}
