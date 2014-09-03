using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Coding;

namespace CSharp.Writers
{
    public class PropertyWriter : Writer, IClassChild, IInterfaceChild, IParameterTypeWriter
    {
        public string Name { get; internal set; }

        internal IParameterTypeWriter PropertyType { get; set; }

        internal PrimaryAccessModifiers AccessModifier { get; set; }

        internal PrimaryAccessModifiers GetterAccessModifier { get; set; }

        internal PrimaryAccessModifiers SetterAccessModifier { get; set; }

        internal SecondaryAccessModifiers? SecondaryAccessModifier { get; set; }

        public PropertyWriter(IParameterTypeWriter propertyType, string name)
        {
            PropertyType = propertyType;
            Name = name;
            AccessModifier = PrimaryAccessModifiers.Public;
            GetterAccessModifier = PrimaryAccessModifiers.Public;
            SetterAccessModifier = PrimaryAccessModifiers.Public;
        }

        public override void Build(TokenBuilder builder)
        {
            builder.Add(To.Token(AccessModifier))
                .Add(To.Token(SecondaryAccessModifier))
                .Add(PropertyType.BuildParameterTypeName)
                .Add(Name)
                .Add(Token.OpenCurly)
                .Add(To.TokenConditional(AccessModifier != GetterAccessModifier, GetterAccessModifier))
                .Add(Token.Get)
                .Add(Token.SemiColon)
                .Add(To.TokenConditional(AccessModifier != SetterAccessModifier, SetterAccessModifier))
                .Add(Token.SemiColon)
                .Add(Token.CloseCurly);
        }

        public void BuildParameterTypeName(TokenBuilder builder)
        {
            builder.Add(Name);
        }
    }
}
