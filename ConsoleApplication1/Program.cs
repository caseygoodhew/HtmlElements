using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp;
using CSharp.Binding;
using CSharp.Writers;

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
                        x.IsGeneric(
                            g =>
                            g.HasParameter("TSomething", p => p.WhereIsStruct())
                                .HasParameter("TElse", p => p.WhereIsNew().WhereIsType(new TypeParameterWriter<int>()))))
                    .HasClass("AnyClass", 
                        x => x.Has(new FieldWriter(newClass, "NewClass").IsPrivate().IsStaticReadonly())
                              .Has(new PropertyWriter(new TypeParameterWriter<string>(), "Awesome").IsPrivate(Property.Setter))
                              .HasField<object>("Object", f => f.IsStatic())
                              .HasProperty<bool>("Inline", p => p.IsInternal())
                              .Has(new PropertyWriter(new TypeParameterWriter<string>(), "Awesome2").IsAbstract(Property.Setter))
                              .Has(new FieldWriter(new TypeParameterWriter<DateTime>(), "SomeField").IsProtected())
                              .Has(new MethodWriter("MyMethod")
                                            .IsPrivate()
                                            .IsGeneric(g => g.HasParameter("TDani").HasParameter("TOlivia", p => p.WhereIsNew()))
                                            .HasParameter<Type>("type")
                                            .HasParameter<string>("name"))
                              .HasMethod("MyMethod", m => m.IsExtensionMethod<MethodWriter>("Testing"))
                              .HasMethod<string>("MyMethod", m => m.HasParameter<IClassChild>("classChild").IsAbstract())
                              .Has(new MethodWriter("MyOtherMethod"))
                    ));

            Console.WriteLine(module.Write());

            Console.WriteLine(module2.Write());

            Console.Read();
        }


    }
}
