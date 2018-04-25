using System.IO;
using UnityEngine;
using UDBase.Utils;
using UDBase.Controllers.LogSystem;
using Zenject;

namespace UDBase.Controllers.ConfigSystem {

	/// <summary>
	/// Config controller, which uses JSON file (located on remote web server), serialized via Fullserializer.
	/// How to use:
	/// 1. Save config in your client Resources
	/// 2. When config update is required, upload new version to your web server
	/// 3. Client starts with default config in Resources and tries to load stored config from data path immediately
	/// 4. Client tries to load new config from web server at the same time
	/// 5. If config not loaded to data path yet, Resources config is used
	/// 6. When config loaded from web server, it saved to data path and used
	/// 7. If config can't be loaded because of some problem, but loaded previously to data path, it used from here
	/// </summary>
	public sealed class FsJsonNetworkConfig : FsJsonBaseConfig, ILogContext, IInitializable {
		readonly NetUtils            _net;
		readonly string              _url;
		readonly IConfig             _embeddedFallback;
		readonly Config.JsonSettings _loadedSettings;

		IConfig  _loadedFallback;

		public FsJsonNetworkConfig(Config.JsonNetworkSettings settings, NetUtils net, ILog log) : base(log) {
			_loadedSettings   = settings;
			_net              = net;
			_url              = settings.GetFullConfigUrl();
			_embeddedFallback = new FsJsonResourcesConfig(settings, log);

			InitLoadedFallback();
			InitNodes(settings.Items);
		}

		void InitLoadedFallback() {
			_loadedFallback = new FsJsonDataConfig(_loadedSettings, _log);
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
				SaveContent(configContent);
			}
		}

		void SaveContent(string configContent) {
			var path = Path.Combine(Application.persistentDataPath, _loadedSettings.FileName + ".json");
			IOTool.WriteAllText(path, configContent);
			InitLoadedFallback();
		}

		public override bool IsReady() {
			return _loadedFallback.IsReady();
		}

		public override T GetNode<T>() {
			if ( IsReady() ) {
				return _loadedFallback.GetNode<T>();
			} else {
				return _embeddedFallback.GetNode<T>();
			}
		}
	}
}