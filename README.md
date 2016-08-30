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
### Components
All logics in UDBase separated by components that provide abstract interface to specific features. Components can be replaced in one place without any changes to other code. You can make your own components, that implements your logics (based on existing or completely new interface). 

**How to use:**

Declare your component interface (based on IComponent):

```
public interface ITest : IComponent {
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

### Component helpers
You can call any component logics using helpers that provide static methods which hide concrete component instance.

**How to use:**
 
Create helper class used ComponentHelper with your component interface:

```
public class Test : ComponentHelper<ITest> {
}
```

And declare methods to cover your component logics:

```
public class Test : ComponentHelper<ITest> {
		public static int MyMethod() {
			if(Instance != null) {
				return Instance.MyMethod();
			}
			return 0;
		}
}
```


### Schemes
Using schemes you can easily switch components or disable it. It based on scripting define symbols and doesn't cause runtime overhead.

**How to use:**

Open **UDBase/Schemes/Edit** in menu

Click **Add new scheme** and write it name (DesktopScheme, for example)

Open generated file **UDBase_Project/Schemes/DesktopScheme.cs** and define its behavior:

```
public class DesktopScheme : Scheme {
	public DesktopScheme() {
		AddComponent(new Test(), new TestOne());
	}
}
```

In example above, on that scheme any calls to **Test.MyMethod()** will be redirected to **TestOne** instance.

Now you can switch to your scheme using **Switch** in Schemes window or just appropriate menu item in **UDBase/Schemes/**.

## Built-in Components

### Config

You can simple load settings for you components or other classes via **Config** methods. It allow you to get any class instance (inherited from TODO) from some storage. By default Unity's JsonUtility is used (you can read about it here TODO), so you class need to correctly deserialized with it.

TODO: Examples

### Save

Using **Save** methods you can load and save runtime specific data (). Currently it is used JsonUtility and store file(s) in *Application.persistantDataPath*.

TODO: Examples

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

Any block must contains header (allow you to get and save block data via code) and body in json format.
Empty line between blocks is required.

## Examples
Example project - [https://github.com/KonH/UDBaseExample](https://github.com/KonH/UDBaseExample)

## License
See **LICENSE.txt** beside.
