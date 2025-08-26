using System.IO;
using UnityEditor;
using UnityEngine.Device;
using static System.IO.Directory;
using static UnityEditor.AssetDatabase;
using static System.IO.Path;
using static UnityEngine.Application;

namespace _Game.Scripts.Editor
{
    public static class DirectoryStructureCreator
    {
        [MenuItem("Tools/Setup/Create Directory Structure")]
        public static void CreateDirectoryStructure()
        {
            CreateDirectories("_Game", "Scripts", "Data", "Resources", "Scenes");
            CreateDirectories("_Game", "Data/Audio", "Data/Sprites");
            CreateDirectories("_Game", "Scripts/Core", "Scripts/Features", "Scripts/Common", "Scripts/Utilities", "Scripts/Test");

            Refresh();
            
           
        }
        private static void CreateDirectories(string root, params string[] dir)
        {
            var fullPath = Combine(dataPath, root);
            foreach (var directory in dir)
            {
                CreateDirectory(Combine(fullPath, directory));
            }
        }
    }
}