using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class PropertyWriter : VariableWriter
    {
        internal PrimaryAccessModifiers GetterAccessModifier { get; set; }

        internal PrimaryAccessModifiers SetterAccessModifier { get; set; }

        internal bool HasGetter { get; set; }

        internal bool HasSetter { get; set; }
        
        public PropertyWriter(VariableTypeWriter variableType, string name) : base(variableType, name)
        {
            GetterAccessModifier = PrimaryAccessModifiers.Public;
            SetterAccessModifier = PrimaryAccessModifiers.Public;
            HasGetter = true;
            HasSetter = true;
        }

        protected override void WriteDeclarationCompletion(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.OpenCurly);

            if (HasGetter)
            {
                builder.Add(To.TokenConditional(PrimaryAccessModifier > GetterAccessModifier, GetterAccessModifier))
                    .Add(Token.Get)
                    .Add(Token.SemiColon);
            }

            if (HasSetter)
            {
                builder.Add(To.TokenConditional(PrimaryAccessModifier > SetterAccessModifier, SetterAccessModifier))
                    .Add(Token.Set)
                    .Add(Token.TerminatingSemiColon);
            }

            builder.Add(Token.CloseCurly);
        }
    }
}
