namespace Coding.NewFolder1
{
    public class GenericClassTypeConstraintWriter<T> : GenericConstraintWriter where T : class
    {
        protected override void WriteGenericConstraint(TokenBuilder builder, WriterContext context)
        {
            builder.Add(typeof(T).Name);
        }
    }
}