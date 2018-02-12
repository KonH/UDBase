using UDBase.Utils;
using NUnit.Framework;

namespace UDBase.Tests {
	class RandomUtilsTests {

		[SetUp]
		public void Setup() {
			TestUtils.EnableUnityAssertExceptions();
		}

		[Test]
		public void RangeExcluded_ExcludedItemsNotPresent() {
			var exclude = new int[] { 1 };
			for ( var i = 0; i < 100; i++ ) {
				Assert.False(RandomUtils.RangeExcluded(0, 3, exclude) == exclude[0]);
			}
		}

		[Test]
		public void RangeExcluded_OnlyForNonEmptySets() {
			TestUtils.ThrowsAssert(() => RandomUtils.RangeExcluded(0, 3, new int[] { 0, 1, 2 }));
		}

		[Test]
		public void GetEnumValue_OnlyForEnums() {
			TestUtils.ThrowsAssert(() => RandomUtils.GetEnumValue<int>());
		}

		enum EmptyEnum { }
		
		[Test]
		public void GetEnumValue_OnlyForNonEmptyEnums() {
			TestUtils.ThrowsAssert(() => RandomUtils.GetEnumValue<EmptyEnum>());
		}
	}
}
