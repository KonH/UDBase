using UnityEngine;

namespace UDBase.Controllers.ContentSystem {

	/// <summary>
	/// Specialized GameObject content holder
	/// </summary>
	[System.Serializable]
	public class GameObjectHolder : ContentHolder<GameObject> { }

	/// <summary>
	/// Specialized AudioClip content holder
	/// </summary>
	[System.Serializable]
	public class AudioClipHolder : ContentHolder<AudioClip> { }
}