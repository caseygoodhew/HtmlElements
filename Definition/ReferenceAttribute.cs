using System;

namespace Definition
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal class ReferenceAttribute : Attribute
    {
        public readonly string Url;

        public ReferenceAttribute(string url)
        {
            Url = url;
        }
    }
}