using System;

namespace Jint.Native {
    public interface IGlobal: IJsObject {
        bool HasOption(Options options);

        JsObjectConstructor ObjectClass { get; }
        JsFunctionConstructor FunctionClass { get; }
        JsArrayConstructor ArrayClass { get; }
        JsStringConstructor StringClass { get; }
        JsBooleanConstructor BooleanClass { get; }
        JsNumberConstructor NumberClass { get; }
        JsDateConstructor DateClass { get; }
        JsRegExpConstructor RegExpClass { get; }

        JsErrorConstructor ErrorClass { get; }
        JsErrorConstructor EvalErrorClass { get; }
        JsErrorConstructor RangeErrorClass { get; }
        JsErrorConstructor ReferenceErrorClass { get; }
        JsErrorConstructor SyntaxErrorClass { get; }
        JsErrorConstructor TypeErrorClass { get; }
        JsErrorConstructor URIErrorClass { get; }

        IJsObject NewPrimitive(string value);
        IJsObject NewPrimitive(double value);
        IJsObject NewPrimitive(bool value);

        IJsObject NaN { get; }
        IJsObject Infinity { get; }
        IJsObject Undefined { get; }

        IJsObject ParseInt(IJsInstance[] arguments);
        IJsObject ParseFloat(IJsInstance[] arguments);
        IJsObject IsNaN(IJsInstance[] arguments);
        IJsObject IsFinite(IJsInstance[] arguments);

        IJsObject DecodeURI(IJsInstance[] arguments);
        IJsObject DecodeURIComponent(IJsInstance[] arguments);
        IJsObject EncodeURI(IJsInstance[] arguments);
        IJsObject EncodeURIComponent(IJsInstance[] arguments);

        JsMath MathClass { get; }
        JsJSON JSON { get; }

        Marshaller Marshaller { get; }

    }
}
