using System;
using System.Collections.Generic;
using System.Text;
using Jint.Delegates;
using System.Globalization;
using System.Text.RegularExpressions;
using Jint.Expressions;
using System.Diagnostics;

namespace Jint.Native {
    [Serializable]
    public class JsDateConstructor : JsConstructor {
        protected JsDateConstructor(IGlobal global)
            : base(JsInstance.CLASS_DATE, global, global.FunctionClass.PrototypeProperty ) {

            IJsObject p = CreatePrototypeObject();

            JsFunctionConstructor fc = global.FunctionClass;

            DefineOwnProperty(PROTOTYPE, p , ConstPropertyAttributes);

            DefineOwnProperty("now", fc.New(delegate(IJsInstance[] args) { return New(DateTime.Now); }), PropertyAttributes.DontEnum);
            DefineOwnProperty("parse", fc.New(ParseImpl), PropertyAttributes.DontEnum);
            DefineOwnProperty("parseLocale", fc.New(ParseLocaleImpl), PropertyAttributes.DontEnum);
            DefineOwnProperty("UTC", fc.New(UTCImpl), PropertyAttributes.DontEnum);

            #region Methods
            DefineProperty(p, "toString", fc.New<JsDate>(ToStringImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "toDateString", fc.New<JsDate>(ToDateStringImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "toTimeString", fc.New<JsDate>(ToTimeStringImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "toLocaleString", fc.New<JsDate>(ToLocaleStringImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "toLocaleDateString", fc.New<JsDate>(ToLocaleDateStringImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "toLocaleTimeString", fc.New<JsDate>(ToLocaleTimeStringImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "valueOf", fc.New<JsDate>(ValueOfImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getTime", fc.New<JsDate>(GetTimeImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getFullYear", fc.New<JsDate>(GetFullYearImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getUTCFullYear", fc.New<JsDate>(GetUTCFullYearImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getMonth", fc.New<JsDate>(GetMonthImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getUTCMonth", fc.New<JsDate>(GetUTCMonthImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getDate", fc.New<JsDate>(GetDateImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getUTCDate", fc.New<JsDate>(GetUTCDateImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getDay", fc.New<JsDate>(GetDayImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getUTCDay", fc.New<JsDate>(GetUTCDayImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getHours", fc.New<JsDate>(GetHoursImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getUTCHours", fc.New<JsDate>(GetUTCHoursImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getMinutes", fc.New<JsDate>(GetMinutesImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getUTCMinutes", fc.New<JsDate>(GetUTCMinutesImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getSeconds", fc.New<JsDate>(GetSecondsImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getUTCSeconds", fc.New<JsDate>(GetUTCSecondsImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getMilliseconds", fc.New<JsDate>(GetMillisecondsImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getUTCMilliseconds", fc.New<JsDate>(GetUTCMillisecondsImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "getTimezoneOffset", fc.New<JsDate>(GetTimezoneOffsetImpl), PropertyAttributes.DontEnum);

            DefineProperty(p, "setTime", fc.New<JsDate>(SetTimeImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "setMilliseconds", fc.New<JsDate>(SetMillisecondsImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "setUTCMilliseconds", fc.New<JsDate>(SetUTCMillisecondsImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "setSeconds", fc.New<JsDate>(SetSecondsImpl, 2), PropertyAttributes.DontEnum);
            DefineProperty(p, "setUTCSeconds", fc.New<JsDate>(SetUTCSecondsImpl, 2), PropertyAttributes.DontEnum);
            DefineProperty(p, "setMinutes", fc.New<JsDate>(SetMinutesImpl, 3), PropertyAttributes.DontEnum);
            DefineProperty(p, "setUTCMinutes", fc.New<JsDate>(SetUTCMinutesImpl, 3), PropertyAttributes.DontEnum);
            DefineProperty(p, "setHours", fc.New<JsDate>(SetHoursImpl, 4), PropertyAttributes.DontEnum);
            DefineProperty(p, "setUTCHours", fc.New<JsDate>(SetUTCHoursImpl, 4), PropertyAttributes.DontEnum);
            DefineProperty(p, "setDate", fc.New<JsDate>(SetDateImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "setUTCDate", fc.New<JsDate>(SetUTCDateImpl), PropertyAttributes.DontEnum);
            DefineProperty(p, "setMonth", fc.New<JsDate>(SetMonthImpl, 2), PropertyAttributes.DontEnum);
            DefineProperty(p, "setUTCMonth", fc.New<JsDate>(SetUTCMonthImpl, 2), PropertyAttributes.DontEnum);
            DefineProperty(p, "setFullYear", fc.New<JsDate>(SetFullYearImpl, 3), PropertyAttributes.DontEnum);
            DefineProperty(p, "setUTCFullYear", fc.New<JsDate>(SetUTCFullYearImpl, 3), PropertyAttributes.DontEnum);

            Prototype.DefineOwnProperty("toUTCString", fc.New<JsDate>(ToUTCStringImpl), PropertyAttributes.DontEnum);
            #endregion
        }
        
        public JsDate New() {
            return new JsDate(this.PrototypeProperty);
        }

        public JsDate New(double value) {
            return new JsDate(value, this.PrototypeProperty);
        }

        public JsDate New(DateTime value) {
            return new JsDate(value, this.PrototypeProperty);
        }

        public JsDate New(DateTime value, JsObject prototype)
        {
            return new JsDate(value, prototype);
        }

        private bool ParseDate(string p, IFormatProvider culture, out double result) {
            DateTime d = new DateTime(0, DateTimeKind.Utc); ;
            result = 0;

            if (DateTime.TryParse(p, culture, DateTimeStyles.None, out d)) {
                result = New(d).ToNumber();
                return true;
            }

            if (DateTime.TryParseExact(p, JsDate.FORMAT, culture, DateTimeStyles.None, out d)) {
                result = New(d).ToNumber();
                return true;
            }

            DateTime ld;

            if (DateTime.TryParseExact(p, JsDate.DATEFORMAT, culture, DateTimeStyles.None, out ld)) {
                d = d.AddTicks(ld.Ticks);
            }

            if (DateTime.TryParseExact(p, JsDate.TIMEFORMAT, culture, DateTimeStyles.None, out ld)) {
                d = d.AddTicks(ld.Ticks);
            }

            if (d.Ticks > 0) {
                result = New(d).ToNumber();
                return true;
            }

            return true;
        }

        // 15.9.4.1
        IJsObject ParseImpl(IJsInstance[] parameters) {
            if (parameters == null || parameters.Length == 0)
                return Global.NaN;

            double d;
            if (ParseDate(parameters[0].GetObject().ToString(), CultureInfo.InvariantCulture, out d)) {
                return Global.NewPrimitive(d);
            }
            else {
                return Global.NaN;
            }
        }

        // 15.9.5.2
        IJsObject ToStringImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            return Global.NewPrimitive(target.ToLocalStringImpl(CultureInfo.InvariantCulture));
        }

        

        // 15.9.5.3
        IJsObject ToDateStringImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            return Global.NewPrimitive(target.ToLocalDateStringImpl(CultureInfo.InvariantCulture));
        }

        // 15.9.5.4
        IJsObject ToTimeStringImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            return Global.NewPrimitive(target.ToLocalTimeStringImpl(CultureInfo.InvariantCulture));
        }

        // 15.9.5.5
        IJsObject ToLocaleStringImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            return Global.NewPrimitive(target.ToLocalStringImpl(CultureInfo.CurrentCulture));
        }



        // 15.9.5.6
        IJsObject ToLocaleDateStringImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            return Global.NewPrimitive(target.ToLocalDateStringImpl(CultureInfo.CurrentCulture));
        }

        // 15.9.5.7
        IJsObject ToLocaleTimeStringImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            return Global.NewPrimitive(target.ToLocalTimeStringImpl(CultureInfo.CurrentCulture));
        }

        // 15.9.5.8
        IJsObject ValueOfImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            return Global.NewPrimitive(target.DoubleValue);
        }

        // 15.9.5.9
        IJsObject GetTimeImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            return Global.NewPrimitive(target.DoubleValue);
        }

        // 15.9.5.10
        IJsObject GetFullYearImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (target.IsNaN)
                return Global.NaN;

            return Global.NewPrimitive(target.DateTimeValue.ToLocalTime().Year);
        }

        // 15.9.5.11
        IJsObject GetUTCFullYearImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (target.IsNaN)
                return Global.NaN;

            return Global.NewPrimitive(target.DateTimeValue.ToUniversalTime().Year);
        }

        // 15.9.5.12
        IJsObject GetMonthImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (target.IsNaN)
                return Global.NaN;

            return Global.NewPrimitive(target.DateTimeValue.ToLocalTime().Month - 1);
        }

        // 15.9.5.13
        IJsObject GetUTCMonthImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (target.IsNaN)
                return Global.NaN;

            return Global.NewPrimitive(target.DateTimeValue.ToUniversalTime().Month - 1);
        }

        // 15.9.5.14
        IJsObject GetDateImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (target.IsNaN)
                return Global.NaN;

            return Global.NewPrimitive(target.DateTimeValue.ToLocalTime().Day );
        }

        // 15.9.5.15
        IJsObject GetUTCDateImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (target.IsNaN)
                return Global.NaN;

            return Global.NewPrimitive(target.DateTimeValue.ToUniversalTime().Day);
        }

        // 15.9.5.16
        IJsObject GetDayImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (target.IsNaN)
                return Global.NaN;

            return Global.NewPrimitive((int)target.DateTimeValue.ToLocalTime().DayOfWeek);
        }

        // 15.9.5.17
        IJsObject GetUTCDayImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (target.IsNaN)
                return Global.NaN;

            return Global.NewPrimitive((int)target.DateTimeValue.ToUniversalTime().DayOfWeek);
        }

        // 15.9.5.18
        IJsObject GetHoursImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (target.IsNaN)
                return Global.NaN;

            return Global.NewPrimitive(target.DateTimeValue.ToLocalTime().Hour);
        }

        // 15.9.5.19
        IJsObject GetUTCHoursImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (target.IsNaN)
                return Global.NaN;

            return Global.NewPrimitive(target.DateTimeValue.ToUniversalTime().Hour);
        }

        // 15.9.5.20
        IJsObject GetMinutesImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (target.IsNaN)
                return Global.NaN;

            return Global.NewPrimitive(target.DateTimeValue.ToLocalTime().Minute);
        }

        // 15.9.5.21
        IJsObject GetUTCMinutesImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (target.IsNaN)
                return Global.NaN;

            return Global.NewPrimitive(target.DateTimeValue.ToUniversalTime().Minute);
        }

