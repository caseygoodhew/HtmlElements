namespace HtmlElements
{
	internal interface IRootElement { }

	internal interface IDocumentMetadataElement { }

	internal interface IScriptingElement { }

	internal interface ISectionElement { }

	internal interface IContentGroupingElement { }

	internal interface ISemanticTextElement { }

	internal interface IEmbeddedContentElement { }

	internal interface ITableElement { }

	internal interface IFormElement { }

	internal interface IInteractiveElement { }

	internal interface IFrequentElement { }
	
	public enum EndTag
	{
		Required,
		Forbidden
	}
	
	public enum TagBody
	{
		Allowed,
		Forbidden,
		TextOnly
	}
	
	public abstract class Element
	{
		private string _tag;

		private EndTag _endTag;

		private TagBody _tagBody;

		protected string _revisitUrl;

		protected Element(string tag, TagBody tagBody)
			: this(tag, tagBody == TagBody.Forbidden ? EndTag.Forbidden : EndTag.Required, tagBody)
		{
		}
		
		protected Element(string tag, EndTag endTag = EndTag.Required, TagBody tagBody = TagBody.Allowed)
		{
			_tag = tag;
			_endTag = endTag;
			_tagBody = tagBody;
		}

	    public TAttribute GetAttribute<TAttribute>() where TAttribute : ElementAttribute
	    {
	        return null;
	    }
	}
	
	public class A : Element, ISemanticTextElement, IFrequentElement
	{
		public A() : base("a")
		{
		}
	}

	public class Abbr : Element, ISemanticTextElement
	{
		public Abbr() : base("abbr")
		{
		}
	}

	public class Address : Element, ISectionElement
	{
		public Address() : base("address")
		{
		}
	}

	public class Area : Element, IEmbeddedContentElement
	{
		public Area() : base("area", TagBody.Forbidden)
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_area.asp";
		}
	}

	public class Article : Element, ISectionElement
	{
		public Article() : base("article")
		{
		}
	}

	public class Aside : Element, ISectionElement
	{
		public Aside() : base("aside")
		{
		}
	}

	public class Audio : Element, IEmbeddedContentElement
	{
		public Audio() : base("audio")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_audio.asp";
		}
	}

	public class B : Element, ISemanticTextElement
	{
		public B() : base("b")
		{
		}
	}

	public class Base : Element, IDocumentMetadataElement
	{
		public Base() : base("base", TagBody.Forbidden)
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_base.asp";
		}
	}

	public class Bdo : Element, ISemanticTextElement
	{
		public Bdo() : base("bdo")
		{
		}
	}

	public class BlockQuote : Element, IContentGroupingElement
	{
		public BlockQuote() : base("blockquote")
		{
		}
	}

	public class Body : Element, ISectionElement
	{
		public Body() : base("body")
		{
		}
	}

	public class Br : Element, IContentGroupingElement, IFrequentElement
	{
		public Br() : base("br", TagBody.Forbidden)
		{
		}
	}

	public class Button : Element, IFormElement, IFrequentElement
	{
		public Button() : base("button")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_button.asp";
		}
	}

	public class Canvas : Element, IEmbeddedContentElement, IFrequentElement
	{
		public Canvas() : base("canvas", TagBody.TextOnly)
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_canvas.asp";
		}
	}

	public class Caption : Element, ITableElement
	{
		public Caption() : base("caption", TagBody.TextOnly)
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_caption.asp";
		}
	}

	public class Cite : Element, ISemanticTextElement
	{
		public Cite() : base("cite")
		{
		}
	}

	public class Code : Element, ISemanticTextElement
	{
		public Code() : base("code")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_code.asp";
		}
	}

	public class Col : Element, ITableElement
	{
		public Col() : base("col", TagBody.Forbidden)
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_col.asp";
		}
	}

	public class ColGroup : Element, ITableElement
	{
		public ColGroup() : base("colgroup")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_colgroup.asp";
		}
	}

	public class DataList : Element, IFormElement
	{
		public DataList() : base("datalist")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_datalist.asp";
		}
	}

	public class Dd : Element, IContentGroupingElement
	{
		public Dd() : base("dd")
		{
		}
	}

	public class Del : Element, ISemanticTextElement
	{
		public Del() : base("del")
		{
		}
	}

	public class Details : Element, IInteractiveElement
	{
		public Details() : base("details")
		{
		}
	}

	public class Dfn : Element, ISemanticTextElement
	{
		public Dfn() : base("dfn")
		{
		}
	}

	public class Div : Element, IContentGroupingElement, IFrequentElement
	{
		public Div() : base("div")
		{
		}
	}

	public class Dl : Element, IContentGroupingElement
	{
		public Dl() : base("dl")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_dl.asp";
		}
	}

	public class Dt : Element, IContentGroupingElement
	{
		public Dt() : base("dt")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_dt.asp";
		}
	}

	public class Em : Element, ISemanticTextElement
	{
		public Em() : base("em")
		{
		}
	}

	public class Embed : Element, IEmbeddedContentElement
	{
		public Embed() : base("embed", TagBody.Forbidden)
		{
		}
	}

	public class FieldSet : Element, IFormElement, IFrequentElement
	{
		public FieldSet() : base("fieldset")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_fieldset.asp";
		}
	}

	public class FigCaption : Element, IContentGroupingElement
	{
		public FigCaption() : base("figcaption")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_figcaption.asp";
		}
	}

	public class Figure : Element, IContentGroupingElement
	{
		public Figure() : base("figure")
		{
		}
	}

	public class Footer : Element, ITableElement
	{
		public Footer() : base("footer")
		{
		}
	}

	public class Form : Element, IFormElement, IFrequentElement
	{
		public Form() : base("form")
		{
		}
	}

	public class H1 : Element, ISectionElement, IFrequentElement
	{
		public H1() : base("h1")
		{
		}
	}

	public class H2 : Element, ISectionElement, IFrequentElement
	{
		public H2() : base("h2")
		{
		}
	}

	public class H3 : Element, ISectionElement, IFrequentElement
	{
		public H3() : base("h3")
		{
		}
	}

	public class H4 : Element, ISectionElement, IFrequentElement
	{
		public H4() : base("h4")
		{
		}
	}

	public class H5 : Element, ISectionElement, IFrequentElement
	{
		public H5() : base("h5")
		{
		}
	}

	public class H6 : Element, ISectionElement, IFrequentElement
	{
		public H6() : base("h6")
		{
		}
	}

	public class Head : Element, IDocumentMetadataElement
	{
		public Head() : base("head")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_head.asp";
		}
	}

	public class Header : Element, ISectionElement
	{
		public Header() : base("header")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_header.asp";
		}
	}

	public class Hr : Element, IContentGroupingElement, IFrequentElement
	{
		public Hr() : base("hr", TagBody.Forbidden)
		{
		}
	}

	public class Html : Element, IRootElement
	{
		public Html() : base("html")
		{
		}
	}

	public class I : Element, ISemanticTextElement
	{
		public I() : base("i")
		{
		}
	}

	public class IFrame : Element, IEmbeddedContentElement
	{
		public IFrame() : base("iframe", TagBody.TextOnly)
		{
		}
	}

	public class Img : Element, IEmbeddedContentElement, IFrequentElement
	{
		public Img() : base("img", TagBody.Forbidden)
		{
		}
	}

	public abstract class Input : Element, IFormElement
	{
		private readonly string _type;

		protected Input(string type)
			: base("input", TagBody.Forbidden)
		{
			_type = type;
		}
	}

	public abstract class VisibleInput : Input
	{
		protected VisibleInput(string type) : base(type)
		{
		}
	}

	public abstract class DateTypeInput : VisibleInput
	{
		protected DateTypeInput(string type) : base(type)
		{
		}
	}

	public abstract class TextTypeInput : VisibleInput
	{
		protected TextTypeInput(string type) : base(type)
		{
		}
	}

	public abstract class ButtonTypeInput : VisibleInput
	{
		protected ButtonTypeInput(string type) : base(type)
		{
		}
	}

	public class ButtonInput : ButtonTypeInput, IFrequentElement
	{
		public ButtonInput() : base("button")
		{
		}
	}

	public class CheckboxInput : VisibleInput, IFrequentElement
	{
		public CheckboxInput() : base("checkbox")
		{
		}
	}

	public class ColorInput : VisibleInput
	{
		public ColorInput() : base("color")
		{
		}
	}

	public class DateInput : DateTypeInput
	{
		public DateInput() : base("date")
		{
		}
	}

	public class DateTimeLocalInput : DateTypeInput
	{
		public DateTimeLocalInput() : base("datetime-local")
		{
		}
	}

	public class EmailInput : TextTypeInput, IFrequentElement
	{
		public EmailInput() : base("email")
		{
		}
	}

	public class FileInput : VisibleInput, IFrequentElement
	{
		public FileInput() : base("file")
		{
		}
	}

	public class HiddenInput : Input, IFrequentElement
	{
		public HiddenInput() : base("hidden")
		{
		}
	}

	public class ImageInput : VisibleInput
	{
		public ImageInput() : base("image")
		{
		}
	}

	public class MonthInput : DateTypeInput
	{
		public MonthInput() : base("month")
		{
		}
	}

	public class NumberInput : VisibleInput, IFrequentElement
	{
		public NumberInput() : base("number")
		{
		}
	}

	public class PasswordInput : TextTypeInput, IFrequentElement
	{
		public PasswordInput() : base("password")
		{
		}
	}

	public class RadioInput : VisibleInput, IFrequentElement
	{
		public RadioInput() : base("radio")
		{
		}
	}

	public class RangeInput : VisibleInput
	{
		public RangeInput() : base("range")
		{
		}
	}

	public class ResetInput : ButtonTypeInput
	{
		public ResetInput() : base("reset")
		{
		}
	}

	public class SearchInput : TextTypeInput
	{
		public SearchInput() : base("search")
		{
		}
	}

	public class SubmitInput : ButtonTypeInput, IFrequentElement
	{
		public SubmitInput() : base("submit")
		{
		}
	}

	public class TelInput : TextTypeInput
	{
		public TelInput() : base("tel")
		{
		}
	}

	public class TextInput : TextTypeInput, IFrequentElement
	{
		public TextInput() : base("text")
		{
		}
	}

	public class TimeInput : DateTypeInput
	{
		public TimeInput() : base("time")
		{
		}
	}

	public class UrlInput : TextTypeInput
	{
		public UrlInput() : base("url")
		{
		}
	}

	public class WeekInput : DateTypeInput
	{
		public WeekInput() : base("button")
		{
		}
	}

	public class Ins : Element, ISemanticTextElement
	{
		public Ins() : base("ins")
		{
		}
	}

	public class Kbd : Element, ISemanticTextElement
	{
		public Kbd() : base("kbd")
		{
		}
	}

	public class KeyGen : Element, IFormElement
	{
		public KeyGen() : base("kengen", TagBody.Forbidden)
		{
		}
	}

	public class Label : Element, IFormElement, IFrequentElement
	{
		public Label() : base("label")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_label.asp";
		}
	}

	public class Legend : Element, IFormElement, IFrequentElement
	{
		public Legend() : base("legend")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_legend.asp";
		}
	}

	public class Li : Element, IContentGroupingElement
	{
		public Li() : base("li")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_li.asp";
		}
	}

	public class Link : Element, IDocumentMetadataElement
	{
		public Link() : base("link", TagBody.Forbidden)
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_link.asp";
		}
	}

	public class Main : Element, ISectionElement
	{
		public Main() : base("main")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_main.asp";
		}
	}

	public class Map : Element, IEmbeddedContentElement
	{
		public Map() : base("map")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_map.asp";
		}
	}

	public class Mark : Element, ISemanticTextElement
	{
		public Mark() : base("mark")
		{
		}
	}

	public class Meta : Element, IDocumentMetadataElement
	{
		public Meta() : base("meta", TagBody.Forbidden)
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_meta.asp";
		}
	}

	public class Meter : Element, IFormElement
	{
		public Meter() : base("meter")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_meter.asp";
		}
	}

	public class Nav : Element, ISectionElement
	{
		public Nav() : base("nav")
		{
		}
	}

	public class NoScript : Element, IScriptingElement
	{
		public NoScript() : base("noscript")
		{
		}
	}

	public class Object : Element, IEmbeddedContentElement
	{
		public Object() : base("object")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_object.asp";
		}
	}

	public class Ol : Element, IContentGroupingElement, IFrequentElement
	{
		public Ol() : base("ol")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_ol.asp";
		}
	}

	public class OptGroup : Element, IFormElement
	{
		public OptGroup() : base("optgroup")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_option.asp";
		}
	}

	public class Option : Element, IFormElement, IFrequentElement
	{
		public Option() : base("option")
		{
		}
	}

	public class Output : Element, IFormElement
	{
		public Output() : base("output")
		{
		}
	}

	public class P : Element, IContentGroupingElement, IFrequentElement
	{
		public P() : base("p")
		{
		}
	}

	public class Param : Element, IEmbeddedContentElement
	{
		public Param() : base("param", TagBody.Forbidden)
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_param.asp";
		}
	}

	public class Pre : Element, IContentGroupingElement
	{
		public Pre() : base("pre")
		{
		}
	}

	public class Progress : Element, IFormElement
	{
		public Progress() : base("progress")
		{
		}
	}

	public class Q : Element, ISemanticTextElement
	{
		public Q() : base("q")
		{
		}
	}

	public class Rp : Element, ISemanticTextElement
	{
		public Rp() : base("rp")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_rp.asp";
		}
	}

	public class Rt : Element, ISemanticTextElement
	{
		public Rt() : base("rt")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_rt.asp";
		}
	}

	public class Ruby : Element, ISemanticTextElement
	{
		public Ruby() : base("ruby")
		{
		}
	}

	public class S : Element, ISemanticTextElement
	{
		public S() : base("s")
		{
		}
	}

	public class Samp : Element, ISemanticTextElement
	{
		public Samp() : base("samp")
		{
		}
	}

	public class Script : Element, IScriptingElement
	{
		public Script() : base("script")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_script.asp";
		}
	}

	public class Section : Element, ISectionElement
	{
		public Section() : base("section")
		{
		}
	}

	public class Select : Element, IFormElement, IFrequentElement
	{
		public Select() : base("select")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_select.asp";
		}
	}

	public class Small : Element, ISemanticTextElement
	{
		public Small() : base("small")
		{
		}
	}

	public class Source : Element, IEmbeddedContentElement
	{
		public Source() : base("source", TagBody.Forbidden)
		{
		}
	}

	public class Span : Element, ISemanticTextElement, IFrequentElement
	{
		public Span() : base("span")
		{
		}
	}

	public class Strong : Element, ISemanticTextElement
	{
		public Strong() : base("strong")
		{
		}
	}

	public class Style : Element, IDocumentMetadataElement
	{
		public Style() : base("style")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_style.asp";
		}
	}

	public class Sub : Element, ISemanticTextElement
	{
		public Sub() : base("sub")
		{
		}
	}

	public class Summary : Element, IInteractiveElement
	{
		public Summary() : base("summary")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_summary.asp";
		}
	}

	public class Sup : Element, ISemanticTextElement
	{
		public Sup() : base("sup")
		{
		}
	}

	public class Table : Element, ITableElement, IFrequentElement
	{
		public Table() : base("table")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_table.asp";
		}
	}

	public class Tbody : Element, ITableElement, IFrequentElement
	{
		public Tbody() : base("tbody")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_tbody.asp";
		}
	}

	public class Td : Element, ITableElement, IFrequentElement
	{
		public Td() : base("td")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_td.asp";
		}
	}

	public class TextArea : Element, IFormElement, IFrequentElement
	{
		public TextArea() : base("textarea", TagBody.TextOnly)
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_tr.asp";
		}
	}

	public class Tfoot : Element, ITableElement
	{
		public Tfoot() : base("tfoot")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_tfoot.asp";
		}
	}

	public class Th : Element, ITableElement, IFrequentElement
	{
		public Th() : base("th")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_th.asp";
		}
	}

	public class Thead : Element, ITableElement, IFrequentElement
	{
		public Thead() : base("thead")
		{
			_revisitUrl = "v";
		}
	}

	public class Time : Element, ISemanticTextElement
	{
		public Time() : base("time")
		{
		}
	}

	public class Title : Element, IDocumentMetadataElement
	{
		public Title() : base("title")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_title.asp";
		}
	}

	public class Tr : Element, ITableElement, IFrequentElement
	{
		public Tr() : base("tr")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_tr.asp";
		}
	}

	public class Track : Element, IEmbeddedContentElement
	{
		public Track() : base("track", TagBody.Forbidden)
		{
		}
	}

	public class U : Element, ISemanticTextElement
	{
		public U() : base("u")
		{
		}
	}

	public class Ul : Element, IContentGroupingElement, IFrequentElement
	{
		public Ul() : base("ul")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_ul.asp";
		}
	}

	public class Var : Element, ISemanticTextElement
	{
		public Var() : base("var")
		{
		}
	}

	public class Video : Element, IEmbeddedContentElement
	{
		public Video() : base("video")
		{
			_revisitUrl = "http://www.w3schools.com/tags/tag_video.asp";
		}
	}

	public class Wbr : Element, ISemanticTextElement
	{
		public Wbr() : base("wbr", TagBody.Forbidden)
		{
		}
	}
}
