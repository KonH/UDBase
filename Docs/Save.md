# Save

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
