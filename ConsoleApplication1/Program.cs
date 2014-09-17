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
using Coding.Binding2;
using Coding.Writers;
using Coding.Writers2;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
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

            var variableOne = new VariableWriter(new BoolWriter(), "test");
            var variableTwo = new VariableWriter(new BoolWriter(), "test");

            var conditionOne = new ConditionWriter(x => x.IsTrue().And().IsFalse().Or().Group(y => y.AreEqual()));
            conditionOne.IsTrue(variableOne);
                        .IsFalse(variableOne);
                        .IsNull(variableOne);
                        .IsNotNull(variableOne);

            var conditionTwo = new ConditionWriter();
            conditionTwo.AreEqual(variableTwo, 42);
                        .NotEqual(variableTwo, 42);

            var conditionThree = new ConditionWriter();
            //conditionThree.`

            var ifStatement = new StatementWriter();
            
            var conditionStatementOne = new StatementWriter();
            var conditionStatementTwo = new StatementWriter();
            var conditionStatementThree = new StatementWriter();
            
            ifStatement.If(conditionOne, conditionStatementOne)
                    .ElseIf(conditionTwo, conditionStatementTwo)
                    .Else(conditionStatementThree);
            
            
            
            /*
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

            */

            Console.Read();
        }









    }
}
