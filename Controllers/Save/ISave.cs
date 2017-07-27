namespace UDBase.Controllers.SaveSystem {
	public interface ISave : IController {		
		T GetNode<T>(bool autoFill);
		void SaveNode<T>(T node);
		void Clear();
	}
}
