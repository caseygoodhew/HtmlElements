using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding.NewFolder1
{
    public class ParameterWriter : VariableWriter
    {
        public ParameterWriter(VariableTypeWriter variableType, string name) : base(variableType, name)
        {
        }

        protected override void WritePrimaryAccessModifier(TokenBuilder builder, WriterContext context)
        {
            // do nothing
        }

        protected override void WriteSecondaryAccessModifier(TokenBuilder builder, WriterContext context)
        {
            // do nothing
        }

        protected override void WriteDeclarationCompletion(TokenBuilder builder, WriterContext context)
        {
            // do nothing
        }
    }
}
