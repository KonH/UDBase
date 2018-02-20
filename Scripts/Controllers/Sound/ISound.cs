using UDBase.Controllers.AudioSystem;
using UDBase.Controllers.ContentSystem;

namespace UDBase.Controllers.SoundSystem {

	/// <summary>
	/// ISound is uses Audio for channel settings and provides two ways to work: direct SoundSource and SoundController.
	/// First is used for positional or deep controlled sounds, second for simple 2D sounds(UI, for example).
	/// All ISound methods require Content system is used for store AudioClips.
	/// </summary>
	public interface ISound {

		/// <summary>
		/// Play the specified sound (AudioClip inside ContentId), with optional delay and channelName
		/// </summary>
		void Play(ContentId sound, float delay = 0, string channelName = Audio.DefaultSoundChannelName);

		/// <summary>
		/// Play the specified sound (AudioClip inside ContentId) as loop, with optional delay and channelName
		/// </summary>
		void StartLoop(ContentId sound, float delay = 0, string channelName = Audio.DefaultSoundChannelName);

		/// <summary>
		/// End already started loop (AudioClip inside ContentId)
		/// </summary>
		void EndLoop(ContentId sound);
	}
}