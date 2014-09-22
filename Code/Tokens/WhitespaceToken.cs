namespace Coding.Tokens
{
    internal abstract class WhitespaceToken : TokenBase
    {
        protected WhitespaceToken(string value)
            : base(value)
        {
        }
    }
}