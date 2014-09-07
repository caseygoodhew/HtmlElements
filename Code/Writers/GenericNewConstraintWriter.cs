using Coding.Tokens;

namespace Coding.Writers
{
    public class GenericNewConstraintWriter : GenericTokenConstraintWriter
    {
        public GenericNewConstraintWriter()
            : base(Token.GenericNew)
        {
        }
    }
}