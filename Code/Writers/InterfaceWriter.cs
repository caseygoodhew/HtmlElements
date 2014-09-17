using Coding.Tokens;

namespace Coding.Writers
{
    public class InterfaceWriter : ComposableWriter
    {
        public InterfaceWriter(string name) : base(name, Token.Interface)
        {
        }
    }
}
