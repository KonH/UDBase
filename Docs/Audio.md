# Audio

Audio is a volume control system.

## Basics

Audio uses AudioMixer to control channel volumes and have ability to mute it with previous volume saving.
For get it to work, you need AudioMixer with exposed volume parameters (their names is used as channel names in next methods).

## Usage

### AudioController

**AudioController** changes volume and mute settings within current session.
You need to add controller to your scheme:

```
AddController<Audio>(new SaveAudioController(
	"AudioMixer", channels: new string[] {"SoundVolume", "MusicVolume"}, initialVolume: 0.5f));
```

**channels** is optional, but is required to correctly set **initialVolume** for it.

After it, you can change channel volume:

```
Audio.SetChannelVolume("ChannelName", 0.5f);
```

Or mute it:

```
Audio.MuteChannel("ChannelName");
Audio.UnMuteChannel("ChannelName"); // volume set back to previous unmuted value
Audio.ToggleChannel("ChannelName"); // toggle set reversed mute state
```

Also, you can use helpers for default channels:

```
Audio.SetMusicVolume(0.5f);
Audio.MuteMusic();
Audio.UnMuteMusic();
Audio.ToggleMusic();
```

Or like this:

```
Audio.SetChannelVolume(Audio.Default_Music_Channel_Volume, 0.5f);
```


### SaveAudioController

**SaveAudioController** is AudioController decorator for saving volume and mute parameters between sessions.
First, you need to add save item:

```
var save = 
	new FsJsonDataSave(true, true).
	AddNode<AudioSaveNode>("audio");
```

And initialize controller as before:

```
AddController<Audio>(new SaveAudioController("AudioMixer", saveDelta: 0.1f));
```

## UI

### AudioToggleButton

**AudioToggleButton** is used for mute channels and display its mute state for concrete channel (default or custom).

### AudioSlider

**AudioSlider** is used for flexible volume control for concrete channel (default or custom).
