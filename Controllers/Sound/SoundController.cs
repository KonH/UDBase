using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.ContentSystem;
using UDBase.Utils;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.SoundSystem {
	public class SoundController : ISound {
		
		Dictionary<ContentId, AudioClip> _clipCache = new Dictionary<ContentId, AudioClip>();

		ILog _log;
		SoundUtility _utility;
		List<IContent> _loaders;


		public SoundController(ILog log, SoundUtility utility, List<IContent> loaders) {
			_log = log;
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
					_log.MessageFormat(LogTags.Sound, "Loaded clip for '{0}': '{1}'", sound.ToString(), clip.name);
					if ( !_clipCache.ContainsKey(sound) ) {
						_clipCache.Add(sound, clip);
					}
					_utility.Play(sound.ToString(), clip, loop, delay, channelName);
				} else {
					_log.ErrorFormat(LogTags.Sound, "Not found clip for {0}", sound.ToString());
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