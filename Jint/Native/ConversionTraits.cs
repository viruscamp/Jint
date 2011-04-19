using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Jint.Native {
    /// <summary>
    /// ecma 262.5 9
    /// </summary>
    public static class ConversionTraits {
        
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
    }
}
