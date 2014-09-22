using System;
using System.Collections.Generic;

using Coding.Tokens;

namespace Coding.Writers
{
    public class InterfaceWriter : ComposableWriter
    {
        public InterfaceWriter(string name) : base(name, Token.Interface)
        {
        }

        protected internal override bool IsValidValue(object value, bool asParameterDefault = false)
        {
            throw new NotImplementedException();
        }

        internal override List<MethodWriter> GetMethods(MethodWriter method)
        {
            throw new NotImplementedException();
        }

        internal override List<MethodWriter> GetMethods(string name)
        {
            throw new NotImplementedException();
        }
    }
}
