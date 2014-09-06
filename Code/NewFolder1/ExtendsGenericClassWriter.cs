using System;

namespace Coding.NewFolder1
{
    public class ExtendsGenericClassWriter<TClass> : ExtendsClassWriter where TClass : class
    {
        internal readonly Type ClassType;
        
        public ExtendsGenericClassWriter()
        {
            ClassType = typeof(TClass);

            if (!ClassType.IsClass)
            {
                throw new InvalidOperationException(string.Format("{0} is not a class.", ClassType.Name));
            }
        }
        
        protected override void WriteClassType(TokenBuilder builder, WriterContext context)
        {
            builder.Add(ClassType.Name);
        }
    }
}