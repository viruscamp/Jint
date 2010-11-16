using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;
using System.Collections;
using System.Reflection;
using Jint.Native;
using Jint.Debugger;
using System.Security;
using System.Runtime.Serialization;
using Jint.Delegates;

namespace Jint {
    [Serializable]
    public class ExecutionVisitor : IStatementVisitor, IJintVisitor, IDeserializationCallback {
        struct ResultInfo {
            // When the last result is a base object
            public JsDictionaryObject baseObject;
            public JsInstance result;
        }

        [NonSerialized]
        protected internal IFieldGetter fieldGetter;
        [NonSerialized]
        protected internal IPropertyGetter propertyGetter;
        [NonSerialized]
        protected internal IMethodInvoker methodInvoker;
        [NonSerialized]
        protected internal IConstructorInvoker constructorInvoker;
        [NonSerialized]
        protected internal ITypeResolver typeResolver;

        public IGlobal Global { get; private set; }
        public JsScope GlobalScope { get; private set; }

        protected Stack<JsScope> Scopes = new Stack<JsScope>();

        protected bool exit;
        protected JsInstance returnInstance;
        protected int recursionLevel;

        public event EventHandler<DebugInformation> Step;
        public Stack<string> CallStack { get; set; }
        public Statement CurrentStatement { get; set; }

        public bool DebugMode { get; set; }
        public int MaxRecursions { get; set; }

        public JsInstance Returned { get { return returnInstance; } }
        public bool AllowClr { get; set; }
        public PermissionSet PermissionSet { get; set; }
        [NonSerialized]
        private StringBuilder typeFullname = new StringBuilder();
        private string lastIdentifier = String.Empty;

        /// <summary>
        /// Use to keep the previous evaluated member to call the method on (e.g., myArray/.push/()). When
        /// evaluating the MethodCall, the latest Result is a JsFunction, and myArray is lost. Here it will be 
        /// in callTarget
        /// </summary>

        ResultInfo lastResult;
        Stack<ResultInfo> stackResults = new Stack<ResultInfo>();

        public JsDictionaryObject CallTarget {
            get {
                return lastResult.baseObject;
            }
        }
        public JsInstance Result {
            get {
                return lastResult.result;
            }
            set {
                lastResult.result = value;
                lastResult.baseObject = null;
            }
        }

        public void SetResult(JsInstance value, JsDictionaryObject baseObject) {
            lastResult.result = value;
            lastResult.baseObject = baseObject;
        }

        void SaveResult() {
            stackResults.Push(lastResult);
        }
        void RestoreResult() {
            lastResult = stackResults.Pop();
        }

        public ExecutionVisitor(Options options) {
            methodInvoker = new CachedMethodInvoker(this);
            propertyGetter = new CachedReflectionPropertyGetter(methodInvoker);
            constructorInvoker = new CachedConstructorInvoker(methodInvoker);
            typeResolver = new CachedTypeResolver();
            fieldGetter = new CachedReflectionFieldGetter(methodInvoker);

            Global = new JsGlobal(this, options);
            GlobalScope = new JsScope(Global as JsObject);

            EnterScope(GlobalScope);

            CallStack = new Stack<string>();
        }

        public void OnStep(DebugInformation info) {
            if (Step != null && info.CurrentStatement != null && info.CurrentStatement.Source != null) {
                Step(this, info);
            }
        }

        public DebugInformation CreateDebugInformation(Statement statement) {
            DebugInformation info = new DebugInformation();
            info.CurrentStatement = statement;
            info.CallStack = CallStack;
            info.Locals = new JsObject(JsNull.Instance);
            DebugMode = false;

            foreach (var property in CurrentScope.GetKeys())
                info.Locals[property] = CurrentScope[property];

            DebugMode = true;

            return info;
        }

        public JsScope CurrentScope {
            get { return Scopes.Peek(); }
        }

        protected void EnterScope(JsDictionaryObject scope) {
            Scopes.Push(new JsScope(CurrentScope, scope));
        }

        protected void EnterScope(JsScope scope) {
            Scopes.Push(scope);
        }

        protected void ExitScope() {
            Scopes.Pop();
        }


        public void Visit(Program program) {
            // initialize local variables, in case the visitor is used multiple times by the same engine
            typeFullname = new StringBuilder();
            exit = false;
            lastIdentifier = String.Empty;

            foreach (var statement in program.ReorderStatements()) {
                CurrentStatement = statement;

                if (DebugMode) {
                    OnStep(CreateDebugInformation(statement));
                }
                Result = null;
                statement.Accept(this);

                if (exit) {
                    exit = false;
                    return;
                }
            }
        }


        public void Visit(AssignmentExpression statement) {
            switch (statement.AssignmentOperator) {
                case AssignmentOperator.Assign: statement.Right.Accept(this);
                    break;
                case AssignmentOperator.Multiply: new BinaryExpression(BinaryExpressionType.Times, statement.Left, statement.Right).Accept(this);
                    break;
                case AssignmentOperator.Divide: new BinaryExpression(BinaryExpressionType.Div, statement.Left, statement.Right).Accept(this);
                    break;
                case AssignmentOperator.Modulo: new BinaryExpression(BinaryExpressionType.Modulo, statement.Left, statement.Right).Accept(this);
                    break;
                case AssignmentOperator.Add: new BinaryExpression(BinaryExpressionType.Plus, statement.Left, statement.Right).Accept(this);
                    break;
                case AssignmentOperator.Substract: new BinaryExpression(BinaryExpressionType.Minus, statement.Left, statement.Right).Accept(this);
                    break;
                case AssignmentOperator.ShiftLeft: new BinaryExpression(BinaryExpressionType.LeftShift, statement.Left, statement.Right).Accept(this);
                    break;
                case AssignmentOperator.ShiftRight: new BinaryExpression(BinaryExpressionType.RightShift, statement.Left, statement.Right).Accept(this);
                    break;
                case AssignmentOperator.UnsignedRightShift: new BinaryExpression(BinaryExpressionType.UnsignedRightShift, statement.Left, statement.Right).Accept(this);
                    break;
                case AssignmentOperator.And: new BinaryExpression(BinaryExpressionType.BitwiseAnd, statement.Left, statement.Right).Accept(this);
                    break;
                case AssignmentOperator.Or: new BinaryExpression(BinaryExpressionType.BitwiseOr, statement.Left, statement.Right).Accept(this);
                    break;
                case AssignmentOperator.XOr: new BinaryExpression(BinaryExpressionType.BitwiseXOr, statement.Left, statement.Right).Accept(this);
                    break;
                default: throw new NotSupportedException();
            }

            JsInstance right = Result;

            MemberExpression left = statement.Left as MemberExpression;
            if (left == null) {
                left = new MemberExpression(statement.Left, null);
            }

            Assign(left, right);

            Result = right;
        }

