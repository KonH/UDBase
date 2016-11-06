using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.SceneSystem {
	public interface IScene : IController {
		ISceneInfo CurrentScene { get; }
		void LoadScene(ISceneInfo sceneInfo);
	}
}
