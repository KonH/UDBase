# Config

You can simple load settings for your controllers or other classes via **Config** methods. It allows you to get any class instance or list item from some storage. For json deserialization used FullSerializer.

By default **Resources/config.json** file is used, but you can specify custom filename for it with this code in your Scheme constructor:

```
/* path - filename without extension */
var config = new JsonResourcesConfig(path);
AddController(new Config(), config);
```

Simple class for config with one string value:

```
	class ConcreteStateExampleConfig {
		[fsProperty("value")]
		public string Value = "";
	}
```

**fsProperty** attribute is not mandatory, it can be used to define property name in file.  

For use in **Config** controller, you need to add your class type to it and assign node name:

```
var save = new FsJsonResourcesConfig();
save.AddNode<ConcreteStateExampleConfig>("example_node");
```

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

For this cases your **config.json** needs to look like this:

```
{
	"example_node": // node name
	{
		"value": "some_string" // your instance value
	}
}
```

Also, you can store your custom item lists:

```
config.AddList<CommonItemInfo>("list_node");
```

Config content:

```
{
	"list_node":
	{
		"item_0": { "value": "some_value" },
		"item_1": { "value": "another_value" },
	}
}
```

And item you can get by its name:

```
config.GetItem<CommonItemInfo>("item_0");
```