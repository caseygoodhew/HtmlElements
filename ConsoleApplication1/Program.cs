using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Coding.Binding;
using Coding.Writers;
using Coding.Writers2;

namespace ConsoleApplication1
{
    public enum TestEnum
    {
        SomeValue
    }
    
    internal class Program
    {
        private static void Main(string[] args)
        {
            var @class = new ClassWriter("MyClass").HasConstructor(x => x.HasParameter<bool>("flag"));
            var method = new MethodWriter("MyMethod").HasParameter<int>("id").HasParameter<object>("name", null);
            @class.HasMethod(method);

            var newUp = new NewClassInstanceWriter(@class, true);
            var variable = new VariableWriter(@class, "someVariable", newUp);
            var variableDeclaration = new VariableDeclarationStatementWriter(variable);

            var callMethod = new InvokeMethodWriter(variable, method, 101, "casey");

            Console.WriteLine(@class.Write());
            Console.WriteLine(new StatementsWriter(variableDeclaration, callMethod).Write());
            



            //Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
            
            var ifstatement = new IfStatementWriter(new ConditionWriter().IsFalse(new ValueWriter<bool>(false)) as ConditionWriter);

            Console.WriteLine(new StatementsWriter(ifstatement).Write());

            Console.ReadKey();

            var module = new ModuleWriter();
            var codingNamespace = new NamespaceWriter("Coding");
            module.HasUsing(new NamespaceWriter(codingNamespace, "Binding"));
            module.HasUsing(new NamespaceWriter(codingNamespace, "Writers"));

            var programClass = new ClassWriter("Program").IsInternal();
            module.HasNamespace("ConsoleApplication1", x => x.HasClass(programClass));

            var mainMethod = new MethodWriter("Main").IsPrivate().IsStatic();
            mainMethod.HasParamsParameter<string>("args");

            programClass.HasMethod(mainMethod);

            Console.WriteLine(module.Write());

            var variableOne = new VariableWriter<bool>("test1", true);
            var variableTwo = new VariableWriter<int>("test2", 32);
            var variableThree = new VariableWriter(new BoolWriter(), "test2", false);
            
            var conditionOne = new ConditionWriter();
            
            conditionOne
                .IsFalse(variableThree)
                .And(x => x.IsNull(variableOne)
                    .Or()
                    .IsNotNull(variableOne))
                .And()
                .AreEqual(variableOne, variableTwo)
                .And()
                .AreNotEqual(variableOne, variableTwo)
                .And()
                .AreEqual(variableOne, 'x')
                .And()
                .AreEqual(variableOne, TestEnum.SomeValue);

            Console.WriteLine(new VariableDeclarationStatementWriter(new VariableWriter<bool>("isTrue", new ConditionWriter().IsFalse(new ValueWriter<bool>(false)) as ConditionWriter)).Write());

            //Console.ReadKey();

            Console.WriteLine(new VariableAssignmentStatementWriter(new VariableWriter(new ClassWriter("SomeClass"), "classVar"), new VariableWriter(new ClassWriter("SomeClass"), "harry")).Write());
            Console.WriteLine(conditionOne.Write());

            



            var module1 =
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
                              .Has(new FieldWriter(To.GetTypeWriter<DateTime>(), "SomeField").IsProtected())
                              .Has(new MethodWriter("MyMethod")
                                            .IsPrivate()
                                            .HasGenericParameter("TDani")
                                            .HasGenericParameter("TOlivia", p => p.WhereIsNew())
                                            .HasParameter<Type>("type")
                                            .HasParameter<string>("name"))
                              .HasMethod("MyMethod", m => m.IsExtensionMethod<Program>("Testing"))
                              .HasMethod<string>("MyMethod", m => m.HasParameter<IDisposable>("classChild").IsAbstract())
                              .Has(new MethodWriter("MyOtherMethod"))
                    ));

            Console.WriteLine(module.Write());

            Console.WriteLine(module1.Write());

            Console.WriteLine(module2.Write());


            Console.Read();
        }









    }
}
