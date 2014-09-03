using Coding;

using CSharp.Writers;

namespace CSharp
{
    public interface IParameterTypeWriter
    {
        string Name { get; }

        void BuildParameterTypeName(TokenBuilder builder);
    }
}