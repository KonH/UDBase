# Leaderboard

Leaderboard is a score management system, now it is used self-hosted service.

## Basics

For use this controller, you need to prepare your server application (or use test implementation before setup your own).
With Leaderboard system you can send your player scores, collect it and pull in ordered and filtered format.
You can use two filters: parameter (such as Level or GameType) and version (like 1.0.0 and so on). Also, you can combine or skip it.

## Usage

You need to add controller and provide your service url to it:

```
AddController<Leaderboard>(
			new WebLeaderboard("https://konhit.xyz/lbservice/", "testGame", "1.0.0", "testUser", "mGPRudr8")); // For non-production test cases
```

If you want to change version for requests, use property:

```
Leaderboard.Version = "1.0.1";
```

Also, for get results for all versions, leave this value empty.

To get scores you can use:

```
Leaderboard.GetScores(Limit, "param", EndRefresh);
```

Where EndRefresh is an **List<LeaderboardItem>** callback:

```
void EndRefresh(List<LeaderboardItem> items) {
	if ( items != null ) {
		// If items is null - request is failed
		for ( int i = 0; i < items.Count; i++ ) {
			// Your item processing logics here
		}
	}
}
```

To post scores you can use:

```
Leaderboard.PostScore("param", "userName", 100, EndSend);
```

Where EndSend is an **bool** callback:

```
void EndSend(bool result) {
	// If you get result == true, request is succeded
}
```


## Implementation

You can use [ASP.NET Core Leaderboard Service](https://github.com/KonH/LeaderboardService), deploy it on your own server and use in your projects.
