using System;

namespace UDBase.Controllers.ContentSystem {
	public interface IContent {
		bool CanLoad(ContentId contentId);
		void LoadAsync<T>(ContentId id, Action<T> callback) where T:UnityEngine.Object;
	}
}
