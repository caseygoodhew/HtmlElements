namespace Coding.Writers
{
    public class ConstructorWriter : InvokableWriter
    {
        internal readonly ClassWriter Class;
        
        public ConstructorWriter(ClassWriter @class) : base(@class.Name)
        {
            Class = @class;
        }
    }
}