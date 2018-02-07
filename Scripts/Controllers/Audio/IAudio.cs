using UnityEngine.Audio;

namespace UDBase.Controllers.AudioSystem {
	public static class Audio {
		public const string DefaultSoundChannelVolume = "SoundVolume";
		public const string DefaultMusicChannelVolume = "MusicVolume";
		public const string DefaultSoundChannelName   = "Sound";
		public const string DefaultMusicChannelName   = "Music";
	}

	public interface IAudio {
		void            MuteChannel     (string channelParam);
		void            UnMuteChannel   (string channelParam);
		float           GetChannelVolume(string channelParam);
		bool            IsChannelMuted  (string channelParam);
		void            ToggleChannel   (string channelParam);
		void            SetChannelVolume(string channelParam, float normalizedVolume);
		AudioMixerGroup GetMixerGroup   (string channelName);
	}
}