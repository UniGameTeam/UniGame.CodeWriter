using System.IO;
using UnityEngine;

namespace UniModules.UniGame.CodeWriter.Editor.UnityTools
{
    using UnityEditor;

    public static class UnityFileWriter
    {
        public static bool WriteAssetsContent(string targetPath, string content)
        {
            if (string.IsNullOrEmpty(targetPath))
                return false;

            var path    = Application.dataPath;
            path = Path.Combine(path,targetPath);

            ValidateDirectories(path);

            var activeContent = File.Exists(path) ?
                File.ReadAllText(path) :
                string.Empty;

            if (string.Equals(activeContent, content)) {
                return false;
            }

            File.WriteAllText(path,content);

            Debug.Log($"WRITE CONTENT TO {path}");

            AssetDatabase.Refresh();

            return true;
        }

        public static void ValidateDirectories(string path)
        {
            var directories = Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(directories) == false) {
                var folders = Directory.GetDirectories(directories);

                foreach (var folder in folders) {
                    path = Path.Combine(path,folder);
                    if (Directory.Exists(path)) {
                        continue;
                    }

                    Debug.Log(path);
                    Directory.CreateDirectory(path);
                }
            }
        }
    }
}
