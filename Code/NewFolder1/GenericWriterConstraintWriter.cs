namespace Coding.NewFolder1
{
    public abstract class GenericWriterConstraintWriter : GenericConstraintWriter
    {
        internal readonly Writer Writer;

        protected GenericWriterConstraintWriter(Writer writer)
        {
            Writer = writer;
        }

        protected override void WriteGenericConstraint(TokenBuilder builder, WriterContext context)
        {
            Writer.Write(builder, context.Switch(WriterContextFlags.VariableType));
        }
    }
}