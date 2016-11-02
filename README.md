# UDBase 

**Current version:** 0.1.0

**Unity version:** 5.4.0f3 (last tested)

Repository link: [https://github.com/KonH/UDBase](https://github.com/KonH/UDBase)

DevBlog: [http://konhit.blogspot.ru/](http://konhit.blogspot.ru/)

## Overview

**UDBase** is module-based game template for [Unity](https://unity3d.com/). Modules in UDBase are called **Controllers**, their implementation can be replaced without changing your project source code. Configuration is stored and modified based on custom classes called **Schemes**, that used scripting define symbols and can be switched in one click. It is Open-Source project with MIT license, so you overview source code, send pull requests, create your own issues and fork the project, if you want.

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
3. Execute **UDBase/Setup** in menu to make default user project structure

### Manual
You can download last version here: [https://github.com/KonH/UDBase/archive/master.zip](https://github.com/KonH/UDBase/archive/master.zip)

## Update

### Using git-submodule
Just update submodule: `git submodule update`

### Manual
Also, you can re-install project as described above.

## Features
### Controllers
All logics in UDBase separated by controllers that provide abstract interface to specific features. controllers can be replaced in one place without any changes to other code. You can make your own controllers, that implements your logics (based on existing or completely new interface). 

**How to use:**

Declare your controller interface (based on IController):

```
public interface ITest : IController {
	// Your logics here
	int MyMethod();
}
```

Make classes that implements your interface:

```
public class TestOne: ITest {
	public int MyMethod() {
		return -1;
	}
}
```
```
public class TestTwo: ITest {
	public int MyMethod() {
		return 42;
	}
}
```

### Controller helpers
You can call any controller logics using helpers that provide static methods which hide concrete controller instance.

**How to use:**
 
Create helper class used ControllerHelper with your controller interface:

```
public class Test : ControllerHelper<ITest> {
}
```

And declare methods to cover your controller logics:

```
public class Test : ControllerHelper<ITest> {
		public static int MyMethod() {
			if(Instance != null) {
				return Instance.MyMethod();
			}
			return 0;
		}
}
```


### Schemes
Using schemes you can easily switch controllers or disable it. It based on scripting define symbols and doesn't cause runtime overhead.

**How to use:**

Open **UDBase/Schemes/Edit** in menu

Click **Add new scheme** and write it name (DesktopScheme, for example)

Open generated file **UDBase_Project/Schemes/DesktopScheme.cs** and define its behavior:

```
public class DesktopScheme : Scheme {
	public DesktopScheme() {
		AddController(new Test(), new TestOne());
	}
}
```

In the example above, on this scheme any calls to **Test.MyMethod()** will be redirected to **TestOne** instance.

Now you can switch to your scheme using **Switch** in Schemes window or just appropriate menu item in **UDBase/Schemes/**.

## Built-in Controllers

- **[Scene](Docs/Scene.md)** (load scenes)
- **[Config](Docs/Config.md)** (load permanent configuration, json)
- **[Save](Docs/Save.md)** (load and save user data, json)
- **[Log](Docs/Log.md)** (custom logging with visual logger)

## Notes

### Config/Save Json

Configs and saves stored not in pure Json format (because of limitation of Unity's JsonUtility). Format is simple:

```
header0
{regular json-body}

header1
{...}

etc...
```

Any block must contain header (allows you to get and save block data via code) and body in json format.
Empty line between blocks is required.

## Editor Tools

### CaptureScreen

Using menu items at **UDBase/Screenshots** you can make screenshots (with upscaling resolution) and manage directory to save these screenshots (you can clean or open it).

## Examples
Example project - [https://github.com/KonH/UDBaseExample](https://github.com/KonH/UDBaseExample)

## License
See **LICENSE.txt** beside.
