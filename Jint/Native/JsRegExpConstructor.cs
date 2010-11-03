using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Jint.Expressions;

namespace Jint.Native
{
    [Serializable]
    public class JsRegExpConstructor : JsConstructor
    {
        public JsRegExpConstructor(IGlobal global)
            : base(global)
        {
            Name = "RegExp";
            DefineOwnProperty(PROTOTYPE, global.ObjectClass.New(this), PropertyAttributes.DontDelete | PropertyAttributes.DontEnum | PropertyAttributes.ReadOnly );
        }

        public override void InitPrototype(IGlobal global)
        {
            var Prototype = PrototypeProperty;
            //Prototype = global.ObjectClass.New(this);
            
            Prototype.DefineOwnProperty("toString", global.FunctionClass.New<JsDictionaryObject>(ToStringImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("toLocaleString", global.FunctionClass.New<JsDictionaryObject>(ToStringImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("lastIndex", global.FunctionClass.New<JsRegExp>(GetLastIndex), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("exec", global.FunctionClass.New<JsRegExp>(ExecImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("test", global.FunctionClass.New<JsRegExp>(TestImpl), PropertyAttributes.DontEnum);
        }

        public JsInstance GetLastIndex(JsRegExp regex, JsInstance[] parameters)
        {
            return regex["lastIndex"];
        }

        public JsRegExp New()
        {
            return New(String.Empty, false, false, false);
        }

        public JsRegExp New(string pattern, bool g, bool i, bool m)
        {
            var ret = new JsRegExp(pattern, g, i, m, PrototypeProperty);
            ret["source"] = Global.StringClass.New(pattern);
            ret["lastIndex"] = Global.NumberClass.New(0);
            ret["global"] = Global.BooleanClass.New(g);

            return ret;
        }

        public JsInstance ExecImpl(JsRegExp regexp, JsInstance[] parameters)
        {
            var R = regexp;
            var S = parameters[0].ToString();
            var length = S.Length;
            var lastIndex = R["lastIndex"];
            var i = lastIndex.ToInteger();
            var global = R.IsGlobal;
            
            if (global == false)
                i = 0;

            Match r = null;
            MatchCollection rs = null;
            var matchSucceeded = false;
            while (matchSucceeded == false) 
            {
                if (i < 0 || i > length) 
                {
                    R["lastIndex"] = Global.NumberClass.New(0);
                    return JsNull.Instance;
                }

                rs = ((Regex)regexp.Value).Matches(S, i);

                if (rs.Count == 0) {
                    i++;
                }
                else {
                    r = rs[0];
                    matchSucceeded = true;
                }

            }

            var e = r.Index + r.Length;

            if (R.IsGlobal) {
                R["lastIndex"] = Global.NumberClass.New(e);
            }

            var n = r.Groups.Count;
            JsArray A = Global.ArrayClass.New();
            var matchIndex = r.Index;
            A["index"] = Global.NumberClass.New(matchIndex);
            A["input"] = Global.StringClass.New(S);

            if (regexp.IsGlobal) {
                for (i = 0; i < rs.Count; i++) {
                    A[Global.NumberClass.New(i)] = Global.StringClass.New(rs[i].Value);
                }
            }
            else {
                for (i = 0; i < r.Groups.Count; i++) {
                    A[Global.NumberClass.New(i)] = Global.StringClass.New(r.Groups[i].Value);
                }
            }

            return A;
        }

        public JsInstance TestImpl(JsRegExp regex, JsInstance[] parameters)
        {
            return Global.BooleanClass.New(ExecImpl(regex, parameters) != JsNull.Instance);
        }

        public override JsInstance Execute(IJintVisitor visitor, JsDictionaryObject that, JsInstance[] parameters)
        {
            if (parameters.Length == 0)
            {
                return visitor.Return(New());
                //throw new ArgumentNullException("pattern");
            }

            return visitor.Return(New(parameters[0].ToString(), false, false, false));
        }

        public JsInstance ToStringImpl(JsDictionaryObject target, JsInstance[] parameters)
        {
            return Global.StringClass.New(target.ToString());
        }
    }
}
