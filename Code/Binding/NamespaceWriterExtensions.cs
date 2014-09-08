using System;

using Coding.Writers;

namespace Coding.Binding
{
    public static class NamespaceWriterExtensions
    {
        public static NamespaceWriter HasEnum(this NamespaceWriter @namespace, EnumWriter @enum)
        {
            @namespace.Enums.Add(@enum);
            return @namespace;
        }

        public static NamespaceWriter HasEnum(this NamespaceWriter @namespace, string @enum, Action<EnumWriter> configAction = null)
        {
            var enumWriter = new EnumWriter(@enum);

            if (configAction != null)
            {
                configAction.Invoke(enumWriter);
            }

            return @namespace.HasEnum(enumWriter);
        }

        public static NamespaceWriter HasInterface(this NamespaceWriter @namespace, InterfaceWriter @interface)
        {
            @namespace.Interfaces.Add(@interface);
            return @namespace;
        }

        public static NamespaceWriter HasInterface(this NamespaceWriter @namespace, string @interface, Action<InterfaceWriter> configAction = null)
        {
            var interfaceWriter = new InterfaceWriter(@interface);

            if (configAction != null)
            {
                configAction.Invoke(interfaceWriter);
            }

            return @namespace.HasInterface(interfaceWriter);
        }

        public static NamespaceWriter HasStruct(this NamespaceWriter @namespace, StructWriter @struct)
        {
            @namespace.Structs.Add(@struct);
            return @namespace;
        }

        public static NamespaceWriter HasStruct(this NamespaceWriter @namespace, string @struct, Action<StructWriter> configAction = null)
        {
            var structWriter = new StructWriter(@struct);

            if (configAction != null)
            {
                configAction.Invoke(structWriter);
            }

            return @namespace.HasStruct(structWriter);
        }
        
        public static NamespaceWriter HasClass(this NamespaceWriter @namespace, string @class, Action<ClassWriter> configAction = null)
        {
            var classWriter = new ClassWriter(@class);
            
            if (configAction != null)
            {
                configAction.Invoke(classWriter);
            }

            return @namespace.HasClass(classWriter);
        }

        public static NamespaceWriter HasClass(this NamespaceWriter @namespace, ClassWriter @class)
        {
            @namespace.Classes.Add(@class);
            return @namespace;
        }

        

        
    }
}
