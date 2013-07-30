﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUO2C.CodeGen.LLVM
{
    public static partial class IntermediaryCodeGenerator
    {
        public static GenerationContext Header(this GenerationContext ctx, Guid guid)
        {
            ctx.Write("; Generated {0}", DateTime.Now.ToString()).NewLine();
            ctx.Write("; GlobalUID {0}", guid.ToString()).NewLine();
            ctx.Write(";").NewLine();
            ctx.Write("; LLVM IR file for module \"{0}\"", _module.Identifier).NewLine();
            ctx.Write(";").NewLine();
            ctx.Write("; WARNING: This file is automatically").NewLine();
            ctx.Write("; generated and should not be edited").NewLine().NewLine();

            return ctx;
        }
    }
}
