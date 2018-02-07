using UnityEngine;

namespace UDBase.Controllers.ContentSystem {
	public class ContentHolder<T>: ISerializationCallbackReceiver {
		public ContentId Id;

		public bool IsValidId() {
			if ( Id ) {
				if ( Id.Type != Content.GetTypeString(typeof(T)) ) {
					return false;
				}
			}
			return true;
		}

		public void OnBeforeSerialize() {
			if ( Id ) {
				if ( !IsValidId() ) {
					Debug.LogErrorFormat(
						"Type '{0}' is not allowed to this item ('{1}' required)",
						Id.Type, Content.GetTypeString(typeof(T)));
					Id = null;
				}
			}
		}

		public void OnAfterDeserialize() { }
	}
}