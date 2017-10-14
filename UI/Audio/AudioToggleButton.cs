﻿using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.EventSystem;

namespace UDBase.Controllers.AudioSystem.UI {
	[RequireComponent(typeof(Button))]
	public class AudioToggleButton : MonoBehaviour {
		public ChannelSettings Settings   = new ChannelSettings();
		public GameObject      ActiveItem;
		public GameObject      MutedItem;

		Button _button;

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
			var muted = Audio.IsChannelMuted(Settings.ChannelParam);
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
			Audio.ToggleChannel(Settings.ChannelParam);
		}
	}
}