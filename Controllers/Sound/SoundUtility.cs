using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.AudioSystem;

namespace UDBase.Controllers.SoundSystem {
	public class SoundUtility : MonoBehaviour {
		Stack<SoundPoolItem> _freeItems = new Stack<SoundPoolItem>();
		List<SoundPoolItem>  _usedItems = new List<SoundPoolItem>();

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

		public void InitPool(int poolSize) {
			for ( int i = 0; i < poolSize; i++ ) {
				AddItemToPool();
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

		public void Play(string key, AudioClip clip, bool loop, float delay, string channelName) {
			var item = GetOrCreateFromPool();
			var group = Audio.GetMixerGroup(channelName);
			item.Init(key, clip, group, loop, delay);
			if ( delay <= 0 ) {
				item.Play();
			}
			_usedItems.Add(item);
		}

		public void StopLoop(string key) {
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
