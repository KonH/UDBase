namespace UDBase.Controllers.ConfigSystem {

	/// <summary>
	/// Using IConfig you can simple load data for your classes.
	/// You need to define class inherited from IConfigSource and add it to settings, after it you can read data, defined in it.
	/// One node per type is allowed.
	/// </summary>
	public interface IConfig {

		/// <summary>
		/// Method to safe reload config in expected place
		/// </summary>
		void Reload();

		/// <summary>
		/// Is current config instance ready to use
		/// </summary>
		bool IsReady();

		/// <summary>
		/// Gets the node of specific type
		/// </summary>
		T GetNode<T>() where T:IConfigSource;
	}
}
