namespace UDBase.Controllers.SaveSystem {
	public interface ISave {		
		T GetNode<T>(bool autoFill = true) where T:ISaveSource;
		void SaveNode<T>(T node) where T:ISaveSource;
	}
}
