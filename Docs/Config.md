# Config

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
