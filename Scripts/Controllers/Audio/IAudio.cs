using UnityEngine.Audio;

namespace UDBase.Controllers.AudioSystem {

	/// <summary>
	/// Default values of audio settings
	/// </summary>
	public static class Audio {

		/// <summary>
		/// Exposed volume parameter for sound channel
		/// </summary>
		public const string DefaultSoundChannelVolume = "SoundVolume";

		/// <summary>
		/// Exposed volume parameter for music channel
		/// </summary>
		public const string DefaultMusicChannelVolume = "MusicVolume";

		/// <summary>
		/// Channel name for sound
		/// </summary>
		public const string DefaultSoundChannelName = "Sound";

		/// <summary>
		/// Channel name for music
		/// </summary>
		public const string DefaultMusicChannelName = "Music";
	}

	/// <summary>
	/// IAudio uses AudioMixers to control channel volumes and have ability to mute it with previous volume saving.
	/// For get it to work, you need AudioMixer with channels (channelName) and exposed volume parameters (channelParam).
	/// </summary>
	public interface IAudio {

		/// <summary>
		/// Mutes the channel via given channel parameter
		/// </summary>
		void MuteChannel(string channelParam);

		/// <summary>
		/// Unmutes the channel via given channel parameter
		/// </summary>
		void UnMuteChannel(string channelParam);

		/// <summary>
		/// Get the channel volume via given channel parameter
		/// </summary>
		float GetChannelVolume(string channelParam);

		/// <summary>
		/// Is the channel muted via given channel parameter?
		/// </summary>
		bool IsChannelMuted(string channelParam);

		/// <summary>
		/// Mutes the channel if it isn't yet muted (and opposite) via given channel parameter
		/// </summary>
		void ToggleChannel(string channelParam);

		/// <summary>
		/// Changes volume of given channel parameter
		/// </summary>
		void SetChannelVolume(string channelParam, float normalizedVolume);

		/// <summary>
		/// Gets the mixer group by given channel name
		/// </summary>
		AudioMixerGroup GetMixerGroup(string channelName);
	}
}