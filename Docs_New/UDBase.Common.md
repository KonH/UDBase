## `BuildType`

Information defining the execution context for further use in conditial binding
```csharp
public class UDBase.Common.BuildType

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | IsEditor | Equals to Application.isEditor, but can be overriden | 
| `RuntimePlatform` | Platform | Equals to Application.platform, but can be overriden | 
| `String` | Type | What build type is it? (e.g. "DEV", "PROD" etc.) | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Is(`String` buildType) | Return true, if it is given buildType | 
| `String` | ToString() |  | 


