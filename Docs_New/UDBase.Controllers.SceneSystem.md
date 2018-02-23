## `AsyncLoadHelper`

Helper class for async scene loading
```csharp
public class UDBase.Controllers.SceneSystem.AsyncLoadHelper
    : MonoBehaviour

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Single` | Progress |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | LoadScene(`String` sceneName, `Action` callback) |  | 


## `AsyncSceneLoader`

Asynchronous scene loader
```csharp
public class UDBase.Controllers.SceneSystem.AsyncSceneLoader
    : IScene

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `ISceneInfo` | CurrentScene |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | LoadScene(`ISceneInfo` sceneInfo) |  | 
| `void` | LoadScene(`String` sceneName) |  | 
| `void` | LoadScene(`T` type) |  | 
| `void` | LoadScene(`T` type, `String` param) |  | 
| `void` | LoadScene(`T` type, `String[]` parameters) |  | 
| `void` | ReloadScene() |  | 


## `DirectSceneLoader`

Synchronous scene loader
```csharp
public class UDBase.Controllers.SceneSystem.DirectSceneLoader
    : IScene

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `ISceneInfo` | CurrentScene |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | LoadScene(`ISceneInfo` sceneInfo) |  | 
| `void` | LoadScene(`String` sceneName) |  | 
| `void` | LoadScene(`T` type) |  | 
| `void` | LoadScene(`T` type, `String` param) |  | 
| `void` | LoadScene(`T` type, `String[]` parameters) |  | 
| `void` | ReloadScene() |  | 


## `IScene`

```csharp
public interface UDBase.Controllers.SceneSystem.IScene

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `ISceneInfo` | CurrentScene | Info of current loaded scene | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | LoadScene(`ISceneInfo` sceneInfo) | Loads the scene by specific info | 
| `void` | LoadScene(`String` sceneName) | Loads the scene by specific info | 
| `void` | LoadScene(`T` type) | Loads the scene by specific info | 
| `void` | LoadScene(`T` type, `String` param) | Loads the scene by specific info | 
| `void` | LoadScene(`T` type, `String[]` parameters) | Loads the scene by specific info | 
| `void` | ReloadScene() | Reloads the current scene. | 


## `ISceneInfo`

Interface for scene information
```csharp
public interface UDBase.Controllers.SceneSystem.ISceneInfo

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Name |  | 


## `MultiSceneParam<T>`

Multi scene parameter - custom type with &gt;1 parameters.  Example: Level_Type1_1, Level_TypeN_N, etc.
```csharp
public struct UDBase.Controllers.SceneSystem.MultiSceneParam<T>
    : ISceneInfo

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Name |  | 
| `String[]` | Params |  | 
| `String` | Type |  | 


## `Scene_Loaded`

Event which fired when scene was changed
```csharp
public struct UDBase.Controllers.SceneSystem.Scene_Loaded

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `ISceneInfo` | SceneInfo |  | 


## `SceneInfo`

Scene info factory
```csharp
public static class UDBase.Controllers.SceneSystem.SceneInfo

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `ISceneInfo` | Get(`T` type) |  | 
| `ISceneInfo` | Get(`T` type, `String` param) |  | 
| `ISceneInfo` | Get(`T` type, `String[]` param) |  | 


## `SceneName`

Basic scene info - requires only name.  Example: MainMenu, Settings, etc.
```csharp
public struct UDBase.Controllers.SceneSystem.SceneName
    : ISceneInfo

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Name |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | ToString() |  | 


## `SceneParam<T>`

Specific info - custom type and (optional) parameter.  Example: Level_1, Level_N, etc.
```csharp
public struct UDBase.Controllers.SceneSystem.SceneParam<T>
    : ISceneInfo

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Name |  | 
| `String` | Param |  | 
| `String` | Type |  | 


