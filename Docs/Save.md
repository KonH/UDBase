# Save

Using **Save** methods you can load and save runtime specific data (any custom class). Currently it is used FullSerializer and store file(s) in *Application.persistantDataPath*. Way to use is a simillar with Config controller.

By default, **save.json** file is used, but you can specify custom filename for it with this code in your Scheme constructor:

```
/* path - filename with extension */
var save = new FsJsonDataSave(path);
AddController(new Save(), save);
```

And also you can change **prettyJson** value, what defines how your json string is saved (small or human-readable):

```
var save = new FsJsonDataSave(prettyJson);
/* or */
var save = new FsJsonDataSave(prettyJson, path);
```

Simple class for save with one int value:

```
	class ConcreteStateExampleSave {
		[fsProperty("int_value")]
		public int IntValue = 0;
	}
```

**fsProperty** attribute is not mandatory, it can be used to define property name in file.  

For use in **Save** controller, you need to add your class type to it and assign node name:

```
var save = new FsJsonDataSave();
save.AddNode<ConcreteStateExampleSave>("save_node");
```

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
