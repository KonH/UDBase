using UDBase.Utils;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.ConfigSystem {

	/// <summary>
	/// Config controller, which uses JSON file (located on remote web server), serialized via Fullserializer
	/// </summary>
	public sealed class FsJsonNetworkConfig : FsJsonBaseConfig, ILogContext {

		// TODO:
		// - Fix parsing issue
		// - Load config from web server
		// -- Local
		// -- konhit.xyz
		// - Use unity web request caching instead of dataConfig?
		// - IsReady usage & example
		// - Reload
		// - Blocking errors?
		// - Preloading

		readonly NetUtils _net;

		readonly IConfig _embeddedFallback;

		bool _isReady = false;

		public FsJsonNetworkConfig(Config.JsonNetworkSettings settings, NetUtils net, ILog log) : base(log) {
			_net = net;

			_embeddedFallback = new FsJsonResourcesConfig(settings, log);

			InitNodes(settings.Items);

			TryLoadConfig(settings.GetFullConfigUrl());
		}

		void TryLoadConfig(string url) {
			_net.SendGetRequest(url, onComplete: OnConfigLoaded);
		}

		void OnConfigLoaded(NetUtils.Response response) {
			if ( !response.HasError ) {
				LoadContent(response.Text);
				_isReady = true;
			}
		}

		public override bool IsReady() {
			return _isReady;
		}

		public override void Reload() {
			// TODO
		}

		public override T GetNode<T>() {
			if ( IsReady() ) {
				return base.GetNode<T>();
			} else {
				return _embeddedFallback.GetNode<T>();
			}
		}
	}
}