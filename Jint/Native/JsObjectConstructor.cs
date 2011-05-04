using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;
using System.Diagnostics;

namespace Jint.Native {
    [Serializable]
    public class JsObjectConstructor : JsConstructor {
        public JsObjectConstructor(IGlobal global, IJsObject prototype, JsObject prototypeProperty)
            : base(JsInstance.CLASS_OBJECT, global, prototype) {

            DefineOwnProperty(PROTOTYPE, prototypeProperty, ConstPropertyAttributes);
        
            DefineProperty(prototypeProperty, "constructor", this, PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty, "toString", global.FunctionClass.New<IJsObject>(ToStringImpl), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty, "toLocaleString", global.FunctionClass.New<IJsObject>(ToStringImpl), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty, "valueOf", global.FunctionClass.New<IJsObject>(ValueOfImpl), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty, "hasOwnProperty", global.FunctionClass.New<IJsObject>(HasOwnPropertyImpl,1), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty, "isPrototypeOf", global.FunctionClass.New<IJsObject>(IsPrototypeOfImpl,1), PropertyAttributes.DontEnum);
            DefineProperty(prototypeProperty, "propertyIsEnumerable", global.FunctionClass.New<IJsObject>(PropertyIsEnumerableImpl), PropertyAttributes.DontEnum);

            DefineOwnProperty("getPrototypeOf", global.FunctionClass.New(GetPrototypeOfImpl, 1), PropertyAttributes.DontEnum);
            DefineOwnProperty("getOwnPropertyDescriptor", global.FunctionClass.New(GetOwnPropertyDescriptorImpl, 2), PropertyAttributes.DontEnum);
            DefineOwnProperty("getOwnPropertyNames", global.FunctionClass.New(GetOwnPropertyNames, 1), PropertyAttributes.DontEnum);
            DefineOwnProperty("create", global.FunctionClass.New(CreateImpl, 1), PropertyAttributes.DontEnum);
            DefineOwnProperty("defineProperty", global.FunctionClass.New(DefinePropertyImpl, 3), PropertyAttributes.DontEnum);
            DefineOwnProperty("defineProperties", global.FunctionClass.New(DefinePropertiesImpl, 2), PropertyAttributes.DontEnum);
            DefineOwnProperty("seal", global.FunctionClass.New(SealImpl,1), PropertyAttributes.DontEnum);
            DefineOwnProperty("freeze", global.FunctionClass.New(FreezeImpl, 1), PropertyAttributes.DontEnum);
            DefineOwnProperty("preventExtensions", global.FunctionClass.New(PreventExtensionsImpl, 1), PropertyAttributes.DontEnum);
            DefineOwnProperty("isSealed", global.FunctionClass.New(IsSealedImpl, 1), PropertyAttributes.DontEnum);
            DefineOwnProperty("isFrozen", global.FunctionClass.New(IsFrozenImpl, 1), PropertyAttributes.DontEnum);
            DefineOwnProperty("isExtensible", global.FunctionClass.New(IsExtensibleImpl, 1), PropertyAttributes.DontEnum);
            DefineOwnProperty("keys", global.FunctionClass.New(KeysImpl, 1), PropertyAttributes.DontEnum);

        }

        /// <summary>
        /// Creates a new object which holds a specified value
        /// </summary>
        /// <param name="value">Value to store in the new object</param>
        /// <returns>new object</returns>
        public JsObject New(object value) {
            return new JsObject(value, this.PrototypeProperty);
        }

        public IJsObject New(object value, JsObject prototype)
        {
            return new JsObject(value, prototype);
        }

        public IJsObject New() {
            return new JsObject(PrototypeProperty);
        }

        public IJsObject New(JsObject prototype)
        {
            return new JsObject(prototype);
        }

        // 15.2.4.2 15.2.4.3
        internal IJsObject ToStringImpl(IJsObject target, IJsInstance[] parameters) {
            Debug.Assert(target != null);
            return Global.NewPrimitive(String.Concat("[object ", target.Class, "]"));
        }

        // 15.2.4.4
        internal IJsObject ValueOfImpl(IJsObject target, IJsInstance[] parameters) {
            Debug.Assert(target != null);
            return target;
        }

