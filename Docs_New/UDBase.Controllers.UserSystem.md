## `IUser`

IUser is a simple storage for user information.  If you need to store additinal ids, assigned to current user,  you can get it on your side and add using AddExternalId(),  after it you can get it using FindExternalId()
```csharp
public interface UDBase.Controllers.UserSystem.IUser

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Id | Unique id of user (if required) | 
| `String` | Name | User name to display | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | AddExternalId(`String` provider, `String` id) | Adds the external identifier for given provider | 
| `String` | FindExternalId(`String` provider) | Finds the external identifier for given provider | 


## `SaveUser`

User controller with saving information using ISave
```csharp
public class UDBase.Controllers.UserSystem.SaveUser
    : IUser

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Id |  | 
| `String` | Name |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | AddExternalId(`String` provider, `String` id) |  | 
| `String` | FindExternalId(`String` provider) |  | 


## `User_ExternalIdChange`

Event, which fired when user extenal id was changed
```csharp
public struct UDBase.Controllers.UserSystem.User_ExternalIdChange

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Provider | New provider (or provider with changed id) | 
| `String` | Value | New id | 


## `User_NameChange`

Event, which fired when user name was changed
```csharp
public struct UDBase.Controllers.UserSystem.User_NameChange

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Name | New user name | 


## `UserSaveNode`

Save node for user information
```csharp
public class UDBase.Controllers.UserSystem.UserSaveNode
    : ISaveSource

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Dictionary<String, String>` | ExternalIds |  | 
| `String` | Id |  | 
| `String` | Name |  | 


