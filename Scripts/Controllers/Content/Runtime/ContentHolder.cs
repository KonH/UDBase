using UnityEngine;

namespace UDBase.Controllers.ContentSystem {

	/// <summary>
	/// ContentId holder with type validation on changes.
	/// It preventing from select incorrect item in inspector.
	/// </summary>
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