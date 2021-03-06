﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DUO2C.Nodes;
using DUO2C.Nodes.Oberon2;

namespace DUO2C.Semantics
{
    public class UndeclaredIdentifierException : CompilerException
    {
        public UndeclaredIdentifierException(ParseNode node)
            : base(ParserError.Semantics, "Undeclared identifier", node.StartIndex, node.Length) { }
    }
}
