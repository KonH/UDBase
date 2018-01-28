using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.EventSystem;
using Zenject;

namespace UDBase.Controllers.AudioSystem.UI {
	[RequireComponent(typeof(Button))]
	public class AudioToggleButton : MonoBehaviour {
		public ChannelSettings Settings   = new ChannelSettings();
		public GameObject      ActiveItem;
		public GameObject      MutedItem;

		Button _button;

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
			_button = GetComponent<Button>();
			_button.onClick.AddListener(OnClick);
			Settings.SetupChannelParams();
			UpdateState();
		}

		void UpdateState() {
			var muted = _audio.IsChannelMuted(Settings.ChannelParam);
			if ( ActiveItem ) {
				ActiveItem.SetActive(!muted);
			}
			if ( MutedItem ) {
				MutedItem.SetActive(muted);
			}
		}

		void OnVolumeChanged(VolumeChangeEvent e) {
			if ( e.Channel == Settings.ChannelParam ) {
				UpdateState();
			}
		}

		void OnClick() {
			_audio.ToggleChannel(Settings.ChannelParam);
		}
	}
}
