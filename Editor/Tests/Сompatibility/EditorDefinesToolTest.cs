using System;
using UnityEditor;
using NUnit.Framework;
using UDBase.EditorTools;

namespace UDBase.Tests {
	public class EditorDefinesToolTest {

		[Test]
		public void ConvertBuildTargetTest()
		{
			var currentBuildTargets = Enum.GetValues(typeof(BuildTarget));
			var iter = currentBuildTargets.GetEnumerator();
			while(iter.MoveNext()) {
				var target = (BuildTarget)iter.Current;
				if( IsCorrentTarget(target) ) {
					var group = BuildTargetGroup.Unknown;
					TestDelegate convertDelegate = delegate {
						group = EditorDefinesTool.ConvertBuildTarget(target);
					};
					Assert.DoesNotThrow(convertDelegate, "Failed to convert " + target); 
					Assert.AreNotEqual(BuildTargetGroup.Unknown, group, "Failed to convert " + target);
				}
			}
		}

		bool IsCorrentTarget(BuildTarget target) {
			if( target == BuildTarget.NoTarget ) {
				return false;
			}
			var type = typeof(BuildTarget);
			var memInfo = type.GetMember(target.ToString());
			var attributes = memInfo[0].GetCustomAttributes(typeof(ObsoleteAttribute),
				false);
			return attributes.Length == 0;
		}
	}
}
