using UniModules.UniCore.Runtime.Utils;

namespace UniModules.UniGame.CodeWriter.Editor.UnityTools
{
    using Core.EditorTools.Editor.Tools;
    using global::CodeWriter.Editor.UnityTools;

    public static class UnityCodeWriterExtensions
    {
        private static MemorizeItem<string, string> _fileContentCache = MemorizeTool.Memorize<string, string>(
            targetPath =>
            {
                if (string.IsNullOrEmpty(targetPath))
                    return string.Empty;

                var result = EditorFileUtils.ReadContent(targetPath, false);
                return result.content;
            });

        public static bool CreateScript(this ScriptData scriptData, string path,bool force = false)
        {
            var result = EditorFileUtils.WriteAssetsContent(path,scriptData.Convert() );

            return result;
        }

        public static bool CreateScript(this string scriptData, string path)
        {
            return EditorFileUtils.WriteAssetsContent(path, scriptData);
        }

        public static bool WriteUnityFile(this string scriptValue,string path,bool force = false)
        {
            var content = _fileContentCache[path];

            if (string.IsNullOrEmpty(scriptValue))
                return false;

            if (!force && scriptValue.Equals(content))
                return false;

            var result = EditorFileUtils.WriteAssetsContent(path,scriptValue);
            if (result)
                _fileContentCache[path] = scriptValue;

            return result;
        }

        public static void ReadUnityFile(this string path, out string content, bool createIfNonExists = false)
        {
            var result = EditorFileUtils.ReadContent(path,createIfNonExists );
            content = result.content;
        }
    }
}
