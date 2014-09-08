using Coding.Builder;

namespace Coding.Writers
{
    public class EnumValueWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.EnumDeclaration; } }

        internal readonly EnumWriter ParentEnum;
        
        internal readonly string Name;

        public EnumValueWriter(EnumWriter parentEnum, string name)
        {
            ParentEnum = parentEnum;
            Name = name;
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Name);
        }
    }
}