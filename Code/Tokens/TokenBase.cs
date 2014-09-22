namespace Coding.Tokens
{
    internal abstract class TokenBase
    {
        private readonly string value;

        protected TokenBase(string value)
        {
            this.value = value;
        }

        internal string GetValue()
        {
            return value;
        }

        internal bool Is<T>() where T : TokenBase
        {
            return this is T;
        }
    }
}