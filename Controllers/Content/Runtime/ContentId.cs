using UnityEngine;

namespace UDBase.Controllers.ContentSystem {
	public class ContentId : ScriptableObject {
		public ContentLoadType LoadType;
		public Object          Asset;
		public string          BundleName;
		public string          AssetName;

		string _toStringCache = null;

		public override string ToString() {
			if ( _toStringCache == null ) {
				if ( !string.IsNullOrEmpty(AssetName) ) {
					_toStringCache = string.Format("{0}/{1}", AssetName, BundleName);
				}
				if ( Asset ) {
					_toStringCache = Asset.name;
				}
			}
			return _toStringCache;
		}
	}
}
