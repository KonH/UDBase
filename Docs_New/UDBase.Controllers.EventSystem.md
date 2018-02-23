## `EventController`

Default event controller
```csharp
public class UDBase.Controllers.EventSystem.EventController
    : ILogContext, IEvent

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Fire(`T` arg) |  | 
| `Dictionary<Type, List<Object>>` | GetHandlers() | Gets the handlers for further use in EventWindow | 
| `void` | Subscribe(`Object` handler, `Action<T>` callback) |  | 
| `void` | Unsubscribe(`Action<T>` action) |  | 


## `IEvent`

IEvent is a lightweight event system, based on System.Action.  It does not use UnityEvent or native C# event/delegate way.  You can use both class and struct as event object.  For prevent leak issues you need to unsubscribe from events when you doesn't need them, e.g. in OnDisable/OnDestroy.  Unsubscribing is required for custom classes, for MonoBehaviour classes it recommended,  because before each event firing watchers checked for destroyed scripts and remove it (but if event is rare it may not happen).
```csharp
public interface UDBase.Controllers.EventSystem.IEvent

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Fire(`T` arg) |  | 
| `void` | Subscribe(`Object` handler, `Action<T>` callback) |  | 
| `void` | Unsubscribe(`Action<T>` callback) |  | 


