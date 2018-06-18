namespace UDBase.Controllers.LogSystem {
	/// <summary>
	/// Log interface without additional allocation when less then 5 parameters is used.
	/// To use ILog you need to use ILogContext object, which specify area of logging and allow you to filter logs at runtime.
	/// Also, you can create ULogger for shorter logging calls.
	/// Notes:
	/// All these boilerplate is required to avoid additional allocation for params usage. 
	/// Generics is required to avoid boxing in valye type cases.
	/// </summary>
	public interface ILog {

		/// <summary>
		/// Creates logger for shorter calls to ILog
		/// </summary>
		ULogger CreateLogger(ILogContext context);

		/// <summary>
		/// Log message with given context
		/// </summary>
		void Message(ILogContext context, string msg);

		/// <summary>
		/// Log message with given context
		/// </summary>
		void MessageFormat<T1>(ILogContext context, string msg, T1 arg1);

		/// <summary>
		/// Log message with given context
		/// </summary>
		void MessageFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2);

		/// <summary>
		/// Log message with given context
		/// </summary>
		void MessageFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3);

		/// <summary>
		/// Log message with given context
		/// </summary>
		void MessageFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

		/// <summary>
		/// Log message with given context
		/// </summary>
		void MessageFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

		/// <summary>
		/// Log message with given context
		/// </summary>
		void MessageFormat(ILogContext context, string msg, params object[] args);


		/// <summary>
		/// Log warning with given context
		/// </summary>
		void Warning(ILogContext context, string msg);

		/// <summary>
		/// Log warning with given context
		/// </summary>
		void WarningFormat<T1>(ILogContext context, string msg, T1 arg1);

		/// <summary>
		/// Log warning with given context
		/// </summary>
		void WarningFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2);

		/// <summary>
		/// Log warning with given context
		/// </summary>
		void WarningFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3);

		/// <summary>
		/// Log warning with given context
		/// </summary>
		void WarningFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

		/// <summary>
		/// Log warning with given context
		/// </summary>
		void WarningFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

		/// <summary>
		/// Log warning with given context
		/// </summary>
		void WarningFormat(ILogContext context, string msg, params object[] args);


		/// <summary>
		/// Log assert with given context
		/// </summary>
		void Assert(ILogContext context, string msg);

		/// <summary>
		/// Log assert with given context
		/// </summary>
		void AssertFormat<T1>(ILogContext context, string msg, T1 arg1);

		/// <summary>
		/// Log assert with given context
		/// </summary>
		void AssertFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2);

		/// <summary>
		/// Log assert with given context
		/// </summary>
		void AssertFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3);

		/// <summary>
		/// Log assert with given context
		/// </summary>
		void AssertFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

		/// <summary>
		/// Log assert with given context
		/// </summary>
		void AssertFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

		/// <summary>
		/// Log assert with given context
		/// </summary>
		void AssertFormat(ILogContext context, string msg, params object[] args);


		/// <summary>
		/// Log error with given context
		/// </summary>
		void Error(ILogContext context, string msg);

		/// <summary>
		/// Log error with given context
		/// </summary>
		void ErrorFormat<T1>(ILogContext context, string msg, T1 arg1);

		/// <summary>
		/// Log error with given context
		/// </summary>
		void ErrorFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2);

		/// <summary>
		/// Log error with given context
		/// </summary>
		void ErrorFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3);

		/// <summary>
		/// Log error with given context
		/// </summary>
		void ErrorFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

		/// <summary>
		/// Log error with given context
		/// </summary>
		void ErrorFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

		/// <summary>
		/// Log error with given context
		/// </summary>
		void ErrorFormat(ILogContext context, string msg, params object[] args);



		/// <summary>
		/// Log exception with given context
		/// </summary>
		void Exception(ILogContext context, string msg);

		/// <summary>
		/// Log exception with given context
		/// </summary>
		void ExceptionFormat<T1>(ILogContext context, string msg, T1 arg1);

		/// <summary>
		/// Log exception with given context
		/// </summary>
		void ExceptionFormat<T1, T2>(ILogContext context, string msg, T1 arg1, T2 arg2);

		/// <summary>
		/// Log exception with given context
		/// </summary>
		void ExceptionFormat<T1, T2, T3>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3);

		/// <summary>
		/// Log exception with given context
		/// </summary>
		void ExceptionFormat<T1, T2, T3, T4>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

		/// <summary>
		/// Log exception with given context
		/// </summary>
		void ExceptionFormat<T1, T2, T3, T4, T5>(ILogContext context, string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

		/// <summary>
		/// Log exception with given context
		/// </summary>
		void ExceptionFormat(ILogContext context, string msg, params object[] args);
	}
}
