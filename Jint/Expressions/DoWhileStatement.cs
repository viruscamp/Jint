﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Expressions {
    [Serializable]
    public class DoWhileStatement : Statement, IWalkable {
        public Expression Condition { get; set; }
        public Statement Statement { get; set; }

        public DoWhileStatement(Expression condition, Statement statement) {
            Condition = condition;
            Statement = statement;
        }

        [System.Diagnostics.DebuggerStepThrough]
        public override void Accept(IStatementVisitor visitor) {
            visitor.Visit(this);
        }


        #region IWalkable Members

        public StatementWalkerPosition GetFirstStatement() {
            var walker = new CustomWalkerPosition(new Statement[] { Statement } ) ;
            walker.OnDelete += delegate(object sender, StatementEventArgs<Statement> args) {
                if (args.position != null && args.position == Statement)
                    Statement = new EmptyStatement() {
                        Label = args.position.Label,
                        Source = args.position.Source
                    };
            };
            return walker;
        }

        #endregion
    }
}
