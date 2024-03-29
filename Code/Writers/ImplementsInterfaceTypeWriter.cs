using Coding.Builder;

namespace Coding.Writers
{
    public class ImplementsInterfaceTypeWriter : ImplementsInterfaceWriter
    {
        internal readonly InterfaceWriter InterfaceWriter;

        public ImplementsInterfaceTypeWriter(InterfaceWriter interfaceWriter)
        {
            InterfaceWriter = interfaceWriter;
        }

        protected override void WriteInterfaceType(TokenBuilder builder, WriterContext context)
        {
            InterfaceWriter.Write(builder, context.Switch(WriterContextFlags.VariableType));
        }
    }
}