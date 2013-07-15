﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUO2C.Nodes.Oberon2
{
    [SubstituteToken("StatementSeq")]
    public class NStatementSeq : SubstituteNode
    {
        public NStatementSeq(ParseNode original)
            : base(original, false)
        {

        }
    }
}
