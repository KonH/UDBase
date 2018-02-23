## `FsJsonDataSave`

ISave implementation, which used JSON file with FullSerializer.  File with name from settings is saved to Application.persistantDataPath.
```csharp
public class UDBase.Controllers.SaveSystem.FsJsonDataSave
    : ILogContext, ISave

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `T` | GetNode(`Boolean` autoFill) |  | 
| `void` | SaveNode(`T` node) |  | 


## `InMemorySave`

ISave implementation, which doesn't save data between sessions
```csharp
public class UDBase.Controllers.SaveSystem.InMemorySave
    : ISave

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Dictionary<Type, Object>` | _state |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `InMemorySave` | AddNode(`String` name) |  | 
| `T` | GetNode(`Boolean` autoFill) |  | 
| `void` | SaveNode(`T` node) |  | 


## `ISave`

Using ISave methods you can load and save runtime specific data (any custom class derived from ISaveSource).  ISaveSource implementation is required only for ClassTypeReference filtering.  All nodes need to added in controller settings.  You can make inner controller state as private nested class for controller and control all changes via this controller methods.
```csharp
public interface UDBase.Controllers.SaveSystem.ISave

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `T` | GetNode(`Boolean` autoFill = True) |  | 
| `void` | SaveNode(`T` node) |  | 


## `ISaveSource`

Interface for savable items
```csharp
public interface UDBase.Controllers.SaveSystem.ISaveSource

```

## `Save`

```csharp
public static class UDBase.Controllers.SaveSystem.Save

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | OpenDirectory() | Opens the saves directory | 


## `SaveInfoNode`

Save node with information about save itself
```csharp
public class UDBase.Controllers.SaveSystem.SaveInfoNode
    : ISaveSource

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int64` | LocalTime | Last saved local date time | 
| `Int64` | Version | How many times save have been saved | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Update() |  | 


