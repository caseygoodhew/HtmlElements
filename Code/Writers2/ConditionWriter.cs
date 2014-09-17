using System.Collections.Generic;
using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public class ConditionWriter : BaseConditionWriter
    {
        internal readonly ConditionGroupWriter ConditionGroup;

        public ConditionWriter()
        {
            ConditionGroup = new ConditionGroupWriter();
        }

        internal override void WriteCondition(TokenBuilder builder, WriterContext context)
        {
            ConditionGroup.Write(builder, context);
        }
    }

    public abstract class ConditionTreeNodeWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.Condition; } }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.Condition))
            {
                WriteCondition(builder, context);
                return;
            }

            base.Write(builder, context);
        }

        protected abstract void WriteCondition(TokenBuilder builder, WriterContext context);
    }

    public class ConditionGroupWriter : ConditionTreeNodeWriter
    {
        internal readonly List<ConditionTreeNodeWriter> Nodes;

        public ConditionGroupWriter()
        {
            Nodes = new List<ConditionTreeNodeWriter>();
        }

        protected override void WriteCondition(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.OpenBracket);

            builder.Join(Nodes, x => x.Write(builder, context), Token.Empty);

            builder.Add(Token.CloseBracket);
        }
    }

    public class ConditionTreeLeafWriter : ConditionTreeNodeWriter
    {
        internal readonly BaseConditionWriter Condition;
        
        public ConditionTreeLeafWriter(BaseConditionWriter condition)
        {
            Condition = condition;
        }

        protected override void WriteCondition(TokenBuilder builder, WriterContext context)
        {
            Condition.Write(builder, context);
        }
    }

    public class ConditionTreeAndWriter : ConditionTreeNodeWriter
    {
        protected override void WriteCondition(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.ConditionalAnd);
        }
    }

    public class ConditionTreeOrWriter : ConditionTreeNodeWriter
    {
        protected override void WriteCondition(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.ConditionalOr);
        }
    }



    
    public class XConditionTreeWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.Condition; } }

        internal XConditionTreeNodeWriter Node { get; set; }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.Condition))
            {
                if (Node != null)
                {
                    Node.Write(builder, context);
                }
                return;
            }

            base.Write(builder, context);
        }
    }

    public abstract class XConditionTreeNodeWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.Condition; } }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.Condition))
            {
                WriteCondition(builder, context);
                return;
            }

            base.Write(builder, context);
        }

        protected abstract void WriteCondition(TokenBuilder builder, WriterContext context);
    }

    public class XConditionTreeLeafWriter : XConditionTreeNodeWriter
    {
        internal readonly BaseConditionWriter Condition;
        
        public XConditionTreeLeafWriter(BaseConditionWriter condition)
        {
            Condition = condition;
        }

        protected override void WriteCondition(TokenBuilder builder, WriterContext context)
        {
            Condition.Write(builder, context);
        }
    }

    public abstract class XConditionTreeJoinWriter : XConditionTreeNodeWriter
    {
        internal XConditionTreeNodeWriter FirstNode { get; set; }

        internal XConditionTreeNodeWriter SecondNode { get; set; }

        protected XConditionTreeJoinWriter(XConditionTreeNodeWriter node)
        {
            FirstNode = node;
        }

        protected override void WriteCondition(TokenBuilder builder, WriterContext context)
        {
            WriteFirstNode(builder, context);
            WriteJoin(builder, context);
            WriteSecondNode(builder, context);
        }
        
        protected virtual void WriteFirstNode(TokenBuilder builder, WriterContext context)
        {
            FirstNode.Write(builder, context);
        }

        protected abstract void WriteJoin(TokenBuilder builder, WriterContext context);

        protected virtual void WriteSecondNode(TokenBuilder builder, WriterContext context)
        {
            SecondNode.Write(builder, context);
        }
    }

    public class XConditionTreeBranchWriter : XConditionTreeJoinWriter
    {
        public XConditionTreeBranchWriter(XConditionTreeNodeWriter node)
            : base(node)
        {
        }

        protected override void WriteJoin(TokenBuilder builder, WriterContext context)
        {
            // nothing
        }

        protected override void WriteSecondNode(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.OpenBracket);
            base.WriteSecondNode(builder, context);
            builder.Add(Token.CloseBracket);
        }
    }

    public class XConditionTreeAndWriter : XConditionTreeJoinWriter
    {
        public XConditionTreeAndWriter(XConditionTreeNodeWriter node)
            : base(node)
        {
        }

        protected override void WriteJoin(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.ConditionalAnd);
        }
    }

    public class XConditionTreeOrWriter : XConditionTreeJoinWriter
    {
        public XConditionTreeOrWriter(XConditionTreeNodeWriter node) 
            : base(node)
        {
        }

        protected override void WriteJoin(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.ConditionalOr);
        }
    }
}
