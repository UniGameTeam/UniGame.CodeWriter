namespace UniModules.UniGame.CodeWriter.Editor.UnityTools
{
    using Core.EditorTools.Editor.Tools;
    using global::CodeWriter.Editor.UnityTools;

    public static class UnityCodeWriterExtensions
    {

        public static bool CreateScript(this ScriptData scriptData, string path)
        {
            return EditorFileUtils.WriteAssetsContent(path, scriptData.Convert());
        }

        public static bool CreateScript(this string scriptData, string path)
        {
            return EditorFileUtils.WriteAssetsContent(path, scriptData);
        }

        public static bool WriteUnityFile(this string content,string path)
        {
            return EditorFileUtils.WriteAssetsContent(path, content);
        }

        public static void ReadUnityFile(this string path, out string content, bool createIfNonExists = false)
        {
            var result = EditorFileUtils.ReadContent(path,createIfNonExists );
            content = result.content;
        }
    }
}
