using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.EventSystem;
using Zenject;

namespace UDBase.Controllers.AudioSystem.UI {
	
	/// <summary>
	/// UnityEngine.UI.Slider to control given channel volume settings
	/// </summary>
	[RequireComponent(typeof(Slider))]
	[AddComponentMenu("UDBase/UI/Audio/AudioSlider")]
	public class AudioSlider : MonoBehaviour {

		/// <summary>
		/// Channel which volume will be changed
		/// </summary>
		[Tooltip("Channel which volume will be changed")]
		public ChannelSettings Settings = new ChannelSettings();

		Slider _slider;

		IAudio _audio;
		IEvent _events;

		/// <summary>
		/// Init with dependencies
		/// </summary>
		[Inject]
		public void Init(IAudio audio, IEvent events) {
			_audio  = audio;
			_events = events;
		}

		void OnEnable() {
			_events.Subscribe<VolumeChangeEvent>(this, OnVolumeChanged);
		}

		void OnDisable() {
			_events.Unsubscribe<VolumeChangeEvent>(OnVolumeChanged);
		}

		void Start() {
			_slider = GetComponent<Slider>();
			_slider.value = _audio.GetChannelVolume(Settings.ChannelParam);
			_slider.onValueChanged.AddListener(OnValueChanged);
		}

		void OnVolumeChanged(VolumeChangeEvent e) {
			if ( e.Channel == Settings.ChannelParam ) {
				_slider.value = e.Volume;
			}
		}

		void OnValueChanged(float value) {
			var curValue = _audio.GetChannelVolume(Settings.ChannelParam);
			if ( !Mathf.Approximately(value, curValue) ) {
				_audio.SetChannelVolume(Settings.ChannelParam, value);
			}
		}
	}
}
