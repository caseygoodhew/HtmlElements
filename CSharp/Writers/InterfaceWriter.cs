using System;
using System.Collections.Generic;

using Coding;
using Coding.Builder;
using Coding.Writers;

namespace CSharp.Writers
{
    public class InterfaceWriter : Writer, INamespaceChild
    {
        internal override WriterContext DefaultWriterContext { get { return WriterContext.Declaration; } }
        
        internal PrimaryAccessModifiers PrimaryAccessModifier { get; set; }

        internal string Name { get; set; }

        internal List<IParameterTypeWriter> GenericParameters { get; set; }

        public InterfaceWriter(string name)
        {
            Name = name;
            PrimaryAccessModifier = PrimaryAccessModifiers.Public;
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            switch (context)
            {
                default:
                    throw new ArgumentOutOfRangeException("context");
            }
        }
    }
}