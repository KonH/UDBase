using System;
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

		public bool LoadAsync<T>(Action<T> callback) where T:UnityEngine.Object {
			return Content.LoadAsync<T>(Id, callback);
		}

		public bool Instantiate<T>() where T:UnityEngine.Object {
			return LoadAsync<T>(InstantiateCallback);
		}

		void InstantiateCallback<T>(T obj) where T:UnityEngine.Object {
			if( obj ) {
				Instantiate(obj, transform, false);
			}
		}
	}
}