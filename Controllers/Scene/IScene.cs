using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.SceneSystem {
	public interface IScene : IController {
		void LoadScene(ISceneInfo sceneInfo);
	}
}
