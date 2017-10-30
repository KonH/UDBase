using System;
using UDBase.Controllers.LogSystem;
using FullSerializer;

namespace UDBase.Utils.Json {
	public static class JsonUtils {
		public static T Deserialize<T>(string json) where T:new() {
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

		public static object Deserialize(string json, Type type) {
			var serializer = new fsSerializer();
			try {
				var data = fsJsonParser.Parse(json);
				object result = null;
				serializer.TryDeserialize(data, type, ref result);
				return result;
			} catch ( Exception e ) {
				Log.ErrorFormat("Serialize: exception: {0}", LogTags.Common, e);
			}
			return null;
		}

		public static string Serialize<T>(T item, bool pretty = true) where T : new() {
			var serializer = new fsSerializer();
			try {
				fsData data;
				serializer.TrySerialize(typeof(T), item, out data);
				var result = pretty ? fsJsonPrinter.PrettyJson(data) : fsJsonPrinter.CompressedJson(data);
				return result;
			} catch ( Exception e ) {
				Log.ErrorFormat("Serialize: exception: {0}", LogTags.Common, e);
			}
			return null;
		}
	}
}
