using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.ContentSystem;
using UDBase.Utils;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.SoundSystem {
	public class SoundController : ISound {
		
		Dictionary<ContentId, AudioClip> _clipCache = new Dictionary<ContentId, AudioClip>();

		SoundUtility _utility;
		List<IContent> _loaders;


		public SoundController(SoundUtility utility, List<IContent> loaders) {
			_utility = utility;
			_loaders = loaders;
		}

		void Play(ContentId sound, bool loop, float delay, string channelName) {
			if ( sound == null ) {
				return;
			}
			AudioClip cachedClip;
			if ( _clipCache.TryGetValue(sound, out cachedClip) ) {
				_utility.Play(sound.ToString(), cachedClip, loop, delay, channelName);
				return;
			}
			_loaders.GetLoaderFor(sound).LoadAsync<AudioClip>(sound, (clip) => {
				if ( clip ) {
					Log.MessageFormat("Loaded clip for '{0}': '{1}'", LogTags.Sound, sound.ToString(), clip.name);
					if ( !_clipCache.ContainsKey(sound) ) {
						_clipCache.Add(sound, clip);
					}
					_utility.Play(sound.ToString(), clip, loop, delay, channelName);
				} else {
					Log.ErrorFormat("Not found clip for {0}", LogTags.Sound, sound.ToString());
				}
			});
		}

		public void Play(ContentId sound, float delay, string channelName) {
			Play(sound, false, delay, channelName);
		}

		public void StartLoop(ContentId sound, float delay, string channelName) {
			Play(sound, true, delay, channelName);
		}

		public void EndLoop(ContentId sound) {
			if ( sound ) {
				_utility.StopLoop(sound.ToString());
			}
		}
	}
}