using System;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Utils;
using UDBase.Controllers.LogSystem;
using FullSerializer;

namespace UDBase.Controllers.LeaderboardSystem {

	/// <summary>
	/// Leaderboard implementation uses web server with API described here:
	/// https://github.com/KonH/LeaderboardService
	/// 
	/// Examples:
	/// Get scores:
	/// GET {url}/api/Score/top/{game}?max={max}&amp;param={param}&amp;version={version}
	/// 
	/// Post scores:
	/// POST {url}/api/Score/
	/// {
	///    "game": "{game}",
	///    "version": "{version}",
	///    "param": "{param}",
	///    "score": {playerScore},
	///    "user": "{playerName}",
	/// }
	/// 
	/// For authorization Basic Auth is used by default
	/// </summary>
	public class WebLeaderboard : ILeaderboard, ILogContext {

		/// <summary>
		/// Backend access parameters
		/// </summary>
		[Serializable]
		public class Settings {

			/// <summary>
			/// Base URL of leaderboard service
			/// </summary>
			[Tooltip("Base URL of leaderboard service")]
			public string Url;

			/// <summary>
			/// The {game} url parameter
			/// </summary>
			[Tooltip("The {game} url parameter")]
			public string GameName;

			/// <summary>
			/// The {version} url parameter
			/// </summary>
			[Tooltip("The {version} url parameter")]
			public string GameVersion;

			/// <summary>
			/// Basic Auth UserName
			/// </summary>
			[Tooltip("Basic Auth UserName")]
			public string ClientName;

			/// <summary>
			/// Basic Auth Password
			/// </summary>
			[Tooltip("Basic Auth Password")]
			public string ClientPassword;
		}

		readonly string                     _url;
		readonly string                     _gameName;
		readonly WebClient                  _client;
		readonly fsSerializer               _serializer  = new fsSerializer();
		readonly Dictionary<string, string> _postHeaders = new Dictionary<string, string>();

		public string Version { get; set; }

		ULogger _log;

		public WebLeaderboard(Settings settings, ILog log, WebClient client) {
			_log      = log.CreateLogger(this);
			Version   = settings.GameVersion;
			_url      = settings.Url;
			_gameName = settings.GameName;
			_client   = client;
			_client.AddUserData(settings.ClientName, settings.ClientPassword);
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
				_log.ErrorFormat("Wrong response: {0}, '{1}'", response.Code, response.Text);
			}
			callback?.Invoke(result);
		}

		public void PostScore(string parameter, string playerName, int score, Action<bool> callback) {
			var item = new LeaderboardItem(_gameName, Version, parameter, playerName, score);
			fsData data = null;
			_serializer.TrySerialize(item, out data);
			var dataString = data.ToString();
			_log.MessageFormat("Serialized score item: '{0}'", dataString);
			var postUrl = $"{_url}/api/Score";
			_client.SendJsonPostRequest(
				postUrl, dataString, headers: _postHeaders, onComplete: (response) => OnPostScoreComplete(response, callback)
			);
		}

		void OnPostScoreComplete(NetUtils.Response response, Action<bool> callback) {
			var result = false;
			if ( IsCorrectResponse(response) && response.Code == 201 ) {
				result = true;
			} else {
				_log.ErrorFormat("Wrong response: {0}, '{1}'", response.Code, response.Text);
			}
			callback?.Invoke(result);
		}
	}
}
