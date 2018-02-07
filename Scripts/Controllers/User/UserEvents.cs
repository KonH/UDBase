namespace UDBase.Controllers.UserSystem {
	public struct User_NameChange {
		public string Name { get; private set; }

		public User_NameChange(string name) {
			Name = name;
		}
	}

	public struct User_ExternalIdChange {
		public string Provider { get; private set; }
		public string Value { get; private set; }

		public User_ExternalIdChange(string provider, string value) {
			Provider = provider;
			Value = value;
		}
	}
}
