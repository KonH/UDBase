using System;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.AudioSystem;
using Zenject;

namespace UDBase.Controllers.SoundSystem {

	/// <summary>
	/// Sound utility for playing sounds with ISound/SoundController
	/// </summary>
	public class SoundUtility : MonoBehaviour {

		/// <summary>
		/// Settings for sound utility
		/// </summary>
		[Serializable]
		public class Settings {

			/// <summary>
			/// How many AudioSources needs to created at startup?
			/// </summary>
			[Tooltip("How many AudioSources needs to created at startup?")]
			public int PoolSize;	
		}

		Stack<SoundPoolItem> _freeItems = new Stack<SoundPoolItem>();
		List<SoundPoolItem>  _usedItems = new List<SoundPoolItem>();

		IAudio _audio;

		/// <summary>
		/// Init with dependencies
		/// </summary>
		[Inject]
		public void Init(IAudio audio, SoundUtility.Settings settings) {
			_audio = audio;
			for ( int i = 0; i < settings.PoolSize; i++ ) {
				AddItemToPool();
			}
		}

		void Update() {
			if ( _usedItems.Count > 0 ) {
				for ( var i = 0; i < _usedItems.Count; i++ ) {
					var item = _usedItems[i];
					if ( !item.InUse ) {
						if ( item.Delay > 0 ) {
							item.Delay -= Time.deltaTime;
							if ( item.Delay < 0 ) {
								item.Play();
							}
						} else {
							_usedItems.RemoveAt(i);
							ReturnToPool(item);
							i--;
						}
					}
				}
			}
		}

		void AddItemToPool() {
			var item = CreateItem();
			ReturnToPool(item);
		}

		void ReturnToPool(SoundPoolItem item) {
			item.Free();
			_freeItems.Push(item);
		}

		SoundPoolItem CreateItem() {
			var source = gameObject.AddComponent<AudioSource>();
			return new SoundPoolItem(source);
		}

		SoundPoolItem GetOrCreateFromPool() {
			if ( _freeItems.Count == 0 ) {
				AddItemToPool();
			}
			return _freeItems.Pop();
		}

		internal void Play(string key, AudioClip clip, bool loop, float delay, string channelName) {
			var item = GetOrCreateFromPool();
			var group = _audio.GetMixerGroup(channelName);
			item.Init(key, clip, group, loop, delay);
			if ( delay <= 0 ) {
				item.Play();
			}
			_usedItems.Add(item);
		}

		internal void StopLoop(string key) {
			for ( var i = 0; i < _usedItems.Count; i++ ) {
				var item = _usedItems[i];
				if ( item.Key == key) {
					_usedItems.RemoveAt(i);
					ReturnToPool(item);
					i--;
				}
			}
		}
	}
}
