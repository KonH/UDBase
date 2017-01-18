using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.ContentSystem {
	public class ContentId : ScriptableObject {

		public ContentLoadType LoadType;
		public Object          Asset;
		public string          BundleName;
		public string          AssetName;
	}
}
