using Coding;
using Coding.Builder;

using CSharp.Writers;

namespace CSharp
{
    public interface IWriter
    {
        void Write(TokenBuilder builder, WriterContext newContext);
    }
}