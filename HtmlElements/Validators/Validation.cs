using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using HtmlElements.Elements;
using HtmlElements.Meta;

namespace HtmlElements.Validators
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
            var genericArgs =
                GetType()
                    .GetInterfaces()
                    .Where(x => x.IsGenericType)
                    .Where(x => typeof(IAttributeValidator).IsAssignableFrom(x.GetGenericTypeDefinition()))
                    .Select(x => x.GetGenericArguments())
                    .Single();

            if (!genericArgs.Any())
            {
                // this implementation does not implement a validation method (possibly a typed placeholder for future implementation)
                validationMethodInfo = null;
                return;
            }
            
            var methodPotenials =
                GetType()
                    .GetMethods()
                    .Where(x => x.Name == "Validate")
                    .Where(x => x.ReturnType == typeof(string))
                    .Where(x => x.IsGenericMethod)
                    .ToArray();
                    
            foreach (var method in methodPotenials.Where(method => method.GetGenericArguments().SequenceEqual(genericArgs)))
            {
                validationMethodInfo = method;
                return;
            }

            // presumably impossible - check your linq
            throw new SomethingStrangeException();
        }

        public virtual string Validate(Element el, params object[] arguments)
        {
            if (validationMethodInfo == null)
            {
                return null;
            }

            return (string)validationMethodInfo.Invoke(this, arguments);
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

    public class OneCharacterValidator : AttributeValidator<char>
    {
        public override string Validate(Element el, char param)
        {
            return null;
        }
    }

    public abstract class NotImplementedValidator : AttributeValidator
    {
    }

    public abstract class NotImplementedValidator<T> : AttributeValidator<T>
    {
        public override string Validate(Element el, T param)
        {
            return null;
        }
    }

    public abstract class NotImplementedValidator<T1, T2> : AttributeValidator<T1, T2>
    {
        public override string Validate(Element el, T1 param1, T2 param2)
        {
            return null;
        }
    }

    public abstract class NotImplementedValidator<T1, T2, T3> : AttributeValidator<T1, T2, T3>
    {
        public override string Validate(Element el, T1 param1, T2 param2, T3 param3)
        {
            return null;
        }
    }

    public abstract class NotImplementedValidator<T1, T2, T3, T4> : AttributeValidator<T1, T2, T3, T4>
    {
        public override string Validate(Element el, T1 param1, T2 param2, T3 param3, T4 param4)
        {
            return null;
        }
    }

    public class NoValidator : AttributeValidator
    {
    }

    public abstract class RegexValidator : AttributeValidator<string>
    {
        private readonly Regex regex;

        private readonly string failureMessage;

        private readonly bool messageHasParam;

        protected RegexValidator(string regex, string failureMessage)
            : this(regex, false, failureMessage)
        {
        }

        protected RegexValidator(string regex, bool ignoreCase, string failureMessage)
            : this(ignoreCase ? new Regex(regex, RegexOptions.IgnoreCase) : new Regex(regex), failureMessage)
        {
        }

        protected RegexValidator(Regex regex, string failureMessage)
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

    public class ClassValidator : RegexValidator
    {
        public ClassValidator() : base("^-?[_a-zA-Z]+[_a-zA-Z0-9-]*$", "{0} is an invalid class name")
        {
        }
    }

    public class IdValidator : RegexValidator
    {
        public IdValidator() : base("^[A-Za-z][-A-Za-z0-9_:.]*$", "{0} is an invalid id value")
        {
        }
    }

    public class LanguageCodeValidator : NotImplementedValidator<string>
    {
    }

    public class UrlValidator : AttributeValidator<string>
    {
        public override string Validate(Element el, string param)
        {
            return null;
        }
    }

    public class MediaExpressionValidator : NotImplementedValidator<string>
    {
    }

    public class MediaTypeValidator : NotImplementedValidator<string>
    {
    }

    public class EnumValidator<TEnum> : AttributeValidator<TEnum> where TEnum : struct, IConvertible
    {
        public EnumValidator()
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum must be an enumerated type");
            }
        }

        public override string Validate(Element el, TEnum param)
        {
            return Enum.IsDefined(typeof(TEnum), param) ? null : string.Format(@"{0} is not a known enumeration member of {1}", param, typeof(TEnum));
        }
    }

    public class DecimalValidator : AttributeValidator<decimal>
    {
        public override string Validate(Element el, decimal param)
        {
            return null;
        }
    }

    public class DecimalArrayValidator : AttributeValidator<IEnumerable<decimal>>
    {
        public override string Validate(Element el, IEnumerable<decimal> param)
        {
            return null;
        }
    }

    public class RectShapeCoordValidator : AttributeValidator<int, int, int, int>
    {
        public override string Validate(Element el, int param1, int param2, int param3, int param4)
        {
            /*var shape = el.GetAttribute<ShapeAttribute>();

            if (shape == null)
            {
                return new ShapeAttribute().
            }
            return true;*/
            throw new NotImplementedException();
        }
    }
        
    public class CircleShapeCoordValidator : AttributeValidator<int, int, int>
    {
        public override string Validate(Element el, int param1, int param2, int param3)
        {
            /*var shape = el.GetAttribute<ShapeAttribute>();

            if (shape == null)
            {
                return new ShapeAttribute().
            }
            return true;*/
            throw new NotImplementedException();
        }
    }
        
    public class PolyShapeCoordValidator : AttributeValidator<IEnumerable<int>>
    {
        public override string Validate(Element el, IEnumerable<int> param)
        {
            /*var shape = el.GetAttribute<ShapeAttribute>();

            if (shape == null)
            {
                return new ShapeAttribute().
            }
            return true;*/
            throw new NotImplementedException();
        }
    }
















    public enum Editable
    {
        /// <summary>
        /// Specifies that the element is editable.
        /// </summary>
        True,

        /// <summary>
        /// Specifies that the element is not editable.
        /// </summary>
        False
    }

    public enum Draggable
    {
        /// <summary>
        /// Specifies that the element is draggable.
        /// </summary>
        True,
        
        /// <summary>
        /// Specifies that the element in not draggable.
        /// </summary>
        False,
        
        /// <summary>
        /// Uses the default behavior of the browser.
        /// </summary>
        Auto
    }

    public enum TextDirection
    {
        /// <summary>
        /// Default. Left-to-right text direction.
        /// </summary>
        Ltr,

        /// <summary>
        /// Right-to-left text direction.
        /// </summary>
        Rtl,

        /// <summary>
        /// Let the browser figure out the text direction, based on the content (only recommended if the text direction is unknown).
        /// </summary>
        Auto
    }

    public enum LinkedRel
    {
        /// <summary>
        /// Links to an alternate version of the document (i.e. print page, translated or mirror).
        /// </summary>
        Alternate,

        /// <summary>
        /// Links to the author of the document.
        /// </summary>
        Author,

        /// <summary>
        /// Permanent URL used for bookmarking.
        /// </summary>
        Bookmark,

        /// <summary>
        /// Links to a help document.
        /// </summary>
        Help,

        /// <summary>
        /// Links to copyright information for the document.
        /// </summary>
        License,

        /// <summary>
        /// The next document in a selection
        /// </summary>.
        Next,

        /// <summary>
        /// Links to an unendorsed document, like a paid link.
        /// ("nofollow" is used by Google, to specify that the Google search spider should not follow that link)
        /// </summary>
        NoFollow,

        /// <summary>
        /// Specifies that the browser should not send a HTTP referer header if the user follows the hyperlink.
        /// </summary>
        NoReferrer,

        /// <summary>
        /// Specifies that the target document should be cached.
        /// </summary>
        Prefetch,

        /// <summary>
        /// The previous document in a selection.
        /// </summary>
        Prev,

        /// <summary>
        /// Links to a search tool for the document.
        /// </summary>
        Search,

        /// <summary>
        /// A tag (keyword) for the current document.
        /// </summary>
        Tag
    }

    public enum ResourceRel
    {
        /// <summary>
        /// Links to an alternate version of the document (i.e. print page, translated or mirror).
        /// </summary>
        Alternate,

        /// <summary>
        /// Links to the author of the document.
        /// </summary>
        Author,

        /// <summary>
        /// Links to a help document.
        /// </summary>
        Help,

        /// <summary>
        /// Imports an icon to represent the document.
        /// </summary>
        Icon,

        /// <summary>
        /// Links to copyright information for the document.
        /// </summary>
        License,

        /// <summary>
        /// Indicates that the document is a part of a series, and that the next document in the series is the referenced document.
        /// </summary>
        Next,

        /// <summary>
        /// Specifies that the target resource should be cached.
        /// </summary>
        Prefetch,

        /// <summary>
        /// Indicates that the document is a part of a series, and that the previous document in the series is the referenced document.
        /// </summary>
        Prev,

        /// <summary>
        /// Links to a search tool for the document.
        /// </summary>
        Search,

        /// <summary>
        /// URL to a style sheet to import.
        /// </summary>
        StyleSheet
    }

    internal enum CoordValidators
    {
        /// <summary>
        /// Specifies the coordinates of the left, top, right, bottom corner of the rectangle (for shape="rect").
        /// </summary>
        [Validator(typeof(RectShapeCoordValidator))]
        X1Y1X2Y2,

        /// <summary>
        /// Specifies the coordinates of the circle center and the radius (for shape="circle")
        /// </summary>
        [Validator(typeof(CircleShapeCoordValidator))]
        XYRadius,

        /// <summary>
        /// Specifies the coordinates of the edges of the polygon. If the first and last coordinate pairs are not the same, the browser will add the last coordinate pair to close the polygon (for shape="poly").
        /// </summary>
        [Validator(typeof(PolyShapeCoordValidator))]
        X1Y1XnYn	
    }

    public enum Shape
    {
        /// <summary>
        /// Specifies the entire region.
        /// </summary>
        Default,

        /// <summary>
        /// Defines a rectangular region.
        /// </summary>
        Rect,

        /// <summary>
        /// Defines a circular region.
        /// </summary>
        Circle,
        
        /// <summary>
        /// Defines a polygonal region.
        /// </summary>
        Poly
    }
}
