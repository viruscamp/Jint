using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Jint.Native {
    /// <summary>
    /// Number class, see ecma 262.5 15.7.
    /// </summary>
    /// <remarks>
    public sealed class JsNumber : JsObjectBase {

        double m_value;

        public JsNumber(double value, IJsObject prototype)
            : base(prototype) {
            m_value = value;
        }

        public override bool IsClr {
            get { return false; }
        }

        public override object Value {
            get {
                return m_value;
            }
            set {
                m_value = (double)value;
            }
        }

        public double PrimitiveValue {
            get {
                return m_value;
            }
        }

        public override string Class {
            get { return JsInstance.CLASS_NUMBER; }
        }

    }
}
