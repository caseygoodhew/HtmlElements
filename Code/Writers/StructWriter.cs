using System;
using System.Collections.Generic;

using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class StructWriter : ComposableWriter
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.StructDeclaration; } }
        
        public StructWriter(string name) : base(name, Token.Struct)
        {
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.NamespaceDeclaration) || context.Is(WriterContextFlags.StructDeclaration))
            {
                WriteDeclaration(builder, context.Switch(WriterContextFlags.StructDeclaration));
                return;
            }
            
            base.Write(builder, context);
        }

        protected internal override bool IsValidValue(object value, bool asParameterDefault = false)
        {
            throw new NotImplementedException();
        }

        internal override List<MethodWriter> GetMethods(MethodWriter method)
        {
            throw new NotImplementedException();
        }

        internal override List<MethodWriter> GetMethods(string name)
        {
            throw new NotImplementedException();
        }
    }
}
