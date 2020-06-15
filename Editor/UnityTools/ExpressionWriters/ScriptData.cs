namespace CodeWriter.Editor.UnityTools
{
    public class ScriptData : IExpressionItem
    {
        private static ScriptWriter _writer = new ScriptWriter();

        public string   Namespace = string.Empty;
        public string   Name      = string.Empty;
        public bool     IsStatic  = true;
        public bool     IsPublic  = true;
        public string[] Usings    = new string[0];
        public string[] Methods   = new string[0];

        public string Convert() => _writer.CreateScript(this);
    }
}
