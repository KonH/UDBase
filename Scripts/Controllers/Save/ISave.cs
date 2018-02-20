namespace UDBase.Controllers.SaveSystem {

	/// <summary>
	/// Using ISave methods you can load and save runtime specific data (any custom class derived from ISaveSource).
	/// ISaveSource implementation is required only for ClassTypeReference filtering.
	/// All nodes need to added in controller settings.
	/// You can make inner controller state as private nested class for controller and control all changes via this controller methods.
	/// </summary>
	public interface ISave {

		/// <summary>
		/// Return node for given type (if it isn't exists and autoFill is set to 'true', it will be created)
		/// </summary>
		T GetNode<T>(bool autoFill = true) where T:ISaveSource;

		/// <summary>
		/// Save new or updated node
		/// </summary>
		void SaveNode<T>(T node) where T:ISaveSource;
	}
}
