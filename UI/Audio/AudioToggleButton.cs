using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.EventSystem;

namespace UDBase.Controllers.AudioSystem.UI {
	[RequireComponent(typeof(Button))]
	public class AudioToggleButton : MonoBehaviour {

		public ChannelSettings Settings   = new ChannelSettings();
		public GameObject      ActiveItem = null;
		public GameObject      MutedItem  = null;

		Button _button = null;

		void OnEnable() {
			Events.Subscribe<VolumeChangeEvent>(this, OnVolumeChanged);
		}

		void OnDisable() {
			Events.Unsubscribe<VolumeChangeEvent>(OnVolumeChanged);
		}

		void Start() {
			_button = GetComponent<Button>();
			_button.onClick.AddListener(OnClick);
			Settings.SetupChannelName();
			UpdateState();
		}

		void UpdateState() {
			var muted = Audio.IsChannelMuted(Settings.ChannelName);
			if ( ActiveItem ) {
				ActiveItem.SetActive(!muted);
			}
			if ( MutedItem ) {
				MutedItem.SetActive(muted);
			}
		}

		void OnVolumeChanged(VolumeChangeEvent e) {
			if ( e.Channel == Settings.ChannelName ) {
				UpdateState();
			}
		}

		void OnClick() {
			Audio.ToggleChannel(Settings.ChannelName);
		}
	}
}
