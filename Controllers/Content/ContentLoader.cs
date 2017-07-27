using System;
using UnityEngine;

namespace UDBase.Controllers.ContentSystem {
	public class ContentLoader : MonoBehaviour {

		public ContentId Id;
		public bool      InstantiateOnStart;

		void Start() {
			if( InstantiateOnStart ) {
				Instantiate<GameObject>();
			}
		}

		public bool LoadAsync<T>(Action<T> callback) where T:UnityEngine.Object {
			return Content.LoadAsync(Id, callback);
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