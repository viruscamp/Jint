using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Jint.Native {
    /// <summary>
    /// ecma 262.5 9
    /// </summary>
    public static class ConversionTraits {
        static readonly long TICKS_OFFSET_1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
        static readonly int TICKS_FACTOR = 10000;
        
        public static bool ToBoolean(double d) {
            if (d == 0 || Double.IsNaN(d))
                return false;
            return true;
        }

        public static string ToString(double d) {
            if (d == 0)
                return "0";
            else if (Double.IsNaN(d))
                return "NaN";
            else if (Double.IsPositiveInfinity(d))
                return "Infinity";
            else if (Double.IsNegativeInfinity(d))
                return "-Infinity";
            else
                return d.ToString(CultureInfo.InvariantCulture).ToLower();
        }

        public static int ToInteger(double d) {
            if (Double.IsNaN(d) || Double.IsInfinity(d))
                return 0;
            return Convert.ToInt32(d);
        }

        public static UInt32 ToUInt32(double d) {
            if (Double.IsNaN(d) || Double.IsInfinity(d))
                return 0;
            return Convert.ToUInt32(d);
        }

        public static UInt32 ToUInt16(double d) {
            if (Double.IsNaN(d) || Double.IsInfinity(d))
                return 0;
            return Convert.ToUInt16(d);
        }

        public static double ToNumber(string value) {
            if (value == null) {
                return double.NaN;
            }

            double result;

            if (Double.TryParse(value, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out result)) {
                return result;
            } else {
                return double.NaN;
            }
        }

        public static int ToInteger(string value) {
            return ToInteger(ToNumber(value));
        }

        public static UInt32 ToUInt32(string value) {
            return ToUInt32(ToNumber(value));
        }

        public static UInt16 ToUInt16(string value) {
            return ToUInt16(ToNumber(value));
        }

        public static bool ToBoolean(string value) {
            if (value == null || value.Length == 0)
                return false;
            return true;
        }

        public static double ToNumber(DateTime date) {
            return (date.ToUniversalTime().Ticks - TICKS_OFFSET_1970) / TICKS_FACTOR;
        }

        /// <summary>
        /// returns a local time string
        /// </summary>
        /// <param name="dateTime">A DateTime object</param>
        /// <returns>a string representation of the date time</returns>
        public static string ToString(DateTime dateTime) {
            return dateTime.ToLocalTime().ToString(CultureInfo.CurrentCulture);
        }

        public static IConvertible ToPrimitive(IConvertible v) {
            if (v == null)
                return null;

            switch (v.GetTypeCode()) {
                case TypeCode.Boolean:
                case TypeCode.Double:
                case TypeCode.String:
                    return v;

                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.Decimal:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return Convert.ToDouble(v);

                case TypeCode.DBNull:
                case TypeCode.Empty:
                    return null;

                case TypeCode.DateTime:
                    return ToNumber((DateTime)v);

                break;
                case TypeCode.Object:
                    return v.ToString();
                break;
            };
        }

        public static bool ToBoolean(object value) {
            if (value == null)
                return false;

            IConvertible v = value as IConvertible;

            if (v == null) {
                return ToBoolean(v.ToString());
            }

            switch (v.GetTypeCode()) {
                case TypeCode.Boolean:
                    return (bool)v;

                case TypeCode.String:
                    return ToBoolean((string)v);

                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.Decimal:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return ToBoolean(Convert.ToDouble(v));

                case TypeCode.Double:
                    return ToBoolean((double)v);

                case TypeCode.DBNull:
                case TypeCode.Empty:
                    return false;

                case TypeCode.DateTime:
                    return true;
                
                case TypeCode.Object:
                    return ToBoolean(v.ToString());
            };
        }

        public static double ToNumber(object value) {
            if (value == null)
                return Double.NaN;
            IConvertible v = value as IConvertible;

            if (v == null)
                return ToNumber(v.ToString());

            switch (v.GetTypeCode()) {
                case TypeCode.Boolean:
                    return v ? 1 : 0;

                case TypeCode.String:
                    return ToNumber((string)v);

                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.Decimal:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return Convert.ToDouble(v);

                case TypeCode.Double:
                    return (double)v;

                case TypeCode.DBNull:
                case TypeCode.Empty:
                    return double.NaN;

                case TypeCode.DateTime:
                    return ToNumber((DateTime)v);

                case TypeCode.Object:
                    return ToNumber(v.ToString());
            };
        }

        public static int ToInteger(object value) {
            return ToInteger(ToNumber(value));
        }

        public static uint ToUInt32(object value) {
            return ToUInt32(ToNumber(value));
        }

        public static ushort ToUInt16(object value) {
            return ToUInt16(ToNumber(value));
        }

        public static DateTime ToDate(double value) {
            if (Double.IsNaN(value) || Double.IsInfinity(value))
                return DateTime.MinValue;
            return new DateTime((long)(number * JsDate.TICKSFACTOR + JsDate.OFFSET_1970), DateTimeKind.Utc);
        }
    }
}