        public void Assign(MemberExpression left, JsInstance value) {
            string propertyName;
            Descriptor d = null;

            if (!(left.Member is IAssignable)) {
                throw new JintException("The left member of an assignment must be a member");
            }

            JsDictionaryObject baseObject;

            if (left.Previous != null) {
                // if this a property
                left.Previous.Accept(this);
                baseObject = Result as JsDictionaryObject;

                if (baseObject == null)
                    throw new JintException("Attempt to assign to an undefined variable.");
            }
            else {
                baseObject = CurrentScope;
                // this a variable
                propertyName = ((Identifier)left.Member).Text;

                CurrentScope.TryGetDescriptor(propertyName, out d);
            }

            // now baseObject contains an object or a scope against which to resolve left.Member

            if (left.Member is Identifier) {
                propertyName = ((Identifier)left.Member).Text;
            }
            else {
                Indexer indexer = left.Member as Indexer;

                // calculate index expression
                indexer.Index.Accept(this);

                // The left member might be a CLR instance
                if (baseObject.IsClr) {
                    if (baseObject.Value.GetType().IsArray) {
                        Array array = (Array)baseObject.Value;
                        array.SetValue(Convert.ChangeType(value.Value, array.GetType().GetElementType()), (int)Result.ToNumber());
                        return;
                    }
                    else // Search custom indexer
                    {
                        // Converts to CLR objects
                        var parameters = JsClr.ConvertParameters(Result, value);

                        PropertyInfo pi = propertyGetter.GetValue(baseObject.Value, "Item", parameters);

                        if (pi != null) {
                            pi.GetSetMethod().Invoke(baseObject.Value, parameters);
                            Result = Global.ObjectClass.New(baseObject.Value);
                            return;
                        }
                    }
                }

                propertyName = Result.Value.ToString();
            }

            EnsureIdentifierIsDefined(value);

            // Assigning function Name
            if (value.Class == JsFunction.TYPEOF)
                ((JsFunction)value).Name = propertyName;

            Result = baseObject[propertyName] = value;
        }

        public void Visit(CommaOperatorStatement statement) {
            foreach (var s in statement.Statements) {
                if (DebugMode) {
                    OnStep(CreateDebugInformation(s));
                }

                s.Accept(this);

                if (StopStatementFlow()) {
                    return;
                }
            }
        }

        public void Visit(BlockStatement statement) {
            Statement oldStatement = CurrentStatement;
            foreach (var s in statement.ReorderStatements()) {
                CurrentStatement = s;

                if (DebugMode) {
                    OnStep(CreateDebugInformation(s));
                }

                Result = null;
                s.Accept(this);

                if (StopStatementFlow()) {
                    return;
                }
            }
            CurrentStatement = oldStatement;
        }

        protected ContinueStatement continueStatement = null;
        public void Visit(ContinueStatement statement) {
            continueStatement = statement;
        }

        protected BreakStatement breakStatement = null;
        public void Visit(BreakStatement statement) {
            breakStatement = statement;
        }

        public void Visit(DoWhileStatement statement) {
            JsObject scope = new JsObject();
            EnterScope(scope);
            try {
                do {
                    statement.Statement.Accept(this);

                    ResetContinueIfPresent(statement.Label);

                    if (StopStatementFlow()) {
                        if (breakStatement != null && statement.Label == breakStatement.Label) {
                            breakStatement = null;
                        }

                        //ExitScope();
                        return;
                    }

                    statement.Condition.Accept(this);

                } while (Result.ToBoolean());
            }
            finally {
                ExitScope();
            }
        }

        public void Visit(EmptyStatement statement) {
            return;
        }

        [System.Diagnostics.DebuggerStepThrough]
        public void Visit(ExpressionStatement statement) {
            statement.Expression.Accept(this);
        }

        public void Visit(ForEachInStatement statement) {
            // todo: may be declare own property in the current scope if not a globalDeclaration?
            bool globalDeclaration = true;
            string identifier = String.Empty;

            if (statement.InitialisationStatement is VariableDeclarationStatement) {
                globalDeclaration = ((VariableDeclarationStatement)statement.InitialisationStatement).Global;
                identifier = ((VariableDeclarationStatement)statement.InitialisationStatement).Identifier;
            }
            else if (statement.InitialisationStatement is Identifier) {
                globalDeclaration = true;
                identifier = ((Identifier)statement.InitialisationStatement).Text;
            }
            else {
                throw new NotSupportedException("Only variable declaration are allowed in a for in loop");
            }

            statement.Expression.Accept(this);

            var dictionary = Result as JsDictionaryObject;

            if (Result.Value is IEnumerable) {
                foreach (object value in (IEnumerable)Result.Value) {
                    CurrentScope[identifier] = Global.WrapClr(value);

                    statement.Statement.Accept(this);

                    ResetContinueIfPresent(statement.Label);

                    if (StopStatementFlow()) {
                        if (breakStatement != null && statement.Label == breakStatement.Label) {
                            breakStatement = null;
                        }

                        return;
                    }

                    ResetContinueIfPresent(statement.Label);
                }
            }
            else if (dictionary != null) {
                List<string> keys = new List<string>(dictionary.GetKeys());

                // Uses a for loop as it might be changed by the inner statements
                for (int i = 0; i < keys.Count; i++) {
                    string value = keys[i];

                    CurrentScope[identifier] = Global.StringClass.New(value);

                    statement.Statement.Accept(this);

                    ResetContinueIfPresent(statement.Label);

                    if (StopStatementFlow()) {
                        if (breakStatement != null && statement.Label == breakStatement.Label) {
                            breakStatement = null;
                        }

                        return;
                    }

                    ResetContinueIfPresent(statement.Label);
                }
            }
            else {
                throw new InvalidOperationException("The property can't be enumerated");
            }

        }

        public void Visit(WithStatement statement) {
            statement.Expression.Accept(this);

            if (!(Result is JsDictionaryObject)) {
                throw new JsException(Global.StringClass.New("Invalid expression in 'with' statement"));
            }

            EnterScope((JsDictionaryObject)Result);

            try {
                statement.Statement.Accept(this);
            }
            finally {
                ExitScope();
            }
        }

        public void Visit(ForStatement statement) {
            if (statement.InitialisationStatement != null)
                statement.InitialisationStatement.Accept(this);

            if (statement.ConditionExpression != null)
                statement.ConditionExpression.Accept(this);
            else
                Result = Global.BooleanClass.New(true);
            while (Result.ToBoolean()) {
                statement.Statement.Accept(this);

                ResetContinueIfPresent(statement.Label);

                if (StopStatementFlow()) {
                    if (breakStatement != null && statement.Label == breakStatement.Label) {
                        breakStatement = null;
                    }

                    return;
                }

                // Goes back in the scopes so that the variables are accessible after the statement
                if (statement.IncrementExpression != null)
                    statement.IncrementExpression.Accept(this);

                if (statement.ConditionExpression != null)
                    statement.ConditionExpression.Accept(this);
                else
                    Result = Global.BooleanClass.New(true);

            }
        }

