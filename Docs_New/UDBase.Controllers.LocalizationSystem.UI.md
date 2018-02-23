## `LocaleText`

Component to localize UnityEngine.UI.Text by given keys and parameters
```csharp
public class UDBase.Controllers.LocalizationSystem.UI.LocaleText
    : MonoBehaviour

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Init(`ILocalization` locale, `IEvent` events) |  | 
| `void` | UpdateArguments(`String[]` arguments) | Change only localization arguments | 
| `void` | UpdateKey(`String` key) | Change only localization key | 
| `void` | UpdateValues(`String` key, `String[]` arguments) | Change both localization key and arguments | 


## `SetLanguageButton`

ActionButton to change current language of ILocalization component
```csharp
public class UDBase.Controllers.LocalizationSystem.UI.SetLanguageButton
    : ActionButton

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `SystemLanguage` | Language |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Init(`ILocalization` localization, `IEvent` events) |  | 
| `Boolean` | IsInteractable() |  | 
| `Boolean` | IsVisible() |  | 
| `void` | OnClick() |  | 


