## `ButtonPosition`

Debug button position
```csharp
public enum UDBase.Controllers.LogSystem.ButtonPosition
    : Enum, IComparable, IConvertible, IFormattable

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | LeftTop |  | 
| `1` | RightTop |  | 
| `2` | LeftBottom |  | 
| `3` | RightBottom |  | 


## `CommonLogSettings`

Common log settings
```csharp
public class UDBase.Controllers.LogSystem.CommonLogSettings

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | EnabledByDefault | Is logging for all contexts enabled by default? | 
| `List<LogNode>` | Nodes | The contexts with specific enabled state | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | IsContextEnabled(`ILogContext` context) |  | 


## `EmptyLog`

Logger without any output for cases when you don't need any logs
```csharp
public class UDBase.Controllers.LogSystem.EmptyLog
    : ILog

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Assert(`ILogContext` context, `String` msg) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `Object[]` args) |  | 
| `void` | Error(`ILogContext` context, `String` msg) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `Object[]` args) |  | 
| `void` | Exception(`ILogContext` context, `String` msg) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `Object[]` args) |  | 
| `void` | Message(`ILogContext` context, `String` msg) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `Object[]` args) |  | 
| `void` | Warning(`ILogContext` context, `String` msg) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `Object[]` args) |  | 


## `ILog`

Log interface without additional allocation when less then 5 parameters is used.  To use ILog you need to use ILogContext object, which specify area of logging and allow you to filter logs at runtime.  Notes:  All these boilerplate is required to avoid additional allocation for params usage.  Generics is required to avoid boxing in valye type cases.
```csharp
public interface UDBase.Controllers.LogSystem.ILog

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Assert(`ILogContext` context, `String` msg) | Log assert with given context | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1) | Log assert with given context | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) | Log assert with given context | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) | Log assert with given context | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) | Log assert with given context | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) | Log assert with given context | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `Object[]` args) | Log assert with given context | 
| `void` | Error(`ILogContext` context, `String` msg) | Log error with given context | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1) | Log error with given context | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) | Log error with given context | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) | Log error with given context | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) | Log error with given context | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) | Log error with given context | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `Object[]` args) | Log error with given context | 
| `void` | Exception(`ILogContext` context, `String` msg) | Log exception with given context | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1) | Log exception with given context | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) | Log exception with given context | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) | Log exception with given context | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) | Log exception with given context | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) | Log exception with given context | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `Object[]` args) | Log exception with given context | 
| `void` | Message(`ILogContext` context, `String` msg) | Log message with given context | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1) | Log message with given context | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) | Log message with given context | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) | Log message with given context | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) | Log message with given context | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) | Log message with given context | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `Object[]` args) | Log message with given context | 
| `void` | Warning(`ILogContext` context, `String` msg) | Log warning with given context | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1) | Log warning with given context | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) | Log warning with given context | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) | Log warning with given context | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) | Log warning with given context | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) | Log warning with given context | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `Object[]` args) | Log warning with given context | 


## `ILogContext`

Interface to use ILog methods.  If you need logs for specific class, you can simply derive from it.  If you need some common context or required logs in static methods, you can use static class instance for it.  This interface is required only for ClassTypeReference filtering.
```csharp
public interface UDBase.Controllers.LogSystem.ILogContext

```

## `LogNode`

Node, which defined, need to show logs for specific context or not
```csharp
public class UDBase.Controllers.LogSystem.LogNode

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `ClassTypeReference` | Context | Current log context | 
| `Boolean` | Enabled | Is logs enabled for current context? | 


## `UnityLog`

Logger using default UnityLogger.
```csharp
public class UDBase.Controllers.LogSystem.UnityLog
    : ILog

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Assert(`ILogContext` context, `String` msg) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `Object[]` args) |  | 
| `void` | Error(`ILogContext` context, `String` msg) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `Object[]` args) |  | 
| `void` | Exception(`ILogContext` context, `String` msg) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `Object[]` args) |  | 
| `void` | Message(`ILogContext` context, `String` msg) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `Object[]` args) |  | 
| `void` | Warning(`ILogContext` context, `String` msg) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `Object[]` args) |  | 


## `VisualLog`

Logger using VisualLogHandler to display overlay on additional Canvas
```csharp
public class UDBase.Controllers.LogSystem.VisualLog
    : ILog

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Assert(`ILogContext` context, `String` msg) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) |  | 
| `void` | AssertFormat(`ILogContext` context, `String` msg, `Object[]` args) |  | 
| `void` | Error(`ILogContext` context, `String` msg) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) |  | 
| `void` | ErrorFormat(`ILogContext` context, `String` msg, `Object[]` args) |  | 
| `void` | Exception(`ILogContext` context, `String` msg) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) |  | 
| `void` | ExceptionFormat(`ILogContext` context, `String` msg, `Object[]` args) |  | 
| `void` | Message(`LogType` type, `ILogContext` context, `String` msg) |  | 
| `void` | Message(`ILogContext` context, `String` msg) |  | 
| `void` | MessageFormat(`LogType` type, `ILogContext` context, `String` msg, `T1` arg1) |  | 
| `void` | MessageFormat(`LogType` type, `ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) |  | 
| `void` | MessageFormat(`LogType` type, `ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) |  | 
| `void` | MessageFormat(`LogType` type, `ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) |  | 
| `void` | MessageFormat(`LogType` type, `ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) |  | 
| `void` | MessageFormat(`LogType` type, `ILogContext` context, `String` msg, `Object[]` args) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) |  | 
| `void` | MessageFormat(`ILogContext` context, `String` msg, `Object[]` args) |  | 
| `void` | Warning(`ILogContext` context, `String` msg) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `T1` arg1, `T2` arg2, `T3` arg3, `T4` arg4, `T5` arg5) |  | 
| `void` | WarningFormat(`ILogContext` context, `String` msg, `Object[]` args) |  | 