        // 15.9.5.22
        IJsObject GetSecondsImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (target.IsNaN)
                return Global.NaN;

            return Global.NewPrimitive(target.DateTimeValue.ToLocalTime().Second);
        }

        // 15.9.5.23
        IJsObject GetUTCSecondsImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (target.IsNaN)
                return Global.NaN;

            return Global.NewPrimitive(target.DateTimeValue.ToUniversalTime().Second);
        }

        // 15.9.5.24
        IJsObject GetMillisecondsImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (target.IsNaN)
                return Global.NaN;

            return Global.NewPrimitive(target.DateTimeValue.ToLocalTime().Millisecond);
        }

        // 15.9.5.25
        IJsObject GetUTCMillisecondsImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (target.IsNaN)
                return Global.NaN;

            return Global.NewPrimitive(target.DateTimeValue.ToUniversalTime().Millisecond);
        }

        // 15.9.5.26
        IJsObject GetTimezoneOffsetImpl(JsDate target, IJsInstance[] parameters) {
            return Global.NewPrimitive(-TimeZone.CurrentTimeZone.GetUtcOffset(new DateTime()).TotalMinutes);
        }

        // 15.9.5.27
        IJsObject SetTimeImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IJsObject arg = parameters == null || parameters.Length == 0 ? JsUndefined.Instance : parameters[0].GetObject();

            return Global.NewPrimitive(target.DoubleValue = arg.ToNumber());
        }

        // 15.9.5.28
        IJsObject SetMillisecondsImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IJsObject arg = parameters == null || parameters.Length == 0 ? JsUndefined.Instance : parameters[0].GetObject();

            DateTime valueOf = target.DateTimeValue.ToLocalTime();
            valueOf = valueOf.AddMilliseconds(-valueOf.Millisecond);
            valueOf = valueOf.AddMilliseconds(arg.ToNumber());
            target.DateTimeValue = valueOf.ToUniversalTime();

            return Global.NewPrimitive(target.DoubleValue);
        }

        // 15.9.5.29
        IJsObject SetUTCMillisecondsImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IJsObject arg = parameters == null || parameters.Length == 0 ? JsUndefined.Instance : parameters[0].GetObject();

            DateTime valueOf = target.DateTimeValue.ToUniversalTime();
            valueOf = valueOf.AddMilliseconds(-valueOf.Millisecond);
            valueOf = valueOf.AddMilliseconds(arg.ToNumber());
            target.DateTimeValue = valueOf;

            return Global.NewPrimitive(target.DoubleValue);
        }

        // 15.9.5.30
        IJsObject SetSecondsImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IJsObject arg = parameters == null || parameters.Length == 0 ? JsUndefined.Instance : parameters[0].GetObject();

            DateTime valueOf = target.DateTimeValue.ToLocalTime();
            valueOf = valueOf.AddSeconds(-valueOf.Second);
            valueOf = valueOf.AddSeconds(arg.ToNumber());
            target.DateTimeValue = valueOf.ToUniversalTime();

            if (parameters.Length > 1) {
                IJsInstance[] innerParams = new IJsInstance[parameters.Length - 1];
                parameters.CopyTo(innerParams, parameters.Length - 1);
                SetMillisecondsImpl(target, innerParams);
            }
            return Global.NewPrimitive(target.DoubleValue);
        }

        // 15.9.5.31
        IJsObject SetUTCSecondsImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IJsObject arg = parameters == null || parameters.Length == 0 ? JsUndefined.Instance : parameters[0].GetObject();

            DateTime valueOf = target.DateTimeValue.ToUniversalTime();
            valueOf = valueOf.AddSeconds(-valueOf.Second);
            valueOf = valueOf.AddSeconds(arg.ToNumber());
            target.DateTimeValue = valueOf();

            if (parameters.Length > 1) {
                IJsInstance[] innerParams = new IJsInstance[parameters.Length - 1];
                parameters.CopyTo(innerParams, parameters.Length - 1);
                SetUTCMillisecondsImpl(target, innerParams);
            }
            return Global.NewPrimitive(target.DoubleValue);
        }

        // 15.9.5.33
        IJsObject SetMinutesImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IJsObject arg = parameters == null || parameters.Length == 0 ? JsUndefined.Instance : parameters[0].GetObject();

            DateTime valueOf = target.DateTimeValue.ToLocalTime();
            valueOf = valueOf.AddMinutes(-valueOf.Minute);
            valueOf = valueOf.AddMinutes(arg.ToNumber());
            target.DateTimeValue = valueOf.ToUniversalTime();

            if (parameters.Length > 1) {
                IJsInstance[] innerParams = new IJsInstance[parameters.Length - 1];
                parameters.CopyTo(innerParams, parameters.Length - 1);
                SetSecondsImpl(target, innerParams);
            }
            return Global.NewPrimitive(target.DoubleValue);
        }

        // 15.9.5.34
        IJsObject SetUTCMinutesImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IJsObject arg = parameters == null || parameters.Length == 0 ? JsUndefined.Instance : parameters[0].GetObject();

            DateTime valueOf = target.DateTimeValue.ToUniversalTime();
            valueOf = valueOf.AddMinutes(-valueOf.Minute);
            valueOf = valueOf.AddMinutes(arg.ToNumber());
            target.DateTimeValue = valueOf;

            if (parameters.Length > 1) {
                IJsInstance[] innerParams = new IJsInstance[parameters.Length - 1];
                parameters.CopyTo(innerParams, parameters.Length - 1);
                SetUTCSecondsImpl(target, innerParams);
            }
            return Global.NewPrimitive(target.DoubleValue);
        }

        // 15.9.5.35
        IJsObject SetHoursImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IJsObject arg = parameters == null || parameters.Length == 0 ? JsUndefined.Instance : parameters[0].GetObject();

            DateTime valueOf = target.DateTimeValue.ToLocalTime();
            valueOf = valueOf.AddHours(-valueOf.Hour);
            valueOf = valueOf.AddHours(arg.ToNumber());

            target.DateTimeValue = valueOf.ToUniversalTime();

            if (parameters.Length > 1) {
                IJsInstance[] innerParams = new IJsInstance[parameters.Length - 1];
                parameters.CopyTo(innerParams, parameters.Length - 1);
                SetMinutesImpl(target, innerParams);
            }
            return Global.NewPrimitive(target.DoubleValue);
        }

        // 15.9.5.36
        IJsObject SetUTCHoursImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IJsObject arg = parameters == null || parameters.Length == 0 ? JsUndefined.Instance : parameters[0].GetObject();

            DateTime valueOf = target.DateTimeValue.ToUniversalTime();
            valueOf = valueOf.AddHours(-valueOf.Hour);
            valueOf = valueOf.AddHours(arg.ToNumber());

            target.DateTimeValue = valueOf;

            if (parameters.Length > 1) {
                IJsInstance[] innerParams = new IJsInstance[parameters.Length - 1];
                parameters.CopyTo(innerParams, parameters.Length - 1);
                SetUTCMinutesImpl(target, innerParams);
            }
            return Global.NewPrimitive(target.DoubleValue);
        }

        // 15.9.5.36
        IJsObject SetDateImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IJsObject arg = parameters == null || parameters.Length == 0 ? JsUndefined.Instance : parameters[0].GetObject();

            DateTime valueOf = target.DateTimeValue.ToLocalTime();
            valueOf = valueOf.AddDays(-valueOf.Hour);
            valueOf = valueOf.AddDays(arg.ToNumber());

            target.DateTimeValue = valueOf.ToUniversalTime();

            return Global.NewPrimitive(target.DoubleValue);
        }

        // 15.9.5.37
        IJsObject SetUTCDateImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IJsObject arg = parameters == null || parameters.Length == 0 ? JsUndefined.Instance : parameters[0].GetObject();

            DateTime valueOf = target.DateTimeValue.ToUniversalTime();
            valueOf = valueOf.AddDays(-valueOf.Hour);
            valueOf = valueOf.AddDays(arg.ToNumber());

            target.DateTimeValue = valueOf;

            return Global.NewPrimitive(target.DoubleValue);
        }

        // 15.9.5.38
        IJsObject SetMonthImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IJsObject arg = parameters == null || parameters.Length == 0 ? JsUndefined.Instance : parameters[0].GetObject();

            DateTime valueOf = target.DateTimeValue.ToLocalTime();

            valueOf = valueOf.AddMonths(-valueOf.Month);
            valueOf = valueOf.AddMonths((int)arg.ToNumber());

            target.DateTimeValue = valueOf.ToUniversalTime();

            if (parameters.Length > 1) {
                IJsInstance[] innerParams = new IJsInstance[parameters.Length - 1];
                parameters.CopyTo(innerParams, parameters.Length - 1);
                SetDateImpl(target, innerParams);
            }
            return Global.NewPrimitive(target.DoubleValue);
        }

        // 15.9.5.39
        IJsObject SetUTCMonthImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IJsObject arg = parameters == null || parameters.Length == 0 ? JsUndefined.Instance : parameters[0].GetObject();

            DateTime valueOf = target.DateTimeValue.ToUniversalTime();

            valueOf = valueOf.AddMonths(-valueOf.Month);
            valueOf = valueOf.AddMonths((int)arg.ToNumber());

            target.DateTimeValue = valueOf();

            if (parameters.Length > 1) {
                IJsInstance[] innerParams = new IJsInstance[parameters.Length - 1];
                parameters.CopyTo(innerParams, parameters.Length - 1);
                SetDateImpl(target, innerParams);
            }
            return Global.NewPrimitive(target.DoubleValue);
        }

        // 15.9.5.40
        IJsObject SetFullYearImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IJsObject arg = parameters == null || parameters.Length == 0 ? JsUndefined.Instance : parameters[0].GetObject();

            DateTime valueOf = target.DateTimeValue.ToLocalTime();
            valueOf = valueOf.AddYears(-valueOf.Year);
            valueOf = valueOf.AddYears((int)arg.ToNumber());

            target.DateTimeValue = valueOf.ToUniversalTime();

            if (parameters.Length > 1) {
                IJsInstance[] innerParams = new IJsInstance[parameters.Length - 1];
                parameters.CopyTo(innerParams, parameters.Length - 1);
                SetMonthImpl(target, innerParams);
            }
            return Global.NewPrimitive(target.DoubleValue);

        }

        // 15.9.5.41
        IJsObject SetUTCFullYearImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IJsObject arg = parameters == null || parameters.Length == 0 ? JsUndefined.Instance : parameters[0].GetObject();

            DateTime valueOf = target.DateTimeValue.ToUniversalTime();
            valueOf = valueOf.AddYears(-valueOf.Year);
            valueOf = valueOf.AddYears((int)arg.ToNumber());

            target.DateTimeValue = valueOf;

            if (parameters.Length > 1) {
                IJsInstance[] innerParams = new IJsInstance[parameters.Length - 1];
                parameters.CopyTo(innerParams, parameters.Length - 1);
                SetUTCMonthImpl(target, innerParams);
            }
            return Global.NewPrimitive(target.DoubleValue);
        }

        // 15.9.5.42
        IJsObject ToUTCStringImpl(JsDate target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            return Global.NewPrimitive(target.ToUTCStringImpl());
        }

        public override IJsObject Construct(IJsInstance[] rawParameters, JsScope callingContext) {
            
            IJsObject parameters = NormalizeParameters(rawParameters, rawParameters == null ? 0 : rawParameters.Length);

            JsDate result = null;

            if (parameters.Length == 1) {
                IJsObject value = parameters[0].ToPrimitive(Global);

                if ( value.Type == JsObjectType.String ) {
                    double d;
                    if (ParseDate(value.ToString(), CultureInfo.InvariantCulture, out d))
                        result = New(d);
                    else
                        result = New(Double.NaN);

                } else {
                    result = New(value.ToNumber());
                }
            } else if (parameters.Length > 1) {
                DateTime d = new DateTime(0, DateTimeKind.Local);

                if (parameters.Length > 0) {
                    int year = (int)parameters[0].ToNumber() - 1;
                    if (year < 100) {
                        year += 1900;
                    }

                    d = d.AddYears(year);
                }

                if (parameters.Length > 1) {
                    d = d.AddMonths((int)parameters[1].ToNumber());
                }

                if (parameters.Length > 2) {
                    d = d.AddDays((int)parameters[2].ToNumber() - 1);
                }

                if (parameters.Length > 3) {
                    d = d.AddHours((int)parameters[3].ToNumber());
                }

                if (parameters.Length > 4) {
                    d = d.AddMinutes((int)parameters[4].ToNumber());
                }

                if (parameters.Length > 5) {
                    d = d.AddSeconds((int)parameters[5].ToNumber());
                }

                if (parameters.Length > 6) {
                    d = d.AddMilliseconds((int)parameters[6].ToNumber());
                }

                result = New(d);
            } else {
                result = New(DateTime.Now);
            }

            return result;
        }

        public override int Length {
            get { 7; }
        }

        public override IJsObject Invoke(IJsObject that, IJsInstance[] parameters, JsScope callingContext) {
            return Global.NewPrimitive( Construct(parameters, callingContext).ToString() );
        }
    }
}
