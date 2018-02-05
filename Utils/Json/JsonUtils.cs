using System;
using UDBase.Controllers.LogSystem;
using FullSerializer;

namespace UDBase.Utils.Json {
	public static class JsonUtils {
		public static T Deserialize<T>(fsSerializer serializer, ILog log, string json) where T:new() {
			try {
				var data = fsJsonParser.Parse(json);
				var result = new T();
				serializer.TryDeserialize(data, ref result);
				return result;
			} catch ( Exception e ) {
				log.ErrorFormat(LogTags.Common, "Serialize: exception: {0}", e);
			}
			return default(T);
		}

		public static object Deserialize(fsSerializer serializer, ILog log, string json, Type type) {
			try {
				var data = fsJsonParser.Parse(json);
				object result = null;
				serializer.TryDeserialize(data, type, ref result);
				return result;
			} catch ( Exception e ) {
				log.ErrorFormat(LogTags.Common, "Serialize: exception: {0}", e);
			}
			return null;
		}

		public static string Serialize<T>(fsSerializer serializer, ILog log, T item, bool pretty = true) where T : new() {
			try {
				fsData data;
				serializer.TrySerialize(typeof(T), item, out data);
				var result = pretty ? fsJsonPrinter.PrettyJson(data) : fsJsonPrinter.CompressedJson(data);
				return result;
			} catch ( Exception e ) {
				log.ErrorFormat(LogTags.Common, "Serialize: exception: {0}", e);
			}
			return null;
		}
	}
}
