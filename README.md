# UDBase

Repository link: [https://github.com/KonH/UDBase](https://github.com/KonH/UDBase)

DevBlog: [http://konhit.blogspot.ru/] (http://konhit.blogspot.ru/)

## Overview
*TODO*

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

### Config

You can simple load settings for your controllers or other classes via **Config** methods. It allows you to get any class instance (inherited from **IJsonNode** interface) from some storage. By default Unity's JsonUtility is used (you can read about it [here](https://docs.unity3d.com/ScriptReference/JsonUtility.html)), so your class needs to be correctly deserialized with it.

By default **Resources/config.json** file is used, but you can specify custom filename for it with this code in your Scheme constructor:

```
/* path - filename without extension */
AddController(new Config(), new JsonResourcesConfig(path));
```

Simple class for config with one string value:

	class ConcreteStateExampleConfig:IJsonNode {
		public string Name { get { return "example_node"; } }
		public string Value = "";
	}

And basic controller to get and use this data:

```
public class ConcreteStateExample : IStateExample {
	/* ... */
	
	ConcreteStateExampleConfig _config = null;

	public string GetConfigData()
	{
		_config = Config.GetNode<ConcreteStateExampleConfig>();
		if( _config != null ) {
			return _config.Value;
		}
		return "";
	}
}
```


### Save

Using **Save** methods you can load and save runtime specific data (any class inherited from **IJsonNode**). Currently it is used JsonUtility and store file(s) in *Application.persistantDataPath*. Way to use is a simillar with Config controller. 

By default, **save.json** file is used, but you can specify custom filename for it with this code in your Scheme constructor:

```
/* path - filename with extension */
AddController(new Save(), new JsonDataSave(path));
```

And also you can change **prettyJson** value, what defines how your json string is saved (small or human-readable):

```
AddController(new Save(), new JsonDataSave(prettyJson));
/* or */
AddController(new Save(), new JsonDataSave(prettyJson, path));
```

Simple class for save with one int value:

	class ConcreteStateExampleSave:IJsonNode {
		public string Name { get { return "save_node"; } }
		public int IntValue = 0;
	}

And basic controller to get and modify this data:

```
public class ConcreteStateExample : IStateExample {
	/*...*/
	
	ConcreteStateExampleSave   _save   = null;

	public int GetSavedData()
	{
		_save = Save.GetNode<ConcreteStateExampleSave>();
		if( _save != null ) {
			return _save.IntValue;
		}
		return -1;
	}

	public void SetSavedData(int value) {
		if( _save == null ) {
			_save = new ConcreteStateExampleSave();
		}
		_save.IntValue = value;
		Save.SaveNode(_save);
	}
}
```

Best practice in implementation your inner controller state is a declaration private nested class for it and control all changes via this controller methods.

### Log

controller for logging anything to console using custom tags (some integer) and default Unity **LogType**.
 
Supported log handlers: 

- **UnityLog** - Debug.Log wrapper for editor;
- **VisualLog** - in-game visual logger with filter by LogType and tags, colorized logs by LogType, can be cleared at run-time; 
 
If you want to add your own tags, you need to inherit from **LogTags** class, declare tags using constants and override two methods:

```
public class CustomLogTags : LogTags {

	public const int CustomTag = 101;

	public override string GetName(int index)
	{
		switch( index ) {
			case CustomTag: 
				return "CustomTag";
		}
		return base.GetName(index);
	}

	public override string[] GetNames()
	{
		var originalNames = base.GetNames();
		var fullNames = new string[originalNames.Length + 1];
		for( int i = 0; i < originalNames.Length; i++ ) {
			fullNames[i] = originalNames[i];
		}
		fullNames[fullNames.Length - 1] = "CustomTag";
		return fullNames;
	}
}
```

Also, you need to use this class in VisualLog constructor:

```
new VisualLog(new CustomLogTags())
``` 

After that you can log your messages with custom tag:

```
Log.Error("Some Error: ...", CustomLogTags.CustomTag);
```

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
