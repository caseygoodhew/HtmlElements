using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace TheGoal.Programmed
{
    public interface IAttributeValidator
    {
        string Validate(Element el, params object[] arguments);
    }

    public interface IAttributeValidator<in T> : IAttributeValidator
    {
        string Validate(Element el, T param);
    }

    public interface IAttributeValidator<in T1, in T2> : IAttributeValidator
    {
        string Validate(Element el, T1 param1, T2 param2);
    }

    public interface IAttributeValidator<in T1, in T2, in T3> : IAttributeValidator
    {
        string Validate(Element el, T1 param1, T2 param2, T3 param3);
    }

    public interface IAttributeValidator<in T1, in T2, in T3, in T4> : IAttributeValidator
    {
        string Validate(Element el, T1 param1, T2 param2, T3 param3, T4 param4);
    }

    public abstract class AttributeValidator : IAttributeValidator
    {
        private readonly MethodInfo validationMethodInfo;

        protected AttributeValidator()
        {
            var genericArgumentTypes =
                GetType()
                    .GetInterfaces()
                    .Where(x => x.IsGenericType)
                    .Where(x => typeof(IAttributeValidator).IsAssignableFrom(x.GetGenericTypeDefinition()))
                    .Select(x => x.GetGenericArguments())
                    .Single();

            if (!genericArgumentTypes.Any())
            {
                // this implementation does not validate (possibly a typed placeholder for future implementation)
                validationMethodInfo = null;
                return;
            }

            var methodPotenials =
                    GetType()
                    .GetMethods()
                    .Where(x => x.Name == "Validate")
                    .Where(x => x.ReturnType == typeof(string));

            var expectedArgs = new[] { typeof(Element) }.Concat(genericArgumentTypes).ToArray();

            foreach (var method in methodPotenials)
            {
                var methodParameterTypes =
                    method.GetParameters()
                        .Where(x => !x.IsOptional)
                        .Where(x => !x.GetCustomAttributes(typeof(ParamArrayAttribute), false).Any())
                        .Select(x => x.ParameterType);

                if (methodParameterTypes.SequenceEqual(expectedArgs))
                {
                    validationMethodInfo = method;
                    return;
                }
            }

            // presumably impossible - check your linq
            throw new Exception();
        }

        public virtual string Validate(Element el, params object[] arguments)
        {
            if (validationMethodInfo == null)
            {
                return null;
            }

            return (string)validationMethodInfo.Invoke(this, new object[] { el }.Concat(arguments).ToArray());
        }
    }

    public abstract class AttributeValidator<T> : AttributeValidator, IAttributeValidator<T>
    {
        public abstract string Validate(Element el, T param);
    }

    public abstract class AttributeValidator<T1, T2> : AttributeValidator, IAttributeValidator<T1, T2>
    {
        public abstract string Validate(Element el, T1 param1, T2 param2);
    }

    public abstract class AttributeValidator<T1, T2, T3> : AttributeValidator, IAttributeValidator<T1, T2, T3>
    {
        public abstract string Validate(Element el, T1 param1, T2 param2, T3 param3);
    }

    public abstract class AttributeValidator<T1, T2, T3, T4> : AttributeValidator, IAttributeValidator<T1, T2, T3, T4>
    {
        public abstract string Validate(Element el, T1 param1, T2 param2, T3 param3, T4 param4);
    }

    public abstract class RegexAttributeValidator : AttributeValidator<string>
    {
        private readonly Regex regex;

        private readonly string failureMessage;

        private readonly bool messageHasParam;

        protected RegexAttributeValidator(string regex, string failureMessage)
            : this(regex, false, failureMessage)
        {
        }

        protected RegexAttributeValidator(string regex, bool ignoreCase, string failureMessage)
            : this(ignoreCase ? new Regex(regex, RegexOptions.IgnoreCase) : new Regex(regex), failureMessage)
        {
        }

        protected RegexAttributeValidator(Regex regex, string failureMessage)
        {
            this.regex = regex;
            this.failureMessage = failureMessage;
            messageHasParam = failureMessage.Contains("{0}");
        }

        public override string Validate(Element el, string param)
        {
            if (regex.IsMatch(param))
            {
                return null;
            }

            return messageHasParam ? string.Format(failureMessage, param) : failureMessage;
        }
    }

    public class ClassAttributeValidator : RegexAttributeValidator
    {
        public ClassAttributeValidator()
            : base("^-?[_a-zA-Z]+[_a-zA-Z0-9-]*$", @"""{0}"" is an invalid class value")
        {
        }
    }
}