        public JsFunction CreateFunction(IFunctionDeclaration functionDeclaration) {
            JsFunction f = Global.FunctionClass.New();
            f.Statement = functionDeclaration.Statement;
            f.Name = functionDeclaration.Name;
            f.Scope = CurrentScope; // copy current scope hierarchy

            // TODO: cleanup
            // add a return undefined; statement at the end of each method
            /* BlockStatement block = (BlockStatement)f.Statement;
            if (block.Statements.Count == 0)
            {
                block.Statements.AddLast(new ReturnStatement(new ValueExpression(JsUndefined.TYPEOF)));
            }
             */

            f.Arguments = functionDeclaration.Parameters;
            if (HasOption(Options.Strict)) {
                foreach (string arg in f.Arguments) {
                    if (arg == "eval" || arg == "arguments")
                        throw new JsException(Global.StringClass.New("The parameters do not respect strict mode"));
                }
            }

            return f;
        }

        public void Visit(FunctionDeclarationStatement statement) {
            JsFunction f = CreateFunction(statement);
            CurrentScope[statement.Name] = f;
        }

        public void Visit(IfStatement statement) {
            statement.Expression.Accept(this);
            if (Result.ToBoolean()) {
                statement.Then.Accept(this);
            }
            else {
                if (statement.Else != null) {
                    statement.Else.Accept(this);
                }
            }
        }

        public void Visit(ReturnStatement statement) {
            returnInstance = null;

            if (statement.Expression != null) {
                statement.Expression.Accept(this);
                Return(Result);
            }

            exit = true;
        }

        public JsInstance Return(JsInstance instance) {
            returnInstance = instance;
            return returnInstance;
        }

        public void Visit(SwitchStatement statement) {
            CurrentStatement = statement.Expression;

            //statement.Expression.Accept(this);
            //JsInstance caseValue = Result;

            bool found = false;
            foreach (var clause in statement.CaseClauses) {
                CurrentStatement = clause.Expression;

                //clause.Expression.Accept(this);

                new BinaryExpression(BinaryExpressionType.Equal, (Expression)statement.Expression, clause.Expression).Accept(this);

                if (Result.ToBoolean()) {
                    clause.Statements.Accept(this);

                    found = true;
                    break;
                }
            }

            if (!found) {
                statement.DefaultStatements.Accept(this);
            }
        }

        public void Visit(ThrowStatement statement) {
            Result = JsUndefined.Instance;

            if (statement.Expression != null) {
                statement.Expression.Accept(this);
            }

            throw new JsException(Result);
        }

        public void Visit(TryStatement statement) {
            EnterScope(new JsObject());

            try {
                statement.Statement.Accept(this);
            }
            catch (JsException jsException) {
                ExitScope();

                EnterScope(new JsObject());

                // handle thrown exception assignment to a local variable: catch(e)
                if (statement.Catch.Identifier != null) {
                    // if catch is called, Result contains the thrown value
                    Assign(new MemberExpression(new PropertyExpression(statement.Catch.Identifier), null), jsException.Value);
                }

                statement.Catch.Statement.Accept(this);
            }
            finally {
                ExitScope();

                if (statement.Finally != null) {
                    JsObject catchScope = new JsObject();
                    EnterScope(catchScope);

                    statement.Finally.Statement.Accept(this);

                    ExitScope();
                }
            }

        }

        public void Visit(VariableDeclarationStatement statement) {
            Result = JsUndefined.Instance;

            // if the right expression is not defined, declare the variable as undefined
            if (statement.Expression != null) {
                statement.Expression.Accept(this);
                if (statement.Global) {
                    // todo: where is it from? 
                }
                else {
                    if (!CurrentScope.HasOwnProperty(statement.Identifier))
                        CurrentScope.DefineOwnProperty(statement.Identifier, Result);
                    else
                        CurrentScope[statement.Identifier] = Result;
                }
            }
            else {
                // a var declaration should not affect existing one
                if (!CurrentScope.HasOwnProperty(statement.Identifier))
                    CurrentScope.DefineOwnProperty(statement.Identifier, JsUndefined.Instance);
            }



        }

        public void Visit(WhileStatement statement) {
            JsObject scope = new JsObject();
            EnterScope(scope);
            try {
                statement.Condition.Accept(this);

                while (Result.ToBoolean()) {
                    statement.Statement.Accept(this);

                    ResetContinueIfPresent(statement.Label);

                    if (StopStatementFlow()) {
                        if (breakStatement != null && statement.Label == breakStatement.Label) {
                            breakStatement = null;
                        }

                        return;
                    }

                    statement.Condition.Accept(this);
                }
            }
            finally {
                ExitScope();
            }
        }