        // 15.2.4.5
        IJsObject HasOwnPropertyImpl(IJsObject target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            string key;

            if (parameters == null || parameters.Length == 0)
                key = JsUndefined.Instance.ToString();
            else
                key = parameters[0].GetObject().ToString();

            return Global.NewPrimitive( target.HasOwnProperty(key) );
        }

        // 15.2.4.6
        public IJsObject IsPrototypeOfImpl(IJsObject target, IJsInstance[] parameters) {
            Debug.Assert(target != null);

            IJsObject param = parameters = null || parameters.Length == 0 ? JsUndefined.Instance : parameters[0];
            if (param.Type != JsObjectType.Object)
                return Global.NewPrimitive(false);

            // if target is primitive it will return false, same result if primitive will be converted to new Object
            return Global.NewPrimitive( target.IsPrototypeOf(param) );
        }

        // 15.2.4.7
        public IJsObject PropertyIsEnumerableImpl(IJsObject target, IJsInstance[] parameters) {

            string key = parameters = null || parameters.Length == 0 ? JsUndefined.Instance.ToString() : parameters[0].GetObject().ToString() ;
            Descriptor d = target.GetOwnProperty(key);

            if (d == null || d.DescriptorType == DescriptorType.None)
                return Global.NewPrimitive(false);
            else
                return Global.NewPrimitive(d.Enumerable);
        }

        #region Constructor Object methods
        /// <summary>
        /// 15.2.3.2
        /// </summary>
        /// <returns></returns>
        IJsObject GetPrototypeOfImpl(IJsInstance[] parameters) {
            if (parameters == 0 || parameters.Length == 0 || parameters[0].Type != JsObjectType.Object)
                throw new JsTypeException("A parameter should be an object");
            
            return parameters[0].GetObject().Prototype;
        }

        // 15.2.3.3
        IJsObject GetOwnPropertyDescriptorImpl(IJsInstance[] parameters) {
            if (parameters == 0 || parameters.Length == 0 || parameters[0].Type != JsObjectType.Object)
                throw new JsTypeException("A first parameter should be an object");

            string key = parameters.Length > 1 ? parameters[0].GetObject().ToString() : JsUndefined.Instance.ToString();

            return parameters[0].GetObject().GetOwnProperty(key).ToObject();
        }

        // 15.2.3.4
        IJsObject GetOwnPropertyNames(IJsInstance[] parameters) {
            if (parameters == 0 || parameters.Length == 0 || parameters[0].Type != JsObjectType.Object)
                throw new JsTypeException("A parameter should be an object");

            JsArray result = new JsArray(Global.ArrayClass.PrototypeProperty);
            IJsObject target = parameters[0].GetObject();
            int i = 0;

            foreach (var d in target.GetOwnProperties())
                result.Put(i++, Global.NewPrimitive(d.Name));

            return result;
        }

        // 15.2.3.5
        IJsObject CreateImpl(IJsInstance[] parameters) {
            if (
                parameters == null || parameters.Length == 0
                || (parameters[0].Type != JsObjectType.Object && parameters[0].Type != JsObjectType.Null)
            )
                throw new JsTypeException("A first parameter should be either Object or Null");

            IJsObject result = New(parameters[0].GetObject());

            if (parameters.Length > 1 && parameters[1].Type != JsObjectType.Undefined)
                DefinePropertiesImpl(new JsInstance[] { result, parameters[1] });

            return result;
        }

        // 15.2.3.6
        IJsObject DefinePropertyImpl(IJsInstance[] parameters) {
            if (parameters == null || parameters.Length == 0 || parameters[0].Type != JsObjectType.Object)
                throw new JsTypeException("A parameter should be an object");

            IJsObject target = parameters[0].GetObject();
            string name = parameters.Length > 1 ? parameters[1].GetObject().ToString() : JsUndefined.Instance.ToString();
            IJsObject attributes = parameters.Length > 2 ? parameters[2].GetObject() : JsUndefined.Instance;

            Descriptor d = Descriptor.ToPropertyDesciptor(Global, target, name, attributes);
            target.DefineOwnProperty(d, true);

            return target;
        }

