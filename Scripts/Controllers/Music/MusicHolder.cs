using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.SoundSystem;

namespace UDBase.Controllers.MusicSystem {

	/// <summary>
	/// MusicHolder is a set of music for the scene
	/// </summary>
	[AddComponentMenu("UDBase/Music/MusicHolder")]
	public class MusicHolder : MonoBehaviour {

		/// <summary>
		/// All tracks for scene, on of it selected randomly on scene start
		/// </summary>
		[Tooltip("All tracks for scene, on of it selected randomly on scene start")]
		public List<SoundSource> Sources = new List<SoundSource>();
	}
}
