using UnityEngine;

namespace UDBase.Controllers.LogSystem {
	public sealed class EmptyLog : ILog {
		public void Assert(ILogContext context, string msg) { }
		public void AssertFormat<T1>(ILogContext context, string msg, T1 arg1) { }
		public void AssertFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2) { }
		public void AssertFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3) { }
		public void AssertFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) { }
		public void AssertFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) { }
		public void AssertFormat(ILogContext context, string msg, params object[] args) { }
		public void Error(ILogContext context, string msg) { }
		public void ErrorFormat<T1>(ILogContext context, string msg, T1 arg1) { }
		public void ErrorFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2) { }
		public void ErrorFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3) { }
		public void ErrorFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) { }
		public void ErrorFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) { }
		public void ErrorFormat(ILogContext context, string msg, params object[] args) { }
		public void Exception(ILogContext context, string msg) { }
		public void ExceptionFormat<T1>(ILogContext context, string msg, T1 arg1) { }
		public void ExceptionFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2) { }
		public void ExceptionFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3) { }
		public void ExceptionFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) { }
		public void ExceptionFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) { }
		public void ExceptionFormat(ILogContext context, string msg, params object[] args) { }
		public void Message(LogType type, ILogContext context, string msg) { }
		public void Message(ILogContext context, string msg) { }
		public void MessageFormat<T1>(LogType type, ILogContext context, string msg, T1 arg1) { }
		public void MessageFormat<T1, T2>(LogType type, ILogContext context, string msg, T1 arg1, T2 arg2) { }
		public void MessageFormat<T1, T2, T3>(LogType type, ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3) { }
		public void MessageFormat<T1, T2, T3, T4>(LogType type, ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) { }
		public void MessageFormat<T1, T2, T3, T4, T5>(LogType type, ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) { }
		public void MessageFormat(LogType type, ILogContext context, string msg, params object[] args) { }
		public void MessageFormat<T1>(ILogContext context, string msg, T1 arg1) { }
		public void MessageFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2) { }
		public void MessageFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3) { }
		public void MessageFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) { }
		public void MessageFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) { }
		public void MessageFormat(ILogContext context, string msg, params object[] args) { }
		public void Warning(ILogContext context, string msg) { }
		public void WarningFormat<T1>(ILogContext context, string msg, T1 arg1) { }
		public void WarningFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2) { }
		public void WarningFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3) { }
		public void WarningFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) { }
		public void WarningFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) { }
		public void WarningFormat(ILogContext context, string msg, params object[] args) { }
	}
}
