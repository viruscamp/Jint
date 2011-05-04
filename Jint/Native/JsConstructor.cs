using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Jint.Native {
    /// <summary>
    /// Constructors is a special class of functions, they are able to create
    /// new objects and always have a prototype.
    /// </summary>
    public abstract class JsConstructor : JsFunctionBase, IConstructor {
        IGlobal m_global;
        string m_name;

        JsDescriptorReference m_prototypeReference;
        
        protected JsConstructor(string name, IGlobal global, IJsObject prototype)
            : base(prototype) {

            Debug.Assert(global != null);
            
            m_prototypeReference = new JsDescriptorReference(this, PROTOTYPE);

            m_global = global;
        }

        public IGlobal Global {
            get { return m_global; }
        }

        public override string Name {
            get {
                return m_name;
            }
        }

        public override IList<string> Arguments {
            get { return new string[0]; }
        }

        public override string GetBody() {
            return "/* native code */";
        }

        /// <summary>
        /// Creates a new object and sets it's 'contructor' property to this constructor.
        /// </summary>
        /// <returns>A new object which references this constructor.</returns>
        protected IJsObject CreatePrototypeObject() {
            IJsObject obj = Global.ObjectClass.New();
            obj.DefineOwnProperty(new ValueDescriptor(obj, CONSTRUCTOR, this) { Enumerable = false }, true);
            return obj;
        }

        #region IConstructor Members

        public IJsObject PrototypeProperty {
            get {
                return m_prototypeReference.GetObject();
            }
            set {
                m_prototypeReference.SetObject(value);
            }
        }

        public bool HasInstance(IJsObject instance) {
            if (instance == null)
                throw new ArgumentNullException("instance");

            IJsObject proto = PrototypeProperty;
            for (IJsObject p = instance.Prototype; p != JsNull.Instance; p = p.Prototype)
                if (p == proto)
                    return true;
            return false;
        }

        public abstract IJsObject Construct(IJsInstance[] parameters, JsScope callingContext);

        #endregion
    }
}
