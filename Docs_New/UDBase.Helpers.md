## `FloatRange`

Float range helper class for work with values in specific range
```csharp
public class UDBase.Helpers.FloatRange
    : Range<Single>

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Contains(`Single` value) | Check that given value in Start &lt;= value &lt;= End | 
| `Boolean` | IsValid() | Returns true if range is valid (End &gt; Start) | 
| `Single` | Random() | Return value in Start &lt;= value &lt; End | 


## `IntRange`

Integer range helper class for work with values in specific range
```csharp
public class UDBase.Helpers.IntRange
    : Range<Int32>

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Contains(`Int32` value) | Check that given value in Start &lt;= value &lt;= End | 
| `Boolean` | IsValid() | Returns true if range is valid (End &gt; Start) | 
| `Int32` | Random() | Return value in Start &lt;= value &lt; End | 
| `Int32` | RandomInclusive() | Return value in Start &lt;= value &lt;= End | 


## `Range<T>`

Base range helper class for work with values in specific range
```csharp
public abstract class UDBase.Helpers.Range<T>

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `T` | End |  | 
| `T` | Start |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Contains(`T` value) |  | 
| `Boolean` | IsValid() |  | 
| `T` | Random() |  | 
| `String` | ToString() |  | 


