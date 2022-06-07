namespace UnityCodeGen.Ast
{
    public class PropertyNode
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public AccessType Visibility { get; set; }
        public AccessType SetVisibility { get; set; }

        public string GetBody { get; set; }
        public string SetBody { get; set; }

        public bool IsStatic { get; set; }

        public bool HasGetBody => !string.IsNullOrEmpty(GetBody);
        public bool HasSetBody => !string.IsNullOrEmpty(SetBody);

        public bool HasSet { get; set; }
    }
}
