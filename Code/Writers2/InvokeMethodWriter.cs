using System;
using System.Collections.Generic;
using System.Linq;

using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public class InvokeMethodWriter : InvokeStatementWriter<MethodWriter>
    {
        protected readonly VariableWriter Variable;

        public InvokeMethodWriter(VariableWriter variable, MethodWriter method, params object[] parameters)
            : base(new List<MethodWriter> { ValidateMethod(variable.Type, method) }, parameters.ToList())
        {
            Variable = variable;
        }
        
        public InvokeMethodWriter(VariableWriter variable, string methodName, params object[] parameters)
            : base(GetMethods(variable.Type, methodName), parameters.ToList())
        {
            Variable = variable;
        }

        private static MethodWriter ValidateMethod(TypeWriter type, MethodWriter method)
        {
            var result = AsInvokableContainer(type).GetMethods(method);

            if (result == null || !result.Any())
            {
                throw new InvokableNotFoundException("Type does not have method.");
            }
            
            if (result.Count > 1)
            {
                throw new InvokableNotUniqueException(string.Format("{0} matching methods found.", result.Count));
            }
                
            return result.First();
        }

        private static List<MethodWriter> GetMethods(TypeWriter type, string method)
        {
            return AsInvokableContainer(type).GetMethods(method);
        }

        private static InvokableContainerWriter AsInvokableContainer(TypeWriter type)
        {
            var result = type as InvokableContainerWriter;

            if (result == null)
            {
                throw new InvalidOperationException("Variable type is not an interface, class or struct.");
            }

            return result;
        }
        
        protected override void WriteInvocation(TokenBuilder builder, WriterContext context)
        {
            Variable.Write(builder, context.Switch(WriterContextFlags.VariableName));
            builder.Add(Token.Dot);
            // TODO: Write generic parameters
            base.WriteInvocation(builder, context);
        }
    }
}