        public void Visit(NewExpression expression) {


            //int scopes = Scopes.Count;

            //foreach (var property in expression.Identifiers)
            //{
            //    property.Accept(this);

            //    if (Result == null)
            //    {
            //        break;
            //    }

            //    EnterScope((JsDictionaryObject)Result);
            //}

            //while (scopes < Scopes.Count)
            //{
            //    ExitScope();
            //}

            Result = null;

            // don't even try if there is a generic type specifier

            if (expression.Generics.Count == 0) {
                expression.Expression.Accept(this);
            }

            if (Result != null && Result.Class == JsFunction.TYPEOF) {
                JsFunction function = (JsFunction)Result;

                // Process parameters
                JsInstance[] parameters = new JsInstance[expression.Arguments.Count];

                for (int i = 0; i < expression.Arguments.Count; i++) {
                    expression.Arguments[i].Accept(this);
                    parameters[i] = Result;
                }

                // TODO: implement construct method inside the JsFunction
                // Calls the constructor on a brand new object
                JsObject instance;
                if (function is JsArrayConstructor) {
                    instance = new JsArray(function.PrototypeProperty);
                }
                else {
                    instance = new JsObject(function.PrototypeProperty);
                }

                // Once 'new' is called, the result is the new instance, given by the Execute() method on the proper constructor
                ExecuteFunction(function, instance, parameters);

                return;
            }

            if (Result != null && Result.IsClr && Result.Value is Type) {
                Type type = (Type)Result.Value;

                var tempTypeFullname = typeFullname;

                var parameters = new object[expression.Arguments.Count];

                for (int i = 0; i < expression.Arguments.Count; i++) {
                    typeFullname = new StringBuilder();
                    expression.Arguments[i].Accept(this);
                    parameters[i] = JsClr.ConvertParameter(Result);
                }

                typeFullname = tempTypeFullname;

                var constructor = constructorInvoker.Invoke(type, parameters);

                if (constructor == null) {
                    // Struct don't reflect their default constructor
                    if (type.IsValueType) {
                        PermissionSet.PermitOnly();

                        try {
                            Result = Global.WrapClr(Activator.CreateInstance(type));
                        }
                        finally {
                            CodeAccessPermission.RevertPermitOnly();
                        }
                    }
                    else {
                        throw new JintException("Matching constructor not found for: " + type.Name);
                    }
                }
                else {

                    PermissionSet.PermitOnly();

                    try {
                        Result = Global.WrapClr(constructor.Invoke(parameters));
                    }
                    finally {
                        CodeAccessPermission.RevertPermitOnly();
                    }
                }
            }

            // Try to get identifiers as a CLR type
            if (Result == null) {
                EnsureClrAllowed();

                // Process parameters
                object[] parameters = new object[expression.Arguments.Count];

                for (int i = 0; i < expression.Arguments.Count; i++) {
                    typeFullname = new StringBuilder();
                    expression.Arguments[i].Accept(this);
                    parameters[i] = JsClr.ConvertParameter(Result);
                }

                expression.Expression.Accept(this);

                var typeBuilder = new StringBuilder(typeFullname.ToString());

                if (expression.Generics.Count > 0) {
                    List<string> types = new List<string>();
                    foreach (Expression generic in expression.Generics) {
                        typeFullname = new StringBuilder();
                        generic.Accept(this);

                        if (!(Result.Value is Type)) {
                            throw new JintException("Invalid generic type");
                        }

                        types.Add(Result.Value.ToString());
                    }

                    typeBuilder.Append("`").Append(types.Count);
                    typeBuilder.Append("[");
                    typeBuilder.Append(String.Join(",", types.ToArray()));
                    typeBuilder.Append("]");
                }

                var type = typeResolver.ResolveType(typeBuilder.ToString());

                if (type == null) {
                    throw new JintException("Unknown type: " + typeBuilder);
                }

                typeFullname = new StringBuilder();

                var constructor = constructorInvoker.Invoke(type, parameters);

                if (constructor == null) {
                    // Struct don't reflect their default constructor
                    if (type.IsValueType) {
                        PermissionSet.PermitOnly();

                        try {
                            Result = Global.WrapClr(Activator.CreateInstance(type));
                        }
                        finally {
                            CodeAccessPermission.RevertPermitOnly();
                        }
                    }
                    else {
                        throw new JintException("Matching constructor not found for: " + typeBuilder);
                    }
                }
                else {
                    PermissionSet.PermitOnly();

                    try {
                        Result = Global.WrapClr(constructor.Invoke(parameters));
                    }
                    finally {
                        CodeAccessPermission.RevertPermitOnly();
                    }
                }
            }
        }

        public void Visit(TernaryExpression expression) {
            Result = null;

            // Evaluates the left expression and saves the value
            expression.LeftExpression.Accept(this);
            var left = Result;

            Result = null;

            if (left.ToBoolean()) {
                // Evaluates the middle expression
                expression.MiddleExpression.Accept(this);
            }
            else {
                // Evaluates the right expression
                expression.RightExpression.Accept(this);
            }
        }

        public static bool IsNullOrUndefined(JsInstance o) {
            return (o == JsUndefined.Instance) || (o == JsNull.Instance) || (o.IsClr && o.Value == null);
        }

