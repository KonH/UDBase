# UTime

## Summary

**UTime** is a simple interface to retrieve time from device and/or internet server and check time status.

## Usage

Initialization:

```
AddController<UTime>(
	new LocalTime(), // To retrieve device time
	new NetworkTime("url")); // To request time from your server
```

You can add NetworkTime controllers as many as you want.
Optionally, you can set parameters to time controllers:

```
// isTrusted - should we trust this time source, useUniversalTime - use UTC or current timezone time
new LocalTime(bool isTrusted = false, bool useUniversalTime = false)
// timeout - max wait for response in seconds
new NetworkTime(string url, float timeout = 10.0f, bool isTrusted = true)
```

*UTime* provides several methods to work with time:

- **IsStable()** - return true only if all time controllers are available or failed (and you can't get better time)
- **IsTrusted()** - return true if any trusted time controller is available
- **GetTrustedTime()** - first available current trusted time (network time by default)
- **GetUntrustedTime()** - current untrusted time (device time by default)
- **GetAvailableTime()** - trusted or untrusted time, if no trusted time available


## Server protocol

You can make your own implementation that returns datetime in this format "2016-12-25T14:12:33+00:00" in answer for HTTP request.

## Available server versions

- [DotNetCoreTimeServer](https://github.com/KonH/DotNetCoreTimeServer) - C#, .NET Core, ASP.NET, Docker
