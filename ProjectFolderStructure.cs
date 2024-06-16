using UnityEngine;

using UnityEditor;
using UnityEngine;

public class ProjectFolderStructure
{
	[MenuItem("Tools/Create Project Folders")]
	private static void CreateProjectFolders()
	{
		// Base directories
		string[] baseFolders = {
			"Assets/Art",
			"Assets/Audio",
			"Assets/Materials",
			"Assets/Prefabs",
			"Assets/Scripts",
			"Assets/Scenes",
			"Assets/Textures",
			"Assets/Animations",
			"Assets/Editor",
			"Assets/Resources"
		};

		// Subdirectories
		string[][] subFolders = {
			new string[] { "Assets/Art/3D", "Assets/Art/2D" },
			new string[] { "Assets/Audio/Music", "Assets/Audio/SFX" },
			new string[] { },
			new string[] { },
			new string[] { },
			new string[] { },
			new string[] { },
			new string[] { },
			new string[] { },
			new string[] { "Assets/Resources/Prefabs", "Assets/Resources/Materials" }
		};

		for (int i = 0; i < baseFolders.Length; i++)
		{
			if (!AssetDatabase.IsValidFolder(baseFolders[i]))
			{
				AssetDatabase.CreateFolder("Assets", baseFolders[i].Split('/')[1]);
			}

			foreach (string subFolder in subFolders[i])
			{
				string parentFolder = subFolder.Substring(0, subFolder.LastIndexOf('/'));
				string newFolderName = subFolder.Substring(subFolder.LastIndexOf('/') + 1);

				if (!AssetDatabase.IsValidFolder(subFolder))
				{
					AssetDatabase.CreateFolder(parentFolder, newFolderName);
				}
			}
		}

		AssetDatabase.Refresh();
		Debug.Log("Project folders created successfully!");
	}
}