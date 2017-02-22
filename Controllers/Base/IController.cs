using UnityEngine;
using System.Collections;

namespace UDBase.Controllers {
	
	//Interface for any controller, what can be store in your Scheme
	public interface IController {
		void Init();
		void PostInit();
		void Reset();
	}
}
