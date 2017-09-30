using System;
using UnityEngine;

public class LogHandler:IDisposable {
	readonly bool _prevEnabled;

	public LogHandler() {
		_prevEnabled = Debug.unityLogger.logEnabled;
		Debug.unityLogger.logEnabled = false;
	}

    public void Dispose() {
		Debug.unityLogger.logEnabled = _prevEnabled;
    }
}
