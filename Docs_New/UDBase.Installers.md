## `BuildTypeInstaller`

Scriptable object UDBase installer for load BuildType from given source before all installers is called
```csharp
public class UDBase.Installers.BuildTypeInstaller
    : ScriptableObjectInstaller, IInstaller

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | FileName |  | 
| `Boolean` | OverrideIsEditor |  | 
| `RuntimePlatform` | OverridePlatform |  | 
| `String` | OverrideType |  | 
| `BuildTypeSource` | Source |  | 
| `String` | Type |  | 
| `Boolean` | UseOverrides |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | InstallBindings() |  | 


## `UDBaseInstaller`

Base UDBase installer with set of helper methods to bind UDBase controllers and helpers
```csharp
public abstract class UDBase.Installers.UDBaseInstaller
    : MonoInstaller, IInstaller

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `BuildType` | _buildType |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | AddAsyncSceneLoader(`Settings` settings) |  | 
| `void` | AddAudio(`Settings` settings) |  | 
| `void` | AddBundleContentLoader(`Settings` settings) |  | 
| `void` | AddDirectContentLoader() |  | 
| `void` | AddDirectSceneLoader() |  | 
| `void` | AddEmptyLogger() |  | 
| `void` | AddEvents() |  | 
| `void` | AddInMemorySave() |  | 
| `void` | AddJsonConfig(`JsonSettings` settings) |  | 
| `void` | AddJsonSave(`JsonSettings` settings) |  | 
| `void` | AddLocalization(`Settings` settings) |  | 
| `void` | AddLocalLeaderboard() |  | 
| `void` | AddLocalTime() |  | 
| `void` | AddMusic() |  | 
| `void` | AddNetUtils() |  | 
| `void` | AddNetworkTime(`Settings` settings) |  | 
| `void` | AddSaveAudio(`Settings` settings) |  | 
| `void` | AddSaveLocalization(`Settings` settings) |  | 
| `void` | AddSaveUser() |  | 
| `void` | AddSingleFileLocalizationParser(`Settings` settings) |  | 
| `void` | AddSound(`Settings` settings) |  | 
| `void` | AddUnityLogger(`Settings` settings) |  | 
| `void` | AddVisualLogger(`Settings` settings) |  | 
| `void` | AddWebLeaderboards(`Settings` settings) |  | 
| `void` | Init(`BuildType` buildType) |  | 


## `UDBaseSceneInstaller`

Installer for UDBase components with scene-based life-cycle
```csharp
public class UDBase.Installers.UDBaseSceneInstaller
    : UDBaseInstaller, IInstaller

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Settings` | UISettings |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | AddUIManager(`Settings` settings) |  | 
| `void` | InstallBindings() |  | 


