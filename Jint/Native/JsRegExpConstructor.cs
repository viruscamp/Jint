using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Jint.Expressions;

namespace Jint.Native {
    [Serializable]
    public class JsRegExpConstructor : JsConstructor {
        public JsRegExpConstructor(IGlobal global)
            : base(global) {
            Name = "RegExp";
            DefineOwnProperty(PROTOTYPE, global.ObjectClass.New(this), PropertyAttributes.DontConfigure | PropertyAttributes.DontEnum | PropertyAttributes.ReadOnly);
        }

        public override void InitPrototype(IGlobal global) {
            var Prototype = PrototypeProperty;
            //Prototype = global.ObjectClass.New(this);

            Prototype.DefineOwnProperty("toString", global.FunctionClass.New<JsObjectBase>(ToStringImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("toLocaleString", global.FunctionClass.New<JsObjectBase>(ToStringImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("lastIndex", global.FunctionClass.New<JsRegExp>(GetLastIndex), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("exec", global.FunctionClass.New<JsRegExp>(ExecImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("test", global.FunctionClass.New<JsRegExp>(TestImpl), PropertyAttributes.DontEnum);
        }

        public IJsInstance GetLastIndex(JsRegExp regex, IJsInstance[] parameters) {
            return regex["lastIndex"];
        }

        public JsRegExp New() {
            return New(String.Empty, false, false, false);
        }

        public JsRegExp New(string pattern, bool g, bool i, bool m) {
            var ret = new JsRegExp(pattern, g, i, m, PrototypeProperty);
            ret["source"] = Global.StringClass.New(pattern);
            ret["lastIndex"] = Global.NumberClass.New(0);
            ret["global"] = Global.BooleanClass.New(g);

            return ret;
        }

        public IJsInstance ExecImpl(JsRegExp regexp, IJsInstance[] parameters) {
            JsArray A = Global.ArrayClass.New();
            string input = parameters[0].ToString();
            A["input"] = Global.StringClass.New(input);

            int i = 0;
            MatchCollection matches = Regex.Matches(input, regexp.Pattern, regexp.Options);
            if (matches.Count > 0) {
                if (regexp.IsGlobal) {
                    foreach (Match m in matches) {
                        A[Global.NumberClass.New(i++)] = Global.StringClass.New(m.Value);
                    }
                }
                else {
                    foreach (Group g in matches[0].Groups) {
                        A[Global.NumberClass.New(i++)] = Global.StringClass.New(g.Value);
                    }
                }

                A["index"] = Global.NumberClass.New(matches[0].Index);
            }

            return A;
        }

        public IJsInstance TestImpl(JsRegExp regex, IJsInstance[] parameters) {
            return Global.BooleanClass.New(ExecImpl(regex, parameters) != JsNull.Instance);
        }

        public override IJsInstance Execute(IJintVisitor visitor, JsObjectBase that, IJsInstance[] parameters) {
            if (parameters.Length == 0) {
                return visitor.Return(New());
                //throw new ArgumentNullException("pattern");
            }

            return visitor.Return(New(parameters[0].ToString(), false, false, false));
        }

        public IJsInstance ToStringImpl(JsObjectBase target, IJsInstance[] parameters) {
            return Global.StringClass.New(target.ToString());
        }
    }
}
