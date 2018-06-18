﻿using System;
using UnityEngine;

namespace UDBase.Controllers.LogSystem {

	/// <summary>
	/// Logger using default UnityLogger.
	/// </summary>
	public sealed class UnityLog : ILog {
		
		[Serializable]
		public class Settings : CommonLogSettings { }

		Settings _settings;

		public UnityLog(Settings settings) {
			_settings = settings;
		}

		public ULogger CreateLogger(ILogContext context) { return new ULogger(this, context); }

		public void Assert(ILogContext context, string msg) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Assert, context.ToString(), msg);
			}
		}

		public void AssertFormat<T1>(ILogContext context, string msg, T1 arg1) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Assert, context.ToString(), string.Format(msg, arg1));
			}
		}

		public void AssertFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Assert, context.ToString(), string.Format(msg, arg1, arg2));
			}
		}

		public void AssertFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Assert, context.ToString(), string.Format(msg, arg1, arg2, arg3));
			}
		}

		public void AssertFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Assert, context.ToString(), string.Format(msg, arg1, arg2, arg3, arg4));
			}
		}

		public void AssertFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Assert, context.ToString(), string.Format(msg, arg1, arg2, arg3, arg4, arg5));
			}
		}

		public void AssertFormat(ILogContext context, string msg, params object[] args) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Assert, context.ToString(), string.Format(msg, args));
			}
		}

		public void Error(ILogContext context, string msg) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Error, context.ToString(), msg);
			}
		}

		public void ErrorFormat<T1>(ILogContext context, string msg, T1 arg1) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Error, context.ToString(), string.Format(msg, arg1));
			}
		}

		public void ErrorFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Error, context.ToString(), string.Format(msg, arg1, arg2));
			}
		}

		public void ErrorFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Error, context.ToString(), string.Format(msg, arg1, arg2, arg3));
			}
		}

		public void ErrorFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Error, context.ToString(), string.Format(msg, arg1, arg2, arg3, arg4));
			}
		}

		public void ErrorFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Error, context.ToString(), string.Format(msg, arg1, arg2, arg3, arg4, arg5));
			}
		}

		public void ErrorFormat(ILogContext context, string msg, params object[] args) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Error, context.ToString(), string.Format(msg, args));
			}
		}

		public void Exception(ILogContext context, string msg) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Exception, context.ToString(), msg);
			}
		}

		public void ExceptionFormat<T1>(ILogContext context, string msg, T1 arg1) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Exception, context.ToString(), string.Format(msg, arg1));
			}
		}

		public void ExceptionFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Exception, context.ToString(), string.Format(msg, arg1, arg2));
			}
		}

		public void ExceptionFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Exception, context.ToString(), string.Format(msg, arg1, arg2, arg3));
			}
		}

		public void ExceptionFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Exception, context.ToString(), string.Format(msg, arg1, arg2, arg3, arg4));
			}
		}

		public void ExceptionFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Exception, context.ToString(), string.Format(msg, arg1, arg2, arg3, arg4, arg5));
			}
		}

		public void ExceptionFormat(ILogContext context, string msg, params object[] args) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Exception, context.ToString(), string.Format(msg, args));
			}
		}

		public void Message(ILogContext context, string msg) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Log, context.ToString(), msg);
			}
		}

		public void MessageFormat<T1>(ILogContext context, string msg, T1 arg1) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Log, context.ToString(), string.Format(msg, arg1));
			}
		}

		public void MessageFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Log, context.ToString(), string.Format(msg, arg1, arg2));
			}
		}

		public void MessageFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Log, context.ToString(), string.Format(msg, arg1, arg2, arg3));
			}
		}

		public void MessageFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Log, context.ToString(), string.Format(msg, arg1, arg2, arg3, arg4));
			}
		}

		public void MessageFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Log, context.ToString(), string.Format(msg, arg1, arg2, arg3, arg4, arg5));
			}
		}

		public void MessageFormat(ILogContext context, string msg, params object[] args) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Log, context.ToString(), string.Format(msg, args));
			}
		}

		public void Warning(ILogContext context, string msg) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Warning, context.ToString(), msg);
			}
		}

		public void WarningFormat<T1>(ILogContext context, string msg, T1 arg1) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Warning, context.ToString(), string.Format(msg, arg1));
			}
		}

		public void WarningFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Warning, context.ToString(), string.Format(msg, arg1, arg2));
			}
		}

		public void WarningFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Warning, context.ToString(), string.Format(msg, arg1, arg2, arg3));
			}
		}

		public void WarningFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Warning, context.ToString(), string.Format(msg, arg1, arg2, arg3, arg4));
			}
		}

		public void WarningFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Warning, context.ToString(), string.Format(msg, arg1, arg2, arg3, arg4, arg5));
			}
		}

		public void WarningFormat(ILogContext context, string msg, params object[] args) {
			if ( _settings.IsContextEnabled(context) ) {
				Debug.unityLogger.Log(LogType.Warning, context.ToString(), string.Format(msg, args));
			}
		}
	}
}
