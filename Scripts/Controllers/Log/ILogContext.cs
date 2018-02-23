namespace UDBase.Controllers.LogSystem {

	/// <summary>
	/// Interface to use ILog methods.
	/// If you need logs for specific class, you can simply derive from it.
	/// If you need some common context or required logs in static methods, you can use static class instance for it.
	/// This interface is required only for ClassTypeReference filtering.
	/// </summary>
	public interface ILogContext { }
}
