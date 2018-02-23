namespace UDBase.Controllers.UserSystem {

	/// <summary>
	/// Event, which fired when user name was changed
	/// </summary>
	public struct User_NameChange {

		/// <summary>
		/// New user name
		/// </summary>
		public string Name { get; private set; }

		public User_NameChange(string name) {
			Name = name;
		}
	}

	/// <summary>
	/// Event, which fired when user extenal id was changed
	/// </summary>
	public struct User_ExternalIdChange {

		/// <summary>
		/// New provider (or provider with changed id)
		/// </summary>
		public string Provider { get; private set; }

		/// <summary>
		/// New id
		/// </summary>
		public string Value { get; private set; }

		public User_ExternalIdChange(string provider, string value) {
			Provider = provider;
			Value = value;
		}
	}
}
