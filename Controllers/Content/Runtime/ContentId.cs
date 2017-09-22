using UnityEngine;

namespace UDBase.Controllers.ContentSystem {
	public class ContentId : ScriptableObject {
		public ContentLoadType LoadType;
		public Object          Asset;
		public string          Type;
		public string          BundleName;
		public string          AssetName;

		[System.NonSerialized]
		string _toStringCache = null;

		public override string ToString() {
			if ( _toStringCache == null ) {
				if ( !string.IsNullOrEmpty(AssetName) ) {
					_toStringCache = string.Format("{0}/{1} ({2})", AssetName, BundleName, Type);
				}
				if ( Asset ) {
					_toStringCache = string.Format("{0} ({1})", Asset.name, Type);
				}
			}
			return _toStringCache;
		}
	}
}
