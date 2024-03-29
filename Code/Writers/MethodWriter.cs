﻿using System.Collections.Generic;
using System.Linq;

using Coding.Builder;
using Coding.Tokens;
using Coding.Writers2;

namespace Coding.Writers
{
    public class MethodWriter : InvokableWriter
    {
        internal SecondaryAccessModifiers? SecondaryAccessModifier { get; set; }
        
        internal TypeWriter ReturnType { get; set; }

        internal readonly List<GenericParameterWriter> GenericParameters;

        internal ParameterWriter ExtensionParameter { get; set; }

        public MethodWriter(string name) : base(name)
        {
            GenericParameters = new List<GenericParameterWriter>();
        }

        protected override void WriteReturnType(TokenBuilder builder, WriterContext context)
        {
            if (ReturnType == null)
            {
                builder.Add(Token.Void);
            }
            else
            {
                ReturnType.Write(builder, context.Switch(WriterContextFlags.VariableType));
            }
        }

        protected override void WriteGenericParameters(TokenBuilder builder, WriterContext context)
        {
            if (GenericParameters.Any())
            {
                builder.Add(Token.OpenAngle);

                builder.Join(
                    GenericParameters,
                    x => x.Write(builder, context.Switch(WriterContextFlags.GenericParameter)),
                    Token.Comma);

                builder.Add(Token.CloseAngle);
            }
        }

        protected override void WriteAccessModifier(TokenBuilder builder, WriterContext context)
        {
            base.WriteAccessModifier(builder, context);
            builder.Add(To.Token(SecondaryAccessModifier));
        }

        protected override void WriteParameters(TokenBuilder builder, WriterContext context)
        {
            if (ExtensionParameter != null)
            {
                builder.Add(Token.This);

                ExtensionParameter.Write(builder, context.Switch(WriterContextFlags.VariableDeclaration));

                if (Parameters.Any())
                {
                    builder.Add(Token.Comma);
                }
            }

            base.WriteParameters(builder, context);
        }

        protected override void WriteGenericConstraints(TokenBuilder builder, WriterContext context)
        {
            if (GenericParameters.SelectMany(x => x.Constraints).Any())
            {
                GenericParameters.ForEach(x => x.Write(builder, context.Switch(WriterContextFlags.GenericConstraints)));
            }
        }

        internal override bool IsEquivalentTo<T>(T invokable)
        {
            var method = invokable as MethodWriter;

            return method != null
                   && base.IsEquivalentTo(method)
                   && TypesAreEquivalent(method.ReturnType, ReturnType)
                   && VariablesAreEquivalent(method.ExtensionParameter, ExtensionParameter)
                   && TypesAreEquivalent(method.GenericParameters, GenericParameters);
        }

        internal override void FillStats(InvokableStats invokableStats)
        {
            base.FillStats(invokableStats);
            invokableStats.ExtensionParameterType = ExtensionParameter == null ? null : ExtensionParameter.Type;
            invokableStats.ReturnType = ReturnType;
            invokableStats.GenericParameterTypes = GenericParameters.Cast<TypeWriter>().ToList();
        }
    }
}
