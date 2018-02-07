using UDBase.Controllers.AudioSystem;
using UDBase.Controllers.ContentSystem;

namespace UDBase.Controllers.SoundSystem {
	public interface ISound {
		void Play(ContentId sound, float delay = 0, string channelName = Audio.DefaultSoundChannelName);
		void StartLoop(ContentId sound, float delay = 0, string channelName = Audio.DefaultSoundChannelName);
		void EndLoop(ContentId sound);
	}
}