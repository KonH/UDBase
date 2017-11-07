using System;
using System.Text;

namespace UDBase.Utils {
	public static class TextUtils {
		public static string EnsureString(string value) {
			return value != null ? value : ""; 
		}

		public static string RemoveWhitespaces(string str) {
			var sb = new StringBuilder(str.Length);
			foreach ( var c in str ) {
				if ( char.IsWhiteSpace(c) || char.IsControl(c) ) {
					continue;
				}
				sb.Append(c);
			}
			return sb.ToString();
		}

		public static bool EqualsIgnoreWhitespaces(
			string leftStr, string rightStr,
			StringComparison comparison = StringComparison.Ordinal) {
			if ( (leftStr == null) || (rightStr == null) ) {
				return false;
			}
			var normLeft  = RemoveWhitespaces(leftStr );
			var normRight = RemoveWhitespaces(rightStr);
			return normLeft.Equals(normRight, comparison);
		}
	}
}
