using System;
using System.Collections.Generic;
using UDBase.Utils;
using UDBase.Controllers.LogSystem;
using FullSerializer;

namespace UDBase.Controllers.LeaderboardSystem {
	public class WebLeaderboard : ILeaderboard {

		string       _url        = null;
		string       _gameName   = null;
		WebClient    _client     = null;
		fsSerializer _serializer = new fsSerializer();

		public string Version { get; set; }

		public WebLeaderboard(string url, string gameName, string gameVersion, string clientName, string clientPassword) {
			Version   = gameVersion;
			_url      = url;
			_gameName = gameName;
			_client   = new WebClient(clientName, clientPassword);
		}

		public void Init() { }

		public void PostInit() { }

		public void Reset() { }

		string FormatGetScoresUrl(int max, string parameter) {
			return string.Format("{0}/api/Score/top/{1}", _url, _gameName);
		}

		bool IsCorrectResponse(NetUtils.Response response) {
			return !(response.HasError || response.Timeout || response.IsEmpty);
		}

		public void GetScores(int max, string parameter, Action<List<LeaderboardItem>> callback) {
			var url = FormatGetScoresUrl(max, parameter);
			_client.SendGetRequest(url, onComplete: (response) => OnGetScoresComplete(response, callback));
		}

		void OnGetScoresComplete(NetUtils.Response response, Action<List<LeaderboardItem>> callback) {
			List<LeaderboardItem> result = null;
			if ( IsCorrectResponse(response) ) {
				var data = fsJsonParser.Parse(response.Text);
				_serializer.TryDeserialize(data, ref result);
			} else {
				Log.ErrorFormat("Wrong response: {0}, '{1}'", LogTags.Network, response.Code, response.Text);
			}
			if ( callback != null ) {
				callback(result);
			}
		}
	}
}
