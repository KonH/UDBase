using UDBase.Utils;
using UDBase.Controllers.LogSystem;
using Zenject;

namespace UDBase.Controllers.ConfigSystem {

	/// <summary>
	/// Config controller, which uses JSON file (located on remote web server), serialized via Fullserializer
	/// </summary>
	public sealed class FsJsonNetworkConfig : FsJsonBaseConfig, ILogContext, IInitializable {

		// TODO:
		// + Fix parsing issue
		// + Load config from web server
		// ++ Local
		// ++ konhit.xyz
		// - IsReady usage & example
		// - Reload
		// + Preloading

		readonly NetUtils _net;
		readonly string   _url;
		readonly IConfig  _embeddedFallback;

		bool _isReady = false;

		public FsJsonNetworkConfig(Config.JsonNetworkSettings settings, NetUtils net, ILog log) : base(log) {
			_net              = net;
			_url              = settings.GetFullConfigUrl();
			_embeddedFallback = new FsJsonResourcesConfig(settings, log);
			InitNodes(settings.Items);
		}

		public void Initialize() {
			TryLoadConfig(_url);
		}

		void TryLoadConfig(string url) {
			_net.SendGetRequest(url, onComplete: OnConfigLoaded);
		}

		void OnConfigLoaded(NetUtils.Response response) {
			if ( !response.HasError ) {
				var configContent = TextUtils.TrimFileContent(response.Text);
				LoadContent(configContent);
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