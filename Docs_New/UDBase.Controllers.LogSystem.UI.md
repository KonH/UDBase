## `ToggleContainer`

Internal LogSystem.UI component to switch tag/type visibility
```csharp
public class UDBase.Controllers.LogSystem.UI.ToggleContainer
    : MonoBehaviour

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Text` | Text |  | 
| `Toggle` | Toggle |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Init(`Boolean` state, `String` itemName, `Action<String, Boolean>` onValueChangedCallback) |  | 


## `VisualLogHandler`

Component to show ILog messages in visual overlay
```csharp
public class UDBase.Controllers.LogSystem.UI.VisualLogHandler
    : MonoBehaviour

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Button` | ClearButton |  | 
| `Button` | CloseButton |  | 
| `Button` | CloseSettingsButton |  | 
| `String` | CurrentState |  | 
| `GameObject` | EmptyContent |  | 
| `GameObject` | MainContent |  | 
| `Button` | MaximizeButton |  | 
| `Button` | MinimizeButton |  | 
| `Button` | OpenButton |  | 
| `GameObject` | OpenContent |  | 
| `List<ButtonPosHander>` | OpenPositions |  | 
| `Button` | OpenSettingsButton |  | 
| `GameObject` | SettingsContent |  | 
| `ToggleContainer` | TagSample |  | 
| `Text` | Text |  | 
| `GameObject` | TopControlsContent |  | 
| `ToggleContainer` | TypeSample |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | AddMessage(`LogType` type, `ILogContext` context, `String` msg) | Add given message to log handler to display in visual overlay | 
| `void` | Init(`Settings` settings) |  | 


