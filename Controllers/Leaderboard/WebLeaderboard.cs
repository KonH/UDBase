using System;
using System.Collections.Generic;
using UDBase.Utils;
using UDBase.Controllers.LogSystem;
using FullSerializer;

namespace UDBase.Controllers.LeaderboardSystem {
	public class WebLeaderboard : ILeaderboard {
		readonly string                     _url;
		readonly string                     _gameName;
		readonly WebClient                  _client;
		readonly fsSerializer               _serializer  = new fsSerializer();
		readonly Dictionary<string, string> _postHeaders = new Dictionary<string, string>();

		public string Version { get; set; }

		public WebLeaderboard(string url, string gameName, string gameVersion, string clientName, string clientPassword) {
			Version   = gameVersion;
			_url      = url;
			_gameName = gameName;
			_client   = new WebClient(clientName, clientPassword);
			_postHeaders.Add("Content-Type", "application/json");
		}

		string FormatGetScoresUrl(int max, string parameter) {
			var url = string.Format("{0}/api/Score/top/{1}?max={2}", _url, _gameName, max);
			if ( !string.IsNullOrEmpty(parameter) ) {
				url += string.Format("&param={0}", parameter);
			}
			if ( !string.IsNullOrEmpty(Version) ) {
				url += string.Format("&version={0}", Version);
			}
			return url;
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
				Log.ErrorFormat("Wrong response: {0}, '{1}'", LogTags.Leaderboard, response.Code, response.Text);
			}
			if ( callback != null ) {
				callback(result);
			}
		}

		public void PostScore(string param, string userName, int score, Action<bool> callback) {
			var item = new LeaderboardItem(_gameName, Version, param, userName, score);
			fsData data = null;
			_serializer.TrySerialize(item, out data);
			var dataString = data.ToString();
			Log.MessageFormat("Serialized score item: '{0}'", LogTags.Leaderboard, dataString);
			var url = "https://konhit.xyz/lbservice/api/Score";
			_client.SendJsonPostRequest(url, dataString, headers: _postHeaders, onComplete: (response) => OnPostScoreComplete(response, callback));
		}

		void OnPostScoreComplete(NetUtils.Response response, Action<bool> callback) {
			var result = false;
			if ( IsCorrectResponse(response) && response.Code == 201 ) {
				result = true;
			} else {
				Log.ErrorFormat("Wrong response: {0}, '{1}'", LogTags.Leaderboard, response.Code, response.Text);
			}
			if ( callback != null ) {
				callback(result);
			}
		}
	}
}
