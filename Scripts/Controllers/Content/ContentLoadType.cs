namespace UDBase.Controllers.ContentSystem {

	/// <summary>
	/// Content load type
	/// </summary>
	public enum ContentLoadType {

		/// <summary>
		/// Invalid loading type
		/// </summary>
		None = 0,

		/// <summary>
		/// Load directly from project assets
		/// </summary>
		Direct = 1,

		/// <summary>
		/// Load from asset bundle
		/// </summary>
		AssetBundle = 2
	}
}
