using System.Collections.Generic;
using System.Linq;

using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class ModuleWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.ModuleDeclaration; } }
        
        internal readonly List<UsingDirectiveWriter> UsingDirectives;

        internal readonly List<NamespaceWriter> NamespaceWriters;

        public ModuleWriter()
        {
            UsingDirectives = new List<UsingDirectiveWriter>();
            NamespaceWriters = new List<NamespaceWriter>();
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (UsingDirectives.Any())
            {
                builder.Join(
                    UsingDirectives,
                    x => x.Write(builder, context.Switch(WriterContextFlags.ModuleDeclaration)),
                    Token.Empty);

                builder.Add(Token.NewLine);
            }

            builder.Join(
                    NamespaceWriters,
                    x => x.Write(builder, context.Switch(WriterContextFlags.ModuleDeclaration)),
                    Token.NewLine);
        }
    }
}
