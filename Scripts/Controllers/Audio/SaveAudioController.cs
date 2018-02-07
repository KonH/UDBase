using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UDBase.Utils;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.EventSystem;

namespace UDBase.Controllers.AudioSystem {
	public class SaveAudioController : IAudio {
		
		[Serializable]
		public class Settings : AudioController.Settings {
			public float SaveDelta;
		}

		readonly IAudio _controller;
		readonly float  _saveDelta;
		
		AudioSaveNode _node;

		ISave _save;

		public SaveAudioController(Settings settings, ISave save, ILog log, IEvent events) {
			_controller = new AudioController(settings, log, events);
			_save = save;
			_saveDelta = settings.SaveDelta;
			LoadState();
			UnityHelper.AddPersistantStartCallback(SetupState);
		}

		void LoadState() {
			_node = _save.GetNode<AudioSaveNode>();
			if ( _node.Channels == null ) {
				_node.Channels = new Dictionary<string, ChannelNode>();
			}
		}

		void SetupState() {
			var channelIter = _node.Channels.GetEnumerator();
			while ( channelIter.MoveNext() ) {
				var current = channelIter.Current;
				_controller.SetChannelVolume(current.Key, current.Value.Volume);
				if ( current.Value.IsMuted ) {
					_controller.MuteChannel(current.Key);
				}
			}
		}

		public void Reset() {}

		public void MuteChannel(string channelParam) {
			_controller.MuteChannel(channelParam);
			SaveMute(channelParam);
		}

		public void UnMuteChannel(string channelParam) {
			_controller.UnMuteChannel(channelParam);
			SaveMute(channelParam);
		}

		public float GetChannelVolume(string channelParam) {
			return _controller.GetChannelVolume(channelParam);
		}

		public bool IsChannelMuted(string channelParam) {
			return _controller.IsChannelMuted(channelParam);
		}

		public void ToggleChannel(string channelParam) {
			_controller.ToggleChannel(channelParam);
			SaveMute(channelParam);
		}

		ChannelNode GetOrCreateChannelNode(string channelParam) {
			var channels = _node.Channels;
			if ( channels.ContainsKey(channelParam) ) {
				return channels[channelParam];
			} else {
				var channel = new ChannelNode();
				channels.Add(channelParam, channel);
				return channel;
			}
		}

		void SaveMute(string channelParam) {
			var channel = GetOrCreateChannelNode(channelParam);
			var mute = _controller.IsChannelMuted(channelParam);
			if ( channel.IsMuted != mute ) {
				channel.IsMuted = mute;
				_save.SaveNode(_node);
			}
		}

		bool CheckValues(float newValue, float currentValue, float checkValue) {
			return Mathf.Approximately(newValue, checkValue) && !Mathf.Approximately(currentValue, checkValue);
		}

		bool IsNeedToSaveVolume(float currentValue, float newValue) {
			if ( Mathf.Approximately(currentValue, newValue) ) {
				return false;
			}
			if ( CheckValues(newValue, currentValue, 0.0f) || CheckValues(newValue, currentValue, 1.0f) ) {
				return true;
			}
			return Mathf.Abs(newValue - currentValue) > _saveDelta;
		}

		public void SetChannelVolume(string channelParam, float normalizedVolume) {
			_controller.SetChannelVolume(channelParam, normalizedVolume);
			var channel = GetOrCreateChannelNode(channelParam);
			if ( IsNeedToSaveVolume(channel.Volume, normalizedVolume) ) {
				channel.Volume = normalizedVolume;
				_save.SaveNode(_node);
			}
		}

		public AudioMixerGroup GetMixerGroup(string channelName) {
			return _controller.GetMixerGroup(channelName);
		}
	}
}
