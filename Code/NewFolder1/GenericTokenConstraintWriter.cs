namespace Coding.NewFolder1
{
    public abstract class GenericTokenConstraintWriter : GenericConstraintWriter
    {
        internal readonly Token Token;

        protected GenericTokenConstraintWriter(Token token)
        {
            Token = token;
        }

        protected override void WriteGenericConstraint(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token);
        }
    }
}