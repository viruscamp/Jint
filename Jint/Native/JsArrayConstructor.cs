using System;
using System.Collections.Generic;
using System.Text;
using Jint.Delegates;
using Jint.Expressions;
using System.Diagnostics;
using System.Globalization;

namespace Jint.Native {
    [Serializable]
    public class JsArrayConstructor : JsConstructor {
        public JsArrayConstructor(IGlobal global)
            : base(JsInstance.CLASS_ARRAY, global, global.FunctionClass.Prototype) {

            var prototypeProperty = CreatePrototypeObject();

            DefineOwnProperty(PROTOTYPE, prototypeProperty, ConstPropertyAttributes);

            var fc = global.FunctionClass;

            DefineProperty(prototypeProperty, "toString", fc.New(ToStringImpl), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty, "toLocaleString", fc.New(ToLocaleStringImpl), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty, "concat", fc.New(Concat,1), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty, "join", fc.New(Join, 1), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty, "pop", fc.New(Pop), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty, "push", fc.New(Push, 1), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty, "reverse", fc.New(Reverse), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty, "shift", fc.New(Shift), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty, "slice", fc.New(Slice, 2), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty, "sort", fc.New(Sort), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty, "splice", fc.New(Splice, 2), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty, "unshift", fc.New(UnShift, 1), PropertyAttributes.DontEnum);

            if (Global.HasOption(Options.Ecmascript5)) {
                DefineProperty(prototypeProperty, "indexOf", fc.New(IndexOfImpl, 1), PropertyAttributes.DontEnum);
                DefineProperty(prototypeProperty, "lastIndexOf", fc.New(LastIndexOfImpl, 1), PropertyAttributes.DontEnum);
            }

        }


        public JsArray New() {
            JsArray array = new JsArray(PrototypeProperty);
            //array.DefineOwnProperty("constructor", new ValueDescriptor(this) { Enumerable = false });
            return array;
        }

        public override IJsObject Construct(IJsInstance[] parameters, JsScope callingContext) {
            JsArray array = new JsArray(Global, PrototypeProperty);

            if (parameters != null && parameters.Length > 0) {
                if (parameters.Length > 1) {
                    for (int i = 0; i < parameters.Length; i++)
                        array.Put((uint)i, parameters[i].GetObject());
                } else {
                    IJsObject len = parameters[0].GetObject();
                    if (!Double.IsNaN(len.ToNumber())) {
                        if (len.ToUInt32() == len.ToNumber())
                            array.Length = len.ToUInt32();
                        else
                            throw new JsRangeException("Invalid array length");
                    } else {
                        array.Put(0, len);
                    }
                }
            }

            return array;
        }

        public override int Length {
            get { return 1; }
        }

        public override IJsObject Invoke(IJsObject that, IJsInstance[] parameters, JsScope callingContext) {
            return Construct(parameters, callingContext);
        }

        #region Array.prototype functions
        
        /// 15.4.4.2
        IJsObject ToStringImpl(IJsObject target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IFunction join = target["join"] as IFunction;
            if (join != null)
                return join.Invoke(target, parameters, null);
            else
                return Global.ObjectClass.ToStringImpl(target, parameters);
        }

        /// 15.4.4.3
        IJsObject ToLocaleStringImpl(IJsObject target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            uint len = target["length"].ToUInt32();

            if (len == 0)
                return Global.NewPrimitive(String.Empty);

            string[] result = new string[len];

            for (uint i = 0; i < len; i++) {
                IJsObject item = target[i];

                result[i] = (
                    item == JsNull.Instance || item == JsUndefined.Instance ?
                    String.Empty :
                    item.CallMethod("toLocaleString",null).ToString()
                );
            }

            return Global.NewPrimitive( String.Join(CultureInfo.CurrentCulture.TextInfo.ListSeparator, result) );
        }

        /// <summary>
        /// 15.4.4.4
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsObject Concat(IJsObject target, IJsInstance[] parameters) {
            if (target is JsArray)
                return ((JsArray)target).concat(Global, parameters);
            JsArray array = Global.ArrayClass.New();
            List<IJsInstance> items = new List<IJsInstance>();
            items.Add(target);
            items.AddRange(parameters);
            int n = 0;
            while (items.Count > 0) {
                IJsInstance e = items[0];
                items.RemoveAt(0);
                if (Global.ArrayClass.HasInstance(e as JsObject)) {
                    for (int k = 0; k < ((JsObject)e).Length; k++) {
                        string p = k.ToString();
                        IJsInstance result = null;
                        if (((JsObject)e).TryGetProperty(p, out result))
                            array.Put(n, result);
                        n++;
                    }
                } else {
                    array.Put(n, e);
                    n++;
                }
            }
            return array;
        }

