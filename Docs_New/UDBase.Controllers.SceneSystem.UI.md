## `LoadingView`

Component to show IScene loading progress on UnityEngine.UI.Text (in percent format) and Image (use fill amount)
```csharp
public class UDBase.Controllers.SceneSystem.UI.LoadingView
    : MonoBehaviour

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | PercentDecimals |  | 
| `Text` | PercentText |  | 
| `Image` | ProgressBar |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Init(`AsyncLoadHelper` helper) |  | 


## `SceneLoadButton`

ActionButton to load scene by name via IScene component
```csharp
public class UDBase.Controllers.SceneSystem.UI.SceneLoadButton
    : ActionButton

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Name |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Init(`IScene` scene) |  | 
| `Boolean` | IsInteractable() |  | 
| `Boolean` | IsVisible() |  | 
| `void` | OnClick() |  | 


## `SceneParamLoadButton<T>`

Base ActionButton to load scene by typed parameter via IScene controller
```csharp
public abstract class UDBase.Controllers.SceneSystem.UI.SceneParamLoadButton<T>
    : ActionButton

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Param |  | 
| `T` | Type |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Init(`IScene` scene) |  | 
| `Boolean` | IsInteractable() |  | 
| `Boolean` | IsVisible() |  | 
| `void` | OnClick() |  | 


