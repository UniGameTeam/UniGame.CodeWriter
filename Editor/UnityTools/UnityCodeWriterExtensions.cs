namespace UniModules.UniGame.CodeWriter.Editor.UnityTools
{
    using global::CodeWriter.Editor.UnityTools;

    public static class UnityCodeWriterExtensions
    {

        public static bool CreateScript(this ScriptData scriptData, string path)
        {
            return UnityFileWriter.WriteAssetsContent(path, scriptData.Convert());
        }

        public static bool WriteUnityFile(this string path, string content)
        {
            return UnityFileWriter.WriteAssetsContent(path, content);
        }

        public static void ReadUnityFile(this string path, out string content, bool createIfNonExists = false)
        {
            var result = UnityFileWriter.ReadContent(path,createIfNonExists );
            content = result.content;
        }
    }
}
