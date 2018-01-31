namespace UDBase.Controllers.SaveSystem {
	public interface ISave {		
		T GetNode<T>(bool autoFill = true);
		void SaveNode<T>(T node);
	}
}
