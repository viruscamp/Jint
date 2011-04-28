using System;
using System.Collections.Generic;
using System.Text;
using Jint.Delegates;
using System.Globalization;

namespace Jint.Native {
    [Serializable]
    public sealed class JsDate : JsObjectBase {
        static internal long OFFSET_1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
        static internal int TICKSFACTOR = 10000;

        public const string FORMAT = "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'zzz";
        public const string FORMATUTC = "ddd, dd MMM yyyy HH':'mm':'ss 'UTC'";
        public const string DATEFORMAT = "ddd, dd MMM yyyy";
        public const string TIMEFORMAT = "HH':'mm':'ss 'GMT'zzz";

        bool m_isNaN;
        private DateTime value;

        public override object Value {
            get {
                return value;
            }
            set {
                if (value is DateTime)
                    this.value = (DateTime)value;
                else if (value is double)
                    this.value = JsDateConstructor.CreateDateTime((double)value);
            }
        }

        public JsDate(IJsObject prototype)
            : base(prototype) {
                value = DateTime.UtcNow;
        }

        public JsDate(DateTime date, IJsObject prototype): base(prototype) {
            value = date;
        }

        public JsDate(double value, IJsObject prototype)
            : this(ConversionTraits.ToDate(value), prototype) {
            if (Double.IsNaN(value) || Double.IsInfinity(value))
                m_isNaN = true;
        }

        public bool IsNaN {
            get { return m_isNaN; }
        }

        public override bool IsClr
        {
            get
            {
                return false;
            }
        }

        public DateTime DateTimeValue {
            get {
                return value;
            }

            set {
                this.value = value.ToUniversalTime();
                m_isNaN = false;
            }
        }

        public Double DoubleValue {
            get { return IsNaN ? Double.NaN : ConversionTraits.ToNumber(value); }
            set {
                m_isNaN = (Double.IsNaN(value) || Double.IsInfinity(value) );
                this.value = ConversionTraits.ToNumber(value);
            }
        }

        
        public override string Class {
            get { return CLASS_DATE; }
        }

        public string ToLocalStringImpl(IFormatProvider formatter) {
            if (IsNaN)
                return ConversionTraits.ToString(Double.NaN);
            return value.ToLocalTime().ToString(FORMAT, formatter);
        }

        public string ToLocalDateStringImpl(IFormatProvider formatter) {
            if (IsNaN)
                return ConversionTraits.ToString(Double.NaN);
            return value.ToLocalTime().ToString(DATEFORMAT, formatter);
        }

        public string ToLocalTimeStringImpl(IFormatProvider formatter) {
            if (IsNaN)
                return ConversionTraits.ToString(Double.NaN);
            return value.ToLocalTime().ToString(TIMEFORMAT, formatter);
        }

        public string ToUTCStringImpl() {
            if (IsNaN)
                return ConversionTraits.ToString(Double.NaN);
            return value.ToUniversalTime().ToString(FORMATUTC, CultureInfo.InvariantCulture);
        }
    }
}
