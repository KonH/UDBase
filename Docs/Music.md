# Music

Music is a music playing system.

## Basics

For use it, you need to add to scene where you need music **MusicHolder** with assigned list of **SoundSource**, represented wanted music tracks. 
Also, you need add **MusicController** to your scheme.

## Usage

### MusicController

You need to add controller to your scheme:

```
AddController<Music>(new MusicController());
```

After it, you can call helper methods:

```
Music.Pause();
Music.UnPause();
```

But it is optional, music starts playing on every scene with **MusicHolder**.