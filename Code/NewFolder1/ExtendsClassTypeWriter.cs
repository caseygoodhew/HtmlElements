namespace Coding.NewFolder1
{
    public class ExtendsClassTypeWriter : ExtendsClassWriter
    {
        internal readonly ClassWriter ClassWriter;

        protected ExtendsClassTypeWriter(ClassWriter classWriter)
        {
            ClassWriter = classWriter;
        }

        protected override void WriteClassType(TokenBuilder builder, WriterContext context)
        {
            ClassWriter.Write(builder, context.Switch(WriterContextFlags.VariableType));
        }
    }
}