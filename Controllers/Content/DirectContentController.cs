using System;

namespace UDBase.Controllers.ContentSystem {
	public sealed class DirectContentController:IContent {
		public bool CanLoad(ContentId id) {
			return id && (id.LoadType == ContentLoadType.Direct);
		}

		public void LoadAsync<T>(ContentId id, Action<T> callback) where T:UnityEngine.Object {
			if( callback != null ) {
				callback(id.Asset as T);
			}
		}
	}
}
