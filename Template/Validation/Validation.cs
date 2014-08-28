using System;
using System.Collections.Generic;
using Template.Elements;

namespace Template.Validation
{
	public class RectShapeCoordValidator : Validator<int, int, int, int>
	{
		public override string Validate(Element el, int param1, int param2, int param3, int param4)
		{
			var shapes = Reveal.GetAttributeInstances(el, "shape");
			
			/*var shape = el.GetAttribute<ShapeAttribute>();

            if (shape == null)
            {
                return new ShapeAttribute().
            }
            return true;*/
			throw new NotImplementedException();
		}
	}

	public class CircleShapeCoordValidator : Validator<int, int, int>
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
        
    public class PolyShapeCoordValidator : Validator<IEnumerable<int>>
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
