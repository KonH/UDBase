namespace UDBase.Controllers.UserSystem {

	/// <summary>
	/// IUser is a simple storage for user information.
	/// If you need to store additinal ids, assigned to current user,
	/// you can get it on your side and add using AddExternalId(),
	/// after it you can get it using FindExternalId()
	/// </summary>
	public interface IUser {

		/// <summary>
		/// Unique id of user (if required)
		/// </summary>
		string Id { get; set; }

		/// <summary>
		/// User name to display
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Finds the external identifier for given provider
		/// </summary>
		string FindExternalId(string provider);

		/// <summary>
		/// Adds the external identifier for given provider
		/// </summary>
		void AddExternalId(string provider, string id);
	}
}