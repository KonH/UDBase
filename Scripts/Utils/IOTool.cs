using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Utils {
	/// <summary>
	/// Input/output helpers
	/// </summary>
	public static class IOTool {

		/// <summary>
		/// Exception-safe helper for Directory.CreateDirectory (silent = 'no log output')
		/// </summary>
		public static bool CreateDirectory(string path, bool silent = false) {
			try {
				Directory.CreateDirectory(path);
				return true;
			} catch (Exception e) {
				if( !silent ) {
					Debug.LogErrorFormat("Exception while create directory at '{0}': {1}", path, e);
				}
				return false;
			}
		}

		/// <summary>
		/// Exception-safe helper for Directory.Delete (silent = 'no log output')
		/// </summary>
		public static bool DeleteDirectory(string path, bool recursive, bool silent = false) {
			try {
				Directory.Delete(path, recursive);
				return true;
			} catch (Exception e) {
				Debug.LogErrorFormat("Exception while delete directory at '{0}': {1}", path, e);
				return false;
			}
		}

		/// <summary>
		/// Exception-safe helper for new DirectoryInfo().GetFiles(); (silent = 'no log output')
		/// </summary>
		public static FileInfo[] GetDirFiles(string path, string searchPattern, bool silent = false) {
			try {
				var dir = new DirectoryInfo(path);
				return dir.GetFiles(searchPattern);
			} catch (Exception e) {
				if( !silent ) {
					Debug.LogErrorFormat("Exception while get files from directory at '{0}': {1}", path, e);
				}
				return new FileInfo[0];
			}
		}

		/// <summary>
		/// Exception-safe helper for File.WriteAllText (silent = 'no log output')
		/// </summary>
		public static void WriteAllText(string path, string contents, bool silent = false) {
			try {
				File.WriteAllText(path, contents);
			} catch (Exception e) {
				if( !silent ) {
					Debug.LogErrorFormat("Exception while write text to '{0}': {1}", path, e);
				}
			}
		}

		/// <summary>
		/// Exception-safe helper for File.WriteAllLines (silent = 'no log output')
		/// </summary>
		public static void WriteAllLines(string path, IEnumerable<string> contents, bool silent = false) {
			try {
				File.WriteAllLines(path, contents);
			} catch (Exception e) {
				if( !silent ) {
					Debug.LogErrorFormat("Exception while write lines to '{0}': {1}", path, e);
				}
			}
		}

		/// <summary>
		/// Exception-safe helper for File.ReadAllText (silent = 'no log output')
		/// </summary>
		public static string ReadAllText(string path, bool silent = false) {
			try {
				return File.ReadAllText(path);
			} catch (Exception e) {
				if( !silent ) {
					Debug.LogErrorFormat("Exception while read file from '{0}': {1}", path, e);
				}
				return null;
			}
		}

		/// <summary>
		/// Exception-safe helper for File.ReadAllLines (silent = 'no log output')
		/// </summary>
		public static string[] ReadAllLines(string path, bool silent = false) {
			try {
				return File.ReadAllLines(path);
			} catch (Exception e) {
				if( !silent ) {
					Debug.LogErrorFormat("Exception while read file from '{0}': {1}", path, e);
				}
				return null;
			}
		}

		/// <summary>
		/// Exception-safe helper for File.Copy (silent = 'no log output')
		/// </summary>
		public static bool CopyFile(string originPath, string destinationPath, bool silent = false) {
			try {
				File.Copy(originPath, destinationPath);
				return true;
			} catch (Exception e) {
				if( !silent ) {
					Debug.LogErrorFormat("Exception while copy file from '{0}' to {1}: {2}", 
						originPath, destinationPath, e);
				}
				return false;
			}
		}

		/// <summary>
		/// Exception-safe helper for File.Create (silent = 'no log output')
		/// </summary>
		public static bool CreateFile(string path, bool silent = false) {
			try {
				var fs = File.Create(path);
				fs.Close();
				return true;
			} catch (Exception e) {
				if( !silent ) {
					Debug.LogErrorFormat("Exception while create file '{0}': {1}", path, e);
				}
				return false;
			}
		}

		/// <summary>
		/// Exception-safe helper for File.Delete (silent = 'no log output')
		/// </summary>
		public static bool DeleteFile(string path, bool silent = false) {
			try {
				File.Delete(path);
				return true;
			} catch (Exception e) {
				if( !silent ) {
					Debug.LogErrorFormat("Exception while delete file from '{0}': {1}", path, e);
				}
				return false;
			}
		}

		/// <summary>
		/// Exception-safe helper for open file/directory (silent = 'no log output')
		/// </summary>
		public static bool Open(string path, bool silent = false) {
			try {
				var trimmedPath = path.TrimEnd(new[]{'\\', '/'});
				System.Diagnostics.Process.Start(trimmedPath);
				return true;
			} catch (Exception e) {
				if( !silent ) {
					Debug.LogErrorFormat("Exception while open file at '{0}': {1}", path, e);
				}
				return false;
			}
		}
	}
}
