# Sound

Sound is a sound playing system.

## Basics

Sound is used Audio for channel settings and provides two ways to work: direct SoundSource and SoundController.
First is used for positional or deep controlled sounds, second for simple 2D sounds (UI, for example).

## Usage

### SoundSource

**SoundSource** is a AudioSource wrapper, it load clip at runtime by ContentId and used selected channel for play sound.
Also, AutoPlay, Loop, Delay are supported.
Provide methods: Play/Pause/UnPause/Stop.

### SoundController

**SoundController** is used for playing simple 2D sounds.
You need to add controller to your scheme:

```
AddController<Sound>(new SoundController());
```

After it you can call several obvious methods:

```
Sound.Play(soundId, delay, channelName);
Sound.StartLoop(soundId, delay, channelName);
Sound.EndLoop(soundId);
```
