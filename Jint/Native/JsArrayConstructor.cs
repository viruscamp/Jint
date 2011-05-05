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
        
        // 15.4.4.2
        IJsObject ToStringImpl(IJsObject target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IFunction join = target["join"] as IFunction;
            if (join != null)
                return join.Invoke(target, parameters, null);
            else
                return Global.ObjectClass.ToStringImpl(target, parameters);
        }

        // 15.4.4.3
        IJsObject ToLocaleStringImpl(IJsObject target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            uint len = target["length"].ToUInt32();

            if (len == 0)
                return Global.NewPrimitive(String.Empty);

            string[] result = new string[len];

            // TODO: optimize

            for (uint i = 0; i < len; i++) {
                IJsObject item = target[i.ToString()];

                result[i] = 
                    item == JsNull.Instance || item == JsUndefined.Instance ?
                    String.Empty :
                    item.CallMethod("toLocaleString",null).ToString() ;
            }

            return Global.NewPrimitive( String.Join(CultureInfo.CurrentCulture.TextInfo.ListSeparator, result) );
        }

        // 15.4.4.4
        IJsObject Concat(IJsObject target, IJsInstance[] parameters) {
            Debug.Assert(target != null);
            
            IJsObject[] list = new IJsObject[ parameters == null ? 1 : parameters.Length + 1 ];
            list[0] = target;

            if (parameters != null) {
                for (int i = 0; i < parameters.Length; i++)
                    list[i + 1] = parameters[i].GetObject();
            }

            JsArray result = new JsArray(Global, PrototypeProperty);

            // TODO: optimize

            uint n = 0;
            foreach (IJsObject item in list) {
                if (item.Class == JsInstance.CLASS_ARRAY) {
                    uint len = item["length"].ToUInt32();
                    IJsObject value;
                    for (uint i = 0; i < len; i++)
                        if (item.TryGetValue(i.ToString(), out value))
                            result.Put(n + i, value);
                    n += len;
                } else {
                    result.Put(n, item);
                    n++;
                }
            }
        }

        // 15.4.4.5
        IJsObject Join(IJsObject target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            string sep;

            if (parameters == null || parameters.Length == 0)
                sep = ",";
            else
                sep = parameters[0].GetObject().ToString();


            uint len = target["length"].ToUInt32();

            if (len == 0)
                return String.Empty;

            string[] result = new string[len];

            for (uint i = 0; i < len; i++) {
                IJsObject item = target[i.ToString()];

                if (item == JsUndefined.Instance || item == JsNull.Instance)
                    result[i] = String.Empty;
                else
                    result[i] = item.ToString();
            }

            return Global.NewPrimitive(String.Join(sep, result));
        }

        // 15.4.4.6
        IJsObject Pop(IJsObject target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            uint len = target[LENGTH].ToUInt32();
            if (len == 0) {
                target.Put(LENGTH, Global.NewPrimitive(len), true);
                return JsUndefined.Instance;
            }
            
            uint last = len -1;

            IJsObject result = target.Get(last.ToString());
            target.Delete(last.ToString(), true);
            target.Put(LENGTH, Global.NewPrimitive(last), true);
            return result;
        }

        // 15.4.4.7
        public IJsObject Push(IJsObject target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            uint length = target[LENGTH].ToUInt32();

            if (parameters != null) {
                foreach (var arg in parameters) {
                    target.Put(length.ToString(),arg.GetObject(),true);
                    length++;
                }
            }

            IJsObject len = Global.NewPrimitive(length);

            target.Put(LENGTH, len, true);
            return len;
        }

        // 15.4.4.8
        IJsObject Reverse(IJsObject target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            uint len = target[LENGTH].ToUInt32();
            uint middle = len / 2;

            for (uint lower = 0; lower != middle; lower++) {
                uint upper = len - lower - 1;

                string upperP = upper.ToString();
                string lowerP = lower.ToString();

                IJsObject lowerValue = null;
                IJsObject upperValue = null;
                bool lowerExists = target.TryGetValue(lowerP, out lowerValue);
                bool upperExists = target.TryGetValue(upperP, out upperValue);

                if (lowerExists) {
                    target.Put(upperP,lowerValue,true);
                } else {
                    target.Delete(upperP,true);
                }

                if (upperExists) {
                    target.Put(lowerP, upperValue, true);
                } else {
                    target.Delete(lowerP,true);
                }
            }
            return target;
        }

        // 15.4.4.9
        IJsObject Shift(IJsObject target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            uint len = target[LENGTH].ToUInt32();

            if (len == 0) {
                target.Put(LENGTH, Global.NewPrimitive(0), true);
                return Global.NewPrimitive(0);
            }

            IJsObject first = target[0.ToString()];

            for (uint k = 1; k < len; k++) {
                IJsObject result = null;

                string from = k.ToString();
                string to = (k - 1).ToString();

                if (target.TryGetValue(from, out result))
                    target.Put(to,result,true);
                else
                    target.Delete(to,true);
            }

            target.Delete((len - 1).ToString(),true);
            target.Put(LENGTH,Global.NewPrimitive(len-1),true);

            return first;
        }

        // 15.4.4.10
        IJsObject Slice(IJsObject target, IJsInstance[] _parameters) {
            Debug.Assert(target != null);

            IJsObject[] parameters = NormalizeParameters(_parameters, 2);

            int len = target[LENGTH].ToUInt32();

            int start = parameters[0].ToInteger();
            int end;

            if (parameters[1] == JsUndefined.Instance)
                end = len;
            else
                end = parameters[1].ToInteger();

            if (start < 0)
                start = Math.Max(len + start, 0);
            else
                start = Math.Min(len, start);

            if (end < 0)
                end = Math.Max(len + end, 0);
            else
                end = Math.Min(end, len);

            JsArray result = new JsArray(Global,PrototypeProperty);
            IJsObject value;

            for (int i = start; i < end; i++)
                if (target.TryGetValue(i.ToString(),out value))
                    result.Put((uint)i,value,true);

            return result;
        }

        // 15.4.4.11
        IJsObject Sort(IJsObject target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            uint length = target["length"].ToUInt32();

            if (length == 0)
                return target;

            IFunction compare = null;

            // Compare function defined
            if (parameters != null && parameters.Length > 0)
                compare = parameters[0].GetObject() as IFunction;

            List<IJsObject> values = new List<IJsObject>();
            IJsObject value;

            // if object is sparse (see 15.4) let's sort only
            // present values
            for (uint i = 0; i < length; i++)
                if (target.TryGetValue(i.ToString(),out value))
                    values.Add(value);

            values.Sort(new JsComparer(compare));

            for (int i = 0; i < length; i++)
                target.Put(i.ToString(),values[i],true);

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
