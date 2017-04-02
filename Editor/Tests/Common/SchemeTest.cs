using NUnit.Framework;
using UDBase.Common;
using UDBase.Controllers;

namespace UDBase.Tests {
	public class SchemeTest {

		class SchemeEmptyMock:Scheme {}
		class EmptyController:IController {
			public virtual void Init() {}
			public virtual void PostInit() {}
			public virtual void Reset() {}
		}
		class EmptyHelper:ControllerHelper<EmptyController> {}

		[Test]
		public void AddController_Normal() {
			var controller = new EmptyController();
			var helper = new EmptyHelper();
			var mock = new SchemeEmptyMock();
			mock.AddController(helper, controller);
			Assert.AreEqual(true, mock.HasController(controller));
			Assert.AreEqual(true, mock.HasControllerHelper(controller));
			Assert.AreSame(helper, mock.GetControllerHelper(controller));
			mock.Init();
		}

		class WrongController:EmptyController {
			public override void Init() {
				throw new System.NotImplementedException();
			}
		}

		[Test]
		public void AddController_Wrong() {
			var controller = new WrongController();
			var helper = new EmptyHelper();
			var mock = new SchemeEmptyMock();
			mock.AddController(helper, controller);
			Assert.AreEqual(true, mock.HasController(controller));
			Assert.AreEqual(true, mock.HasControllerHelper(controller));
			Assert.AreSame(helper, mock.GetControllerHelper(controller));
			Assert.Throws<System.NotImplementedException>(() => mock.Init());
		}

		[Test]
		public void AddController_NullHelper() {
			using ( new LogHandler() ) {
				var controller = new EmptyController();
				EmptyHelper helper = null;
				var mock = new SchemeEmptyMock();
				mock.AddController(helper, controller);
				Assert.AreEqual(false, mock.HasController(controller));
				Assert.AreEqual(false, mock.HasControllerHelper(controller));
				Assert.IsNull(mock.GetControllerHelper(controller));
				mock.Init();
			}
		}

		[Test]
		public void AddController_NullController() {
			EmptyController controller = null;
			var helper = new EmptyHelper();
			var mock = new SchemeEmptyMock();
			mock.AddController(helper, controller);
			Assert.AreEqual(false, mock.HasController(controller));
			Assert.AreEqual(false, mock.HasControllerHelper(controller));
			Assert.IsNull(mock.GetControllerHelper(controller));
			mock.Init();
		}

		[Test]
		public void AddController_BothNull() {
			using ( new LogHandler() ) {
				EmptyController controller = null;
				EmptyHelper helper = null;
				var mock = new SchemeEmptyMock();
				mock.AddController(helper, controller);
				Assert.AreEqual(false, mock.HasController(controller));
				Assert.AreEqual(false, mock.HasControllerHelper(controller));
				Assert.IsNull(mock.GetControllerHelper(controller));
				mock.Init();
			}
		}
	}
}