        public void Visit(BinaryExpression expression) {
            // Evaluates the left expression and saves the value
            expression.LeftExpression.Accept(this);

            EnsureIdentifierIsDefined(Result);

            JsInstance left = Result;

            //prevents execution of the right hand side if false
            if (expression.Type == BinaryExpressionType.And && !left.ToBoolean()) {
                Result = left;
                return;
            }

            //prevents execution of the right hand side if true
            if (expression.Type == BinaryExpressionType.Or && left.ToBoolean()) {
                Result = left;
                return;
            }

            // Evaluates the right expression and saves the value
            expression.RightExpression.Accept(this);

            EnsureIdentifierIsDefined(Result);

            JsInstance right = Result;

            switch (expression.Type) {
                case BinaryExpressionType.And:

                    if (left.ToBoolean()) {
                        Result = right;
                    }
                    else {
                        Result = Global.BooleanClass.False;
                    }

                    break;

                case BinaryExpressionType.Or:
                    if (left.ToBoolean()) {
                        Result = left;
                    }
                    else {
                        Result = right;
                    }

                    break;

                case BinaryExpressionType.Div:
                    var rightNumber = right.ToNumber();
                    var leftNumber = left.ToNumber();

                    if (right == Global.NumberClass["NEGATIVE_INFINITY"] || right == Global.NumberClass["POSITIVE_INFINITY"]) {
                        Result = Global.NumberClass.New(0);
                    }
                    else if (rightNumber == 0) {
                        Result = leftNumber > 0 ? Global.NumberClass["POSITIVE_INFINITY"] : Global.NumberClass["NEGATIVE_INFINITY"];
                    }
                    else {
                        Result = Global.NumberClass.New(leftNumber / rightNumber);
                    }
                    break;

                case BinaryExpressionType.Equal:
                    Func<JsInstance, JsInstance, JsBoolean> equals = null;
                    equals = (JsInstance x, JsInstance y) => {
                        if (x.IsClr && y.IsClr) {
                            return Global.BooleanClass.New(x.Value.Equals(y.Value));
                        }

                        if (x.IsClr) {
                            return equals(x.ToPrimitive(Global), y);
                        }

                        if (y.IsClr) {
                            return equals(x, y.ToPrimitive(Global));
                        }

                        if (x.Class == y.Class) { // if both are Objects but then only one is Clrs
                            if (x == JsUndefined.Instance) {
                                return Global.BooleanClass.True;
                            }
                            else if (x == JsNull.Instance) {
                                return Global.BooleanClass.True;
                            }
                            else if (x.Class == JsNumber.TYPEOF) {
                                if (x.ToNumber() == double.NaN) {
                                    return Global.BooleanClass.False;
                                }
                                else if (y.ToNumber() == double.NaN) {
                                    return Global.BooleanClass.False;
                                }
                                else if (x.ToNumber() == y.ToNumber()) {
                                    return Global.BooleanClass.True;
                                }
                                else {
                                    return Global.BooleanClass.False;
                                }
                            }
                            else if (x.Class == JsString.TYPEOF) {
                                return Global.BooleanClass.New(x.ToString() == y.ToString());
                            }
                            else if (x.Class == JsBoolean.TYPEOF) {
                                return Global.BooleanClass.New(x.ToBoolean() == y.ToBoolean());
                            }
                            else if (x.Class == JsObject.TYPEOF) {
                                return Global.BooleanClass.New(x == y);
                            }
                            else {
                                return Global.BooleanClass.New(x.Value.Equals(y.Value));
                            }
                        }
                        else if (x == JsNull.Instance && y == JsUndefined.Instance) {
                            return Global.BooleanClass.True;
                        }
                        else if (x == JsUndefined.Instance && y == JsNull.Instance) {
                            return Global.BooleanClass.True;
                        }
                        else if (x.Class == JsNumber.TYPEOF && y.Class == JsString.TYPEOF) {
                            return Global.BooleanClass.New(x.ToNumber() == y.ToNumber());
                        }
                        else if (x.Class == JsString.TYPEOF && y.Class == JsNumber.TYPEOF) {
                            return Global.BooleanClass.New(x.ToNumber() == y.ToNumber());
                        }
                        else if (x.Class == JsBoolean.TYPEOF || y.Class == JsBoolean.TYPEOF) {
                            return Global.BooleanClass.New(x.ToNumber() == y.ToNumber());
                        }
                        else if (y.Class == JsObject.TYPEOF && (x.Class == JsString.TYPEOF || x.Class == JsNumber.TYPEOF)) {
                            return equals(x, y.ToPrimitive(Global));
                        }
                        else if (x.Class == JsObject.TYPEOF && (y.Class == JsString.TYPEOF || y.Class == JsNumber.TYPEOF)) {
                            return equals(x.ToPrimitive(Global), y);
                        }
                        else {
                            return Global.BooleanClass.False;
                        }
                    };

                    Result = equals(left, right);

                    break;

                case BinaryExpressionType.Greater:
                    Result = Global.BooleanClass.New(left.ToNumber() > right.ToNumber());
                    break;

                case BinaryExpressionType.GreaterOrEqual:
                    Result = Global.BooleanClass.New(left.ToNumber() >= right.ToNumber());
                    break;

                case BinaryExpressionType.Lesser:
                    Result = Global.BooleanClass.New(left.ToNumber() < right.ToNumber());
                    break;

                case BinaryExpressionType.LesserOrEqual:
                    Result = Global.BooleanClass.New(left.ToNumber() <= right.ToNumber());
                    break;

                case BinaryExpressionType.Minus:
                    Result = Global.NumberClass.New(left.ToNumber() - right.ToNumber());
                    break;

                case BinaryExpressionType.Modulo:
                    if (right == Global.NumberClass["NEGATIVE_INFINITY"] || right == Global.NumberClass["POSITIVE_INFINITY"]) {
                        Result = Global.NumberClass["POSITIVE_INFINITY"];
                    }
                    else if (right.ToNumber() == 0) {
                        Result = Global.NumberClass["NaN"];
                    }
                    else {
                        Result = Global.NumberClass.New(left.ToNumber() % right.ToNumber());
                    }
                    break;

                case BinaryExpressionType.NotEqual:

                    if (left == JsUndefined.Instance && right == JsUndefined.Instance || left == JsNull.Instance && right == JsNull.Instance) {
                        Result = Global.BooleanClass.False;
                    }
                    else {
                        if (left == JsUndefined.Instance && right != JsUndefined.Instance || left == JsNull.Instance && right != JsNull.Instance) {
                            Result = Global.BooleanClass.True;
                        }
                        else
                            if (left != JsUndefined.Instance && right == JsUndefined.Instance || left != JsNull.Instance && right == JsNull.Instance) {
                                Result = Global.BooleanClass.True;
                            }
                            else {
                                Result = Global.BooleanClass.New(!left.Value.Equals(right.Value));
                            }
                    }
                    break;

                case BinaryExpressionType.Plus:
                    if (left.Class == JsString.TYPEOF || right.Class == JsString.TYPEOF) {
                        Result = Global.StringClass.New(String.Concat(left.ToString(), right.ToString()));
                    }
                    else {
                        Result = Global.NumberClass.New(left.ToNumber() + right.ToNumber());
                    }
                    break;

                case BinaryExpressionType.Times:
                    Result = Global.NumberClass.New(left.ToNumber() * right.ToNumber());
                    break;

                case BinaryExpressionType.Pow:
                    Result = Global.NumberClass.New(Math.Pow(left.ToNumber(), right.ToNumber()));
                    break;

                case BinaryExpressionType.BitwiseAnd:
                    Result = Global.NumberClass.New(Convert.ToUInt64(left.ToNumber()) & Convert.ToUInt64(right.ToNumber()));
                    break;

                case BinaryExpressionType.BitwiseOr:
                    Result = Global.NumberClass.New(Convert.ToUInt64(left.ToNumber()) | Convert.ToUInt64(right.ToNumber()));
                    break;

                case BinaryExpressionType.BitwiseXOr:
                    Result = Global.NumberClass.New(Convert.ToUInt64(left.ToNumber()) ^ Convert.ToUInt64(right.ToNumber()));
                    break;

                case BinaryExpressionType.Same:
                    // 11.9.6 The Strict Equality Comparison Algorithm
                    if (left.Class != right.Class) {
                        Result = Global.BooleanClass.False;
                    }
                    else if (left.Class == JsUndefined.TYPEOF) {
                        Result = Global.BooleanClass.True;
                    }
                    else if (left.Class == JsNull.TYPEOF) {
                        Result = Global.BooleanClass.True;
                    }
                    else if (left.Class == JsNumber.TYPEOF) {
                        if (left == Global.NumberClass["NaN"] || right == Global.NumberClass["NaN"]) {
                            Result = Global.BooleanClass.False;
                        }
                        else if (left.ToNumber() == right.ToNumber()) {
                            Result = Global.BooleanClass.True;
                        }
                        else
                            Result = Global.BooleanClass.False;
                    }
                    else if (left.Class == JsString.TYPEOF) {
                        Result = Global.BooleanClass.New(left.ToString() == right.ToString());
                    }
                    else if (left.Class == JsBoolean.TYPEOF) {
                        Result = Global.BooleanClass.New(left.ToBoolean() == right.ToBoolean());
                    }
                    else if (left == right) {
                        Result = Global.BooleanClass.True;
                    }
                    else {
                        Result = Global.BooleanClass.False;
                    }

                    break;

                case BinaryExpressionType.NotSame:
                    new BinaryExpression(BinaryExpressionType.Same, expression.LeftExpression, expression.RightExpression).Accept(this);
                    Result = Global.BooleanClass.New(!Result.ToBoolean());
                    break;

                case BinaryExpressionType.LeftShift:
                    Result = Global.NumberClass.New(Convert.ToUInt64(left.ToNumber()) << Convert.ToUInt16(right.ToNumber()));
                    break;

                case BinaryExpressionType.RightShift:
                    Result = Global.NumberClass.New(Convert.ToUInt64(left.ToNumber()) >> Convert.ToUInt16(right.ToNumber()));
                    break;

                case BinaryExpressionType.UnsignedRightShift:
                    Result = Global.NumberClass.New(Convert.ToUInt64(left.ToNumber()) >> Convert.ToUInt16(right.ToNumber()));
                    break;

                case BinaryExpressionType.InstanceOf: {
                        var func = right as JsFunction;
                        var obj = left as JsObject;
                        if (func == null)
                            throw new JsException(Global.TypeErrorClass.New("Right argument should be a function: " + expression.RightExpression.ToString()));
                        if (obj == null)
                            throw new JsException(Global.TypeErrorClass.New("Left argument should be an object: " + expression.LeftExpression.ToString()));

                        Result = Global.BooleanClass.New(func.HasInstance(obj));
                    }
                    break;

                case BinaryExpressionType.In:
                    if (right is ILiteral) {
                        throw new JsException(Global.ErrorClass.New("Cannot apply 'in' operator to the specified member."));
                    }
                    else {
                        Result = Global.BooleanClass.New(((JsDictionaryObject)right).HasProperty(left));
                    }

                    break;

                default:
                    throw new NotSupportedException("Unkown binary operator");
            }
        }

