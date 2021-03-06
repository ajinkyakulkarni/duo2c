﻿using System;
using System.Collections.Generic;
using System.Linq;

using DUO2C.Semantics;

namespace DUO2C.Nodes.Oberon2
{
    [SubstituteToken("Factor")]
    public class NFactor : ExpressionElement
    {
        public ExpressionElement Inner
        {
            get { return (ExpressionElement) Children.First(); }
        }

        public override string String
        {
            get {
                if (Inner is NExpr) {
                    return String.Format("({0})", Inner.String);
                } else if (Inner is NString) {
                    return String.Format("\"{0}\"", Inner.String.Replace("\r", "\\r").Replace("\n", "\\n"));
                } else {
                    return Inner.String;
                }
            }
        }

        public override OberonType GetFinalType(Scope scope)
        {
            return Inner.GetFinalType(scope);
        }

        public override bool IsConstant(Scope scope)
        {
            return Inner.IsConstant(scope);
        }

        public NFactor(ParseNode original)
            : base(original, false)
        {
            if (Children.Count() == 3) {
                Children = new ParseNode[] { Children.ElementAt(1) };
            }
        }

        public void OverwriteConst(LiteralElement value)
        {
            Children = new ParseNode[] { value };
        }

        public override IEnumerable<CompilerException> FindTypeErrors(Scope scope)
        {
            bool innerFound = false;

            foreach (var e in Inner.FindTypeErrors(scope)) {
                innerFound = true;
                yield return e;
            }

            if (!innerFound && IsConstant(scope)) {
                OverwriteConst(EvaluateConst(scope));
            }
        }

        public override LiteralElement EvaluateConst(Scope scope)
        {
            return Inner.EvaluateConst(scope);
        }
    }
}
