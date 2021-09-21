namespace UnityCodeGen.Ast
{
    public class PropertyNode
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public AccessType Visibility { get; set; }
        public AccessType SetVisibility { get; set; }

        public bool IsStatic { get; set; }
    }
}
