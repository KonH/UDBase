using System.Xml;
using UnityEngine;

namespace UDBase.EditorTools {
	public static class CSProjUpdater {
		
		public static void UpdateCsprojFile(string assemblyName) {
			var fileName = assemblyName + ".csproj";
			var docName = assemblyName + ".xml";

			var doc = new XmlDocument();
			doc.Load(fileName);

			// <PropertyGroup>
			//    <DocumentationFile>$(OutputPath)Assembly-CSharp.xml</DocumentationFile>
			// </PropertyGroup>
			var namespaceUri = doc.LastChild.Attributes["xmlns"].Value;
			var group = doc.CreateElement("PropertyGroup", namespaceUri);
			var docFile = doc.CreateElement("DocumentationFile", namespaceUri);
			docFile.InnerText = $"$(OutputPath){docName}";
			group.AppendChild(docFile);

			doc.LastChild.AppendChild(group);

			Debug.Log($"Xml documentation generation added to project '{assemblyName}' (file: '{fileName}', docs: '{docName}')");

			// Windows:
			// <Target Name="PostBuild" AfterTargets="PostBuildEvent">
			//    <Exec Command="call cd $(SolutionDir)Tools\&#xD;&#xA;call &quot;$(SolutionDir)Tools\GenerateDocs.bat&quot;" />
			// </Target>

			// Mac:
			// <Target Name="PostBuild" AfterTargets="PostBuildEvent">
			//    <Exec Command="cd $(SolutionDir)Tools &amp;&amp; ./GenerateDocs.sh" />
			// </Target>

			var execCommand = GetGenerateDocExecForPlatform(Application.platform);

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
					commandAttr.Value = execCommand;
					exec.Attributes.Append(commandAttr);
				}
				target.AppendChild(exec);
			}
			doc.LastChild.AppendChild(target);

			Debug.Log($"Markdown post-process successfully added to project '{assemblyName}' (file: '{fileName}', docs: '{docName}')");

			doc.Save(fileName);
		}

		static string GetGenerateDocExecForPlatform(RuntimePlatform platform) {
			switch ( platform ) {
				case RuntimePlatform.WindowsEditor : return "call cd $(SolutionDir)Tools\ncall \"$(SolutionDir)Tools\\GenerateDocs.bat\"";
				case RuntimePlatform.OSXEditor     : return "cd $(SolutionDir)Tools && ./GenerateDocs.sh";
				default: throw new System.NotSupportedException("Not supported platform");
			}
		}
	}
}
