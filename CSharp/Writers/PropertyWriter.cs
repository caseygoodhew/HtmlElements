using System;

using Coding;
using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace CSharp.Writers
{
    public class PropertyWriter : Writer, IClassChild, IInterfaceChild, IParameterTypeWriter
    {
        internal override WriterContext DefaultWriterContext { get { return WriterContext.Declaration; } }
        
        public string Name { get; internal set; }

        internal IParameterTypeWriter PropertyType { get; set; }

        internal PrimaryAccessModifiers AccessModifier { get; set; }

        internal PrimaryAccessModifiers GetterAccessModifier { get; set; }

        internal PrimaryAccessModifiers SetterAccessModifier { get; set; }

        internal SecondaryAccessModifiers? SecondaryAccessModifier { get; set; }

        internal bool HasGetter { get; set; }

        internal bool HasSetter { get; set; }

        public PropertyWriter(IParameterTypeWriter propertyType, string name)
        {
            PropertyType = propertyType;
            Name = name;
            AccessModifier = PrimaryAccessModifiers.Public;
            GetterAccessModifier = PrimaryAccessModifiers.Public;
            SetterAccessModifier = PrimaryAccessModifiers.Public;
            HasGetter = true;
            HasSetter = true;
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            switch (context)
            {
                case WriterContext.Declaration:
                    WriteDeclaration(builder);
                    break;
                case WriterContext.ParameterDeclaration:
                    builder.Add(Name);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("context");
            }
        }

        private void WriteDeclaration(TokenBuilder builder)
        {
            builder.Add(To.Token(AccessModifier))
               .Add(To.Token(SecondaryAccessModifier));

            PropertyType.Write(builder, WriterContext.ParameterDeclaration);

            builder.Add(Name)
                .Add(Token.OpenCurly);

            if (HasGetter)
            {
                builder.Add(To.TokenConditional(AccessModifier > GetterAccessModifier, GetterAccessModifier))
                    .Add(Token.Get)
                    .Add(Token.SemiColon);
            }

            if (HasSetter)
            {
                builder.Add(To.TokenConditional(AccessModifier > SetterAccessModifier, SetterAccessModifier))
                    .Add(Token.Set)
                    .Add(Token.TerminatingSemiColon);
            }

            builder.Add(Token.CloseCurly);
        }
    }
}
