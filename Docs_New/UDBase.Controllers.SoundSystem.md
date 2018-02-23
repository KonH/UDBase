## `ISound`

ISound is uses Audio for channel settings and provides two ways to work: direct SoundSource and SoundController.  First is used for positional or deep controlled sounds, second for simple 2D sounds(UI, for example).  All ISound methods require Content system is used for store AudioClips.
```csharp
public interface UDBase.Controllers.SoundSystem.ISound

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | EndLoop(`ContentId` sound) | End already started loop (AudioClip inside ContentId) | 
| `void` | Play(`ContentId` sound, `Single` delay = 0, `String` channelName = Sound) | Play the specified sound (AudioClip inside ContentId), with optional delay and channelName | 
| `void` | StartLoop(`ContentId` sound, `Single` delay = 0, `String` channelName = Sound) | Play the specified sound (AudioClip inside ContentId) as loop, with optional delay and channelName | 


## `SoundController`

Default sound controller
```csharp
public class UDBase.Controllers.SoundSystem.SoundController
    : ILogContext, ISound

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | EndLoop(`ContentId` sound) |  | 
| `void` | Play(`ContentId` sound, `Single` delay, `String` channelName) |  | 
| `void` | StartLoop(`ContentId` sound, `Single` delay, `String` channelName) |  | 


## `SoundSource`

AudioSource wrapper to use in ISound
```csharp
public class UDBase.Controllers.SoundSystem.SoundSource
    : MonoBehaviour

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | AutoPlay | Is need to play on start? | 
| `Single` | Delay | Time to wait before playing | 
| `Boolean` | DestroyOnStop | Destroy instance on stop? | 
| `Single` | FadeIn | Time to maximize volume from 0 on start | 
| `Single` | FadeOut | Time to minimize volume to 0 before end | 
| `AudioClipHolder` | Holder | Content holder for current audio clip | 
| `Boolean` | Loop | Is need to play over and over? | 
| `ChannelSettings` | Settings | The settings for the channel to play with | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Init(`IAudio` audio, `List<IContent>` loaders) |  | 
| `void` | Pause() | Pause playing sound | 
| `void` | Play(`Boolean` force = False) | Play the current assigned sound (force is allows to skip Delay) | 
| `void` | Stop() | Stop playing sound | 
| `void` | UnPause() | Resume playing sound | 


## `SoundUtility`

Sound utility for playing sounds with ISound/SoundController
```csharp
public class UDBase.Controllers.SoundSystem.SoundUtility
    : MonoBehaviour

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Init(`IAudio` audio, `Settings` settings) |  | 
| `void` | Play(`String` key, `AudioClip` clip, `Boolean` loop, `Single` delay, `String` channelName) |  | 
| `void` | StopLoop(`String` key) |  | 


