using Template.Elements;

namespace Template.Validation
{
	public interface IValidator<in T1, in T2, in T3, in T4> : IValidator
	{
		string Validate(Element el, T1 param1, T2 param2, T3 param3, T4 param4);
	}

	public interface IValidator<in T1, in T2, in T3> : IValidator
	{
		string Validate(Element el, T1 param1, T2 param2, T3 param3);
	}

	public interface IValidator<in T1, in T2> : IValidator
	{
		string Validate(Element el, T1 param1, T2 param2);
	}

	public interface IValidator<in T> : IValidator
	{
		string Validate(Element el, T param);
	}

	public interface IValidator
	{
		string Validate(Element el, params object[] arguments);
	}
}