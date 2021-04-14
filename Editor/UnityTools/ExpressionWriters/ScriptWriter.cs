using UnityEngine;

namespace CodeWriter.Editor.UnityTools
{
    using System;

    public class ScriptWriter
    {
        public const string PublicModifier = "public";
        public const string StaticModifier = "static";
        public const string PrivateModifier = "private";
        public const string PartialModifier = "partial";
        public const string Namespace = "namespace";

        public string CreateScript(ScriptData scriptData)
        {
            var methods= scriptData.Methods;
            var writer           = new CodeWriter(CodeWriterSettings.CSharpDefault);
            var namespaceValue = string.IsNullOrEmpty(scriptData.Namespace) == false
                ? scriptData.Namespace.StartsWith(Namespace, StringComparison.OrdinalIgnoreCase)
                    ?
                    scriptData.Namespace
                    :
                    $"{Namespace} {scriptData.Namespace}"
                : string.Empty;

            using (writer.B(namespaceValue)) {
                foreach (var dataUsing in scriptData.Usings) {
                    writer._($"using {dataUsing};");
                }

                writer._(string.Empty);

                var publicValue = scriptData.IsPublic ?
                    PublicModifier :
                    PrivateModifier;
                var staticValue = scriptData.IsStatic ? StaticModifier : String.Empty;
                var className = CodeWriter.RemoveSpecialCharacters(scriptData.Name);
                var partial = scriptData.IsPartial ? PartialModifier : String.Empty;
                var baseClass = string.IsNullOrEmpty(scriptData.BaseReference)
                    ? string.Empty
                    : $": {scriptData.BaseReference}";
                var serializable = scriptData.IsSerializable ? $"[{nameof(SerializableAttribute)}]" : String.Empty;

                using (writer.B($"{serializable}{publicValue} {staticValue} {partial} class {className} {baseClass}")) {

                    foreach (var property in scriptData.Properties)
                    {
                        writer._($"{property}\n");
                    }

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
