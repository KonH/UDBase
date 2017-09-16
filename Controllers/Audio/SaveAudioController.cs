using System.Collections.Generic;
using UDBase.Controllers.SaveSystem;
using UnityEngine;
using UDBase.Utils;

namespace UDBase.Controllers.AudioSystem {
	public class SaveAudioController : IAudio {
		readonly IAudio _controller;
		readonly float  _saveDelta;
		
		AudioSaveNode _node;

		public SaveAudioController(IAudio controller) {
			_controller = controller;
		}

		public SaveAudioController(
			string mixerPath, float saveDelta = 0.1f, string[] channels = null, float initialVolume = 0.5f) : 
			this(new AudioController(mixerPath, channels, initialVolume)) {
			_saveDelta = saveDelta;
		}

		public void Init() {
			_controller.Init();
		}

		public void PostInit() {
			_controller.PostInit();
			LoadState();
			UnityHelper.AddPersistantStartCallback(SetupState);
		}

		void LoadState() {
			_node = Save.GetNode<AudioSaveNode>();
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

		public void MuteChannel(string parameter) {
			_controller.MuteChannel(parameter);
			SaveMute(parameter);
		}

		public void UnMuteChannel(string parameter) {
			_controller.UnMuteChannel(parameter);
			SaveMute(parameter);
		}

		public float GetChannelVolume(string parameter) {
			return _controller.GetChannelVolume(parameter);
		}

		public bool IsChannelMuted(string parameter) {
			return _controller.IsChannelMuted(parameter);
		}

		public void ToggleChannel(string parameter) {
			_controller.ToggleChannel(parameter);
			SaveMute(parameter);
		}

		ChannelNode GetOrCreateChannelNode(string parameter) {
			var channels = _node.Channels;
			if ( channels.ContainsKey(parameter) ) {
				return channels[parameter];
			} else {
				var channel = new ChannelNode();
				channels.Add(parameter, channel);
				return channel;
			}
		}

		void SaveMute(string parameter) {
			var channel = GetOrCreateChannelNode(parameter);
			var mute = _controller.IsChannelMuted(parameter);
			if ( channel.IsMuted != mute ) {
				channel.IsMuted = mute;
				Save.SaveNode(_node);
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

		public void SetChannelVolume(string parameter, float normalizedVolume) {
			_controller.SetChannelVolume(parameter, normalizedVolume);
			var channel = GetOrCreateChannelNode(parameter);
			if ( IsNeedToSaveVolume(channel.Volume, normalizedVolume) ) {
				channel.Volume = normalizedVolume;
				Save.SaveNode(_node);
			}
		}
	}
}
