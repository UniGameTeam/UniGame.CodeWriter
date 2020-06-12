using System;
using System.Collections.Generic;
using CodeWriter;

namespace CodeWriter.Demo
{
    using UnityEngine;

    public class DemoClass
    {
        public DemoClass()
        {
            var s = new CodeWriterSettings(CodeWriterSettings.CSharpDefault);
            s.NewLineBeforeBlockBegin = false;
            s.TranslationMapping["`"] = "\"";

            var w = new CodeWriter(s);

            using (w.B("class Test"))
            {
                using (w.B("public int Sum(int a, int b)"))
                {
                    w._("var r = a + b;",
                        "return r;");
                }

                using (w.B("public int Mul(int a, int b)"))
                {
                    w._("var r = `a * b`;",
                        "return r;");
                }
            }
            w.HeadLines = new List<string>
            {
                "// COMMENT1",
                "// COMMENT2",
                "",
                "using System;",
                "",
            };

            Debug.Log(w.ToString());
        }
    }
}
