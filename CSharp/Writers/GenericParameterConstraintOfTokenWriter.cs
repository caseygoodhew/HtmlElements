using Coding;

namespace CSharp.Writers
{
    public class GenericParameterConstraintOfTokenWriter : Writer, IGenericParameterConstraint
    {
        internal readonly Token Token;
        
        public GenericParameterConstraintOfTokenWriter(Token token)
        {
            Token = token;
        }

        public override void Build(TokenBuilder builder)
        {
            builder.Add(Token);
        }
    }
}