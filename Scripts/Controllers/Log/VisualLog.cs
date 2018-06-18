using UnityEngine;
using UDBase.Controllers.LogSystem.UI;

namespace UDBase.Controllers.LogSystem {

	/// <summary>
	/// Debug button position
	/// </summary>
	public enum ButtonPosition {
		LeftTop,
		RightTop,
		LeftBottom,
		RightBottom
	}

	/// <summary>
	/// Logger using VisualLogHandler to display overlay on additional Canvas
	/// </summary>
	public sealed class VisualLog : ILog {
		readonly VisualLogHandler _handler;

		public VisualLog(VisualLogHandler handler) {
			_handler = handler;
		}

		public ULogger CreateLogger(ILogContext context) { return new ULogger(this, context); }

		public void Assert(ILogContext context, string msg) {
			_handler.AddMessage(LogType.Assert, context, msg);
		}

		public void AssertFormat<T1>(ILogContext context, string msg, T1 arg1) {
			_handler.AddMessage(LogType.Assert, context, string.Format(msg, arg1));
		}

		public void AssertFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2) {
			_handler.AddMessage(LogType.Assert, context, string.Format(msg, arg1, arg2));
		}

		public void AssertFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3) {
			_handler.AddMessage(LogType.Assert, context, string.Format(msg, arg1, arg2, arg3));
		}

		public void AssertFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			_handler.AddMessage(LogType.Assert, context, string.Format(msg, arg1, arg2, arg3, arg4));
		}

		public void AssertFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			_handler.AddMessage(LogType.Assert, context, string.Format(msg, arg1, arg2, arg3, arg4, arg5));
		}

		public void AssertFormat(ILogContext context, string msg, params object[] args) {
			_handler.AddMessage(LogType.Assert, context, string.Format(msg, args));
		}

		public void Error(ILogContext context, string msg) {
			_handler.AddMessage(LogType.Error, context, msg);
		}

		public void ErrorFormat<T1>(ILogContext context, string msg, T1 arg1) {
			_handler.AddMessage(LogType.Error, context, string.Format(msg, arg1));
		}

		public void ErrorFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2) {
			_handler.AddMessage(LogType.Error, context, string.Format(msg, arg1, arg2));
		}

		public void ErrorFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3) {
			_handler.AddMessage(LogType.Error, context, string.Format(msg, arg1, arg2, arg3));
		}

		public void ErrorFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			_handler.AddMessage(LogType.Error, context, string.Format(msg, arg1, arg2, arg3, arg4));
		}

		public void ErrorFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			_handler.AddMessage(LogType.Error, context, string.Format(msg, arg1, arg2, arg3, arg4, arg5));
		}

		public void ErrorFormat(ILogContext context, string msg, params object[] args) {
			_handler.AddMessage(LogType.Error, context, string.Format(msg, args));
		}

		public void Exception(ILogContext context, string msg) {
			_handler.AddMessage(LogType.Exception, context, msg);
		}

		public void ExceptionFormat<T1>(ILogContext context, string msg, T1 arg1) {
			_handler.AddMessage(LogType.Exception, context, string.Format(msg, arg1));
		}

		public void ExceptionFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2) {
			_handler.AddMessage(LogType.Exception, context, string.Format(msg, arg1, arg2));
		}

		public void ExceptionFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3) {
			_handler.AddMessage(LogType.Exception, context, string.Format(msg, arg1, arg2, arg3));
		}

		public void ExceptionFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			_handler.AddMessage(LogType.Exception, context, string.Format(msg, arg1, arg2, arg3, arg4));
		}

		public void ExceptionFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			_handler.AddMessage(LogType.Exception, context, string.Format(msg, arg1, arg2, arg3, arg4, arg5));
		}

		public void ExceptionFormat(ILogContext context, string msg, params object[] args) {
			_handler.AddMessage(LogType.Exception, context, string.Format(msg, args));
		}

		public void Message(LogType type, ILogContext context, string msg) {
			_handler.AddMessage(type, context, msg);
		}

		public void Message(ILogContext context, string msg) {
			_handler.AddMessage(LogType.Log, context, msg);
		}

		public void MessageFormat<T1>(LogType type, ILogContext context, string msg, T1 arg1) {
			_handler.AddMessage(type, context, string.Format(msg, arg1));
		}

		public void MessageFormat<T1, T2>(LogType type, ILogContext context, string msg, T1 arg1, T2 arg2) {
			_handler.AddMessage(type, context, string.Format(msg, arg1, arg2));
		}

		public void MessageFormat<T1, T2, T3>(LogType type, ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3) {
			_handler.AddMessage(type, context, string.Format(msg, arg1, arg2, arg3));
		}

		public void MessageFormat<T1, T2, T3, T4>(LogType type, ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			_handler.AddMessage(type, context, string.Format(msg, arg1, arg2, arg3, arg4));
		}

		public void MessageFormat<T1, T2, T3, T4, T5>(LogType type, ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			_handler.AddMessage(type, context, string.Format(msg, arg1, arg2, arg3, arg4, arg5));
		}

		public void MessageFormat(LogType type, ILogContext context, string msg, params object[] args) {
			_handler.AddMessage(type, context, string.Format(msg, args));
		}

		public void MessageFormat<T1>(ILogContext context, string msg, T1 arg1) {
			_handler.AddMessage(LogType.Log, context, string.Format(msg, arg1));
		}

		public void MessageFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2) {
			_handler.AddMessage(LogType.Log, context, string.Format(msg, arg1, arg2));
		}

		public void MessageFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3) {
			_handler.AddMessage(LogType.Log, context, string.Format(msg, arg1, arg2, arg3));
		}

		public void MessageFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			_handler.AddMessage(LogType.Log, context, string.Format(msg, arg1, arg2, arg3, arg4));
		}

		public void MessageFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			_handler.AddMessage(LogType.Log, context, string.Format(msg, arg1, arg2, arg3, arg4, arg5));
		}

		public void MessageFormat(ILogContext context, string msg, params object[] args) {
			_handler.AddMessage(LogType.Log, context, string.Format(msg, args));
		}

		public void Warning(ILogContext context, string msg) {
			_handler.AddMessage(LogType.Warning, context, msg);
		}

		public void WarningFormat<T1>(ILogContext context, string msg, T1 arg1) {
			_handler.AddMessage(LogType.Warning, context, string.Format(msg, arg1));
		}

		public void WarningFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2) {
			_handler.AddMessage(LogType.Warning, context, string.Format(msg, arg1, arg2));
		}

		public void WarningFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3) {
			_handler.AddMessage(LogType.Warning, context, string.Format(msg, arg1, arg2, arg3));
		}

		public void WarningFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			_handler.AddMessage(LogType.Warning, context, string.Format(msg, arg1, arg2, arg3, arg4));
		}

		public void WarningFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			_handler.AddMessage(LogType.Warning, context, string.Format(msg, arg1, arg2, arg3, arg4, arg5));
		}

		public void WarningFormat(ILogContext context, string msg, params object[] args) {
			_handler.AddMessage(LogType.Warning, context, string.Format(msg, args));
		}
	}
}
