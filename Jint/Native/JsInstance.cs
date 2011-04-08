using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    /// <summary>
    /// absolute class, will be removed after refactoring
    /// </summary>
    class JsInstance {

        // TODO: remove
        public const string TYPE_OBJECT = "object";
        public const string TYPE_BOOLEAN = "boolean";
        public const string TYPE_STRING = "string";
        public const string TYPE_NUMBER = "number";
        public const string TYPE_UNDEFINED = "undefined";
        public const string TYPE_NULL = "null";

        public const string TYPEOF_FUNCTION = "function"; // used only in typeof operator!!!

        // embed classes ecma262.3 15

        public const string CLASS_NUMBER = "Number";
        public const string CLASS_STRING = "String";
        public const string CLASS_BOOLEAN = "Boolean";

        public const string CLASS_OBJECT = "Object";
        public const string CLASS_FUNCTION = "Function";
        public const string CLASS_ARRAY = "Array";
        public const string CLASS_REGEXP = "RegExp";
        public const string CLASS_DATE = "Date";
        public const string CLASS_ERROR = "Error";

        public const string CLASS_ARGUMENTS = "Arguments";
        public const string CLASS_GLOBAL = "Global";
        public const string CLASS_SCOPE = "Scope";

    }
}
