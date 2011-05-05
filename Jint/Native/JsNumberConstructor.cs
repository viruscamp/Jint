using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Jint.Expressions;
using System.Diagnostics;

namespace Jint.Native {
    [Serializable]
    public class JsNumberConstructor : JsConstructor {
        public JsNumberConstructor(IGlobal global)
            : base(JsInstance.CLASS_NUMBER, global, global.FunctionClass.PrototypeProperty) {

            IJsObject prototypeProperty = CreatePrototypeObject();
            
            DefineOwnProperty(PROTOTYPE, prototypeProperty , ConstPropertyAttributes);

            DefineOwnProperty("MAX_VALUE", global.NewPrimitive(Double.MaxValue), ConstPropertyAttributes );
            DefineOwnProperty("MIN_VALUE", global.NewPrimitive(Double.MinValue), ConstPropertyAttributes);
            DefineOwnProperty("NaN", global.NewPrimitive(Double.NaN), ConstPropertyAttributes);
            DefineOwnProperty("NEGATIVE_INFINITY", global.NewPrimitive(Double.PositiveInfinity), ConstPropertyAttributes);
            DefineOwnProperty("POSITIVE_INFINITY", global.NewPrimitive(Double.NegativeInfinity), ConstPropertyAttributes);

            var fc = global.FunctionClass;

            DefineProperty(prototypeProperty,"toString", fc.New(ToStringImpl, 1), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty,"toLocaleString", fc.New(ToLocaleStringImpl), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty,"toFixed", fc.New(ToFixedImpl), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty,"toExponential", fc.New(ToExponentialImpl), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty,"toPrecision", fc.New(ToPrecisionImpl), PropertyAttributes.DontEnum);
        }

        public JsNumber New(double value) {
            return new JsNumber(value, PrototypeProperty);
        }

        public JsNumber New() {
            return New(0d);
        }

        IJsObject ToLocaleStringImpl(JsNumber target, IJsInstance[] parameters) {
            return ToStringImpl(target, null);
        }

        // TODO: implement radix convertions
        IJsObject ToStringImpl(JsNumber target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if ( Double.IsNaN( target.PrimitiveValue ) ) {
                return Global.NewPrimitive("NaN");
            }

            if ( Double.IsNegativeInfinity( target.PrimitiveValue ) ) {
                return Global.NewPrimitive("-Infinity");
            }

            if ( Double.IsPositiveInfinity( target.PrimitiveValue ) ) {
                return Global.NewPrimitive("Infinity");
            }

            int radix = 10;

            // is radix defined ?
            if (parameters != null && parameters.Length > 0) {
                IJsObject p0 = parameters[0].GetObject();

                if (p0.ToNumber() != p0.ToInteger())
                    throw new JsTypeException("A radix should be an integer");

                radix = p0.ToInteger();
                if (radix < 2 || radix > 36)
                    throw new JsTypeException("A radix should be between 2 and 36");
            }

            if (radix == 10) {
                return Global.NewPrimitive(ConversionTraits.ToString(target.PrimitiveValue));
            }
            else {
                return Global.NewPrimitive(
                    Convert.ToString(
                        Convert.ToUInt32(target.PrimitiveValue, CultureInfo.InvariantCulture),
                        Convert.ToInt32(radix)
                    )
                    .ToLower()
                );
            }
        }

        /// <summary>
        /// 15.7.4.5
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IJsObject ToFixedImpl(JsNumber target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            int fractions = 0;
            if (parameters != null && parameters.Length > 0) {
                fractions = parameters[0].GetObject().ToInteger();
            }

            if (fractions > 20 || fractions < 0) {
                throw new JsRangeException("Fraction Digits must be greater than 0 and lesser than 20");
            }

            if ( Double.IsNaN( target.PrimitiveValue ) ) {
                return Global.NewPrimitive("NaN");
            }

            return Global.NewPrimitive(
                target.PrimitiveValue.ToString("f" + fractions, CultureInfo.InvariantCulture)
            );
        }

        /// <summary>
        /// 15.7.4.6
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IJsObject ToExponentialImpl(JsNumber target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (double.IsInfinity(target.PrimitiveValue) || double.IsNaN(target.PrimitiveValue)) {
                return ToStringImpl(target, null);
            }

            int fractions = 16;
            if (paramerters != null && parameters.Length > 0) {
                fractions = parameters[0].GetObject().ToInteger();
            }

            if (fractions > 20 || fractions < 0) {
                throw new JsRangeException("Fraction Digits must be greater than 0 and lesser than 20");
            }

            string format = String.Concat("#.", new String('0', fractions), "e+0");
            return Global.NewPrimitive(target.PrimitiveValue.ToString(format, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// 15.7.4.7
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IJsObject ToPrecisionImpl(JsNumber target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            if (double.IsInfinity(target.PrimitiveValue) || double.IsNaN(target.PrimitiveValue)) {
                return ToStringImpl(target, new IJsInstance[0]);
            }

            if (parameters == null || parameters.Length == 0) {
                return Global.NewPrimitive( ConversionTraits.ToString(target.PrimitiveValue) );
            }

            if (parameters[0] == JsUndefined.Instance) {
                return ToStringImpl(target, new IJsInstance[0]);
            }

            int precision = 0;
            if (parameters.Length > 0) {
                precision = Convert.ToInt32(parameters[0].ToNumber());
            }

            if (precision < 1 || precision > 21) {
                throw new JsRangeException("precision must be between 1 and 21");
            }

            // Get the number of decimals
            string str = target.PrimitiveValue.ToString("e23", CultureInfo.InvariantCulture);
            int decimals = str.IndexOfAny(new char[] { '.', 'e' });
            decimals = decimals == -1 ? str.Length : decimals;

            precision -= decimals;
            precision = precision < 1 ? 1 : precision;

            return Global.NewPrimitive(target.PrimitiveValue.ToString("f" + precision, CultureInfo.InvariantCulture));
        }

        public override IJsObject Construct(IJsInstance[] parameters, JsScope callingContext) {
            if (parameters != null && parameters.Length > 0)
                return New(parameters[0].GetObject().ToNumber());
            else
                return New();
        }

        public override int Length {
            get { return 1; }
        }

        public override IJsObject Invoke(IJsObject that, IJsInstance[] parameters, JsScope callingContext) {
            if (parameters != null && parameters.Length > 0)
                return Global.NewPrimitive(parameters[0].GetObject().ToNumber());
            else
                return Global.NewPrimitive(0);
        }
    }
}
