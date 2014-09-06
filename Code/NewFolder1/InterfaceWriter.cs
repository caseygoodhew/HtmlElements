using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding.NewFolder1
{
    public class InterfaceWriter : VariableTypeWriter
    {
        internal PrimaryAccessModifiers PrimaryAccessModifier { get; set; }

        internal readonly string Name;
        
        internal readonly List<GenericParameterWriter> GenericParameters;

        internal readonly List<ImplementsInterfaceWriter> ImplementsInterfaceWriters;

        internal readonly List<PropertyWriter> Properties;

        internal readonly List<FieldWriter> Fields;

        internal readonly List<MethodWriter> Methods;

        public InterfaceWriter(string name)
        {
            PrimaryAccessModifier = PrimaryAccessModifiers.Public;
            GenericParameters = new List<GenericParameterWriter>();
            ImplementsInterfaceWriters = new List<ImplementsInterfaceWriter>();
            Name = name;
            Properties = new List<PropertyWriter>();
            Fields = new List<FieldWriter>();
            Methods = new List<MethodWriter>();
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.NamespaceDeclaration))
            {
                WriteInterfaceDeclaration(builder, context.Switch(WriterContextFlags.InterfaceDeclaration));
                return;
            }
            
            base.Write(builder, context);
        }

        protected override void WriteTypeName(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Name);
        }

        private void WriteInterfaceDeclaration(TokenBuilder builder, WriterContext context)
        {
            WritePrimaryAccessModifier(builder, context);

            builder.Add(Token.Interface);

            builder.Add(Name);

            WriteGenericParameters(builder, context);

            WriteImplementsInterfaces(builder, context);

            WriteGenericConstraints(builder, context);

            WriteBody(builder, context);
        }

        protected virtual void WriteBody(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.OpenCurly);

            Properties.ForEach(x => x.Write(builder, context));

            Fields.ForEach(x => x.Write(builder, context));

            Methods.ForEach(x => x.Write(builder, context));

            builder.Add(Token.CloseCurly);
        }

        protected virtual void WriteGenericConstraints(TokenBuilder builder, WriterContext context)
        {
            if (GenericParameters.SelectMany(x => x.GenericConstraints).Any())
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

        protected virtual void WritePrimaryAccessModifier(TokenBuilder builder, WriterContext context)
        {
            throw new NotImplementedException("uncomment");
            //builder.Add(To.Token(PrimaryAccessModifier));
        }
    }
}
