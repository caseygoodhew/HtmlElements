using System.Collections.Generic;

namespace Coding.Writers
{
    public abstract class InvokableContainerWriter : TypeWriter
    {
        internal abstract List<MethodWriter> GetMethods(MethodWriter method);

        internal abstract List<MethodWriter> GetMethods(string name);
    }
}