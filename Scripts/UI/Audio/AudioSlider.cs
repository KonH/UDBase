using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.EventSystem;
using Zenject;

namespace UDBase.Controllers.AudioSystem.UI {
	[RequireComponent(typeof(Slider))]
	public class AudioSlider : MonoBehaviour {
		public ChannelSettings Settings = new ChannelSettings();

		Slider _slider;

		IAudio _audio;
		IEvent _events;

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
			Settings.SetupChannelParams();
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
