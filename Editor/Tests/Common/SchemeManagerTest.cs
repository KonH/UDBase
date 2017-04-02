using NUnit.Framework;
using UDBase.Common;

namespace UDBase.Tests {
	public class SchemeManagerTest {

		class SchemeMock:Scheme {}

		[Test]
		public void ApplyScheme_Normal() {
			var scheme = new SchemeMock();
			var manager = new SchemeManager();
			manager.ApplyScheme(scheme);
			Assert.AreSame(scheme, manager.CurrentScheme);
		}

		[Test]
		public void ApplyScheme_Null() {
			using ( new LogHandler() ) {
				SchemeMock scheme = null;
				var manager = new SchemeManager();
				manager.ApplyScheme(scheme);
				Assert.IsNull(manager.CurrentScheme);
			}
		}
	}
}