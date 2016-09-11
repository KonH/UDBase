using UnityEngine;
using System.Collections;
using System.Text;

namespace UDBase.Utils.Json {
	public class JsonNodeHolder {
		public string Name    {get; private set;}
		public string Content {get; private set;}

		StringBuilder _builder = new StringBuilder(1000);

		public JsonNodeHolder(string name) {
			Name = name;
		}

		// Read
		public void AddContent(string item) {
			_builder.Append(item);
		}

		public void FillContent() {
			Content = _builder.ToString();
		}

		// Write
		public void Write(string content) {
			Content = content;
		}
	}
}
