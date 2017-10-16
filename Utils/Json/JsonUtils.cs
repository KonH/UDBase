using System;
using UDBase.Controllers.LogSystem;
using FullSerializer;

namespace UDBase.Utils.Json {
	public static class JsonUtils {
		public static T Serialize<T>(string json) where T:new() {
			var serializer = new fsSerializer();
			try {
				var data = fsJsonParser.Parse(json);
				var result = new T();
				serializer.TryDeserialize(data, ref result);
				return result;
			} catch ( Exception e ) {
				Log.ErrorFormat("Serialize: exception: {0}", LogTags.Common, e);
			}
			return default(T);
		}
	}
}
