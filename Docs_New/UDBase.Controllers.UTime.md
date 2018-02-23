## `ITime`

ITime is a simple interface to retrieve time from defined sources
```csharp
public interface UDBase.Controllers.UTime.ITime

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `DateTime` | CurrentTime | Current time | 
| `Boolean` | IsAvailable | Is time already available? | 
| `Boolean` | IsFailed | Is time failed to retrieve? | 


## `LocalTime`

Local time wrapper
```csharp
public class UDBase.Controllers.UTime.LocalTime
    : ITime

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `DateTime` | CurrentTime |  | 
| `Boolean` | IsAvailable |  | 
| `Boolean` | IsFailed |  | 


## `NetworkTime`

Time controller uses remote server.  Supported response format: "2016-12-25T14:12:33+00:00"  Reference implementation is here: https://github.com/KonH/DotNetCoreTimeServer
```csharp
public class UDBase.Controllers.UTime.NetworkTime
    : ILogContext, ITime

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `DateTime` | CurrentTime |  | 
| `Boolean` | IsAvailable |  | 
| `Boolean` | IsFailed |  | 


