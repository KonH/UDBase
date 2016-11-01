# Scene

Using Scene Controller you can load scenes with several methods. You can load scene directly by its name using **Scene.LoadSceneByName(name)** or use advanced methods. For example, you have some scene structure like that (or much more complicated):

- MainMenu
- Level_1
- Level_2
- ...
- Level_N

You can load all scenes by name in this case, but you can use **Scene.LoadSceneByInfo(info)** with your custom class/struct inherited from **ISceneInfo** and implemented *Name* property:

```
public struct CustomInfo : ISceneInfo {
    // 'get' can contains any custom logics to convert your data to scene name
	public string Name { get; private set; }
}
```
Another simple option you can use - **LoadScene(type,...)** helper methods. With it you can declare your custom enum to describe your scene scheme:

```
public enum Scenes {
	MainScene, // Only one scheme
	Level      // Multiple scenes in "Level_*" format
	// ... - and more types
}
```

After it you can load single scene:

```
Scene.LoadScene(Scenes.MainScene);
```

And specific scene in *Level_\** set:

```
Scene.LoadScene(Scenes.Level, "0"); // Load 'Level_0' scene
```

In Unity UI for these cases you can use **SceneLoadButton**/**SceneParamLoadButton\<T\>** components. For using second component you need to make your class that inherited from it to use in *Unity Inspector*:

```
public class YourSceneButton : SceneParamLoadButton<YourScenesEnumType> {}
```

Scenes can be loaded in two ways:

- **DirectSceneLoader** - loads scene synchronously.
- **AsyncSceneLoader** - loads scene asynchronously with (optional) loading scene.

To use one of these types you can add this to your *Scheme* script:

```
AddController(new Scene(), new AsyncSceneLoader());
```

For most cases async load is more acceptable. It provides some useful options:

```
new AsyncSceneLoader() // Load new scene on current scene and go to it after loading
new AsyncSceneLoader("Loading") // Using specific scene for loading process
new AsyncSceneLoader("Loading", "StartScene") // Async load "MainScene" at first time (for scene scheme like this "Loading">"StartScene">"Loading">"Level" and so on
```
UI Component that you can use for Loading scene is **LoadingView** (loading progress counter and progress bar are supported). 
In example project you can look at this features usage.

