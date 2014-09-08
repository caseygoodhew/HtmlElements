using System.Collections.Generic;
using System.Linq;

using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class MethodWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.ModuleDeclaration; } }
        
        internal PrimaryAccessModifiers PrimaryAccessModifier { get; set; }

        internal SecondaryAccessModifiers? SecondaryAccessModifier { get; set; }

        internal VariableTypeWriter ReturnType { get; set; }

        internal readonly string Name;
        
        internal readonly List<GenericParameterWriter> GenericParameters;

        internal ParameterWriter ExtensionParameter { get; set; }

        internal readonly List<ParameterWriter> Parameters;

        public MethodWriter(string name)
        {
            PrimaryAccessModifier = PrimaryAccessModifiers.Public;
            GenericParameters = new List<GenericParameterWriter>();
            Parameters = new List<ParameterWriter>();
            Name = name;
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.ClassDeclaration) || context.Is(WriterContextFlags.InterfaceDeclaration) || context.Is(WriterContextFlags.ModuleDeclaration))
            {
                WriteMethodDeclaration(builder, context);
                return;
            }
            
            base.Write(builder, context);
        }

        private void WriteMethodDeclaration(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.ClassDeclaration))
            {
                WritePrimaryAccessModifier(builder, context);
                WriteSecondaryAccessModifier(builder, context);
            }

            if (ReturnType == null)
            {
                builder.Add(Token.Void);
            }
            else
            {
                ReturnType.Write(builder, context.Switch(WriterContextFlags.VariableType));
            }

            builder.Add(Name);

            if (GenericParameters.Any())
            {
                builder.Add(Token.OpenAngle);

                builder.Join(
                    GenericParameters,
                    x => x.Write(builder, context.Switch(WriterContextFlags.GenericParameter)),
                    Token.Comma);

                builder.Add(Token.CloseAngle);
            }

            builder.Add(Token.OpenBracket);

            if (ExtensionParameter != null)
            {
                builder.Add(Token.This);

                ExtensionParameter.Write(builder, context.Switch(WriterContextFlags.VariableDeclaration));

                if (Parameters.Any())
                {
                    builder.Add(Token.Comma);
                }
            }
            
            builder.Join(
                Parameters, 
                x => x.Write(builder, context.Switch(WriterContextFlags.VariableDeclaration)),
                Token.Comma);

            builder.Add(Token.CloseBracket);

            if (GenericParameters.SelectMany(x => x.Constraints).Any())
            {
                GenericParameters.ForEach(x => x.Write(builder, context.Switch(WriterContextFlags.GenericConstraints)));
            }

            if (context.Is(WriterContextFlags.InterfaceDeclaration))
            {
                builder.Add(Token.TerminatingSemiColon);
            }
            else
            {
                builder.Add(Token.OpenCurly);

                builder.Add(Token.CloseCurly);
            }
        }

        private void WritePrimaryAccessModifier(TokenBuilder builder, WriterContext context)
        {
            builder.Add(To.Token(PrimaryAccessModifier));
        }

        private void WriteSecondaryAccessModifier(TokenBuilder builder, WriterContext context)
        {
            builder.Add(To.Token(SecondaryAccessModifier));
        }
    }
}
