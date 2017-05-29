using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.EventSystem;

namespace UDBase.Controllers.AudioSystem.UI {
	[RequireComponent(typeof(Slider))]
	public class AudioSlider : MonoBehaviour {

		public string ChannelName  = null;
		public bool   DefaultSound = false;
		public bool   DefaultMusic = false;

		Slider _slider = null;

		void OnEnable() {
			Events.Subscribe<VolumeChangeEvent>(this, OnVolumeChanged);
		}

		void OnDisable() {
			Events.Unsubscribe<VolumeChangeEvent>(OnVolumeChanged);
		}

		void Start() {
			_slider = GetComponent<Slider>();
			SetupChannelName();
			_slider.value = Audio.GetChannelVolume(ChannelName);
			_slider.onValueChanged.AddListener(OnValueChanged);
		}

		void SetupChannelName() {
			if ( DefaultSound ) {
				ChannelName = Audio.Default_Sound_Channel_Volume;
			}
			if ( DefaultMusic ) {
				ChannelName = Audio.Default_Music_Channel_Volume;
			}
		}

		void OnVolumeChanged(VolumeChangeEvent e) {
			if ( e.Channel == ChannelName ) {
				_slider.value = e.Volume;
			}
		}

		void OnValueChanged(float value) {
			var curValue = Audio.GetChannelVolume(ChannelName);
			if ( !Mathf.Approximately(value, curValue) ) {
				Audio.SetChannelVolume(ChannelName, value);
			}
		}
	}
}