        public void Visit(UnaryExpression expression) {
            MemberExpression member;

            switch (expression.Type) {
                case UnaryExpressionType.TypeOf:

                    expression.Expression.Accept(this);

                    if (Result == null) {
                        Result = Global.StringClass.New(JsUndefined.Instance.Class);
                    }
                    else {
                        Result = Global.StringClass.New(Result.Class.ToLower());
                    }

                    break;

                case UnaryExpressionType.Not:
                    expression.Expression.Accept(this);
                    EnsureIdentifierIsDefined(Result);
                    Result = Global.BooleanClass.New(!Result.ToBoolean());
                    break;

                case UnaryExpressionType.Negate:
                    expression.Expression.Accept(this);
                    EnsureIdentifierIsDefined(Result);
                    Result = Global.NumberClass.New(-Result.ToNumber());
                    break;

                case UnaryExpressionType.Positive:
                    expression.Expression.Accept(this);
                    EnsureIdentifierIsDefined(Result);
                    Result = Global.NumberClass.New(+Result.ToNumber());
                    break;

                case UnaryExpressionType.PostfixPlusPlus:

                    expression.Expression.Accept(this);
                    EnsureIdentifierIsDefined(Result);
                    JsInstance value = Result;

                    member = expression.Expression as MemberExpression ?? new MemberExpression(expression.Expression, null);

                    Assign(member, Global.NumberClass.New(value.ToNumber() + 1));

                    Result = value;

                    break;

                case UnaryExpressionType.PostfixMinusMinus:

                    expression.Expression.Accept(this);
                    EnsureIdentifierIsDefined(Result);
                    value = Result;

                    member = expression.Expression as MemberExpression ?? new MemberExpression(expression.Expression, null);

                    Assign(member, Global.NumberClass.New(value.ToNumber() - 1));

                    Result = value;

                    break;

                case UnaryExpressionType.PrefixPlusPlus:

                    expression.Expression.Accept(this);
                    EnsureIdentifierIsDefined(Result);
                    value = Global.NumberClass.New(Result.ToNumber() + 1);

                    member = expression.Expression as MemberExpression ?? new MemberExpression(expression.Expression, null);
                    Assign(member, value);

                    break;

                case UnaryExpressionType.PrefixMinusMinus:

                    expression.Expression.Accept(this);
                    EnsureIdentifierIsDefined(Result);
                    value = Global.NumberClass.New(Result.ToNumber() - 1);

                    member = expression.Expression as MemberExpression ?? new MemberExpression(expression.Expression, null);
                    Assign(member, value);

                    break;

                case UnaryExpressionType.Delete:

                    member = expression.Expression as MemberExpression;
                    if (member == null)
                        throw new NotImplementedException("delete");
                    member.Previous.Accept(this);
                    EnsureIdentifierIsDefined(Result);
                    value = Result;
                    string propertyName = null;
                    if (member.Member is PropertyExpression)
                        propertyName = ((PropertyExpression)member.Member).Text;
                    if (member.Member is Indexer) {
                        ((Indexer)member.Member).Index.Accept(this);
                        propertyName = Result.ToString();
                    }
                    if (string.IsNullOrEmpty(propertyName))
                        throw new JsException(Global.TypeErrorClass.New());
                    try {
                        ((JsDictionaryObject)value).Delete(propertyName);
                    }
                    catch (JintException e) {
                        throw new JsException(Global.TypeErrorClass.New());
                    }
                    Result = value;
                    break;

                case UnaryExpressionType.Void:

                    expression.Accept(this);
                    Result = JsUndefined.Instance;
                    break;

                case UnaryExpressionType.Inv:

                    expression.Expression.Accept(this);
                    EnsureIdentifierIsDefined(Result);
                    Result = Global.NumberClass.New(~Convert.ToUInt64(Result.ToNumber()));

                    break;

            }
        }

        public void Visit(ValueExpression expression) {
            switch (expression.TypeCode) {
                case TypeCode.Boolean: Result = Global.BooleanClass.New((bool)expression.Value); break;
                case TypeCode.Int32:
                case TypeCode.Single:
                case TypeCode.Double: Result = Global.NumberClass.New(Convert.ToDouble(expression.Value)); break;
                case TypeCode.String: Result = Global.StringClass.New((string)expression.Value); break;
                default: Result = expression.Value as JsInstance;
                    break;
            }
        }

        public void Visit(FunctionExpression fe) {
            Result = CreateFunction(fe);
        }

        public void Visit(Statement expression) {
            throw new NotImplementedException();
        }

        public void Visit(MemberExpression expression) {
            if (expression.Previous != null) {
                // the previous part is an property, it will set a callTarget
                expression.Previous.Accept(this);
            }

            expression.Member.Accept(this);

            // Try to evaluate a CLR type
            if (Result == JsUndefined.Instance && typeFullname.Length > 0) {
                EnsureClrAllowed();

                Type type = typeResolver.ResolveType(typeFullname.ToString());

                if (type != null) {
                    Result = Global.WrapClr(type);
                    typeFullname = new StringBuilder();
                }
            }
        }

        public void EnsureIdentifierIsDefined(object value) {
            if (value == null) {
                throw new JsException(Global.ReferenceErrorClass.New(lastIdentifier + " is not defined"));
            }
        }

