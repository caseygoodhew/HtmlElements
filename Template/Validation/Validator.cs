using System;
using System.Linq;
using System.Reflection;
using Template.Elements;

namespace Template.Validation
{
	public abstract class Validator : IValidator
	{
		private readonly MethodInfo validationMethodInfo;

		protected Validator()
		{
			var genericArgumentTypes =
				GetType()
					.GetInterfaces()
					.Where(x => x.IsGenericType)
					.Where(x => typeof(IValidator).IsAssignableFrom(x.GetGenericTypeDefinition()))
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
}