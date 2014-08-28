using Template.Elements;

namespace Template.Validation
{
	public abstract class NotImplementedValidator<T1, T2, T3, T4> : Validator<T1, T2, T3, T4>
	{
		public override string Validate(Element el, T1 param1, T2 param2, T3 param3, T4 param4)
		{
			return null;
		}
	}

	public abstract class NotImplementedValidator<T1, T2, T3> : Validator<T1, T2, T3>
	{
		public override string Validate(Element el, T1 param1, T2 param2, T3 param3)
		{
			return null;
		}
	}

	public abstract class NotImplementedValidator<T1, T2> : Validator<T1, T2>
	{
		public override string Validate(Element el, T1 param1, T2 param2)
		{
			return null;
		}
	}

	public abstract class NotImplementedValidator<T> : Validator<T>
	{
		public override string Validate(Element el, T param)
		{
			return null;
		}
	}

	public abstract class NotImplementedValidator : Validator
	{
	}
}