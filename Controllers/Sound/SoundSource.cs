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
		public float           FadeIn;
		public float           FadeOut;
		public bool            DestroyOnStop;

		AudioSource _source;
		bool        _sheduled;
		bool        _fadeIn;
		bool        _fadeOut;
		float       _fadeTimer;
		float       _playDelay;
		float       _maxVolume;

		void OnValidate() {
			if ( string.IsNullOrEmpty(Settings.ChannelName) && string.IsNullOrEmpty(Settings.ChannelParam) && !Settings.DefaultMusic ) {
				Settings.DefaultSound = true;
			}
			_source = GetComponent<AudioSource>();
			if ( _source ) {
				_source.playOnAwake = false;
				_source.loop        = Loop;
			}
		}

		void Awake() {
			Setup();
		}

		void Update() {
			if ( _sheduled ) {
				UpdateShedulePlay();
			}
			if ( _fadeIn ) {
				UpdateFadeIn();
			}
			if ( _fadeOut ) {
				UpdateFadeOut();
			}
		}

		void UpdateShedulePlay() {
			_playDelay -= Time.deltaTime;
			if ( _playDelay < 0 ) {
				Play(true);
				_sheduled = false;
			}
		}

		void UpdateFadeIn() {
			_fadeTimer += Time.deltaTime;
			if ( _fadeTimer > FadeIn ) {
				_fadeIn = false;
				_source.volume = _maxVolume;
			} else {
				_source.volume = Mathf.Lerp(0.0f, _maxVolume, _fadeTimer / FadeIn);
			}
		}

		void UpdateFadeOut() {
			_fadeTimer += Time.deltaTime;
			if ( _fadeTimer > FadeOut ) {
				_fadeOut = false;
				StopImmediate();
			} else {
				_source.volume = Mathf.Min(Mathf.Lerp(_maxVolume, 0.0f, _fadeTimer / FadeOut), _source.volume);
			}
		}

		void Setup() {
			Settings.SetupChannelParams();
			var mixerGroup = Audio.GetMixerGroup(Settings.ChannelName);
			if ( !_source ) {
				_source = GetComponent<AudioSource>();
			}
			_source.outputAudioMixerGroup = mixerGroup;
			_maxVolume = _source.volume;
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
			if ( FadeIn > 0 ) {
				_fadeIn = true;
				_fadeTimer = 0.0f;
				_source.volume = 0.0f;
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
			if ( FadeOut > 0 ) {
				_fadeOut = true;
				_fadeTimer = 0.0f;
			} else {
				StopImmediate();
			}
		}

		void StopImmediate() {
			_source.Stop();
			if ( DestroyOnStop ) {
				Destroy(gameObject);
			}
		}
	}
}
