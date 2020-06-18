using System.IO;
using UnityEngine;

namespace UniModules.UniGame.CodeWriter.Editor.UnityTools
{
    using System;
    using System.Linq;
    using Sirenix.Utilities;
    using UnityEditor;

    public static class UnityFileWriter
    {
        private static string assetsFolderName = "Assets";
        public static bool WriteAssetsContent(string targetPath, string content)
        {
            if (string.IsNullOrEmpty(targetPath))
                return false;

            var result = ReadContent(targetPath, false);
            var path = result.path;
            var activeContent = result.content;

            if (string.Equals(activeContent, content)) {
                return false;
            }

            File.WriteAllText(path,content);

            Debug.Log($"WRITE CONTENT TO {path}");

            AssetDatabase.Refresh();

            return true;
        }

        public static (string path,string content) ReadContent(string targetPath, bool createIfNotExists = false)
        {
            if (string.IsNullOrEmpty(targetPath))
                return (string.Empty,string.Empty);

            if (targetPath.StartsWith(assetsFolderName, StringComparison.OrdinalIgnoreCase)) {
                targetPath = targetPath.Remove(0, assetsFolderName.Length);
            }

            var path = Combine(Application.dataPath, targetPath);

            ValidateDirectories(path);

            var fileExists = File.Exists(path);
            if (!fileExists && createIfNotExists) {
                File.WriteAllText(path,string.Empty);
                AssetDatabase.Refresh();
                return (path,string.Empty);
            }

            var activeContent = fileExists ?
                File.ReadAllText(path) :
                string.Empty;

            return (path,activeContent);
        }

        /// <summary>
        /// Combines two paths, and replaces all backslases with forward slash.
        /// </summary>
        public static string Combine(string a, string b)
        {
            a = a.Replace("\\", "/").TrimEnd('/');
            b = b.Replace("\\", "/").TrimStart('/');
            return a + "/" + b;
        }

        public static string ValidateUnityPath(this string path)
        {
            if (string.IsNullOrEmpty(path))
                return path;
            return path.Replace("\\", "/").TrimEnd('/');
        }

        public static string[] SplitPath(this string path)
        {
            return path.Split('/').ToArray();
        }

        public static void ValidateDirectories(string sourcePath)
        {
            var directoryPath = Path.GetDirectoryName(sourcePath);
            var directories = directoryPath.ValidateUnityPath();
            var path = string.Empty;
            if (string.IsNullOrEmpty(directoryPath) == false) {
                var folders = SplitPath(directories);

                foreach (var folder in folders) {
                    if (string.IsNullOrEmpty(path)) {
                        path = folder;
                        continue;
                    }
                    path = Combine(path,folder);
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
