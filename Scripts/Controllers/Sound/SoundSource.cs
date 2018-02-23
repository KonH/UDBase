using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.AudioSystem;
using UDBase.Controllers.ContentSystem;
using Zenject;

namespace UDBase.Controllers.SoundSystem {

	/// <summary>
	/// AudioSource wrapper to use in ISound
	/// </summary>
	[AddComponentMenu("UDBase/Sound/SoundSource")]
	[RequireComponent(typeof(AudioSource))]
	public class SoundSource : MonoBehaviour {

		/// <summary>
		/// Content holder for current audio clip
		/// </summary>
		[Tooltip("Content holder for current audio clip")]
		public AudioClipHolder Holder;

		/// <summary>
		/// The settings for the channel to play with
		/// </summary>
		[Tooltip("The settings for the channel to play with")]
		public ChannelSettings Settings;

		/// <summary>
		/// Is need to play on start?
		/// </summary>
		[Tooltip("Is need to play on start?")]
		public bool AutoPlay;

		/// <summary>
		/// Is need to play over and over?
		/// </summary>
		[Tooltip("Is need to play over and over?")]
		public bool Loop;

		/// <summary>
		/// Time to wait before playing
		/// </summary>
		[Tooltip("Time to wait before playing")]
		public float Delay;

		/// <summary>
		/// Time to maximize volume from 0 on start
		/// </summary>
		[Tooltip("Time to maximize volume from 0 on start")]
		public float FadeIn;

		/// <summary>
		/// Time to minimize volume to 0 before end
		/// </summary>
		[Tooltip("Time to minimize volume to 0 before end")]
		public float FadeOut;

		/// <summary>
		/// Destroy instance on stop?
		/// </summary>
		[Tooltip("Destroy instance on stop?")]
		public bool DestroyOnStop;

		AudioSource _source;
		bool        _sheduled;
		bool        _fadeIn;
		bool        _fadeOut;
		float       _fadeTimer;
		float       _playDelay;
		float       _maxVolume;

		IAudio _audio;
		List<IContent> _loaders;

		/// <summary>
		/// Init with dependencies
		/// </summary>
		[Inject]
		public void Init(IAudio audio, List<IContent> loaders) {
			_audio = audio;
			_loaders = loaders;
		}

		void OnValidate() {
			_source = GetComponent<AudioSource>();
			if ( _source ) {
				_source.playOnAwake = false;
				_source.loop        = Loop;
			}
		}

		void Start() {
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
			var mixerGroup = _audio.GetMixerGroup(Settings.ChannelName);
			if ( !_source ) {
				_source = GetComponent<AudioSource>();
			}
			_source.outputAudioMixerGroup = mixerGroup;
			_maxVolume = _source.volume;
			_loaders.GetLoaderFor(Holder.Id).LoadAsync<AudioClip>(Holder.Id, OnClipLoad);
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

		/// <summary>
		/// Play the current assigned sound (force is allows to skip Delay)
		/// </summary>
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

		/// <summary>
		/// Pause playing sound
		/// </summary>
		public void Pause() {
			_source.Pause();
		}

		/// <summary>
		/// Resume playing sound
		/// </summary>
		public void UnPause() {
			_source.UnPause();
		}

		/// <summary>
		/// Stop playing sound
		/// </summary>
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
