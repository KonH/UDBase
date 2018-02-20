using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UDBase.Controllers.ContentSystem {

	/// <summary>
	/// Simple content loader
	/// </summary>
	[AddComponentMenu("UDBase/Content/ContentLoader")]
	public class ContentLoader : MonoBehaviour {

		/// <summary>
		/// ContentId to load
		/// </summary>
		[Tooltip("ContentId to load")]
		public ContentId Id;

		/// <summary>
		/// Need to load content on start?
		/// </summary>
		[Tooltip("Need to load content on start?")]
		public bool InstantiateOnStart;

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