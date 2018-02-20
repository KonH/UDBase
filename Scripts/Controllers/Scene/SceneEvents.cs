namespace UDBase.Controllers.SceneSystem {

	/// <summary>
	/// Event which fired when scene was changed
	/// </summary>
	public struct Scene_Loaded {
		public ISceneInfo SceneInfo { get; private set; }

		public Scene_Loaded(ISceneInfo sceneInfo) {
			SceneInfo = sceneInfo;
		}
	}
}
