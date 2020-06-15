using UnityEngine;

namespace CodeWriter.Editor.UnityTools
{
    using System;

    public class ScriptWriter
    {
        public const string PublicModifier = "public";
        public const string StaticModifier = "static";
        public const string PrivateModifier = "private";

        public string CreateScript(ScriptData scriptData)
        {
            var methods= scriptData.Methods;
            var writer           = new CodeWriter(CodeWriterSettings.CSharpDefault);

            using (writer.B(scriptData.Namespace)) {
                foreach (var dataUsing in scriptData.Usings) {
                    writer._($"using {dataUsing};");
                }

                var publicValue = scriptData.IsPublic ?
                    PublicModifier :
                    PrivateModifier;
                var staticValue = scriptData.IsStatic ? StaticModifier : String.Empty;
                var className = CodeWriter.RemoveSpecialCharacters(scriptData.Name);

                using (writer.B($"{publicValue} {staticValue} class {className}")) {
                    foreach (var buildMethod in scriptData.Methods) {
                        var method = buildMethod;
                        writer._($"{method}\n");
                    }
                }

            }

            return writer.ToString();
        }


    }
}
