using UnityEngine;

namespace UDBase.Controllers.LogSystem {
	public interface ILog {

		// Message
		void Message(LogType type, ILogContext context, string msg);
		void MessageFormat<T1>(LogType type, ILogContext context, string msg, T1 arg1);
		void MessageFormat<T1, T2>(LogType type, ILogContext context, string msg, T1 arg1, T2 arg2);
		void MessageFormat<T1, T2, T3>(LogType type, ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3);
		void MessageFormat<T1, T2, T3, T4>(LogType type, ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		void MessageFormat<T1, T2, T3, T4, T5>(LogType type, ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
		void MessageFormat(LogType type, ILogContext context, string msg, params object[] args);

		// Log
		void Message(ILogContext context, string msg);
		void MessageFormat<T1>(ILogContext context, string msg, T1 arg1);
		void MessageFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2);
		void MessageFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3);
		void MessageFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		void MessageFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
		void MessageFormat(ILogContext context, string msg, params object[] args);

		// Warning
		void Warning(ILogContext context, string msg);
		void WarningFormat<T1>(ILogContext context, string msg, T1 arg1);
		void WarningFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2);
		void WarningFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3);
		void WarningFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		void WarningFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
		void WarningFormat(ILogContext context, string msg, params object[] args);

		// Assert
		void Assert(ILogContext context, string msg);
		void AssertFormat<T1>(ILogContext context, string msg, T1 arg1);
		void AssertFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2);
		void AssertFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3);
		void AssertFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		void AssertFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
		void AssertFormat(ILogContext context, string msg, params object[] args);

		// Error
		void Error(ILogContext context, string msg);
		void ErrorFormat<T1>(ILogContext context, string msg, T1 arg1);
		void ErrorFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2);
		void ErrorFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3);
		void ErrorFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		void ErrorFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
		void ErrorFormat(ILogContext context, string msg, params object[] args);

		// Exception
		void Exception(ILogContext context, string msg);
		void ExceptionFormat<T1>(ILogContext context, string msg, T1 arg1);
		void ExceptionFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2);
		void ExceptionFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3);
		void ExceptionFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
		void ExceptionFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
		void ExceptionFormat(ILogContext context, string msg, params object[] args);
	}
}
