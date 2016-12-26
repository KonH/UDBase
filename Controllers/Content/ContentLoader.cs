using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.ContentSystem {
	public class ContentLoader : MonoBehaviour {

		public ContentId Id                 = null;
		public bool      InstantiateOnStart = false;

		void Start() {
			if( InstantiateOnStart ) {
				Instantiate<GameObject>();
			}
		}

		public T Load<T>() where T:Object {
			return Content.Load<T>(Id);
		}

		public T Instantiate<T>() where T:Object {
			return Instantiate(Load<T>());
		}
	}
}