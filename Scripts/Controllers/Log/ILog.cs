using UnityEngine;

namespace UDBase.Controllers.LogSystem {
	public interface ILog {

		// Message
		void Message(LogType type, LogTags tag, string msg);
		void MessageFormat<T1>(LogType type, LogTags tag, string msg, T1 arg1);
		void MessageFormat<T1, T2>(LogType type, LogTags tag, string msg, T1 arg1, T2 arg2);
		void MessageFormat<T1, T2, T3>(LogType type, LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3);
		void MessageFormat<T1, T2, T3, T4>(LogType type, LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		void MessageFormat<T1, T2, T3, T4, T5>(LogType type, LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
		void MessageFormat(LogType type, LogTags tag, string msg, params object[] args);

		// Log
		void Message(LogTags tag, string msg);
		void MessageFormat<T1>(LogTags tag, string msg, T1 arg1);
		void MessageFormat<T1, T2>(LogTags tag, string msg, T1 arg1, T2 arg2);
		void MessageFormat<T1, T2, T3>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3);
		void MessageFormat<T1, T2, T3, T4>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		void MessageFormat<T1, T2, T3, T4, T5>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
		void MessageFormat(LogTags tag, string msg, params object[] args);

		// Warning
		void Warning(LogTags tag, string msg);
		void WarningFormat<T1>(LogTags tag, string msg, T1 arg1);
		void WarningFormat<T1, T2>(LogTags tag, string msg, T1 arg1, T2 arg2);
		void WarningFormat<T1, T2, T3>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3);
		void WarningFormat<T1, T2, T3, T4>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		void WarningFormat<T1, T2, T3, T4, T5>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
		void WarningFormat(LogTags tag, string msg, params object[] args);

		// Assert
		void Assert(LogTags tag, string msg);
		void AssertFormat<T1>(LogTags tag, string msg, T1 arg1);
		void AssertFormat<T1, T2>(LogTags tag, string msg, T1 arg1, T2 arg2);
		void AssertFormat<T1, T2, T3>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3);
		void AssertFormat<T1, T2, T3, T4>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		void AssertFormat<T1, T2, T3, T4, T5>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
		void AssertFormat(LogTags tag, string msg, params object[] args);

		// Error
		void Error(LogTags tag, string msg);
		void ErrorFormat<T1>(LogTags tag, string msg, T1 arg1);
		void ErrorFormat<T1, T2>(LogTags tag, string msg, T1 arg1, T2 arg2);
		void ErrorFormat<T1, T2, T3>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3);
		void ErrorFormat<T1, T2, T3, T4>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		void ErrorFormat<T1, T2, T3, T4, T5>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
		void ErrorFormat(LogTags tag, string msg, params object[] args);

		// Exception
		void Exception(LogTags tag, string msg);
		void ExceptionFormat<T1>(LogTags tag, string msg, T1 arg1);
		void ExceptionFormat<T1, T2>(LogTags tag, string msg, T1 arg1, T2 arg2);
		void ExceptionFormat<T1, T2, T3>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3);
		void ExceptionFormat<T1, T2, T3, T4>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		void ExceptionFormat<T1, T2, T3, T4, T5>(LogTags tag, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
		void ExceptionFormat(LogTags tag, string msg, params object[] args);
	}
}
