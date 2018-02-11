using UnityEngine;

namespace UDBase.Controllers.LogSystem {
	public sealed class UnityLog : ILog {
		public void Assert(LogTags tag, string msg) {
			Debug.unityLogger.Log(LogType.Assert, tag.ToString(), msg);
		}

		public void AssertFormat<T1>(LogTags tag, string msg, T1 arg1) {
			Debug.unityLogger.Log(LogType.Assert, tag.ToString(), string.Format(msg, arg1));
		}

		public void AssertFormat<T1, T2>(LogTags tag, string msg, T1 arg1, T2 arg2) {
			Debug.unityLogger.Log(LogType.Assert, tag.ToString(), string.Format(msg, arg1, arg2));
		}

		public void AssertFormat<T1, T2, T3>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3) {
			Debug.unityLogger.Log(LogType.Assert, tag.ToString(), string.Format(msg, arg1, arg2, arg3));
		}

		public void AssertFormat<T1, T2, T3, T4>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			Debug.unityLogger.Log(LogType.Assert, tag.ToString(), string.Format(msg, arg1, arg2, arg3, arg4));
		}

		public void AssertFormat<T1, T2, T3, T4, T5>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			Debug.unityLogger.Log(LogType.Assert, tag.ToString(), string.Format(msg, arg1, arg2, arg3, arg4, arg5));
		}

		public void AssertFormat(LogTags tag, string msg, params object[] args) {
			Debug.unityLogger.Log(LogType.Assert, tag.ToString(), string.Format(msg, args));
		}

		public void Error(LogTags tag, string msg) {
			Debug.unityLogger.Log(LogType.Error, tag.ToString(), msg);
		}

		public void ErrorFormat<T1>(LogTags tag, string msg, T1 arg1) {
			Debug.unityLogger.Log(LogType.Error, tag.ToString(), string.Format(msg, arg1));
		}

		public void ErrorFormat<T1, T2>(LogTags tag, string msg, T1 arg1, T2 arg2) {
			Debug.unityLogger.Log(LogType.Error, tag.ToString(), string.Format(msg, arg1, arg2));
		}

		public void ErrorFormat<T1, T2, T3>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3) {
			Debug.unityLogger.Log(LogType.Error, tag.ToString(), string.Format(msg, arg1, arg2, arg3));
		}

		public void ErrorFormat<T1, T2, T3, T4>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			Debug.unityLogger.Log(LogType.Error, tag.ToString(), string.Format(msg, arg1, arg2, arg3, arg4));
		}

		public void ErrorFormat<T1, T2, T3, T4, T5>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			Debug.unityLogger.Log(LogType.Error, tag.ToString(), string.Format(msg, arg1, arg2, arg3, arg4, arg5));
		}

		public void ErrorFormat(LogTags tag, string msg, params object[] args) {
			Debug.unityLogger.Log(LogType.Error, tag.ToString(), string.Format(msg, args));
		}

		public void Exception(LogTags tag, string msg) {
			Debug.unityLogger.Log(LogType.Exception, tag.ToString(), msg);
		}

		public void ExceptionFormat<T1>(LogTags tag, string msg, T1 arg1) {
			Debug.unityLogger.Log(LogType.Exception, tag.ToString(), string.Format(msg, arg1));
		}

		public void ExceptionFormat<T1, T2>(LogTags tag, string msg, T1 arg1, T2 arg2) {
			Debug.unityLogger.Log(LogType.Exception, tag.ToString(), string.Format(msg, arg1, arg2));
		}

		public void ExceptionFormat<T1, T2, T3>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3) {
			Debug.unityLogger.Log(LogType.Exception, tag.ToString(), string.Format(msg, arg1, arg2, arg3));
		}

		public void ExceptionFormat<T1, T2, T3, T4>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			Debug.unityLogger.Log(LogType.Exception, tag.ToString(), string.Format(msg, arg1, arg2, arg3, arg4));
		}

		public void ExceptionFormat<T1, T2, T3, T4, T5>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			Debug.unityLogger.Log(LogType.Exception, tag.ToString(), string.Format(msg, arg1, arg2, arg3, arg4, arg5));
		}

		public void ExceptionFormat(LogTags tag, string msg, params object[] args) {
			Debug.unityLogger.Log(LogType.Exception, tag.ToString(), string.Format(msg, args));
		}

		public void Message(LogType type, LogTags tag, string msg) {
			Debug.unityLogger.Log(type, tag.ToString(), msg);
		}

		public void Message(LogTags tag, string msg) {
			Debug.unityLogger.Log(LogType.Log, tag.ToString(), msg);
		}

		public void MessageFormat<T1>(LogType type, LogTags tag, string msg, T1 arg1) {
			Debug.unityLogger.Log(type, tag.ToString(), string.Format(msg, arg1));
		}

		public void MessageFormat<T1, T2>(LogType type, LogTags tag, string msg, T1 arg1, T2 arg2) {
			Debug.unityLogger.Log(type, tag.ToString(), string.Format(msg, arg1, arg2));
		}

		public void MessageFormat<T1, T2, T3>(LogType type, LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3) {
			Debug.unityLogger.Log(type, tag.ToString(), string.Format(msg, arg1, arg2, arg3));
		}

		public void MessageFormat<T1, T2, T3, T4>(LogType type, LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			Debug.unityLogger.Log(type, tag.ToString(), string.Format(msg, arg1, arg2, arg3, arg4));
		}

		public void MessageFormat<T1, T2, T3, T4, T5>(LogType type, LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			Debug.unityLogger.Log(type, tag.ToString(), string.Format(msg, arg1, arg2, arg3, arg4, arg5));
		}

		public void MessageFormat(LogType type, LogTags tag, string msg, params object[] args) {
			Debug.unityLogger.Log(type, tag.ToString(), string.Format(msg, args));
		}

		public void MessageFormat<T1>(LogTags tag, string msg, T1 arg1) {
			Debug.unityLogger.Log(LogType.Log, tag.ToString(), string.Format(msg, arg1));
		}

		public void MessageFormat<T1, T2>(LogTags tag, string msg, T1 arg1, T2 arg2) {
			Debug.unityLogger.Log(LogType.Log, tag.ToString(), string.Format(msg, arg1, arg2));
		}

		public void MessageFormat<T1, T2, T3>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3) {
			Debug.unityLogger.Log(LogType.Log, tag.ToString(), string.Format(msg, arg1, arg2, arg3));
		}

		public void MessageFormat<T1, T2, T3, T4>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			Debug.unityLogger.Log(LogType.Log, tag.ToString(), string.Format(msg, arg1, arg2, arg3, arg4));
		}

		public void MessageFormat<T1, T2, T3, T4, T5>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			Debug.unityLogger.Log(LogType.Log, tag.ToString(), string.Format(msg, arg1, arg2, arg3, arg4, arg5));
		}

		public void MessageFormat(LogTags tag, string msg, params object[] args) {
			Debug.unityLogger.Log(LogType.Log, tag.ToString(), string.Format(msg, args));
		}

		public void Warning(LogTags tag, string msg) {
			Debug.unityLogger.Log(LogType.Warning, tag.ToString(), msg);
		}

		public void WarningFormat<T1>(LogTags tag, string msg, T1 arg1) {
			Debug.unityLogger.Log(LogType.Warning, tag.ToString(), string.Format(msg, arg1));
		}

		public void WarningFormat<T1, T2>(LogTags tag, string msg, T1 arg1, T2 arg2) {
			Debug.unityLogger.Log(LogType.Warning, tag.ToString(), string.Format(msg, arg1, arg2));
		}

		public void WarningFormat<T1, T2, T3>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3) {
			Debug.unityLogger.Log(LogType.Warning, tag.ToString(), string.Format(msg, arg1, arg2, arg3));
		}

		public void WarningFormat<T1, T2, T3, T4>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			Debug.unityLogger.Log(LogType.Warning, tag.ToString(), string.Format(msg, arg1, arg2, arg3, arg4));
		}

		public void WarningFormat<T1, T2, T3, T4, T5>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			Debug.unityLogger.Log(LogType.Warning, tag.ToString(), string.Format(msg, arg1, arg2, arg3, arg4, arg5));
		}

		public void WarningFormat(LogTags tag, string msg, params object[] args) {
			Debug.unityLogger.Log(LogType.Warning, tag.ToString(), string.Format(msg, args));
		}
	}
}
