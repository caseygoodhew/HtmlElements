using System;
using System.Collections.Generic;

using Coding;

namespace CSharp.Writers
{
    public class GenericParameterWriter : Writer, IGenericDeclarationChild
    {
        internal override WriterContext DefaultWriterContext { get { return WriterContext.GenericParameter; } }
        
        internal string Name { get; set; }

        internal List<IGenericParameterConstraint> Constraints { get; set; }

        public GenericParameterWriter(string name)
        {
            Name = name;
            Constraints = new List<IGenericParameterConstraint>();
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            switch (context)
            {
                case WriterContext.GenericParameter:
                    builder.Add(Name);
                    break;
                case WriterContext.GenericConstraint:
                    builder.Join(Constraints, x => x.Write(builder, context), Token.Comma);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("context");
            }
        }
    }
}