[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.txt)[![GitHub (pre-)release](https://img.shields.io/github/release/konh/udbase/all.svg)](https://github.com/KonH/UDBase/releases)

# UDBase 

**Current version:** 0.13.0

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

## Basics

UDBase is uses **Zenject** in the core, you need to use it to reach controller functionality.

1. Firstly, creates **ProjectContext** in your Resources directory
2. Creates your installer class(es), then adds adn assign it on ProjectContext
3. You can inherit from **UDBaseInstaller** to bind controllers in easy way using Add* methods 
4. If you need conditional binding (e.g. some controller implementation depends on environment), creates **BuildTypeInstaller** (Create/UDBase/BuildTypeSettings) and assign it on your ProjectContext
5. If you need to use UI system, place custom scene context from UDBase/Prefabs/UDBSceneContext
6. Otherwise, use default scene context
7. In your installer class(es) adds required controllers
8. Implement your logics based on Zenject DI features
9. ...
8. PROFIT 

## How to use controllers

When you use Add* methods in **UDBaseInstaller**, method signature indicates required dependencies, so you can simply creates it from where you want. For example, all 'settings' arguments can be exposed as fields of your installer and serialized in Unity-friendly way.

Almost all controllers requires **ILog**, so you need to add it before adding these controllers. You can use EmptyLog when you do not need any logs, it is not affect performance (if you use it properly and do not make string concatenations in your log calls or something like that).

In other cases, Zenject asserts show you what hidden dependencies is required and must me added using Add* methods.  

## Built-in Controllers

- **[Scene](https://github.com/KonH/UDBase/wiki/UDBase.Controllers.SceneSystem)** (load scenes)
- **[Config](https://github.com/KonH/UDBase/wiki/UDBase.Controllers.ConfigSystem)** (load permanent configuration, json)
- **[Save](https://github.com/KonH/UDBase/wiki/UDBase.Controllers.SaveSystem)** (load and save user data, json)
- **[Log](https://github.com/KonH/UDBase/wiki/UDBase.Controllers.LogSystem)** (custom logging with visual logger)
- **[Event](https://github.com/KonH/UDBase/wiki/UDBase.Controllers.EventSystem)** (lightweight event manager)
- **[Content](https://github.com/KonH/UDBase/wiki/UDBase.Controllers.ContentSystem)** (content loading system using direct load and AssetBundles)
- **[UTime](https://github.com/KonH/UDBase/wiki/UDBase.Controllers.UTime)** (local/network time controller)
- **[UI](Docs/https://github.com/KonH/UDBase/wiki/UDBase.UI.Common)** (UI system)
- **[User](https://github.com/KonH/UDBase/wiki/UDBase.Controllers.UserSystem)** (User system)
- **[Leaderboard](https://github.com/KonH/UDBase/wiki/UDBase.Controllers.LeaderboardSystem)** (Leaderboard system)
- **[Audio](https://github.com/KonH/UDBase/wiki/UDBase.Controllers.AudioSystem)** (Audio system)
- **[Sound](https://github.com/KonH/UDBase/wiki/UDBase.Controllers.SoundSystem)** (Sound playing system)
- **[Music](https://github.com/KonH/UDBase/wiki/UDBase.Controllers.MusicSystem)** (Music playing system for scenes)
- **[Localization](https://github.com/KonH/UDBase/wiki/UDBase.Controllers.LocalizationSystem)** (localization)
- **[Analytics](https://github.com/KonH/UDBase/wiki/UDBase.Controllers.AnalyticsSystem)** (analytics)


## Extensions
- [Zenject](https://github.com/modesttree/Zenject) - DI-container
- [Full Serializer](https://github.com/jacobdufault/fullserializer) - JSON serializer, used for default **Config**/**Save** implementation
- [AssetBundleManager](https://bitbucket.org/Unity-Technologies/assetbundledemo) - asset bundle manager for **Content** controller
- [ObjectPool](https://github.com/UnityPatterns/ObjectPool) - pooling script to prevent garbage generation and performance hiccups while create and recycle objects
- [DOTween](http://dotween.demigiant.com/) - tweening library
- [ClassTypeReference](https://github.com/rotorz/unity3d-class-type-reference) - helper to serialize types
- [OneLine](https://github.com/slavniyteo/one-line) - editor helper to draw simple one-line inspectors

## Common Utils
- [Utils](https://github.com/KonH/UDBase/wiki/UDBase.Utils) - set of useful IO, network, text and etc. utilily classes; 


## Helpers & Editor Tools

- [Helpers](https://github.com/KonH/UDBase/wiki/UDBase.Helpers) - docs about helper tools and common features;

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
