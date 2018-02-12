using System.Xml;

namespace UDBase.EditorTools {
	public static class CSProjUpdater {
		
		public static void UpdateCsprojFile(string fileName) {
			var doc = new XmlDocument();
			doc.Load(fileName);

			// <PropertyGroup>
			//    <DocumentationFile>$(OutputPath)Assembly-CSharp.xml</DocumentationFile>
			// </PropertyGroup>
			var namespaceUri = doc.LastChild.Attributes["xmlns"].Value;
			var group = doc.CreateElement("PropertyGroup", namespaceUri);
			var docFile = doc.CreateElement("DocumentationFile", namespaceUri);
			docFile.InnerText = "$(OutputPath)Assembly-CSharp.xml";
			group.AppendChild(docFile);

			doc.LastChild.AppendChild(group);

			doc.Save(fileName);

			UnityEngine.Debug.Log($"Xml documentation generation added to project '{fileName}'");
		}
	}
}
