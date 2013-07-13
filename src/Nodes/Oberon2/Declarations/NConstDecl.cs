﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUO2C.Nodes.Oberon2
{
    [SubstituteToken("ConstDecl")]
    public class NConstDecl : Declaration
    {
        public NConstExpr ConstExpr
        {
            get { return (NConstExpr) Children.Last(); }
        }

        public NConstDecl(ParseNode original)
            : base(original)
        {
            Children = Children.Where(x => x is NIdentDef || x is NConstExpr);
        }
    }
}
