namespace UniModules.UniGame.CodeWriter.Editor.UnityTools
{
    using global::CodeWriter.Editor.UnityTools;

    public static class UnityCodeWriterExtensions
    {
        public static bool CreateScript(this ScriptData scriptData, string path)
        {
            return UnityFileWriter.WriteAssetsContent(path, scriptData.Convert());
        }
    }
}
