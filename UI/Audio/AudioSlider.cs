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

		[Inject]
		void Init(IAudio audio) {
			_audio = audio;
		}

		void OnEnable() {
			Events.Subscribe<VolumeChangeEvent>(this, OnVolumeChanged);
		}

		void OnDisable() {
			Events.Unsubscribe<VolumeChangeEvent>(OnVolumeChanged);
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
