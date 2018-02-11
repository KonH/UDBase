[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.txt)[![GitHub (pre-)release](https://img.shields.io/github/release/konh/udbase/all.svg)](https://github.com/KonH/UDBase/releases)

# UDBase 

**Current version:** 0.11.0

**Unity version:** 2017.3.0f3 (last tested)

Repository link: [https://github.com/KonH/UDBase](https://github.com/KonH/UDBase)

DevBlog: [http://konhit.blogspot.ru/](http://konhit.blogspot.ru/)

## Overview

**UDBase** is module-based game template for [Unity](https://unity3d.com/). Modules in UDBase are called **Controllers**, their implementation can be replaced without changing your project source code. It is Open-Source project with MIT license, so you overview source code, send pull requests, create your own issues and fork the project, if you want.

## Versioning and releases

UDBase is used semantic versioning convention ([http://semver.org/](http://semver.org/)). 

You can overview releases here - [https://github.com/KonH/UDBase/releases](https://github.com/KonH/UDBase/releases).

Release notes in plain text you can find here - [Docs/_ReleaseNotes.txt](Docs/_ReleaseNotes.txt).

## Install

### Using git-submodule
1. First time: 
	1. Add project as git-submodule to your Unity project: `git submodule add git@github.com:KonH/UDBase.git Assets/UDBase`
2. If you clone your project already with submodule:
	1. Initialize submodule: `git submodule init`
	2. Update submodule: `git submodule update`

### Manual
You can download last version here: [https://github.com/KonH/UDBase/archive/master.zip](https://github.com/KonH/UDBase/archive/master.zip)

## Update

### Using git-submodule
Just update submodule: `git submodule update`

### Manual
Also, you can re-install project as described above.

## Deprecation notice
**Documentation below is deprecated and will be rewritten as soon as possible.** New docs will be generated from source-code instead of hand-made documentation. IController/ControllerHelper, Scheme, Inventory no longer supported (now Zenject is used as architecture basics).

## Built-in Controllers

- **[Scene](Docs/Scene.md)** (load scenes)
- **[Config](Docs/Config.md)** (load permanent configuration, json)
- **[Save](Docs/Save.md)** (load and save user data, json)
- **[Log](Docs/Log.md)** (custom logging with visual logger)
- **[Event](Docs/Event.md)** (lightweight event manager)
- **[Content](Docs/Content.md)** (content loading system using direct load and AssetBundles)
- **[UTime](Docs/UTime.md)** (local/network time controller)
- **[UI](Docs/UI.md)** (UI system)
- **[User](Docs/User.md)** (User system)
- **[Leaderboard](Docs/Leaderboard.md)** (Leaderboard system)
- **[Audio](Docs/Audio.md)** (Audio system)
- **[Sound](Docs/Sound.md)** (Sound playing system)
- **[Music](Docs/Music.md)** (Music playing system for scenes)

## Extensions
- [Zenject](https://github.com/modesttree/Zenject) - DI-container
- [Full Serializer](https://github.com/jacobdufault/fullserializer) - JSON serializer, used for default **Config**/**Save** implementation
- [AssetBundleManager](https://bitbucket.org/Unity-Technologies/assetbundledemo) - asset bundle manager for **Content** controller
- [ObjectPool](https://github.com/UnityPatterns/ObjectPool) - pooling script to prevent garbage generation and performance hiccups while create and recycle objects
- [DOTween](http://dotween.demigiant.com/) - tweening library
- [ClassTypeReference](https://github.com/rotorz/unity3d-class-type-reference) - helper to serialize types

## Helpers & Editor Tools

- [Helpers](Docs/Helpers.md) - docs about helper tools and common features;

### CaptureScreen

Using menu items at **UDBase/Screenshots** you can make screenshots (with upscaling resolution) and manage directory to save these screenshots (you can clean or open it).

### AssetUtility

Helper methods to create **ScriptableObject** assets in project, create and remove sub-assets.

## Examples
Example project - [https://github.com/KonH/UDBaseExample](https://github.com/KonH/UDBaseExample)

## Contribution

You can read contribution rules here - [CONTRIBUTING.md](CONTRIBUTING.md).

## License
See **LICENSE.txt** beside.
