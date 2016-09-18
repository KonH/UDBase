using UnityEngine;
using System;
using System.IO;
using System.Collections;

namespace UDBase.Utils {
	public static class IOTool {

		public static string GetPath(params string[] path) {
			var result = path[0];
			for(int i = 1; i < path.Length; i++) {
				result = Path.Combine(result, path[i]);
			}
			return result;
		}

		public static bool DirectoryExist(string path) {
			return Directory.Exists(path);
		}

		public static bool CreateDirectory(string path) {
			try {
				Directory.CreateDirectory(path);
				return true;
			} catch (Exception e) {
				Debug.LogErrorFormat("Exception while create directory at '{0}': {1}", path, e.ToString());
				return false;
			}
		}

		public static bool DeleteDirectory(string path, bool recursive, bool silent = false) {
			try {
				Directory.Delete(path, recursive);
				return true;
			} catch (Exception e) {
				Debug.LogErrorFormat("Exception while delete directory at '{0}': {1}", path, e.ToString());
				return false;
			}
		}

		public static FileInfo[] GetDirFiles(string path, string searchPattern) {
			try {
				var dir = new DirectoryInfo(path);
				return dir.GetFiles(searchPattern);
			} catch (Exception e) {
				Debug.LogErrorFormat("Exception while get files from directory at '{0}': {1}", path, e.ToString());
				return new FileInfo[0];
			}
		}

		public static void WriteAllText(string path, string contents) {
			try {
				File.WriteAllText(path, contents);
			}
			catch (Exception e) {
				Debug.LogErrorFormat("Exception while write text to '{0}': {1}", path, e.ToString());
			}
		}

		public static string ReadAllText(string path) {
			try {
				return File.ReadAllText(path);
			}
			catch (Exception e) {
				Debug.LogErrorFormat("Exception while read file from '{0}': {1}", path, e.ToString());
				return null;
			}
		}

		public static bool CopyFile(string originPath, string destinationPath) {
			try {
				File.Copy(originPath, destinationPath);
				return true;
			}
			catch (Exception e) {
				Debug.LogErrorFormat("Exception while copy file from '{0}' to {1}: {2}", 
					originPath, destinationPath, e.ToString());
				return false;
			}
		}

		public static bool DeleteFile(string path) {
			try {
				File.Delete(path);
				return true;
			}
			catch (Exception e) {
				Debug.LogErrorFormat("Exception while delete file from '{0}': {1}", path, e.ToString());
				return false;
			}
		}

		public static bool Open(string path, bool silent = false) {
			try {
				string trimmedPath = path.TrimEnd(new[]{'\\', '/'});
				System.Diagnostics.Process.Start(trimmedPath);
				return true;
			} catch (Exception e) {
				if( !silent ) {
					Debug.LogErrorFormat("Exception while open file at '{0}': {1}", path, e.ToString());
				}
				return false;
			}
		}
	}
}
