using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;

namespace Jint.Native
{
    [Serializable]
    public class JsFunction : JsObject
    {        
        public static string CALL = "call";
        public static string APPLY = "apply";
        public static string CONSTRUCTOR = "constructor";
        public static string PROTOTYPE = "prototype";

        public string Name { get; set; }
        public Statement Statement { get; set; }
        public List<string> Arguments { get; set; }
        public JsScope Scope { get; set; }

        public JsFunction(IGlobal global, Statement statement)
            : this(global.FunctionClass.PrototypeProperty)
        {
            Statement = statement;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="global"></param>
        public JsFunction(IGlobal global)
            : this(global.FunctionClass.PrototypeProperty)
        {
        }

        /// <summary>
        /// Init new function object with a specified prototype
        /// </summary>
        /// <param name="prototype">prototype for this object</param>
        public JsFunction(JsObject prototype)
            : base(prototype)
        {
            Arguments = new List<string>();
            Statement = new EmptyStatement();
        }

        public JsObject PrototypeProperty
        {
            get {
                return this[PROTOTYPE] as JsObject;
            }
            set {
                this[PROTOTYPE] = value;
            }
        }

        //15.3.5.3
        public virtual bool HasInstance(JsObject inst)
        {
            if (inst != null && inst != JsNull.Instance && inst != JsNull.Instance)
            {
                return this.PrototypeProperty.IsPrototypeOf(inst);
            }
            return false;
        }

        //13.2.2
        public virtual JsObject Construct(JsInstance[] parameters, Type[] genericArgs, ExecutionVisitor visitor)
        {
            var instance = visitor.Global.ObjectClass.New(PrototypeProperty);
            visitor.ExecuteFunction(this,instance,parameters);

            return (visitor.Result as JsObject ?? instance);
        }

        public override object Value
        {
            get { return null; }
            set { }
        }

        public virtual JsInstance Execute(IJintVisitor visitor, JsDictionaryObject that, JsInstance[] parameters)
        {
            visitor.CallFunction(this, that, parameters);
            return that;
        }

        public const string TYPEOF = "function";

        public override string Class
        {
            get { return TYPEOF; }
        }

        public override string ToSource()
        {
            return String.Concat("(function ", String.IsNullOrEmpty(Name) ? "anonymous" : Name, "() { ... })");
        }

        public override string ToString()
        {
            return TYPEOF;
        }

        public override bool ToBoolean()
        {
            return true;
        }
    }
}
