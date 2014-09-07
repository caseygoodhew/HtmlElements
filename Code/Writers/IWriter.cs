using Coding.Builder;

namespace Coding.Writers
{
    public interface IWriter
    {
        void Write(TokenBuilder builder, WriterContext context);
    }
}