        /// <summary>
        /// 15.4.4.5
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsObject Join(IJsObject target, IJsInstance[] parameters) {
            if (target is JsArray)
                return ((JsArray)target).join(Global, parameters.Length > 0 ? parameters[0] : JsUndefined.Instance);
            string separator = (parameters.Length == 0 || parameters[0] == JsUndefined.Instance)
                ? ","
                : parameters[0].ToString();

            if (target.Length == 0) {
                return Global.StringClass.New();
            }

            IJsInstance element0 = target[0.ToString()];

            StringBuilder r;
            if (element0 == JsUndefined.Instance || element0 == JsNull.Instance) {
                r = new StringBuilder(string.Empty);
            } else {
                r = new StringBuilder(element0.ToString());
            }

            var length = target["length"].ToNumber();

            for (int k = 1; k < length; k++) {
                r.Append(separator);
                IJsInstance element = target[k.ToString()];
                if (element != JsUndefined.Instance && element != JsNull.Instance)
                    r.Append(element.ToString());
            }
            return Global.StringClass.New(r.ToString());
        }

        /// <summary>
        /// 15.4.4.6
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsObject Pop(IJsObject target, IJsInstance[] parameters) {
            var length = Convert.ToUInt32(target.Length);
            if (length == 0)
                return JsUndefined.Instance;
            var key = (length - 1).ToString();
            var result = target[key];
            target.Delete(key);
            target.Length--;
            return result;
        }

        /// <summary>
        /// 15.4.4.7
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsObject Push(JsObjectBase target, IJsInstance[] parameters) {
            int length = (int)target["length"].ToNumber();
            foreach (var arg in parameters) {
                target[Global.NumberClass.New(length)] = arg;
                length++;
            }

            return Global.NumberClass.New(length);
        }

        /// <summary>
        /// 15.4.4.8
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsObject Reverse(IJsObject target, IJsInstance[] parameters) {
            int len = target.Length;
            int middle = len / 2;

            for (int lower = 0; lower != middle; lower++) {
                int upper = len - lower - 1;
                string upperP = upper.ToString();
                string lowerP = lower.ToString();

                IJsInstance lowerValue = null;
                IJsInstance upperValue = null;
                bool lowerExists = target.TryGetProperty(lowerP, out lowerValue);
                bool upperExists = target.TryGetProperty(upperP, out upperValue);

                if (lowerExists) {
                    target[upperP] = lowerValue;
                } else {
                    target.Delete(upperP);
                }

                if (upperExists) {
                    target[lowerP] = upperValue;
                } else {
                    target.Delete(lowerP);
                }
            }
            return target;
        }

        /// <summary>
        /// 15.4.4.9
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsObject Shift(JsObjectBase target, IJsInstance[] parameters) {
            if (target.Length == 0) {
                return JsUndefined.Instance;
            }

            IJsInstance first = target[0.ToString()];
            for (int k = 1; k < target.Length; k++) {
                IJsInstance result = null;

                string from = k.ToString();
                string to = (k - 1).ToString();
                if (target.TryGetProperty(from, out result)) {
                    target[to] = result;
                } else {
                    target.Delete(to);
                }
            }
            target.Delete((target.Length - 1).ToString());
            target.Length--;

            return first;
        }

        /// <summary>
        /// 15.4.4.10
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsObject Slice(IJsObject target, IJsInstance[] parameters) {
            int start = (int)parameters[0].ToNumber();
            int end = target.Length;
            if (parameters.Length > 1)
                end = (int)parameters[1].ToNumber();
            if (start < 0)
                start += target.Length;
            if (end < 0)
                end += target.Length;
            if (start > target.Length)
                start = target.Length;
            if (end > target.Length)
                end = target.Length;
            JsArray result = Global.ArrayClass.New();
            for (int i = start; i < end; i++)
                Push(result, new IJsInstance[] { target[Global.NumberClass.New(i)] });

            return result;
        }

        /// <summary>
        /// 15.4.4.11
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsObject Sort(IJsObject target, IJsInstance[] parameters) {
            if (target.Length <= 1) {
                return target;
            }

            JsFunction compare = null;

            // Compare function defined
            if (parameters.Length > 0) {
                compare = parameters[0] as JsFunction;
            }

            var values = new List<IJsInstance>();
            var length = (int)target["length"].ToNumber();

            for (int i = 0; i < length; i++) {
                values.Add(target[i.ToString()]);
            }

            if (compare != null) {
                try {
                    values.Sort(new JsComparer(Global.Visitor, compare));
                } catch (Exception e) {
                    if (e.InnerException is JsException) {
                        throw e.InnerException;
                    }

                    throw;
                }
            } else {
                values.Sort();
            }

            for (int i = 0; i < length; i++) {
                target[i.ToString()] = values[i];
            }

            return target;
        }

