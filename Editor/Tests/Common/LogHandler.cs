using System;
using UnityEngine;

public class LogHandler:IDisposable {
	
	bool _prevEnabled = false;

	public LogHandler() {
		_prevEnabled = Debug.unityLogger.logEnabled;
		Debug.unityLogger.logEnabled = false;
	}

    public void Dispose() {
		Debug.unityLogger.logEnabled = _prevEnabled;
    }
}
