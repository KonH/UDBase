using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.SoundSystem;

namespace UDBase.Controllers.MusicSystem {
	public class MusicHolder : MonoBehaviour {
		public List<SoundSource> Sources = new List<SoundSource>();
		public bool              Loop    = true;

		void OnValidate() {
			foreach ( var s in Sources ) {
				s.AutoPlay = true;
				s.Loop = Loop;
				if ( string.IsNullOrEmpty(s.Settings.ChannelName) ) {
					s.Settings.DefaultSound = false;
					s.Settings.DefaultMusic = true;
				}
			}
		}
	}
}
