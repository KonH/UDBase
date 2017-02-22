using System;

namespace UDBase.Controllers.ContentSystem {
	public sealed class DirectContentController:IContent {

		public void Init() {}
		
		public void PostInit() {}

		public void Reset() {}

		public bool LoadAsync<T>(ContentId id, Action<T> callback) where T:UnityEngine.Object {
			if( !id || id.LoadType != ContentLoadType.Direct ) {
				return false;
			}
			if( callback != null ) {
				callback(id.Asset as T);
			}
			return true;
		}
	}
}
