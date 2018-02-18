using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.SoundSystem;

namespace UDBase.Controllers.MusicSystem {
	public class MusicHolder : MonoBehaviour {
		public List<SoundSource> Sources = new List<SoundSource>();
		public bool              Loop    = true;
	}
}
