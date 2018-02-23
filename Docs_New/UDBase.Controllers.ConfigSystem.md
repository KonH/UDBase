## `Config`

Common classes for IConfig
```csharp
public class UDBase.Controllers.ConfigSystem.Config

```

## `FsJsonResourcesConfig`

Config controller, which uses JSON file serialization via Fullserializer
```csharp
public class UDBase.Controllers.ConfigSystem.FsJsonResourcesConfig
    : ILogContext, IConfig

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `T` | GetNode() |  | 


## `IConfig`

Using IConfig you can simple load data for your classes.  You need to define class inherited from IConfigSource and add it to settings, after it you can read data, defined in it.  One node per type is allowed.
```csharp
public interface UDBase.Controllers.ConfigSystem.IConfig

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `T` | GetNode() |  | 


## `IConfigSource`

Basic interface for config node.  Used only for ClassTypeReference filtering.
```csharp
public interface UDBase.Controllers.ConfigSystem.IConfigSource

```