        public void Visit(Indexer indexer) {
            EnsureIdentifierIsDefined(Result);

            JsDictionaryObject target = (JsDictionaryObject)Result;

            indexer.Index.Accept(this);

            if (target.IsClr) {
                EnsureClrAllowed();

                PermissionSet.PermitOnly();

                try {
                    if (target.Value.GetType().IsArray) {
                        Result = Global.ObjectClass.New(((Array)target.Value).GetValue((int)Result.ToNumber()));
                        return;
                    }
                    else {
                        var parameters = JsClr.ConvertParameters(Result);

                        PropertyInfo pi = propertyGetter.GetValue(target.Value, "Item", parameters);

                        if (pi != null) {
                            Result = Global.WrapClr(pi.GetValue(target.Value, parameters));
                            return;
                        }
                        else {
                            pi = propertyGetter.GetValue(target.Value, Result.ToString());

                            if (pi != null) {
                                Result = Global.WrapClr(pi.GetValue(target.Value, null));
                                return;
                            }

                            FieldInfo fi = fieldGetter.GetValue(target.Value, Result.ToString());

                            if (fi != null) {
                                Result = Global.WrapClr(fi.GetValue(target.Value));
                                return;
                            }
                            else {
                                throw new JintException("Index not found: " + Result.ToString());
                            }
                        }
                    }
                }
                finally {
                    CodeAccessPermission.RevertPermitOnly();
                }
            }

            if (target.Class == JsString.TYPEOF) {
                Result = Global.StringClass.New(target.ToString()[Convert.ToInt32(Result.ToNumber())].ToString());
            }
            else {
                Result = target[Result];
            }
        }

        public void Visit(MethodCall methodCall) {
            var that = CallTarget;
            var target = Result;

            if (target == JsUndefined.Instance || Result == null) {
                if (!String.IsNullOrEmpty(lastIdentifier)) {
                    throw new JsException(Global.TypeErrorClass.New("Method isn't defined: " + lastIdentifier));
                }
                else {
                    throw new JsException(Global.TypeErrorClass.New("Method isn't defined"));
                }
            }

            #region Evaluates parameters
            JsInstance[] parameters = new JsInstance[methodCall.Arguments.Count];
            Type[] types = new Type[methodCall.Arguments.Count];


            if (methodCall.Arguments.Count > 0) {

                for (int j = 0; j < methodCall.Arguments.Count; j++) {
                    methodCall.Arguments[j].Accept(this);
                    parameters[j] = Result;
                }

            }
            #endregion

            if (target.Class == JsFunction.TYPEOF) {
                JsFunction function = (JsFunction)target;

                if (DebugMode) {
                    string stack = function.Name + "(";
                    string[] paramStrings = new string[parameters.Length];

                    for (int i = 0; i < parameters.Length; i++) {
                        if (parameters[i] != null)
                            paramStrings[i] = parameters[i].ToSource();
                        else
                            paramStrings[i] = "null";
                    }

                    stack += String.Join(", ", paramStrings);
                    stack += ")";
                    CallStack.Push(stack);
                }

                returnInstance = JsUndefined.Instance;

                ExecuteFunction(function, that, parameters);

                if (DebugMode) {
                    CallStack.Pop();
                }

                Result = returnInstance;
                return;
            }

            if (target.Class == JsClrMethodInfo.TYPEOF) {
                // Fallback to CLR methods
                object result = null;

                EnsureClrAllowed();

                #region Converts parameters
                object[] clrParameters = JsClr.ConvertParameters(parameters);
                #endregion

                JsClrMethodInfo clrMethod = (JsClrMethodInfo)target;
                try {

                    List<Type> generics = new List<Type>();
                    if (methodCall.Generics.Count > 0) {
                        foreach (Expression generic in methodCall.Generics) {
                            generic.Accept(this);

                            if (!(Result.Value is Type)) {
                                PermissionSet.PermitOnly();
                                throw new JintException("Invalid type in generics specifier");
                            }

                            generics.Add((Type)Result.Value);
                        }
                    }

                    MethodInfo methodInfo = methodInvoker.Invoke(that.Value, clrMethod.Value.ToString(), clrParameters, generics.ToArray());

                    PermissionSet.PermitOnly();

                    if (methodInfo == null) {
                        throw new JintException("Method not found with specified arguments: " + clrMethod.Value.ToString());
                    }

                    try {
                        result = methodInfo.Invoke(that.Value, clrParameters);
                    }
                    catch (Exception e) {
                        if (e.InnerException is JsException) {
                            throw e.InnerException;
                        }

                        throw;
                    }
                }
                catch (TargetInvocationException e) {
                    // Extract SecurityExpression if thrown
                    throw e.InnerException;
                }
                finally {
                    CodeAccessPermission.RevertPermitOnly();
                }

                Result = Global.WrapClr(result);
            }

        }

        public void ExecuteFunction(JsFunction function, JsDictionaryObject that, JsInstance[] parameters) {
            if (function == null) {
                return;
            }

            if (recursionLevel++ > MaxRecursions) {
                throw new JsException(Global.ErrorClass.New("Too many recursions in the script."));
            }

            // ecma chapter 10.
            // TODO: move creation of the activation object to the JsFunction
            // create new argument object and instantinate arguments into it
            JsArguments args = new JsArguments(Global, function, parameters);

            // create new activation object and copy instantinated arguments to it
            // Activation should be before the function.Scope hierarchy
            JsScope functionScope = new JsScope(function.Scope ?? GlobalScope);

            for (int i = 0; i < function.Arguments.Count; i++)
                functionScope.DefineOwnProperty(
                    function.Arguments[i],
                    new LinkedDescriptor(
                        functionScope,
                        function.Arguments[i],
                        args.GetDescriptor(i.ToString())
                    )
                );


            // define arguments variable
            if (HasOption(Options.Strict))
                functionScope.DefineOwnProperty(JsScope.ARGUMENTS, args);
            else
                args.DefineOwnProperty(JsScope.ARGUMENTS, args);

            // set this variable
            if (that != null)
                functionScope.DefineOwnProperty(JsScope.THIS, that);
            else
                functionScope.DefineOwnProperty(JsScope.THIS, Global as JsObject);

            // enter activation object
            EnterScope(functionScope);

            try {
                PermissionSet.PermitOnly();

                Result = function.Execute(this, that, parameters);

                // Resets the return flag
                if (exit) {
                    exit = false;
                }
            }
            finally {
                // return to previous execution state
                ExitScope();

                CodeAccessPermission.RevertPermitOnly();
                recursionLevel--;
            }
        }

