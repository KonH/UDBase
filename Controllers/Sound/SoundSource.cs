using UnityEngine;
using UDBase.Controllers.AudioSystem;
using UDBase.Controllers.ContentSystem;

namespace UDBase.Controllers.SoundSystem {
	[RequireComponent(typeof(AudioSource))]
	public class SoundSource : MonoBehaviour {
		public AudioClipHolder Holder;
		public ChannelSettings Settings;
		public bool            AutoPlay;
		public bool            Loop;
		public float           Delay;

		AudioSource _source;
		bool        _sheduled;
		float       _playDelay;

		void OnValidate() {
			if ( string.IsNullOrEmpty(Settings.ChannelName) && string.IsNullOrEmpty(Settings.ChannelParam) ) {
				Settings.DefaultSound = true;
			}
			var source = GetComponent<AudioSource>();
			if ( source ) {
				source.playOnAwake = false;
				source.loop        = Loop;
			}
		}

		void Awake() {
			_source = GetComponent<AudioSource>();
			Setup();
		}

		void Update() {
			if ( _sheduled ) {
				_playDelay -= Time.deltaTime;
				if ( _playDelay < 0 ) {
					Play(true);
					_sheduled = false;
				}
			}
		}

		void Setup() {
			Settings.SetupChannelParams();
			var mixerGroup = Audio.GetMixerGroup(Settings.ChannelName);
			_source.outputAudioMixerGroup = mixerGroup;
			Content.LoadAsync<AudioClip>(Holder.Id, OnClipLoad);
		}

		void OnClipLoad(AudioClip clip) {
			_source.clip = clip;
			TryAutoPlay();
		}

		void TryAutoPlay() {
			if ( AutoPlay ) {
				Play();
			}
		}

		public void Play(bool force = false) {
			if ( !force && (Delay > 0) ) {
				ShedulePlay();
				return;
			}
			_source.Play();
		}

		void ShedulePlay() {
			_sheduled = true;
			_playDelay = Delay;
		}

		public void Pause() {
			_source.Pause();
		}

		public void UnPause() {
			_source.UnPause();
		}

		public void Stop() {
			_source.Stop();
		}
	}
}
