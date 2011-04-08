using System;
namespace Jint.Native {
    public interface IGlobal {
        bool HasOption(Options options);

        Jint.Native.JsArrayConstructor ArrayClass { get; }
        Jint.Native.JsBooleanConstructor BooleanClass { get; }
        Jint.Native.JsDateConstructor DateClass { get; }
        Jint.Native.JsErrorConstructor ErrorClass { get; }
        Jint.Native.JsErrorConstructor EvalErrorClass { get; }
        Jint.Native.JsFunctionConstructor FunctionClass { get; }
        Jint.Native.IJsInstance IsNaN(Jint.Native.IJsInstance[] arguments);
        Jint.Native.JsMathConstructor MathClass { get; }
        Jint.Native.JsNumberConstructor NumberClass { get; }
        Jint.Native.JsObjectConstructor ObjectClass { get; }
        Jint.Native.IJsInstance ParseFloat(Jint.Native.IJsInstance[] arguments);
        Jint.Native.IJsInstance ParseInt(Jint.Native.IJsInstance[] arguments);
        Jint.Native.JsErrorConstructor RangeErrorClass { get; }
        Jint.Native.JsErrorConstructor ReferenceErrorClass { get; }
        Jint.Native.JsRegExpConstructor RegExpClass { get; }
        Jint.Native.JsStringConstructor StringClass { get; }
        Jint.Native.JsErrorConstructor SyntaxErrorClass { get; }
        Jint.Native.JsErrorConstructor TypeErrorClass { get; }
        Jint.Native.JsErrorConstructor URIErrorClass { get; }
        Jint.Native.JsObject WrapClr(object value);

        IJsInstance NaN { get; }

        Jint.Expressions.IJintVisitor Visitor { get; }
        Jint.Marshaller Marshaller { get; }
    }
}
