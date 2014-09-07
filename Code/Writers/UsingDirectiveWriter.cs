using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class UsingDirectiveWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.ModuleDeclaration; } }
        
        internal readonly NamespaceWriter NamespaceWriter;

        internal readonly string NamespaceString;

        public UsingDirectiveWriter(string namespaceString)
        {
            NamespaceString = namespaceString;
        }

        public UsingDirectiveWriter(NamespaceWriter namespaceWriter)
        {
            NamespaceWriter = namespaceWriter;
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.Using);

            if (NamespaceWriter == null)
            {
                builder.Add(NamespaceString);
            }
            else
            {
                NamespaceWriter.Write(builder, context.Switch(WriterContextFlags.NamespaceName));
            }

            builder.Add(Token.TerminatingSemiColon);
        }
    }
}
