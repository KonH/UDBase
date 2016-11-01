# Log

Controller for logging anything to console using custom tags (some integer) and default Unity **LogType**.
 
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
