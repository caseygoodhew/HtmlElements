using Coding.Builder;

namespace Coding.Writers
{
    public class ExtendsClassTypeWriter : ExtendsClassWriter
    {
        internal readonly ClassWriter ClassWriter;

        public ExtendsClassTypeWriter(ClassWriter classWriter)
        {
            ClassWriter = classWriter;
        }

        protected override void WriteClassType(TokenBuilder builder, WriterContext context)
        {
            ClassWriter.Write(builder, context.Switch(WriterContextFlags.VariableType));
        }
    }
}