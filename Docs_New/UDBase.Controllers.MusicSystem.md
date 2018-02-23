## `IMusic`

IMusic is a music playing system.  It doesn't provide methods to play, because by default it controlled by MusicHolder on scene.
```csharp
public interface UDBase.Controllers.MusicSystem.IMusic

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Pause() | Pause current track | 
| `void` | UnPause() | Resume current track | 


## `MusicController`

Default music controller.  For use it, you need to add to scene where you need music MusicHolder with assigned list of SoundSource,  represented wanted music tracks.
```csharp
public class UDBase.Controllers.MusicSystem.MusicController
    : IMusic

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Pause() |  | 
| `void` | UnPause() |  | 


## `MusicHolder`

MusicHolder is a set of music for the scene
```csharp
public class UDBase.Controllers.MusicSystem.MusicHolder
    : MonoBehaviour

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `List<SoundSource>` | Sources | All tracks for scene, on of it selected randomly on scene start | 


## `MusicUtility`

Utility class for playing music
```csharp
public class UDBase.Controllers.MusicSystem.MusicUtility
    : MonoBehaviour

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Pause() |  | 
| `void` | SetupTrack() |  | 
| `void` | StopTrack() |  | 
| `void` | UnPause() |  | 


