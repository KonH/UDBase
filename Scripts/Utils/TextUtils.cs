using System;
using System.Text;

namespace UDBase.Utils {
	/// <summary>
	/// Utils for text processing
	/// </summary>
	public static class TextUtils {

		/// <summary>
		/// Returns given value or non-null empty string if value is null
		/// </summary>
		public static string EnsureString(string value) {
			return value != null ? value : ""; 
		}

		/// <summary>
		/// Remove all white-spaces and control chars from given string
		/// </summary>
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

		/// <summary>
		/// Check given strings is equals without all white-spaces and control chars inside
		/// </summary>
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

		/// <summary>
		/// Trim all single and double quotes from given string 
		/// </summary>
		public static string TrimQuotes(string text) {
			return text?.Trim('\"', '\'');
		}
	}
}
