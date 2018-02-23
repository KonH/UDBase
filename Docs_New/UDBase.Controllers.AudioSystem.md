## `Audio`

Default values of audio settings
```csharp
public static class UDBase.Controllers.AudioSystem.Audio

```

Static Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | DefaultMusicChannelName | Channel name for music | 
| `String` | DefaultMusicChannelVolume | Exposed volume parameter for music channel | 
| `String` | DefaultSoundChannelName | Channel name for sound | 
| `String` | DefaultSoundChannelVolume | Exposed volume parameter for sound channel | 


## `AudioController`

AudioController changes volume and mute settings within current session
```csharp
public class UDBase.Controllers.AudioSystem.AudioController
    : ILogContext, IAudio, IInitializable

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Single` | GetChannelVolume(`String` channelParam) |  | 
| `AudioMixerGroup` | GetMixerGroup(`String` channelName) |  | 
| `void` | Initialize() | Initialize this instance is required because channels can't be set correctly in constructor  (Unity audio mixer initialization specific) | 
| `Boolean` | IsChannelMuted(`String` channelParam) |  | 
| `void` | MuteChannel(`String` channelParam) |  | 
| `void` | SetChannelVolume(`String` channelParam, `Single` normalizedVolume) |  | 
| `void` | ToggleChannel(`String` channelParam) |  | 
| `void` | UnMuteChannel(`String` channelParam) |  | 


## `AudioSaveNode`

Audio save node, used for save audio settings using SaveAudioController
```csharp
public class UDBase.Controllers.AudioSystem.AudioSaveNode
    : ISaveSource

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Dictionary<String, ChannelNode>` | Channels | Gets or sets the controlled channel settings | 


## `ChannelNode`

Channel node.
```csharp
public class UDBase.Controllers.AudioSystem.ChannelNode

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | IsMuted | Gets or sets a value indicating whether this node is muted | 
| `Single` | Volume | Gets or sets the volume of this node | 


## `ChannelSettings`

Audio channel inspector setup
```csharp
public class UDBase.Controllers.AudioSystem.ChannelSettings

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | ChannelName | Current channel name in given context | 
| `String` | ChannelParam | Current volume parameter in given context | 


## `IAudio`

IAudio uses AudioMixers to control channel volumes and have ability to mute it with previous volume saving.  For get it to work, you need AudioMixer with channels (channelName) and exposed volume parameters (channelParam).
```csharp
public interface UDBase.Controllers.AudioSystem.IAudio

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Single` | GetChannelVolume(`String` channelParam) | Get the channel volume via given channel parameter | 
| `AudioMixerGroup` | GetMixerGroup(`String` channelName) | Gets the mixer group by given channel name | 
| `Boolean` | IsChannelMuted(`String` channelParam) | Is the channel muted via given channel parameter? | 
| `void` | MuteChannel(`String` channelParam) | Mutes the channel via given channel parameter | 
| `void` | SetChannelVolume(`String` channelParam, `Single` normalizedVolume) | Changes volume of given channel parameter | 
| `void` | ToggleChannel(`String` channelParam) | Mutes the channel if it isn't yet muted (and opposite) via given channel parameter | 
| `void` | UnMuteChannel(`String` channelParam) | Unmutes the channel via given channel parameter | 


## `SaveAudioController`

SaveAudioController is AudioController decorator for saving volume and mute parameters between sessions using ISave
```csharp
public class UDBase.Controllers.AudioSystem.SaveAudioController
    : IAudio, IInitializable

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Single` | GetChannelVolume(`String` channelParam) |  | 
| `AudioMixerGroup` | GetMixerGroup(`String` channelName) |  | 
| `void` | Initialize() | Initialize this instance is required because channels can't be set correctly in constructor  (Unity audio mixer initialization specific) | 
| `Boolean` | IsChannelMuted(`String` channelParam) |  | 
| `void` | MuteChannel(`String` channelParam) |  | 
| `void` | SetChannelVolume(`String` channelParam, `Single` normalizedVolume) |  | 
| `void` | ToggleChannel(`String` channelParam) |  | 
| `void` | UnMuteChannel(`String` channelParam) |  | 


## `VolumeChangeEvent`

Event, which fired when volume of specific channel was changed
```csharp
public struct UDBase.Controllers.AudioSystem.VolumeChangeEvent

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Channel |  | 
| `Single` | Volume |  | 


