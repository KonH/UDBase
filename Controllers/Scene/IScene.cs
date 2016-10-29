using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.Scene {
	public interface IScene : IController {
		void LoadScene(ISceneInfo sceneInfo);
	}
}
