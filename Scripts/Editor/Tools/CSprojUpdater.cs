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

			UnityEngine.Debug.Log($"Xml documentation generation added to project '{fileName}'");

			// <Target Name="PostBuild" AfterTargets="PostBuildEvent">
			//    <Exec Command="call cd $(SolutionDir)Tools\&#xD;&#xA;call &quot;$(SolutionDir)Tools\GenerateDocs.bat&quot;" />
			// </Target>
			var target = doc.CreateElement("Target", namespaceUri);
			{
				var nameAttr = doc.CreateAttribute("Name");
				nameAttr.Value = "PostBuild";
				target.Attributes.Append(nameAttr);

				var targetAttr = doc.CreateAttribute("AfterTargets");
				targetAttr.Value = "PostBuildEvent";
				target.Attributes.Append(targetAttr);

				var exec = doc.CreateElement("Exec", namespaceUri);
				{

					var commandAttr = doc.CreateAttribute("Command");
					commandAttr.Value = "call cd $(SolutionDir)Tools\ncall \"$(SolutionDir)Tools\\GenerateDocs.bat\"";
					exec.Attributes.Append(commandAttr);
				}
				target.AppendChild(exec);
			}
			doc.LastChild.AppendChild(target);

			UnityEngine.Debug.Log($"Markdown post-process added to project '{fileName}'");

			doc.Save(fileName);

		}
	}
}
