using System;

namespace UDBase.Controllers.ContentSystem {

	/// <summary>
	/// Content loader, which used project assets as source
	/// </summary>
	public sealed class DirectContentController:IContent {
		public bool CanLoad(ContentId id) {
			return id && (id.LoadType == ContentLoadType.Direct);
		}

		public void LoadAsync<T>(ContentId id, Action<T> callback) where T:UnityEngine.Object {
			callback?.Invoke(id.Asset as T);
		}
	}
}
