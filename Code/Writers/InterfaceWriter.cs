using System;
using Coding.Tokens;

namespace Coding.Writers
{
    public class InterfaceWriter : ComposableWriter
    {
        public InterfaceWriter(string name) : base(name, Token.Interface)
        {
        }

        protected internal override bool IsValidType(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
