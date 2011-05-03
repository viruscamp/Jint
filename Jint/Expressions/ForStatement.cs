﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Expressions {
    [Serializable]
    public class ForStatement : Statement, IForStatement, IWalkable {
        public Statement InitialisationStatement { get; set; }
        public Statement ConditionExpression { get; set; }
        public Statement IncrementExpression { get; set; }
        public Statement Statement { get; set; }

        public ForStatement() {
        }

        [System.Diagnostics.DebuggerStepThrough]
        public override void Accept(IStatementVisitor visitor) {
            visitor.Visit(this);
        }


        #region IWalkable Members

        public StatementWalkerPosition GetFirstStatement() {
            var walker = new CustomWalkerPosition(new Statement[]{InitialisationStatement, Statement});
            walker.OnDelete += delegate(object sender, StatementEventArgs<Statement> args) {
                if (args.position == null)
                    return;
                var empty = new EmptyStatement() {
                    Label = args.position.Label,
                    Source = args.position.Source
                };
                if (args.position == InitialisationStatement)
                    InitialisationStatement = empty;
                if (args.position == Statement)
                    Statement = empty;
            };
            return walker;
        }

        #endregion
    }
}
