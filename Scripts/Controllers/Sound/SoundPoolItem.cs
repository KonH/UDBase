using UnityEngine;
using UnityEngine.Audio;

namespace UDBase.Controllers.SoundSystem {
	class SoundPoolItem {
		public string Key   { get; private set; }
		public float  Delay { get; set; }

		public bool InUse {
			get {
				return _source.isPlaying;
			}
		}

		AudioSource _source;

		public SoundPoolItem(AudioSource source) {
			_source = source;
		}

		public void Init(string key, AudioClip clip, AudioMixerGroup group, bool loop, float delay) {
			Key = key;
			_source.clip = clip;
			_source.outputAudioMixerGroup = group;
			_source.loop = loop;
			Delay = delay;
		}

		public void Play() {
			_source.enabled = true;
			_source.Play();
		}

		public void Stop() {
			_source.Stop();
		}

		public void Free() {
			_source.clip = null;
			_source.outputAudioMixerGroup = null;
			_source.enabled = false;
		}
	}
}