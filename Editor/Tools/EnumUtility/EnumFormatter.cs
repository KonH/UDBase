using System;
using System.Text;
using System.Collections.Generic;

namespace UDBase.Editor.Tools.EnumUtility {
	public class EnumFormatter {
		const string HeaderFormat = "public enum {0} {{\n";
		const string BodyFormat   = "\t{0} = {1},\n";
		const string Footer       = "}";
	
		public virtual string MakeEnumContent(EnumInfo info) {
			var sb = new StringBuilder();
			sb.AppendFormat(HeaderFormat, info.BaseType.Name);
			foreach (var pair in info.Values) {
				sb.AppendFormat(BodyFormat, pair.Key, pair.Value);
			}
			sb.Remove(sb.Length - 2, 1);
			sb.Append(Footer);
			return sb.ToString();
		}
	}
}