        /// <summary>
        /// 15.4.4.12
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsObject Splice(IJsObject target, IJsInstance[] parameters) {
            JsArray array = Global.ArrayClass.New();
            int relativeStart = Convert.ToInt32(parameters[0].ToNumber());
            int actualStart = relativeStart < 0 ? Math.Max(target.Length + relativeStart, 0) : Math.Min(relativeStart, target.Length);
            int actualDeleteCount = Math.Min(Math.Max(Convert.ToInt32(parameters[1].ToNumber()), 0), target.Length - actualStart);
            int len = target.Length;

            for (int k = 0; k < actualDeleteCount; k++) {
                string from = (relativeStart + k).ToString();
                IJsInstance result = null;
                if (target.TryGetProperty(from, out result)) {
                    array.Put(k, result);
                }
            }

            List<IJsInstance> items = new List<IJsInstance>();
            items.AddRange(parameters);
            items.RemoveAt(0);
            items.RemoveAt(0);

            // use non-distructional copy, determine direction
            if (items.Count < actualDeleteCount) {
                for (int k = actualStart; k < len - actualDeleteCount; k++) {
                    IJsInstance result = null;
                    string from = (k + actualDeleteCount).ToString();
                    string to = (k + items.Count).ToString();
                    if (target.TryGetProperty(from, out result)) {
                        target[to] = result;
                    } else {
                        target.Delete(to);
                    }
                }

                for (int k = target.Length; k > len - actualDeleteCount + items.Count; k--) {
                    target.Delete((k - 1).ToString());
                }

                target.Length = len - actualDeleteCount + items.Count;
            } else {
                for (int k = len - actualDeleteCount; k > actualStart; k--) {
                    IJsInstance result = null;
                    string from = (k + actualDeleteCount - 1).ToString();
                    string to = (k + items.Count - 1).ToString();
                    if (target.TryGetProperty(from, out result)) {
                        target[to] = result;
                    } else {
                        target.Delete(to);
                    }
                }


            }
            for (int k = 0; k < items.Count; k++)
                target[k.ToString()] = items[k];

            return array;
        }

        /// <summary>
        /// 15.4.4.13
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsObject UnShift(IJsObject target, IJsInstance[] parameters) {
            for (int k = target.Length; k > 0; k--) {
                IJsInstance result = null;
                string from = (k - 1).ToString();
                string to = (k + parameters.Length - 1).ToString();
                if (target.TryGetProperty(from, out result)) {
                    target[to] = result;
                } else {
                    target.Delete(to);
                }
            }
            List<IJsInstance> items = new List<IJsInstance>(parameters);
            for (int j = 0; items.Count > 0; j++) {
                IJsInstance e = items[0];
                items.RemoveAt(0);
                target[j.ToString()] = e;
            }
            return Global.NumberClass.New(target.Length);
        }

        /// <summary>
        /// 15.4.4.15
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsObject LastIndexOfImpl(IJsObject target, IJsInstance[] parameters) {
            if (parameters.Length == 0) {
                return Global.NumberClass.New(-1);
            }

            int len = target.Length;
            if (len == 0)
                return Global.NumberClass.New(-1);
            int n = len;
            if (parameters.Length > 1)
                n = Convert.ToInt32(parameters[1].ToNumber());
            int k;
            IJsInstance searchParameter = parameters[0];
            if (n >= 0)
                k = Math.Min(n, len - 1);
            else
                k = len - Math.Abs(n - 1);
            while (k >= 0) {
                IJsInstance result = null;
                if (target.TryGetProperty(k.ToString(), out result)) {
                    if (result == searchParameter) {
                        return Global.NumberClass.New(k);
                    }
                }
                k--;
            }
            return Global.NumberClass.New(-1);
        }

        /// <summary>
        /// 15.4.4.15
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IJsObject IndexOfImpl(IJsObject target, IJsInstance[] parameters) {
            if (parameters.Length == 0) {
                return Global.NumberClass.New(-1);
            }

            int len = (int)target["length"].ToNumber();
            if (len == 0)
                return Global.NumberClass.New(-1);
            int n = 0;
            if (parameters.Length > 1)
                n = Convert.ToInt32(parameters[1].ToNumber());
            int k;
            if (n >= len)
                return Global.NumberClass.New(-1);

            IJsInstance searchParameter = parameters[0];
            if (n >= 0)
                k = n;
            else
                k = len - Math.Abs(n);
            while (k < len) {
                IJsInstance result = null;
                if (target.TryGetProperty(k.ToString(), out result)) {
                    if (result == searchParameter) {
                        return Global.NumberClass.New(k);
                    }
                }
                k++;
            }
            return Global.NumberClass.New(-1);
        }

        IJsInstance GetLengthImpl(JsObject that) {
            return Global.NumberClass.New(that.Length);

        }

        IJsInstance SetLengthImpl(JsObject that, IJsInstance[] parameters) {
            if (that is JsArray) {
                that.Length = (int)parameters[0].ToNumber();
            } else {
                int oldLen = that.Length;
                that.Length = (int)parameters[0].ToNumber();

                for (int i = that.Length; i < oldLen; i++)
                    that.Delete(Global.NumberClass.New(i));
            }

            return parameters[0];
        }

        #endregion
    }
}
