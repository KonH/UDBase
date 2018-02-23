## `ILocaleParser`

```csharp
public interface UDBase.Controllers.LocalizationSystem.ILocaleParser

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | GetValue(`SystemLanguage` language, `String` key) |  | 
| `Boolean` | HasLanguage(`SystemLanguage` language) |  | 


## `ILocalization`

```csharp
public interface UDBase.Controllers.LocalizationSystem.ILocalization

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `SystemLanguage` | CurrentLanguage |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Translate(`String` key) |  | 
| `String` | TranslateFormat(`String` key, `String[]` args) |  | 


## `LanguageChanged`

```csharp
public struct UDBase.Controllers.LocalizationSystem.LanguageChanged

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `SystemLanguage` | NewLanguage |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | ToString() |  | 


## `Localization`

```csharp
public class UDBase.Controllers.LocalizationSystem.Localization
    : ILocalization

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `SystemLanguage` | CurrentLanguage |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `SystemLanguage` | DetectLanguage() |  | 
| `String` | Translate(`String` key) |  | 
| `String` | TranslateFormat(`String` key, `String[]` args) |  | 


## `LocalizationSaveNode`

```csharp
public class UDBase.Controllers.LocalizationSystem.LocalizationSaveNode
    : ISaveSource

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `SystemLanguage` | CurrentLanguage |  | 


## `SaveLocalization`

```csharp
public class UDBase.Controllers.LocalizationSystem.SaveLocalization
    : ILocalization

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `SystemLanguage` | CurrentLanguage |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `SystemLanguage` | DetectLanguage() |  | 
| `String` | Translate(`String` key) |  | 
| `String` | TranslateFormat(`String` key, `String[]` args) |  | 


## `SingleLocaleParser`

```csharp
public class UDBase.Controllers.LocalizationSystem.SingleLocaleParser
    : ILogContext, ILocaleParser

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | GetValue(`SystemLanguage` language, `String` key) |  | 
| `Boolean` | HasLanguage(`SystemLanguage` language) |  | 


