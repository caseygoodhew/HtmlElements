using System;
using System.Collections.Generic;
using System.Linq;
using Coding.Builder;
using Coding.Tokens;
using Coding.Writers2;

namespace Coding.Writers
{
    public abstract class InvokableWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.InvokableDeclaration; } }

        internal PrimaryAccessModifiers PrimaryAccessModifier { get; set; }

        public readonly string Name;

        internal readonly List<ParameterWriter> Parameters;

        internal ParamsParameterWriter ParamsParameter { get; set; }

        protected InvokableWriter(string name)
        {
            Name = name;
            PrimaryAccessModifier = PrimaryAccessModifiers.Public;
            Parameters = new List<ParameterWriter>();
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.ClassDeclaration) ||
                context.Is(WriterContextFlags.StructDeclaration) ||
                context.Is(WriterContextFlags.InterfaceDeclaration) ||
                context.Is(WriterContextFlags.InvokableDeclaration))
            {
                WriteInvokableDeclaration(builder, context);
                return;
            }

            base.Write(builder, context);
        }

        private void WriteInvokableDeclaration(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.ClassDeclaration) || 
                context.Is(WriterContextFlags.StructDeclaration) ||
                context.Is(WriterContextFlags.InvokableDeclaration))
            {
                WriteAccessModifier(builder, context);
            }

            WriteReturnType(builder, context);

            WriteName(builder, context);

            WriteGenericParameters(builder, context);

            builder.Add(Token.OpenBracket);

            WriteParameters(builder, context);

            builder.Add(Token.CloseBracket);

            WriteGenericConstraints(builder, context);

            if (context.Is(WriterContextFlags.InterfaceDeclaration))
            {
                builder.Add(Token.TerminatingSemiColon);
            }
            else
            {
                builder.Add(Token.OpenCurly);
                
                WriteBody(builder, context);

                builder.Add(Token.CloseCurly);
            }
        }

        protected virtual void WriteBody(TokenBuilder builder, WriterContext context)
        {
            // do nothing ... for now
        }

        protected virtual void WriteGenericConstraints(TokenBuilder builder, WriterContext context)
        {
            // do nothing
        }

        protected virtual void WriteParameters(TokenBuilder builder, WriterContext context)
        {
            builder.Join(
                Parameters,
                x => x.Write(builder, context.Switch(WriterContextFlags.VariableDeclaration)),
                Token.Comma);

            if (ParamsParameter == null)
            {
                return;
            }
            
            if (Parameters.Any())
            {
                builder.Add(Token.Comma);
            }

            ParamsParameter.Write(builder, context.Switch(WriterContextFlags.VariableDeclaration));
        }

        protected virtual void WriteGenericParameters(TokenBuilder builder, WriterContext context)
        {
            // do nothing
        }

        protected virtual void WriteName(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Name);
        }

        protected virtual void WriteReturnType(TokenBuilder builder, WriterContext context)
        {
            // do nothing
        }

        protected virtual void WriteAccessModifier(TokenBuilder builder, WriterContext context)
        {
            builder.Add(To.Token(PrimaryAccessModifier));
        }

        internal virtual bool IsEquivalentTo<T>(T invokable) where T : InvokableWriter
        {
            return invokable != null
                   && invokable.Name == Name
                   && VariablesAreEquivalent(invokable.ParamsParameter, ParamsParameter)
                   && VariablesAreEquivalent(invokable.Parameters, Parameters);
        }

        protected static bool VariablesAreEquivalent<T>(T paramOne, T paramTwo) where T : VariableWriter
        {
            if (paramOne == null && paramTwo == null)
            {
                return true;
            }

            if (paramOne == null || paramTwo == null)
            {
                return false;
            }

            return paramOne.IsEquivalentTo(paramTwo);
        }

        protected static bool VariablesAreEquivalent<T>(List<T> listOne, List<T> listTwo) where T : VariableWriter
        {
            if (listOne == null && listTwo == null)
            {
                return true;
            }

            if (listOne == null || listTwo == null)
            {
                return false;
            }

            if (listOne.Count != listTwo.Count)
            {
                return false;
            }

            return !listOne.Where((t, i) => !t.IsEquivalentTo(listTwo[i])).Any();
        }

        protected static bool TypesAreEquivalent<T>(T typeOne, T typeTwo) where T : TypeWriter
        {
            if (typeOne == null && typeTwo == null)
            {
                return true;
            }

            if (typeOne == null || typeTwo == null)
            {
                return false;
            }

            return typeOne.IsEquivalentTo(typeTwo);
        }

        protected static bool TypesAreEquivalent<T>(List<T> listOne, List<T> listTwo) where T : TypeWriter
        {
            if (listOne == null && listTwo == null)
            {
                return true;
            }

            if (listOne == null || listTwo == null)
            {
                return false;
            }

            if (listOne.Count != listTwo.Count)
            {
                return false;
            }

            return !listOne.Where((t, i) => !t.IsEquivalentTo(listTwo[i])).Any();
        }

        internal virtual void FillStats(InvokableStats invokableStats)
        {
            invokableStats.Name = Name;
            invokableStats.RequiredParameterTypes = Parameters.Where(x => x.Value == null).Select(x => x.Type).ToList();
            invokableStats.OptionalParameterTypes = Parameters.Where(x => x.Value != null).Select(x => x.Type).ToList();
            invokableStats.ParamsType = ParamsParameter == null ? null : ParamsParameter.Type;
        }
    }
}
