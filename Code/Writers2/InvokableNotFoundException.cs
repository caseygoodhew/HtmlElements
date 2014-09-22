using System;

namespace Coding.Writers2
{
    internal class InvokableNotFoundException : Exception
    {
        public InvokableNotFoundException(string message) : base(message)
        {
        }
    }
}