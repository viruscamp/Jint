using System;

namespace Jint.Native {
    public interface IGlobal {
        bool HasOption(Options options);

        JsArrayConstructor ArrayClass { get; }
        JsBooleanConstructor BooleanClass { get; }
        JsDateConstructor DateClass { get; }
        JsErrorConstructor ErrorClass { get; }
        JsErrorConstructor EvalErrorClass { get; }
        JsFunctionConstructor FunctionClass { get; }
        IJsInstance IsNaN(Jint.Native.IJsInstance[] arguments);
        JsMathConstructor MathClass { get; }
        JsNumberConstructor NumberClass { get; }
        JsObjectConstructor ObjectClass { get; }
        IJsInstance ParseFloat(Jint.Native.IJsInstance[] arguments);
        IJsInstance ParseInt(Jint.Native.IJsInstance[] arguments);
        JsErrorConstructor RangeErrorClass { get; }
        JsErrorConstructor ReferenceErrorClass { get; }
        JsRegExpConstructor RegExpClass { get; }
        JsStringConstructor StringClass { get; }
        JsErrorConstructor SyntaxErrorClass { get; }
        JsErrorConstructor TypeErrorClass { get; }
        JsErrorConstructor URIErrorClass { get; }
        JsObject WrapClr(object value);

        IJsObject NewPrimitive(string value);
        IJsObject NewPrimitive(double value);
        IJsObject NewPrimitive(bool value);

        IJsInstance NaN { get; }

        // TODO: think about mutation
        Jint.Expressions.IJintVisitor Visitor { get; }
        Jint.Marshaller Marshaller { get; }
    }
}
