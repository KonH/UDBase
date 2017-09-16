using UnityEngine.Audio;

namespace UDBase.Controllers.AudioSystem {
	public interface IAudio : IController {
		void            MuteChannel     (string channelParam);
		void            UnMuteChannel   (string channelParam);
		float           GetChannelVolume(string channelParam);
		bool            IsChannelMuted  (string channelParam);
		void            ToggleChannel   (string channelParam);
		void            SetChannelVolume(string channelParam, float normalizedVolume);
		AudioMixerGroup GetMixerGroup   (string channelName);
	}
}