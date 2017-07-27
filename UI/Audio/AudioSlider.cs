using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.EventSystem;

namespace UDBase.Controllers.AudioSystem.UI {
	[RequireComponent(typeof(Slider))]
	public class AudioSlider : MonoBehaviour {
		public ChannelSettings Settings = new ChannelSettings();

		Slider _slider;

		void OnEnable() {
			Events.Subscribe<VolumeChangeEvent>(this, OnVolumeChanged);
		}

		void OnDisable() {
			Events.Unsubscribe<VolumeChangeEvent>(OnVolumeChanged);
		}

		void Start() {
			_slider = GetComponent<Slider>();
			Settings.SetupChannelName();
			_slider.value = Audio.GetChannelVolume(Settings.ChannelName);
			_slider.onValueChanged.AddListener(OnValueChanged);
		}

		void OnVolumeChanged(VolumeChangeEvent e) {
			if ( e.Channel == Settings.ChannelName ) {
				_slider.value = e.Volume;
			}
		}

		void OnValueChanged(float value) {
			var curValue = Audio.GetChannelVolume(Settings.ChannelName);
			if ( !Mathf.Approximately(value, curValue) ) {
				Audio.SetChannelVolume(Settings.ChannelName, value);
			}
		}
	}
}
