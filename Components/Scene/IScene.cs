using UnityEngine;
using System.Collections;

namespace UDBase.Components.Scene {
	public interface IScene : IComponent {

		void LoadScene(string sceneName);
	}
}
