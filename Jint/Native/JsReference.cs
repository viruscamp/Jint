using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    /// <summary>
    /// Represents a reference.
    /// </summary>
    public abstract class JsReference: IJsInstance {

        #region IJsInstance Members
        public bool IsClr {
            get { return GetObject().IsClr; }
        }

        public object Value {
            get {
                return GetObject().Value;
            }
            set {
                GetObject().Value = value;
            }
        }

        public IJsObject ToPrimitive(IGlobal global) {
            return GetObject().ToPrimitive(global);
        }

        public IJsObject ToPrimitive(IGlobal global, JsObjectType hint) {
            return GetObject().ToPrimitive(global, hint);
        }

        public string Class {
            get { return GetObject().Class; }
        }

        public JsObjectType Type {
            get { return GetObject().Type; }
        }

        public bool IsReference {
            get { return true; }
        }

        public abstract IJsObject BaseObject {
            get;
        }

        public abstract string ReferencedProperty {
            get;
        }

        public abstract IJsObject GetObject();

        public abstract void SetObject(IJsObject value);

        #endregion
    }
}
