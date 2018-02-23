## `IOTool`

Input/output helpers
```csharp
public static class UDBase.Utils.IOTool

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | CopyFile(`String` originPath, `String` destinationPath, `Boolean` silent = False) | Exception-safe helper for File.Copy (silent = 'no log output') | 
| `Boolean` | CreateDirectory(`String` path, `Boolean` silent = False) | Exception-safe helper for Directory.CreateDirectory (silent = 'no log output') | 
| `Boolean` | CreateFile(`String` path, `Boolean` silent = False) | Exception-safe helper for File.Create (silent = 'no log output') | 
| `Boolean` | DeleteDirectory(`String` path, `Boolean` recursive, `Boolean` silent = False) | Exception-safe helper for Directory.Delete (silent = 'no log output') | 
| `Boolean` | DeleteFile(`String` path, `Boolean` silent = False) | Exception-safe helper for File.Delete (silent = 'no log output') | 
| `FileInfo[]` | GetDirFiles(`String` path, `String` searchPattern, `Boolean` silent = False) | Exception-safe helper for new DirectoryInfo().GetFiles(); (silent = 'no log output') | 
| `Boolean` | Open(`String` path, `Boolean` silent = False) | Exception-safe helper for open file/directory (silent = 'no log output') | 
| `String[]` | ReadAllLines(`String` path, `Boolean` silent = False) | Exception-safe helper for File.ReadAllLines (silent = 'no log output') | 
| `String` | ReadAllText(`String` path, `Boolean` silent = False) | Exception-safe helper for File.ReadAllText (silent = 'no log output') | 
| `void` | WriteAllLines(`String` path, `IEnumerable<String>` contents, `Boolean` silent = False) | Exception-safe helper for File.WriteAllLines (silent = 'no log output') | 
| `void` | WriteAllText(`String` path, `String` contents, `Boolean` silent = False) | Exception-safe helper for File.WriteAllText (silent = 'no log output') | 


## `NetUtils`

```csharp
public class UDBase.Utils.NetUtils
    : MonoBehaviour, ILogContext

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | AddHeader(`UnityWebRequest` request, `String` name, `String` value) |  | 
| `void` | AddHeaders(`UnityWebRequest` request, `Dictionary<String, String>` headers) |  | 
| `String` | CreateBasicAuthorization(`String` userName, `String` userPassword) |  | 
| `void` | SendDeleteRequest(`String` url, `Single` timeout = 10, `Dictionary<String, String>` headers = null, `Action<Response>` onComplete = null) |  | 
| `void` | SendGetRequest(`String` url, `Single` timeout = 10, `Dictionary<String, String>` headers = null, `Action<Response>` onComplete = null) |  | 
| `void` | SendJsonPostRequest(`String` url, `String` data, `Single` timeout = 10, `Dictionary<String, String>` headers = null, `Action<Response>` onComplete = null) |  | 
| `void` | SendPostRequest(`String` url, `String` data, `Single` timeout = 10, `Dictionary<String, String>` headers = null, `Action<Response>` onComplete = null) |  | 
| `void` | SendRequest(`UnityWebRequest` request, `Single` timeout = 10, `Dictionary<String, String>` headers = null, `Action<Response>` onComplete = null) |  | 


Static Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Single` | DefaultTimeout |  | 


## `PlayerPrefsUtils`

Helper methods for PlayerPrefs usage
```csharp
public static class UDBase.Utils.PlayerPrefsUtils

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | GetBool(`String` key, `Boolean` defaultValue) | Get boolean value in int representation (1 = true, 0 = false) | 
| `void` | SetBool(`String` key, `Boolean` value, `Boolean` save = True) | Set boolean value in int representation (1 = true, 0 = false) | 


## `RandomUtils`

Set of random helper methods
```csharp
public static class UDBase.Utils.RandomUtils

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `T` | GetEnumValue() |  | 
| `T` | GetItem(`List<T>` items) |  | 
| `T` | GetItem(`T[]` items) |  | 
| `Int32` | RangeExcluded(`Int32` min, `Int32` max, `Int32[]` exclusions) | Returns random value in [min, max] interval without exclusion items  Throws InvalidOperationException when all items is excluded | 


## `TextUtils`

Utils for text processing
```csharp
public static class UDBase.Utils.TextUtils

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | EnsureString(`String` value) | Returns given value or non-null empty string if value is null | 
| `Boolean` | EqualsIgnoreWhitespaces(`String` leftStr, `String` rightStr, `StringComparison` comparison = Ordinal) | Check given strings is equals without all white-spaces and control chars inside | 
| `String` | RemoveWhitespaces(`String` str) | Remove all white-spaces and control chars from given string | 
| `String` | TrimQuotes(`String` text) | Trim all single and double quotes from given string | 


## `TweenHelper`

Helper methods for DG.Tween/Sequence usage
```csharp
public static class UDBase.Utils.TweenHelper

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Sequence` | Replace(`Sequence` seq, `Boolean` complete = False) | Reset given sequence and replace it with new | 
| `Sequence` | Reset(`Sequence` seq, `Boolean` complete = False) | Reset given sequence | 


## `WebClient`

```csharp
public class UDBase.Utils.WebClient

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | HasAuthorization |  | 
| `Boolean` | InProgress |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | ApplyAuthHeader(`String` value) |  | 
| `void` | SendDeleteRequest(`String` url, `Single` timeout = 10, `Dictionary<String, String>` headers = null, `Action<Response>` onComplete = null) |  | 
| `void` | SendGetRequest(`String` url, `Single` timeout = 10, `Dictionary<String, String>` headers = null, `Action<Response>` onComplete = null) |  | 
| `void` | SendJsonPostRequest(`String` url, `String` data, `Single` timeout = 10, `Dictionary<String, String>` headers = null, `Action<Response>` onComplete = null) |  | 
| `void` | SendPostRequest(`String` url, `String` data, `Single` timeout = 10, `Dictionary<String, String>` headers = null, `Action<Response>` onComplete = null) |  | 


