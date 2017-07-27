using UnityEngine;

namespace UDBase.Controllers.LogSystem {
	public class Log : ControllerHelper<ILog> {
		
		// Common 

		public static void Message(string msg, LogType type, LogTags tag) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(msg, type, tag);
			}
		}

		public static void MessageFormat<T1>(string msg, LogType type, LogTags tag, T1 arg1) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1), type, tag);
			}
		}

		public static void MessageFormat<T1, T2>(string msg, LogType type, LogTags tag, T1 arg1, T2 arg2) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2), type, tag);
			}
		}

		public static void MessageFormat<T1, T2, T3>(string msg, LogType type, LogTags tag, T1 arg1, T2 arg2, T3 arg3) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3), type, tag);
			}
		}

		public static void MessageFormat<T1, T2, T3, T4>(string msg, LogType type, LogTags tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3, arg4), type, tag);
			}
		}

		public static void MessageFormat<T1, T2, T3, T4, T5>(string msg, LogType type, LogTags tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3, arg4, arg5), type, tag);
			}
		}

		public static void MessageFormat(string msg, LogType type, LogTags tag, params object[] args) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, args), type, tag);
			}
		}

		// Log

		public static void Message(string msg, LogTags tag) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(msg, LogType.Log, tag);
			}
		}

		public static void MessageFormat<T1>(string msg, LogTags tag, T1 arg1) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1), LogType.Log, tag);
			}
		}

		public static void MessageFormat<T1, T2>(string msg, LogTags tag, T1 arg1, T2 arg2) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2), LogType.Log, tag);
			}
		}

		public static void MessageFormat<T1, T2, T3>(string msg, LogTags tag, T1 arg1, T2 arg2, T3 arg3) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3), LogType.Log, tag);
			}
		}

		public static void MessageFormat<T1, T2, T3, T4>(string msg, LogTags tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3, arg4), LogType.Log, tag);
			}
		}

		public static void MessageFormat<T1, T2, T3, T4, T5>(string msg, LogTags tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3, arg4, arg5), LogType.Log, tag);
			}
		}

		public static void MessageFormat(string msg, LogTags tag, params object[] args) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, args), LogType.Log, tag);
			}
		}

		// Warning

		public static void Warning(string msg, LogTags tag) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(msg, LogType.Warning, tag);
			}
		}

		public static void WarningFormat<T1>(string msg, LogTags tag, T1 arg1) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1), LogType.Warning, tag);
			}
		}

		public static void WarningFormat<T1, T2>(string msg, LogTags tag, T1 arg1, T2 arg2) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2), LogType.Warning, tag);
			}
		}

		public static void WarningFormat<T1, T2, T3>(string msg, LogTags tag, T1 arg1, T2 arg2, T3 arg3) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3), LogType.Warning, tag);
			}
		}

		public static void WarningFormat<T1, T2, T3, T4>(string msg, LogTags tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3, arg4), LogType.Warning, tag);
			}
		}

		public static void WarningFormat<T1, T2, T3, T4, T5>(string msg, LogTags tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3, arg4, arg5), LogType.Warning, tag);
			}
		}

		public static void WarningFormat(string msg, LogTags tag, params object[] args) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, args), LogType.Warning, tag);
			}
		}

		// Assert

		public static void Assert(string msg, LogTags tag) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(msg, LogType.Assert, tag);
			}
		}

		public static void AssertFormat<T1>(string msg, LogTags tag, T1 arg1) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1), LogType.Assert, tag);
			}
		}

		public static void AssertFormat<T1, T2>(string msg, LogTags tag, T1 arg1, T2 arg2) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2), LogType.Assert, tag);
			}
		}

		public static void AssertFormat<T1, T2, T3>(string msg, LogTags tag, T1 arg1, T2 arg2, T3 arg3) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3), LogType.Assert, tag);
			}
		}

		public static void AssertFormat<T1, T2, T3, T4>(string msg, LogTags tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3, arg4), LogType.Assert, tag);
			}
		}

		public static void AssertFormat<T1, T2, T3, T4, T5>(string msg, LogTags tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3, arg4, arg5), LogType.Assert, tag);
			}
		}

		public static void AssertFormat(string msg, LogTags tag, params object[] args) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, args), LogType.Assert, tag);
			}
		}

		// Error

		public static void Error(string msg, LogTags tag) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(msg, LogType.Error, tag);
			}
		}

		public static void ErrorFormat<T1>(string msg, LogTags tag, T1 arg1) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1), LogType.Error, tag);
			}
		}

		public static void ErrorFormat<T1, T2>(string msg, LogTags tag, T1 arg1, T2 arg2) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2), LogType.Error, tag);
			}
		}

		public static void ErrorFormat<T1, T2, T3>(string msg, LogTags tag, T1 arg1, T2 arg2, T3 arg3) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3), LogType.Error, tag);
			}
		}

		public static void ErrorFormat<T1, T2, T3, T4>(string msg, LogTags tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3, arg4), LogType.Error, tag);
			}
		}

		public static void ErrorFormat<T1, T2, T3, T4, T5>(string msg, LogTags tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3, arg4, arg5), LogType.Error, tag);
			}
		}

		public static void ErrorFormat(string msg, LogTags tag, params object[] args) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, args), LogType.Error, tag);
			}
		}

		// Exception

		public static void Exception(string msg, LogTags tag) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(msg, LogType.Exception, tag);
			}
		}

		public static void ExceptionFormat<T1>(string msg, LogTags tag, T1 arg1) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1), LogType.Exception, tag);
			}
		}

		public static void ExceptionFormat<T1, T2>(string msg, LogTags tag, T1 arg1, T2 arg2) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2), LogType.Exception, tag);
			}
		}

		public static void ExceptionFormat<T1, T2, T3>(string msg, LogTags tag, T1 arg1, T2 arg2, T3 arg3) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3), LogType.Exception, tag);
			}
		}

		public static void ExceptionFormat<T1, T2, T3, T4>(string msg, LogTags tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3, arg4), LogType.Exception, tag);
			}
		}

		public static void ExceptionFormat<T1, T2, T3, T4, T5>(string msg, LogTags tag, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, arg1, arg2, arg3, arg4, arg5), LogType.Exception, tag);
			}
		}

		public static void ExceptionFormat(string msg, LogTags tag, params object[] args) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(string.Format(msg, args), LogType.Exception, tag);
			}
		}
	}
}
