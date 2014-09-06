using System.Collections.Generic;
using System.Linq;

namespace CSharp.Writers
{
	public abstract class WriterWithChildren<TChild> : Writer where TChild : IWriter
	{
		internal List<TChild> Children { get; set; }

		protected WriterWithChildren()
		{
			Children = new List<TChild>();
		}

		internal List<TChild> SortChildren<TFirst>() where TFirst : TChild
		{
			var first = Children.OfType<TFirst>().Cast<TChild>();
			var sorted = first;
			var remaining = Children.Where(x => !sorted.Contains(x));
			
			return sorted.Concat(remaining).ToList();
		}

		internal List<TChild> SortChildren<TFirst, TSecond>()
			where TFirst : TChild
			where TSecond : TChild
		{
			var first = Children.OfType<TFirst>().Cast<TChild>();
			var second = Children.OfType<TSecond>().Cast<TChild>();
			var sorted = first.Concat(second);
			var remaining = Children.Where(x => !sorted.Contains(x));

			return sorted.Concat(remaining).ToList();
		}

		internal List<TChild> SortChildren<TFirst, TSecond, TThird>()
			where TFirst : TChild
			where TSecond : TChild
			where TThird : TChild
		{
			var first = Children.OfType<TFirst>().Cast<TChild>();
			var second = Children.OfType<TSecond>().Cast<TChild>();
			var third = Children.OfType<TThird>().Cast<TChild>();
			var sorted = first.Concat(second).Concat(third);
			var remaining = Children.Where(x => !sorted.Contains(x));

			return sorted.Concat(remaining).ToList();
		}
	}
}