        // 15.2.3.7
        IJsObject DefinePropertiesImpl(IJsInstance[] parameters) {
            if (parameters == null || parameters.Length == 0 || parameters[0].Type != JsObjectType.Object)
                throw new JsTypeException("A parameter should be an object");

            IJsObject target = parameters[0].GetObject();
            IJsObject bag = parameters.Length > 1 ? parameters[1].GetObject().ToObject(Global) : JsUndefined.Instance.ToObject(Global);

            foreach (var item in bag.GetOwnProperties())
                if ( item.Enumerable )
                    DefineProperty(target, item.Name, item.Get(bag), PropertyAttributes.None);

            return target;
        }

        // 15.2.3.8
        IJsObject SealImpl(IJsInstance[] parameters) {
            if (parameters == null || parameters.Length == 0 || parameters[0].Type != JsObjectType.Object)
                throw new JsTypeException("A parameter should be an object");

            IJsObject target = parameters[0].GetObject();

            target.Seal();

            return target;
        }

        // 15.2.3.9
        IJsObject FreezeImpl(IJsInstance[] parameters) {
            if (parameters == null || parameters.Length == 0 || parameters[0].Type != JsObjectType.Object)
                throw new JsTypeException("A parameter should be an object");

            IJsObject target = parameters[0].GetObject();

            target.Freeze();

            return target;
        }

        // 15.2.3.10
        IJsObject PreventExtensionsImpl(IJsInstance[] parameters) {
            if (parameters == null || parameters.Length == 0 || parameters[0].Type != JsObjectType.Object)
                throw new JsTypeException("A parameter should be an object");

            IJsObject target = parameters[0].GetObject();

            target.PreventExtensions();

            return target;
        }

        // 15.2.3.11
        IJsObject IsSealedImpl(IJsInstance[] parameters) {
            if (parameters == null || parameters.Length == 0 || parameters[0].Type != JsObjectType.Object)
                throw new JsTypeException("A parameter should be an object");

            IJsObject target = parameters[0].GetObject();

            return Global.NewPrimitive(target.Sealed);
        }

        // 15.2.3.12
        IJsObject IsFrozenImpl(IJsInstance[] parameters) {
            if (parameters == null || parameters.Length == 0 || parameters[0].Type != JsObjectType.Object)
                throw new JsTypeException("A parameter should be an object");

            IJsObject target = parameters[0].GetObject();

            return Global.NewPrimitive(target.Frozen);
        }

        // 15.2.3.13
        IJsObject IsExtensibleImpl(IJsInstance[] parameters) {
            if (parameters == null || parameters.Length == 0 || parameters[0].Type != JsObjectType.Object)
                throw new JsTypeException("A parameter should be an object");

            IJsObject target = parameters[0].GetObject();

            return Global.NewPrimitive(target.Extensible);
        }

        // 15.2.3.14
        IJsObject KeysImpl(IJsInstance[] parameters) {
            if (parameters == 0 || parameters.Length == 0 || parameters[0].Type != JsObjectType.Object)
                throw new JsTypeException("A parameter should be an object");

            JsArray result = new JsArray(Global.ArrayClass.PrototypeProperty);
            IJsObject target = parameters[0].GetObject();
            int i = 0;

            foreach (var d in target.GetOwnProperties())
                if (d.Enumerable)
                    result.Put(i++, Global.NewPrimitive(d.Name));

            return result;
        }

        #endregion

        public override IJsObject Construct(IJsInstance[] parameters, JsScope callingContext) {
            if (parameters == null || parameters.Length == 0 || parameters[0].Type == JsObjectType.Null || parameters[0].Type == JsObjectType.Undefined)
                return New(PrototypeProperty);
            return parameters[0].GetObject().ToObject(Global);
        }

        public override int Length {
            get { return 1; }
        }

        public override IJsObject Invoke(IJsObject that, IJsInstance[] parameters, JsScope callingContext) {
            if (parameters == null || parameters.Length == 0 || parameters[0].Type == JsObjectType.Null || parameters[0].Type == JsObjectType.Undefined)
                return New(PrototypeProperty);
            else
                return parameters[0].GetObject().ToObject(Global);
        }
    }
}