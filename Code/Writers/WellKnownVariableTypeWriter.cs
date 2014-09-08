﻿using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public abstract class WellKnownVariableTypeWriter : VariableTypeWriter
    {
        public abstract Token TypeToken { get; }

        protected override void WriteTypeName(TokenBuilder builder, WriterContext context)
        {
            builder.Add(TypeToken);
        }
    }
}