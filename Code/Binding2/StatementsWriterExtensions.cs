using Coding.Writers;
using Coding.Writers2;

namespace Coding.Binding2
{
    public static class StatementsWriterExtensions
    {
        public static StatementsWriter Declare(this StatementsWriter statments, VariableWriter variable)
        {
            statments.Statements.Add(new VariableDeclarationStatementWriter(variable));
            return statments;
        }

        public static StatementsWriter Declare(this StatementsWriter statments, TypeWriter type, string name, object value)
        {
            return statments.Declare(new VariableWriter(type, name, value));
        }

        public static StatementsWriter Declare<T>(this StatementsWriter statments, string name, T value = default(T))
        {
            return statments.Declare(new VariableWriter<T>(name, value));
        }
        
        public static StatementsWriter Declare<T>(this StatementsWriter statments, string name, StatementWriter statement)
        {
            return statments.Declare(new VariableWriter<T>(name, statement));
        }
    }
}
