using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.ContentSystem;

namespace UDBase.Controllers.SoundSystem {

	/// <summary>
	/// Default sound controller
	/// </summary>
	public class SoundController : ISound, ILogContext {
		
		Dictionary<ContentId, AudioClip> _clipCache = new Dictionary<ContentId, AudioClip>();

		ULogger        _log;
		SoundUtility   _utility;
		List<IContent> _loaders;


		public SoundController(ILog log, SoundUtility utility, List<IContent> loaders) {
			_log = log.CreateLogger(this);
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
					_log.MessageFormat("Loaded clip for '{0}': '{1}'", sound.ToString(), clip.name);
					if ( !_clipCache.ContainsKey(sound) ) {
						_clipCache.Add(sound, clip);
					}
					_utility.Play(sound.ToString(), clip, loop, delay, channelName);
				} else {
					_log.ErrorFormat("Not found clip for {0}", sound.ToString());
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