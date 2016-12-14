﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.SceneSystem {

	public struct Scene_Loaded {
		public ISceneInfo SceneInfo { get; private set; }

		public Scene_Loaded(ISceneInfo sceneInfo) {
			SceneInfo = sceneInfo;
		}
	}
}