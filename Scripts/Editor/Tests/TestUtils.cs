using NUnit.Framework;

namespace UDBase.Tests {
	static class TestUtils {

		public static void EnableUnityAssertExceptions() {
			UnityEngine.Assertions.Assert.raiseExceptions = true;
		}

		public static UnityEngine.Assertions.AssertionException ThrowsAssert(TestDelegate code) {
			return Assert.Throws<UnityEngine.Assertions.AssertionException>(code);
		}
	}
}
