using System;

using Coding.Builder;

namespace Coding.Writers
{
    public class FieldWriter : VariableWriter
    {
        public FieldWriter(VariableTypeWriter variableType, string name) : base(variableType, name)
        {
        }

        protected override void WriteSecondaryAccessModifier(TokenBuilder builder, WriterContext context)
        {
            switch (SeconaryAccessModifier)
            {
                case null:
                case SecondaryAccessModifiers.Readonly:
                case SecondaryAccessModifiers.Static:
                case SecondaryAccessModifiers.StaticReadonly:
                    base.WriteSecondaryAccessModifier(builder, context);
                    break;

                case SecondaryAccessModifiers.Abstract:
                case SecondaryAccessModifiers.Virtual:
                case SecondaryAccessModifiers.Override:
                    throw new InvalidOperationException(string.Format("Fields cannot be marked as {0}.", SeconaryAccessModifier.Value));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
