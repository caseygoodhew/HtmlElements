using System.Collections.Generic;
using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public interface IConditionStatement { }

    public interface IConditionAndOr { }
    
    public class ConditionWriter : BaseConditionWriter, IConditionStatement, IConditionAndOr
    {
        internal readonly List<ConditionTreeNodeWriter> Nodes;

        public ConditionWriter()
        {
            Nodes = new List<ConditionTreeNodeWriter>();
        }

        protected override void WriteCondition(TokenBuilder builder, WriterContext context)
        {
            builder.Join(Nodes, x => x.Write(builder, context), Token.Empty);
        }
    }
}