        private bool HasOption(Options options) {
            return Global.HasOption(options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="function">Function to exectue</param>
        /// <param name="that">Object to call the function on</param>
        /// <param name="parameters">Parameters of the execution</param>
        public void CallFunction(JsFunction function, JsDictionaryObject that, JsInstance[] parameters) {
            function.Statement.Accept(this);
        }

        public void Visit(PropertyExpression expression) {
            // save base of current expression
            var callTarget = Result as JsDictionaryObject;

            // this check is disabled becouse it prevents Clr names to resolve
            //if ((callTarget) == null || callTarget == JsUndefined.Instance || callTarget == JsNull.Instance)
            //{
            //    throw new JsException( Global.TypeErrorClass.New( String.Format("An object is required: {0} while resolving property {1}", lastIdentifier, expression.Text) ) );
            //}

            Result = null;

            string propertyName = lastIdentifier = expression.Text;

            JsInstance result = null;

            if (callTarget != null && callTarget.TryGetProperty(propertyName, out result)) {
                SetResult(result, callTarget);
                return;
            }

            // Search for .NET property or method
            if (callTarget != null && callTarget.IsClr && callTarget.Value != null) {
                EnsureClrAllowed();

                // enum ?
                var type = callTarget.Value as Type;
                if (type != null && type.IsEnum) {
                    SetResult(Global.WrapClr(Enum.Parse(type, propertyName)), callTarget);
                    return;
                }

                var propertyInfo = propertyGetter.GetValue(callTarget.Value, propertyName);
                if (propertyInfo != null) {
                    SetResult(Global.WrapClr(propertyInfo.GetValue(callTarget.Value, null)), callTarget);
                    return;
                }


                var fieldInfo = fieldGetter.GetValue(callTarget.Value, propertyName);
                if (fieldInfo != null) {
                    SetResult(Global.WrapClr(fieldInfo.GetValue(callTarget.Value)), callTarget);
                    return;
                }

                // Not a property, then must be a method
                SetResult(new JsClrMethodInfo(propertyName), callTarget);
                return;

                throw new JintException("Invalid property name: " + propertyName);
            }


            // Search for a static CLR call
            if (Result == null && typeFullname.Length > 0) {
                Type type = typeResolver.ResolveType(typeFullname.ToString());

                if (type != null) {
                    typeFullname = new StringBuilder();
                    EnsureClrAllowed();

                    var propertyInfo = propertyGetter.GetValue(type, propertyName);
                    if (propertyInfo != null) {
                        SetResult(Global.WrapClr(propertyInfo.GetValue(type, null)), callTarget);
                        return;
                    }

                    var fieldInfo = fieldGetter.GetValue(type, propertyName);
                    if (fieldInfo != null) {
                        SetResult(Global.WrapClr(fieldInfo.GetValue(type)), callTarget);
                        return;
                    }

                    // Not a property, then must be a method
                    SetResult(new JsClrMethodInfo(propertyName), callTarget);
                    return;

                    throw new JintException("Invalid property name: " + propertyName);
                }
            }

            if (Result == null && typeFullname.Length > 0) {
                typeFullname.Append('.').Append(propertyName);
            }

            SetResult(JsUndefined.Instance, callTarget);
        }

        public void Visit(PropertyDeclarationExpression expression) {
            // previous result was the object in which we need to define a property
            var target = Result as JsDictionaryObject;

            switch (expression.Mode) {
                case PropertyExpressionType.Data:
                    expression.Expression.Accept(this);
                    Result = new ValueDescriptor(target, expression.Name, Result);
                    break;
                case PropertyExpressionType.Get:
                case PropertyExpressionType.Set:
                    JsFunction get = null, set = null;
                    if (expression.GetExpression != null) {
                        expression.GetExpression.Accept(this);
                        get = (JsFunction)Result;
                    }
                    if (expression.SetExpression != null) {
                        expression.SetExpression.Accept(this);
                        set = (JsFunction)Result;
                    }
                    Result = new PropertyDescriptor(Global, target, expression.Name) { GetFunction = get, SetFunction = set, Enumerable = true };
                    break;
                default:
                    break;
            }
        }

        public void Visit(Identifier expression) {
            Result = null;

            string propertyName = lastIdentifier = expression.Text;


            // Search for .NET property or method
            // TODO: migrate Clr handling to JsScope or to the object
            if (CurrentScope.IsClr && CurrentScope.Value != null) {
                EnsureClrAllowed();

                var propertyInfo = propertyGetter.GetValue(CurrentScope.Value, propertyName);
                if (propertyInfo != null) {
                    Result = Global.WrapClr(propertyInfo.GetValue(CurrentScope.Value, null));
                    return;
                }

                var fieldInfo = fieldGetter.GetValue(CurrentScope.Value, propertyName);
                if (fieldInfo != null) {
                    Result = Global.WrapClr(fieldInfo.GetValue(CurrentScope.Value));
                    return;
                }

                // Not a property, then must be a method
                Result = new JsClrMethodInfo(propertyName);
                return;
            }

            JsInstance result = null;
            if (CurrentScope.TryGetProperty(propertyName, out result)) {
                Result = result;
                if (Result != null)
                    return;
            }

            if (propertyName == "null") {
                Result = JsNull.Instance;
            }

            if (propertyName == "undefined") {
                Result = JsUndefined.Instance;
            }

            // Try to record full path in case it's a type
            if (Result == null) {
                typeFullname.Append(propertyName);
            }
        }

        private void EnsureClrAllowed() {
            if (!AllowClr) {
                throw new SecurityException("Use of Clr is not allowed");
            }
        }

        public void Visit(JsonExpression json) {
            JsObject instance = Global.ObjectClass.New();

            foreach (var item in json.Values) {
                Result = instance;
                item.Value.Accept(this);
                instance.DefineOwnProperty(item.Key, Result);
            }

            Result = instance;
        }

        /// <summary>
        /// Called by a loop to stop the "continue" keyword escalation
        /// </summary>
        protected void ResetContinueIfPresent(string label) {
            if (continueStatement != null && continueStatement.Label == label) {
                continueStatement = null;
            }
        }

        protected bool StopStatementFlow() {
            return exit ||
            breakStatement != null ||
            continueStatement != null;
        }

        public void Visit(ArrayDeclaration expression) {
            var array = Global.ArrayClass.New();

            // Process parameters
            JsInstance[] parameters = new JsInstance[expression.Parameters.Count];

            for (int i = 0; i < expression.Parameters.Count; i++) {
                expression.Parameters[i].Accept(this);
                array[i.ToString()] = Result;
            }

            Result = array;
        }

        public void Visit(RegexpExpression expression) {
            Result = Global.RegExpClass.New(expression.Regexp, expression.Options.Contains("g"), expression.Options.Contains("i"), expression.Options.Contains("m"));
        }


        #region IDeserializationCallback Members

        public void OnDeserialization(object sender) {
            this.methodInvoker = new CachedMethodInvoker(this);
            this.propertyGetter = new CachedReflectionPropertyGetter(methodInvoker);
            this.constructorInvoker = new CachedConstructorInvoker(methodInvoker);
            this.typeResolver = new CachedTypeResolver();
            this.fieldGetter = new CachedReflectionFieldGetter(methodInvoker);
        }

        #endregion

        #region IJintVisitor Members

        public IPropertyGetter PropertyGetter {
            get { return propertyGetter; }
        }

        public IMethodInvoker MethodGetter {
            get { return methodInvoker; }
        }

        public IFieldGetter FieldGetter {
            get { return fieldGetter; }
        }

        #endregion
    }
}
