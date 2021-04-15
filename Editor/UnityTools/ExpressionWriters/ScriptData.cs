using System.Collections.Generic;

namespace CodeWriter.Editor.UnityTools
{
    public class ScriptData : IExpressionItem
    {
        private static ScriptWriter _writer = new ScriptWriter();

        public string Namespace = string.Empty;
        public string Name = string.Empty;
        public bool IsStatic = true;
        public bool IsPublic = true;
        public bool IsPartial = false;
        public bool IsSerializable = false;

        public List<string> BaseReferences = new List<string>();
        public List<string> Usings = new List<string>();
        public List<string> Methods = new List<string>();
        public List<string> Properties = new List<string>();

        public string Convert() => _writer.CreateScript(this);
    }
}
