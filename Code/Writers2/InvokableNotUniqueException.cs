using System;

namespace Coding.Writers2
{
    internal class InvokableNotUniqueException : Exception
    {
        public InvokableNotUniqueException(string message) : base(message)
        {
        }
    }
}