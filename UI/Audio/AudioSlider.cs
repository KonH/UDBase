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
			Settings.SetupChannelParams();
			_slider.value = Audio.GetChannelVolume(Settings.ChannelParam);
			_slider.onValueChanged.AddListener(OnValueChanged);
		}

		void OnVolumeChanged(VolumeChangeEvent e) {
			if ( e.Channel == Settings.ChannelParam ) {
				_slider.value = e.Volume;
			}
		}

		void OnValueChanged(float value) {
			var curValue = Audio.GetChannelVolume(Settings.ChannelParam);
			if ( !Mathf.Approximately(value, curValue) ) {
				Audio.SetChannelVolume(Settings.ChannelParam, value);
			}
		}
	}
}
