namespace UDBase.UI.Common {

	/// <summary>
	/// UI elemenent animation clearing is required when animation has state and it needs to be reset when stopping
	/// </summary>
	public interface IClearAnimation {

		/// <summary>
		/// Clear animation state
		/// </summary>
		void Clear();
	}
}
