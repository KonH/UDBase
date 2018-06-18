namespace UDBase.Controllers.LogSystem {
	/// <summary>
	/// Logger provides shorter version of logging, can be created by ILog.CreateLogger.
	/// Notes:
	/// All these boilerplate is required to avoid additional allocation for params usage. 
	/// Generics is required to avoid boxing in valye type cases.
	/// </summary>
	public struct ULogger {
		readonly ILog        _log;
		readonly ILogContext _context;

		public ULogger(ILog log, ILogContext context) {
			_log     = log;
			_context = context;
		}

		/// <summary>
		/// Log message with current context
		/// </summary>
		public void Message(string msg) {
			_log.Message(_context, msg);
		}

		/// <summary>
		/// Log message with current context
		/// </summary>
		public void MessageFormat<T1>(string msg, T1 arg1) {
			_log.MessageFormat(_context, msg, arg1);
		}

		/// <summary>
		/// Log message with current context
		/// </summary>
		public void MessageFormat<T1, T2>(string msg, T1 arg1, T2 arg2) {
			_log.MessageFormat(_context, msg, arg1, arg2);
		}

		/// <summary>
		/// Log message with current context
		/// </summary>
		public void MessageFormat<T1, T2, T3>(string msg, T1 arg1, T2 arg2, T3 arg3) {
			_log.MessageFormat(_context, msg, arg1, arg2, arg3);
		}

		/// <summary>
		/// Log message with current context
		/// </summary>
		public void MessageFormat<T1, T2, T3, T4>(string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			_log.MessageFormat(_context, msg, arg1, arg2, arg3, arg4);
		}

		/// <summary>
		/// Log message with current context
		/// </summary>
		public void MessageFormat<T1, T2, T3, T4, T5>(string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			_log.MessageFormat(_context, msg, arg1, arg2, arg3, arg4, arg5);
		}

		/// <summary>
		/// Log message with current context
		/// </summary>
		public void MessageFormat(string msg, params object[] args) {
			_log.MessageFormat(_context, msg, args);
		}


		/// <summary>
		/// Log warning with current context
		/// </summary>
		public void Warning(string msg) {
			_log.Warning(_context, msg);
		}

		/// <summary>
		/// Log warning with current context
		/// </summary>
		public void WarningFormat<T1>(string msg, T1 arg1) {
			_log.WarningFormat(_context, msg, arg1);
		}

		/// <summary>
		/// Log warning with current context
		/// </summary>
		public void WarningFormat<T1, T2>(string msg, T1 arg1, T2 arg2) {
			_log.WarningFormat(_context, msg, arg1, arg2);
		}

		/// <summary>
		/// Log warning with current context
		/// </summary>
		public void WarningFormat<T1, T2, T3>(string msg, T1 arg1, T2 arg2, T3 arg3) {
			_log.WarningFormat(_context, msg, arg1, arg2, arg3);
		}

		/// <summary>
		/// Log warning with current context
		/// </summary>
		public void WarningFormat<T1, T2, T3, T4>(string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			_log.WarningFormat(_context, msg, arg1, arg2, arg3, arg4);
		}

		/// <summary>
		/// Log warning with current context
		/// </summary>
		public void WarningFormat<T1, T2, T3, T4, T5>(string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			_log.WarningFormat(_context, msg, arg1, arg2, arg3, arg4, arg5);
		}

		/// <summary>
		/// Log warning with current context
		/// </summary>
		public void WarningFormat(string msg, params object[] args) {
			_log.WarningFormat(_context, msg, args);
		}


		/// <summary>
		/// Log assert with current context
		/// </summary>
		public void Assert(string msg) {
			_log.Assert(_context, msg);
		}

		/// <summary>
		/// Log assert with current context
		/// </summary>
		public void AssertFormat<T1>(string msg, T1 arg1) {
			_log.AssertFormat(_context, msg, arg1);
		}

		/// <summary>
		/// Log assert with current context
		/// </summary>
		public void AssertFormat<T1, T2>(string msg, T1 arg1, T2 arg2) {
			_log.AssertFormat(_context, msg, arg1, arg2);
		}

		/// <summary>
		/// Log assert with current context
		/// </summary>
		public void AssertFormat<T1, T2, T3>(string msg, T1 arg1, T2 arg2, T3 arg3) {
			_log.AssertFormat(_context, msg, arg1, arg2, arg3);
		}

		/// <summary>
		/// Log assert with current context
		/// </summary>
		public void AssertFormat<T1, T2, T3, T4>(string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			_log.AssertFormat(_context, msg, arg1, arg2, arg3, arg4);
		}

		/// <summary>
		/// Log assert with current context
		/// </summary>
		public void AssertFormat<T1, T2, T3, T4, T5>(string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			_log.AssertFormat(_context, msg, arg1, arg2, arg3, arg4, arg5);
		}

		/// <summary>
		/// Log assert with current context
		/// </summary>
		public void AssertFormat(string msg, params object[] args) {
			_log.AssertFormat(_context, msg, args);
		}


		/// <summary>
		/// Log error with current context
		/// </summary>
		public void Error(string msg) {
			_log.Error(_context, msg);
		}

		/// <summary>
		/// Log error with current context
		/// </summary>
		public void ErrorFormat<T1>(string msg, T1 arg1) {
			_log.ErrorFormat(_context, msg, arg1);
		}

		/// <summary>
		/// Log error with current context
		/// </summary>
		public void ErrorFormat<T1, T2>(string msg, T1 arg1, T2 arg2) {
			_log.ErrorFormat(_context, msg, arg1, arg2);
		}

		/// <summary>
		/// Log error with current context
		/// </summary>
		public void ErrorFormat<T1, T2, T3>(string msg, T1 arg1, T2 arg2, T3 arg3) {
			_log.ErrorFormat(_context, msg, arg1, arg2, arg3);
		}

		/// <summary>
		/// Log error with current context
		/// </summary>
		public void ErrorFormat<T1, T2, T3, T4>(string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			_log.ErrorFormat(_context, msg, arg1, arg2, arg3, arg4);
		}

		/// <summary>
		/// Log error with current context
		/// </summary>
		public void ErrorFormat<T1, T2, T3, T4, T5>(string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			_log.ErrorFormat(_context, msg, arg1, arg2, arg3, arg4, arg5);
		}

		/// <summary>
		/// Log error with current context
		/// </summary>
		public void ErrorFormat(string msg, params object[] args) {
			_log.ErrorFormat(_context, msg, args);
		}



		/// <summary>
		/// Log exception with current context
		/// </summary>
		public void Exception(string msg) {
			_log.Exception(_context, msg);
		}

		/// <summary>
		/// Log exception with current context
		/// </summary>
		public void ExceptionFormat<T1>(string msg, T1 arg1) {
			_log.ExceptionFormat(_context, msg, arg1);
		}

		/// <summary>
		/// Log exception with current context
		/// </summary>
		public void ExceptionFormat<T1, T2>(string msg, T1 arg1, T2 arg2) {
			_log.ExceptionFormat(_context, msg, arg1, arg2);
		}

		/// <summary>
		/// Log exception with current context
		/// </summary>
		public void ExceptionFormat<T1, T2, T3>(string msg, T1 arg1, T2 arg2, T3 arg3) {
			_log.ExceptionFormat(_context, msg, arg1, arg2, arg3);
		}

		/// <summary>
		/// Log exception with current context
		/// </summary>
		public void ExceptionFormat<T1, T2, T3, T4>(string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			_log.ExceptionFormat(_context, msg, arg1, arg2, arg3, arg4);
		}

		/// <summary>
		/// Log exception with current context
		/// </summary>
		public void ExceptionFormat<T1, T2, T3, T4, T5>(string msg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			_log.ExceptionFormat(_context, msg, arg1, arg2, arg3, arg4, arg5);
		}

		/// <summary>
		/// Log exception with current context
		/// </summary>
		public void ExceptionFormat(string msg, params object[] args) {
			_log.ExceptionFormat(_context, msg, args);
		}
	}
}
