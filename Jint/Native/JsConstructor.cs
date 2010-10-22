using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native
{
    [Serializable]
    public abstract class JsConstructor : JsFunction
    {
        /// <summary>
        /// Stores Global object used for creating this function.
        /// This property may be used in the InitProtype method.
        /// </summary>
        public IGlobal Global { get; set; }

        /// <summary>
        /// Constructs JsContructor, setting [[Prototype]] property to global.FunctionClass.PrototypeProperty
        /// </summary>
        /// <param name="global">Global</param>
        public JsConstructor(IGlobal global) : base( global )
        {
            Global = global;
        }

        /// <summary>
        /// Special form of the contructor used when constructin JsFunctionConstructor
        /// </summary>
        /// <param name="global">Global</param>
        /// <param name="prototype">Prototype</param>
        protected JsConstructor(IGlobal global,JsObject prototype)
            : base(prototype)
        {
            Global = global;
        }

        public abstract void InitPrototype(IGlobal global);
    }
}
