using Coding.Tokens;
using Coding.Writers;

namespace Coding.Binding
{
    public static class GenericParameterWriterExtensions
    {
        public static GenericParameterWriter WhereIsNew(this GenericParameterWriter genericParameter)
        {
            genericParameter.Constraints.Add(new GenericNewConstraintWriter());
            return genericParameter;
        }

        public static GenericParameterWriter WhereIsClass(this GenericParameterWriter genericParameter)
        {
            genericParameter.Constraints.Add(new GenericClassConstraintWriter());
            return genericParameter;
        }

        public static GenericParameterWriter WhereIsStruct(this GenericParameterWriter genericParameter)
        {
            genericParameter.Constraints.Add(new GenericStructConstraintWriter());
            return genericParameter;
        }

        public static GenericParameterWriter WhereIs(this GenericParameterWriter genericParameter, ClassWriter classWriter) 
        {
            genericParameter.Constraints.Add(new GenericClassWriterConstraintWriter(classWriter));
            return genericParameter;
        }

        public static GenericParameterWriter WhereIs(this GenericParameterWriter genericParameter, InterfaceWriter interfaceWriter)
        {
            genericParameter.Constraints.Add(new GenericInterfaceWriterConstraintWriter(interfaceWriter));
            return genericParameter;
        }
        
        public static GenericParameterWriter WhereIs<TClass>(this GenericParameterWriter genericParameter) where TClass : class
        {
            genericParameter.Constraints.Add(new GenericClassTypeConstraintWriter<TClass>());
            return genericParameter;
        }
    }
}