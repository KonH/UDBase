using System.IO;
using NUnit.Framework;
using UDBase.Common;

namespace UDBase.Tests {
	public class ConfigCheckTest {

		[Test]
		public void SchemeTemplatePath() { 
			Assert.IsTrue(File.Exists(UDBaseConfig.SchemeTemplatePath));
		}

		[Test]
		public void MenuTemplatePath() {
			Assert.IsTrue(File.Exists(UDBaseConfig.MenuTemplatePath));		
		}

		[Test]
		public void MenuItemTemplatePath() {
			Assert.IsTrue(File.Exists(UDBaseConfig.MenuItemTemplatePath));
		}

		[Test]
		public void ProjectPath() {
			Assert.IsTrue(Directory.Exists(UDBaseConfig.ProjectPath));
		}

		[Test]
		public void ProjectEditorPath() {
			Assert.IsTrue(Directory.Exists(UDBaseConfig.ProjectEditorPath));
		}

		[Test]
		public void ProjectSchemesPath() {
			Assert.IsTrue(Directory.Exists(UDBaseConfig.ProjectSchemesPath));
		}

		[Test]
		public void ProjectEditorMenuItemsPath() {
			Assert.IsTrue(File.Exists(UDBaseConfig.ProjectEditorMenuItemsPath));
		}
	}
}
