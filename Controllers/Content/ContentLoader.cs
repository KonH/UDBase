using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UDBase.Controllers.ContentSystem {
	public class ContentLoader : MonoBehaviour {

		public ContentId Id;
		public bool      InstantiateOnStart;

		List<IContent> _loaders;

		[Inject]
		public void Init(List<IContent> loaders) {
			_loaders = loaders;
		}

		void Start() {
			if( InstantiateOnStart ) {
				Instantiate<GameObject>();
			}
		}

		void Instantiate<T>() where T:UnityEngine.Object {
			LoadAsync<T>(InstantiateCallback);
		}

		void LoadAsync<T>(Action<T> callback) where T:UnityEngine.Object {
			_loaders.GetLoaderFor(Id).LoadAsync(Id, callback);
		}

		void InstantiateCallback<T>(T obj) where T:UnityEngine.Object {
			if( obj ) {
				Instantiate(obj, transform, false);
			}
		}
	}
}