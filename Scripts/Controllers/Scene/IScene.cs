namespace UDBase.Controllers.SceneSystem {

	/// <summary>
	/// IScene provide several methods to load scenes:
	/// By name - simpliest method.
	/// By some type and parameters - move specific and flexible.
	/// For example, you have some scene structure like that (or much more complicated):
	/// - MainMenu (loaded by name)
	/// Level_1, Level_2, .., Level_N (custom type with parameter)
	/// Your custom class/struct needs to inherit from ISceneInfo and implement Name property with your custom logics.
	/// Another simple option you can use is enum like Scenes { MainMenu, Level }, which can be used in both cases:
	/// LoadScene(Scenes.MainMenu) => loads "MainMenu"
	/// LoadScene(Scenes.Level, "1") => loads "Level_1"
	/// </summary>
	public interface IScene {

		/// <summary>
		/// Info of current loaded scene
		/// </summary>
		ISceneInfo CurrentScene { get; }

		/// <summary>
		/// Loads the scene by specific info
		/// </summary>
		void LoadScene(ISceneInfo sceneInfo);

		/// <summary>
		/// Loads the scene by name
		/// </summary>
		void LoadScene(string sceneName);

		/// <summary>
		/// Loads the scene by custom type
		/// </summary>
		void LoadScene<T>(T type);

		/// <summary>
		/// Loads the scene by custom type and parameter
		/// </summary>
		void LoadScene<T>(T type, string param);

		/// <summary>
		/// Loads the scene by custom type and parameters
		/// </summary>
		void LoadScene<T>(T type, params string[] parameters);

		/// <summary>
		/// Reloads the current scene.
		/// </summary>
		void ReloadScene();
	}
}
