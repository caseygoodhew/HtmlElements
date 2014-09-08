using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Coding.Binding;
using Coding.Writers;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var module =
                new ModuleWriter()
                    .HasUsing("System.Web")
                    .HasUsing("System.Casey")
                    .HasNamespace(
                        new NamespaceWriter("Casey.Goodhew")
                            .HasEnum(
                                new EnumWriter("Anything")
                                    .HasItem("Something")
                                    .HasItem("Cool")
                                    .HasItem("Happens"))
                            .HasEnum(
                                new EnumWriter("Anything")
                                    .HasItem("Something")
                                    .HasItem("Cool")
                                    .HasItem("Happens")));

            var newClass = new ClassWriter("NewClass");
            
            var module2 = new ModuleWriter().HasNamespace(
                "Maria.Sanchez",
                n =>
                n.HasEnum("Testing", e => e.HasItem("ItemOne").HasItem("ItemTwo"))
                    .HasClass(
                        "MyFristClass",
                        x =>
                        x.HasGenericParameter("TSomething", p => p.WhereIsStruct())
                         .HasGenericParameter("TElse", p => p.WhereIsNew().WhereIs<IntWriter>()))
                    .HasClass("AnyClass", 
                        x => x.Has(new FieldWriter(newClass, "NewClass").IsPrivate().IsStaticReadonly())
                              .Has(new PropertyWriter(new StringWriter(), "Awesome").IsPrivate(Property.Setter))
                              .HasField<object>("Object", f => f.IsStatic())
                              .HasProperty<bool>("Inline", p => p.IsInternal())
                              .Has(new PropertyWriter(new StringWriter(), "Awesome2").IsAbstract(Property.Setter))
                              .Has(new FieldWriter(new RealVariableTypeWriter<DateTime>(), "SomeField").IsProtected())
                              .Has(new MethodWriter("MyMethod")
                                            .IsPrivate()
                                            .HasGenericParameter("TDani")
                                            .HasGenericParameter("TOlivia", p => p.WhereIsNew())
                                            .HasParameter<Type>("type")
                                            .HasParameter<string>("name"))
                              .HasMethod("MyMethod", m => m.IsExtensionMethod<MethodWriter>("Testing"))
                              .HasMethod<string>("MyMethod", m => m.HasParameter<IDisposable>("classChild").IsAbstract())
                              .Has(new MethodWriter("MyOtherMethod"))
                    ));

            Console.WriteLine(module.Write());

            Console.WriteLine(module2.Write());

            Console.Read();
        }


    }
}
