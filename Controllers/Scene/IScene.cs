namespace UDBase.Controllers.SceneSystem {
	public interface IScene {
		ISceneInfo CurrentScene { get; }
		
		void LoadScene   (ISceneInfo sceneInfo);
		void LoadScene   (string sceneName);
		void LoadScene<T>(T type);
		void LoadScene<T>(T type, string param);
		void LoadScene<T>(T type, params string[] parameters);
		void ReloadScene ();
	}
}
