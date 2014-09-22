using System.Collections.Generic;
using System.Linq;

using Coding.Writers;

namespace Coding.Writers2
{
    public class InvokableStats
    {
        public readonly InvokableWriter Invokable;
        
        public string Name;

        public List<TypeWriter> GenericParameterTypes = new List<TypeWriter>();

        public List<TypeWriter> RequiredParameterTypes = new List<TypeWriter>();

        public List<TypeWriter> OptionalParameterTypes = new List<TypeWriter>();

        public TypeWriter ReturnType;

        public TypeWriter ParamsType;

        public TypeWriter ExtensionParameterType;

        public InvokableStats(InvokableWriter invokable)
        {
            Invokable = invokable;
            Invokable.FillStats(this);
        }

        public bool Matches(List<object> parameterValues)
        {
            if (parameterValues.Count < RequiredParameterTypes.Count)
            {
                return false;
            }

            if (RequiredParameterTypes.Where((t, i) => !t.IsValidValue(parameterValues[i])).Any())
            {
                return false;
            }

            if (parameterValues.Count == RequiredParameterTypes.Count)
            {
                return true;
            }

            var remainingValues = parameterValues.GetRange(RequiredParameterTypes.Count, parameterValues.Count - RequiredParameterTypes.Count);

            if (remainingValues.Count <= OptionalParameterTypes.Count)
            {
                if (remainingValues.Where((t, i) => !OptionalParameterTypes[i].IsValidValue(t)).Any())
                {
                    return false;
                }

                return true;
            }

            if (OptionalParameterTypes.Where((t, i) => !t.IsValidValue(remainingValues[i])).Any())
            {
                return false;
            }
            
            if (remainingValues.Count == OptionalParameterTypes.Count)
            {
                return true;
            }

            remainingValues = remainingValues.GetRange(OptionalParameterTypes.Count, remainingValues.Count - OptionalParameterTypes.Count);

            if (ParamsType == null)
            {
                return false;
            }

            return remainingValues.All(x => ParamsType.IsValidValue(x));
        }
    }
}