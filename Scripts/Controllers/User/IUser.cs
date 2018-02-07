namespace UDBase.Controllers.UserSystem {
	public interface IUser {
		string Id            { get; set; }
		string Name          { get; set; }
		string FindExternalId(string provider);
		void   AddExternalId (string provider, string id);
	}
}