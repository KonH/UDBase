using UnityEngine;
using UDBase.Utils;
using UDBase.Controllers.SoundSystem;

namespace UDBase.Controllers.MusicSystem {

	/// <summary>
	/// Utility class for playing music
	/// </summary>
	public class MusicUtility : MonoBehaviour {
		SoundSource _currentSource;

		internal void StopTrack() {
			if ( _currentSource ) {
				_currentSource.DestroyOnStop = true;
				_currentSource.Stop();
				_currentSource = null;
			}
		}

		SoundSource SelectSource(MusicHolder holder) {
			if ( holder.Sources.Count > 0 ) {
				return RandomUtils.GetItem(holder.Sources);
			}
			return null;
		}

		internal void SetupTrack() {
			var holder = GameObject.FindObjectOfType<MusicHolder>();
			if ( holder ) {
				Destroy(holder);
				_currentSource = SelectSource(holder);
				DontDestroyOnLoad(_currentSource.gameObject);
			}
		}

		internal void Pause() {
			if ( _currentSource ) {
				_currentSource.Pause();
			}
		}

		internal void UnPause() {
			if ( _currentSource ) {
				_currentSource.UnPause();
			}
		}
	}
}
