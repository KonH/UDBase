## `ILeaderboard`

Leaderboard interface.  With ILeaderboard you can send your player scores, collect it and pull in ordered and filtered format.  You can use two filters: parameter (such as Level or GameType) and version (like 1.0.0 and so on).  Also, you can combine or skip it.
```csharp
public interface UDBase.Controllers.LeaderboardSystem.ILeaderboard

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Version | Gets or sets the game version, which can be used to filtering, may be empty | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | GetScores(`Int32` max, `String` parameter, `Action<List<LeaderboardItem>>` callback) | Gets the scores, returns null to callback if can't retrieve data.  max - maximum result rows.  parameter - filtering condition (like level name, game type etc), can be empty.  returns data only for current game and version (if specified). | 
| `void` | PostScore(`String` parameter, `String` playerName, `Int32` score, `Action<Boolean>` callback) | Posts the score, returns operation result to callback.  parameter - current level name, game type etc, can be empty.  playerName/scores - current player info.  Version is also used in request. | 


## `LeaderboardItem`

One leaderboard record representation
```csharp
public class UDBase.Controllers.LeaderboardSystem.LeaderboardItem

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Game |  | 
| `String` | Param |  | 
| `Int32` | Score |  | 
| `String` | UserName |  | 
| `String` | Version |  | 


## `LocalLeaderboard`

Leaderboard without network interactions (can be used as mock).  Works only in current session and doesn't save data after relaunch.
```csharp
public class UDBase.Controllers.LeaderboardSystem.LocalLeaderboard
    : ILogContext, ILeaderboard

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Version |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | GetScores(`Int32` max, `String` parameter, `Action<List<LeaderboardItem>>` callback) |  | 
| `void` | PostScore(`String` parameter, `String` playerName, `Int32` score, `Action<Boolean>` callback) |  | 


## `WebLeaderboard`

```csharp
public class UDBase.Controllers.LeaderboardSystem.WebLeaderboard
    : ILogContext, ILeaderboard

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Version |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | GetScores(`Int32` max, `String` parameter, `Action<List<LeaderboardItem>>` callback) |  | 
| `void` | PostScore(`String` parameter, `String` playerName, `Int32` score, `Action<Boolean>` callback) |  | 


