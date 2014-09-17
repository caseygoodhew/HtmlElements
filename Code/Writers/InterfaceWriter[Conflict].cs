using System.Collections.Generic;
using System.Linq;

using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class InterfaceWriter : VariableTypeWriter
    {
        protected readonly Token DeclaringToken;

        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.InterfaceDeclaration; } }
        
        internal PrimaryAccessModifiers PrimaryAccessModifier { get; set; }

        internal readonly string Name;
        
        internal readonly List<GenericParameterWriter> GenericParameters;

        internal readonly List<ImplementsInterfaceWriter> ImplementsInterfaceWriters;

        internal readonly List<PropertyWriter> Properties;

        internal readonly List<FieldWriter> Fields;

        internal readonly List<MethodWriter> Methods;

        public InterfaceWriter(string name) : this(name, Token.Interface)
        {
        }

        protected InterfaceWriter(string name, Token declaringToken) 
        {
            PrimaryAccessModifier = PrimaryAccessModifiers.Public;
            GenericParameters = new List<GenericParameterWriter>();
            ImplementsInterfaceWriters = new List<ImplementsInterfaceWriter>();
            Name = name;
            Properties = new List<PropertyWriter>();
            Fields = new List<FieldWriter>();
            Methods = new List<MethodWriter>();
            DeclaringToken = declaringToken;
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.NamespaceDeclaration) || context.Is(WriterContextFlags.InterfaceDeclaration))
            {
                WriteDeclaration(builder, context.Switch(WriterContextFlags.InterfaceDeclaration));
                return;
            }
            
            base.Write(builder, context);
        }

        protected override void WriteTypeName(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Name);
        }

        protected void WriteDeclaration(TokenBuilder builder, WriterContext context)
        {
            WriteAccessModifier(builder, context);

            builder.Add(DeclaringToken);

            builder.Add(Name);

            WriteGenericParameters(builder, context);

            WriteInheritance(builder, context);

            WriteGenericConstraints(builder, context);

            WriteBody(builder, context);
        }

        protected virtual void WriteInheritance(TokenBuilder builder, WriterContext context)
        {
            WriteImplementsInterfaces(builder, context);
        }

        protected virtual void WriteBody(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.OpenCurly);

            WriteProperties(builder, context);

            WriteFields(builder, context);

            WriteMethods(builder, context);

            builder.Add(Token.CloseCurly);
        }

        protected virtual void WriteMethods(TokenBuilder builder, WriterContext context)
        {
            Methods.ForEach(x => x.Write(builder, context));
        }

        protected virtual void WriteFields(TokenBuilder builder, WriterContext context)
        {
            Fields.ForEach(x => x.Write(builder, context));
        }

        protected virtual void WriteProperties(TokenBuilder builder, WriterContext context)
        {
            Properties.ForEach(x => x.Write(builder, context));
        }

        protected virtual void WriteGenericConstraints(TokenBuilder builder, WriterContext context)
        {
            if (GenericParameters.SelectMany(x => x.Constraints).Any())
            {
                GenericParameters.ForEach(x => x.Write(builder, context.Switch(WriterContextFlags.GenericConstraints)));
            }
        }

        protected virtual void WriteImplementsInterfaces(TokenBuilder builder, WriterContext context, Token beginsWithToken = Token.Colon)
        {
            if (!ImplementsInterfaceWriters.Any())
            {
                return;
            }

            builder.Add(beginsWithToken);

            builder.Join(
                ImplementsInterfaceWriters,
                x => x.Write(builder, context.Switch(WriterContextFlags.ImplementsInterface)),
                Token.Comma);
        }

        protected virtual void WriteGenericParameters(TokenBuilder builder, WriterContext context)
        {
            if (!GenericParameters.Any())
            {
                return;
            }

            builder.Add(Token.OpenAngle);

            builder.Join(
                GenericParameters,
                x => x.Write(builder, context.Switch(WriterContextFlags.GenericParameter)),
                Token.Comma);

            builder.Add(Token.CloseAngle);
        }

        protected virtual void WriteAccessModifier(TokenBuilder builder, WriterContext context)
        {
            builder.Add(To.Token(PrimaryAccessModifier));
        }
    }
}
