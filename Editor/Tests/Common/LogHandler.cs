using System;
using UnityEngine;

public class LogHandler:IDisposable {
	
	bool _prevEnabled = false;

	public LogHandler() {
		_prevEnabled = Debug.logger.logEnabled;
		Debug.logger.logEnabled = false;
	}

    public void Dispose() {
		Debug.logger.logEnabled = _prevEnabled;
    }
}
