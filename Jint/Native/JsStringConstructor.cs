﻿using System;
using System.Collections.Generic;
using System.Text;
using Jint.Delegates;
using System.Text.RegularExpressions;
using Jint.Expressions;

namespace Jint.Native {
    [Serializable]
    public class JsStringConstructor : JsConstructor {
        public JsStringConstructor(IGlobal global)
            : base(global) {
            DefineOwnProperty(PROTOTYPE, global.ObjectClass.New(this), PropertyAttributes.ReadOnly | PropertyAttributes.DontConfigure | PropertyAttributes.DontEnum);
            Name = "String";
        }

        public override void InitPrototype(IGlobal global) {
            var Prototype = PrototypeProperty;

            Prototype.DefineOwnProperty("split", global.FunctionClass.New<JsObjectBase>(SplitImpl, 2), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("replace", global.FunctionClass.New<JsObjectBase>(ReplaceImpl, 2), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("toString", global.FunctionClass.New<JsObjectBase>(ToStringImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("toLocaleString", global.FunctionClass.New<JsObjectBase>(ToStringImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("match", global.FunctionClass.New<JsObjectBase>(MatchFunc), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("localeCompare", global.FunctionClass.New<JsObjectBase>(LocaleCompareImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("substring", global.FunctionClass.New<JsObjectBase>(SubstringImpl, 2), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("substr", global.FunctionClass.New<JsObjectBase>(SubstrImpl, 2), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("search", global.FunctionClass.New<JsObjectBase>(SearchImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("valueOf", global.FunctionClass.New<JsString>(ValueOfImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("concat", global.FunctionClass.New<JsObjectBase>(ConcatImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("charAt", global.FunctionClass.New<JsObjectBase>(CharAtImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("charCodeAt", global.FunctionClass.New<JsObjectBase>(CharCodeAtImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("fromCharCode", global.FunctionClass.New<JsObjectBase>(FromCharCodeImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("lastIndexOf", global.FunctionClass.New<JsObjectBase>(LastIndexOfImpl, 1), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("indexOf", global.FunctionClass.New<JsObjectBase>(IndexOfImpl, 1), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("toLowerCase", global.FunctionClass.New<JsObjectBase>(ToLowerCaseImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("toLocaleLowerCase", global.FunctionClass.New<JsObjectBase>(ToLocaleLowerCaseImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("toUpperCase", global.FunctionClass.New<JsObjectBase>(ToUpperCaseImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("toLocaleUpperCase", global.FunctionClass.New<JsObjectBase>(ToLocaleUpperCaseImpl), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("slice", global.FunctionClass.New<JsObjectBase>(SliceImpl, 2), PropertyAttributes.DontEnum);

            #region Properties
            Prototype.DefineOwnProperty(new PropertyDescriptor<JsObjectBase>(global, Prototype, "length", LengthImpl));
            #endregion
        }

        public JsString New() {
            return New(String.Empty);
        }

        public JsString New(string value) {
            return new JsString(value, PrototypeProperty);
        }

        public override IJsInstance Execute(IJintVisitor visitor, JsObjectBase that, IJsInstance[] parameters) {
            if (that == null || (that as IGlobal) == visitor.Global)
            {
                // 15.5.1 - When String is called as a function rather than as a constructor, it performs a type conversion.
                if (parameters.Length > 0) {
                    return visitor.Return(Global.StringClass.New(parameters[0].ToString()));
                }
                else {
                    return visitor.Return(Global.StringClass.New(String.Empty));
                }
            }
            else {
                // 15.5.2 - When String is called as part of a new expression, it is a constructor: it initialises the newly created object.
                if (parameters.Length > 0) {
                    that.Value = parameters[0].ToString();
                }
                else {
                    that.Value = String.Empty;
                }

                return visitor.Return(that);
            }
        }

        /// <summary>
        /// Used by the String object replace matched pattern
        /// </summary>
        /// <param name="matched"></param>
        /// <param name="before"></param>
        /// <param name="after"></param>
        /// <param name="newString"></param>
        /// <param name="groups"></param>
        /// <returns></returns>
        private static string EvaluateReplacePattern(string matched, string before, string after, string newString, GroupCollection groups) {
            if (newString.Contains("$")) {
                Regex rr = new Regex(@"\$\$|\$&|\$`|\$'|\$\d{1,2}", RegexOptions.Compiled);
                var res = rr.Replace(newString, delegate(Match m) {
                    switch (m.Value) {
                        case "$$": return "$";
                        case "$&": return matched;
                        case "$`": return before;
                        case "$'": return after;
                        default: int n = int.Parse(m.Value.Substring(1)); return n == 0 ? m.Value : groups[n].Value;
                    }
                });

                return res;
            }
            return newString;
        }



        /// <summary>
        /// 15.5.4.2
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public IJsInstance ToStringImpl(JsObjectBase target, IJsInstance[] parameters) {
            return Global.StringClass.New(target.ToString());
        }

        /// <summary>
        /// 15.5.4.3
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsInstance ValueOfImpl(JsString target, IJsInstance[] parameters) {
            return Global.StringClass.New(target.ToString());
        }

        /// <summary>
        /// 15.5.4.4
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsInstance CharAtImpl(JsObjectBase target, IJsInstance[] parameters) {
            return SubstringImpl(target, new IJsInstance[] { parameters[0], Global.NumberClass.New(parameters[0].ToNumber() + 1) });
        }

        /// <summary>
        /// 15.5.4.5
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsInstance CharCodeAtImpl(JsObjectBase target, IJsInstance[] parameters) {
            var r = target.ToString();
            var at = (int)parameters[0].ToNumber();

            if (r == String.Empty || at > r.Length - 1) {
                return Global.NaN;
            }
            else {
                return Global.NumberClass.New(Convert.ToInt32(r[at]));
            }
        }

        /// <summary>
        /// 15.5.3.2
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsInstance FromCharCodeImpl(JsObjectBase target, IJsInstance[] parameters) {
            //var r = target.ToString();

            //if (r == String.Empty || at > r.Length - 1)
            //{
            //    return Global.NaN;
            //}
            //else
            //{
            string result = string.Empty;
            foreach (IJsInstance arg in parameters)
                result += Convert.ToChar(Convert.ToUInt32(arg.ToNumber()));

            return Global.StringClass.New(result);
            //}
        }

        /// <summary>
        /// 15.5.4.6
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public IJsInstance ConcatImpl(JsObjectBase target, IJsInstance[] parameters) {
            StringBuilder sb = new StringBuilder();

            sb.Append(target.ToString());

            for (int i = 0; i < parameters.Length; i++) {
                sb.Append(parameters[i].ToString());
            }

            return Global.StringClass.New(sb.ToString());
        }

        /// <summary>
        /// 15.5.4.7
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public IJsInstance IndexOfImpl(JsObjectBase target, IJsInstance[] parameters) {
            string source = target.ToString();
            string searchString = parameters[0].ToString();
            int position = parameters.Length > 1 ? (int)parameters[1].ToNumber() : 0;

            if (searchString == String.Empty) {
                if (parameters.Length > 1) {
                    return Global.NumberClass.New(Math.Min(source.Length, position));
                }
                else {
                    return Global.NumberClass.New(0);
                }
            }

            if (position >= source.Length) {
                return Global.NumberClass.New(-1);
            }

            return Global.NumberClass.New(source.IndexOf(searchString, position));
        }

        /// <summary>
        /// 15.5.4.8
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public IJsInstance LastIndexOfImpl(JsObjectBase target, IJsInstance[] parameters) {
            string source = target.ToString();
            string searchString = parameters[0].ToString();
            int position = parameters.Length > 1 ? (int)parameters[1].ToNumber() : source.Length;

            return Global.NumberClass.New(source.Substring(0, position).LastIndexOf(searchString));
        }

        /// <summary>
        /// 15.5.4.9
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsInstance LocaleCompareImpl(JsObjectBase target, IJsInstance[] parameters) {
            return Global.NumberClass.New(target.ToString().CompareTo(parameters[0].ToString()));
        }

        /// <summary>
        /// 15.5.4.10
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsInstance MatchFunc(JsObjectBase target, IJsInstance[] parameters) {
            JsRegExp regexp = parameters[0].Class == IJsInstance.CLASS_STRING
                ? Global.RegExpClass.New(parameters[0].ToString(), false, false, false)
                : (JsRegExp)parameters[0];

            return Global.RegExpClass.ExecImpl(regexp, new IJsInstance[] { target });
        }

        /// <summary>
        /// 15.5.4.11
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsInstance ReplaceImpl(JsObjectBase target, IJsInstance[] parameters) {
            if (parameters.Length == 0) {
                return Global.StringClass.New(target.ToString());
            }

            IJsInstance searchValue = parameters[0];
            IJsInstance replaceValue = JsUndefined.Instance;

            if (parameters.Length > 1) {
                replaceValue = parameters[1];
            }

            string source = target.ToString();

            JsFunction function = replaceValue as JsFunction;
            if (searchValue.Class == IJsInstance.CLASS_REGEXP) {
                int count = ((JsRegExp)parameters[0]).IsGlobal ? int.MaxValue : 1;
                var regexp = ((JsRegExp)parameters[0]);
                int lastIndex = regexp.IsGlobal ? 0 : Math.Max(0, (int)regexp["lastIndex"].ToNumber() - 1);

                if (regexp.IsGlobal) {
                    regexp["lastIndex"] = Global.NumberClass.New(0);
                }

                if (replaceValue is JsFunction)
                {
                    string ret = ((JsRegExp)parameters[0]).Regex.Replace(source, delegate(Match m) {
                        List<IJsInstance> replaceParameters = new List<IJsInstance>();
                        if (!regexp.IsGlobal) {
                            regexp["lastIndex"] = Global.NumberClass.New(m.Index + 1);
                        }

                        replaceParameters.Add(Global.StringClass.New(m.Value));
                        for (int i = 1; i < m.Groups.Count; i++) {
                            if (m.Groups[i].Success) {
                                replaceParameters.Add(Global.StringClass.New(m.Groups[i].Value));
                            }
                            else {
                                replaceParameters.Add(JsUndefined.Instance);
                            }
                        }
                        replaceParameters.Add(Global.NumberClass.New(m.Index));
                        replaceParameters.Add(Global.StringClass.New(source));

                        Global.Visitor.ExecuteFunction(function, null, replaceParameters.ToArray());

                        return Global.Visitor.Returned.ToString();
                    }, count, lastIndex);


                    return Global.StringClass.New(ret);

                }
                else {
                    string str = parameters[1].ToString();
                    string ret = ((JsRegExp)parameters[0]).Regex.Replace(target.ToString(), delegate(Match m) {
                        if (!regexp.IsGlobal) {
                            regexp["lastIndex"] = Global.NumberClass.New(m.Index + 1);
                        }

                        string after = source.Substring(Math.Min(source.Length - 1, m.Index + m.Length));
                        return EvaluateReplacePattern(m.Value, source.Substring(0, m.Index), after, str, m.Groups);
                    }, count, lastIndex);

                    return Global.StringClass.New(ret);
                }


            }
            else {
                string search = searchValue.ToString();
                int index = source.IndexOf(search);
                if (index != -1) {
                    if (replaceValue is JsFunction)
                    {
                        List<IJsInstance> replaceParameters = new List<IJsInstance>();
                        replaceParameters.Add(Global.StringClass.New(search));
                        replaceParameters.Add(Global.NumberClass.New(index));
                        replaceParameters.Add(Global.StringClass.New(source));

                        Global.Visitor.ExecuteFunction(function, null, replaceParameters.ToArray());
                        replaceValue = Global.Visitor.Result;

                        return Global.StringClass.New(source.Substring(0, index) + replaceValue.ToString() + source.Substring(index + search.Length));
                    }
                    else {
                        string before = source.Substring(0, index);
                        string after = source.Substring(index + search.Length);
                        string newString = EvaluateReplacePattern(search, before, after, replaceValue.ToString(), null);
                        return Global.StringClass.New(before + newString + after);
                    }
                }
                else {
                    return Global.StringClass.New(source);
                }
            }
        }

        /// <summary>
        /// 15.5.4.12
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsInstance SearchImpl(JsObjectBase target, IJsInstance[] parameters) {
            // Converts the parameters to a regex
            if (parameters[0].Class == IJsInstance.CLASS_STRING) {
                parameters[0] = Global.RegExpClass.New(parameters[0].ToString(), false, false, false);
            }

            Match m = ((JsRegExp)parameters[0]).Regex.Match(target.ToString());

            if (m != null && m.Success) {
                return Global.NumberClass.New(m.Index);
            }
            else {
                return Global.NumberClass.New(-1);
            }
        }

        /// <summary>
        /// 15.5.4.13
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsInstance SliceImpl(JsObjectBase target, IJsInstance[] parameters) {
            string source = target.ToString();
            int start = (int)parameters[0].ToNumber();
            int end = source.Length;
            if (parameters.Length > 1) {
                end = (int)parameters[1].ToNumber();
                if (end < 0) {
                    end = source.Length + end;
                }
            }

            if (start < 0) {
                start = source.Length + start;
            }

            return Global.StringClass.New(source.Substring(start, end - start));
        }

        /// <summary>
        /// 15.5.4.14
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsInstance SplitImpl(JsObjectBase target, IJsInstance[] parameters) {
            JsObject A = Global.ArrayClass.New();
            string S = target.ToString();

            if (parameters.Length == 0 || parameters[0] == JsUndefined.Instance) {
                A["0"] = Global.StringClass.New(S);
            }

            IJsInstance separator = parameters[0];
            int limit = parameters.Length > 1 ? Convert.ToInt32(parameters[1].ToNumber()) : Int32.MaxValue;
            int s = S.Length;
            string[] result;

            if (separator.Class == IJsInstance.CLASS_REGEXP) {
                result = ((JsRegExp)parameters[0]).Regex.Split(S, limit);
            }
            else {
                result = S.Split(new string[] { separator.ToString() }, limit, StringSplitOptions.None);
            }

            for (int i = 0; i < result.Length; i++) {
                A[i.ToString()] = Global.StringClass.New(result[i]);
            }

            return A;
        }

        /// <summary>
        /// 15.5.4.15
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsInstance SubstringImpl(JsObjectBase target, IJsInstance[] parameters) {
            string str = target.ToString();
            int start = 0, end = str.Length;

            if (parameters.Length > 0 && !double.IsNaN(parameters[0].ToNumber())) {
                start = Convert.ToInt32(parameters[0].ToNumber());
            }

            if (parameters.Length > 1 && parameters[1] != JsUndefined.Instance && !double.IsNaN(parameters[1].ToNumber())) {
                end = Convert.ToInt32(parameters[1].ToNumber());
            }

            start = Math.Min(Math.Max(start, 0), Math.Max(0, str.Length - 1));
            end = Math.Min(Math.Max(end, 0), str.Length);
            str = str.Substring(start, end - start);

            return New(str);
        }

        public IJsInstance SubstrImpl(JsObjectBase target, IJsInstance[] parameters) {
            string str = target.ToString();
            int start = 0, end = str.Length;

            if (parameters.Length > 0 && !double.IsNaN(parameters[0].ToNumber())) {
                start = Convert.ToInt32(parameters[0].ToNumber());
            }

            if (parameters.Length > 1 && parameters[1] != JsUndefined.Instance && !double.IsNaN(parameters[1].ToNumber())) {
                end = Convert.ToInt32(parameters[1].ToNumber());
            }

            start = Math.Min(Math.Max(start, 0), Math.Max(0, str.Length - 1));
            end = Math.Min(Math.Max(end, 0), str.Length);
            str = str.Substring(start, end);

            return New(str);
        }

        /// <summary>
        /// 15.5.4.16
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsInstance ToLowerCaseImpl(JsObjectBase target, IJsInstance[] parameters) {
            return Global.StringClass.New(target.ToString().ToLowerInvariant());
        }

        /// <summary>
        /// 15.5.4.17
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsInstance ToLocaleLowerCaseImpl(JsObjectBase target, IJsInstance[] parameters) {
            return Global.StringClass.New(target.ToString().ToLower());
        }

        /// <summary>
        /// 15.5.4.18
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsInstance ToUpperCaseImpl(JsObjectBase target, IJsInstance[] parameters) {
            return Global.StringClass.New(target.ToString().ToUpperInvariant());
        }

        /// <summary>
        /// 15.5.4.19
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsInstance ToLocaleUpperCaseImpl(JsObjectBase target, IJsInstance[] parameters) {
            string str = target.ToString();
            return Global.StringClass.New(str.ToUpper());
        }

        /// <summary>
        /// 15.5.5.1
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public IJsInstance LengthImpl(JsObjectBase target) {
            string str = target.ToString();
            return Global.NumberClass.New(str.Length);
        }

    }
}
