
namespace Definition.Elements
{
	internal abstract class ElementDefinition
	{
		internal readonly string Tag;

		internal readonly Structure Structure;

		protected ElementDefinition(string tag, Structure structure = Structure.Expanded)
		{
			Tag = tag;
			Structure = structure;
		}
	}

	[ElementType(ElementType.Frequent)]
	internal sealed class TextNode : ElementDefinition
	{
		public TextNode() : base(null)
		{
		}
	}

	[ElementType(ElementType.SemanticText, ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class A : ElementDefinition
	{
		internal A() : base("a")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Abbr : ElementDefinition
	{
		internal Abbr() : base("abbr")
		{
		}
	}

	[ElementType(ElementType.Section)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Address : ElementDefinition
	{
		internal Address() : base("address")
		{
		}
	}

	[ElementType(ElementType.EmbeddedContent)]
	[Reference("http://www.w3schools.com/tags/tag_area.asp")]
	internal class Area : ElementDefinition
	{
		internal Area() : base("area", Structure.Condensed)
		{
		}
	}

	[ElementType(ElementType.Section)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Article : ElementDefinition
	{
		internal Article() : base("article")
		{
		}
	}

	[ElementType(ElementType.Section)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Aside : ElementDefinition
	{
		internal Aside() : base("aside")
		{
		}
	}

	[ElementType(ElementType.EmbeddedContent)]
	[Reference("http://www.w3schools.com/tags/tag_audio.asp")]
	internal class Audio : ElementDefinition
	{
		internal Audio() : base("audio")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class B : ElementDefinition
	{
		internal B() : base("b")
		{
		}
	}

	[ElementType(ElementType.DocumentMetadata)]
	[Reference("http://www.w3schools.com/tags/tag_base.asp")]
	internal class Base : ElementDefinition
	{
		internal Base() : base("base", Structure.Condensed)
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Bdo : ElementDefinition
	{
		internal Bdo() : base("bdo")
		{
		}
	}

	[ElementType(ElementType.ContentGrouping)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class BlockQuote : ElementDefinition
	{
		internal BlockQuote() : base("blockquote")
		{
		}
	}

	[ElementType(ElementType.Section)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Body : ElementDefinition
	{
		internal Body() : base("body")
		{
		}
	}

	[ElementType(ElementType.ContentGrouping, ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Br : ElementDefinition
	{
		internal Br() : base("br", Structure.Condensed)
		{
		}
	}

	[ElementType(ElementType.Form, ElementType.Frequent)]
	[Reference("http://www.w3schools.com/tags/tag_button.asp")]
	internal class Button : ElementDefinition
	{
		internal Button() : base("button")
		{
		}
	}

	[RestrictToChild(typeof(TextNode))]
	[ElementType(ElementType.EmbeddedContent, ElementType.Frequent)]
	[Reference("http://www.w3schools.com/tags/tag_canvas.asp")]
	internal class Canvas : ElementDefinition
	{
		internal Canvas() : base("canvas")
		{
		}
	}

	[RestrictToChild(typeof(TextNode))]
	[ElementType(ElementType.Table)]
	[Reference("http://www.w3schools.com/tags/tag_caption.asp")]
	internal class Caption : ElementDefinition
	{
		internal Caption() : base("caption")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Cite : ElementDefinition
	{
		internal Cite() : base("cite")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("http://www.w3schools.com/tags/tag_code.asp")]
	internal class Code : ElementDefinition
	{
		internal Code() : base("code")
		{
		}
	}

	[ElementType(ElementType.Table)]
	[Reference("http://www.w3schools.com/tags/tag_col.asp")]
	internal class Col : ElementDefinition
	{
		internal Col() : base("col", Structure.Condensed)
		{
		}
	}

	[ElementType(ElementType.Table)]
	[Reference("http://www.w3schools.com/tags/tag_colgroup.asp")]
	internal class ColGroup : ElementDefinition
	{
		internal ColGroup() : base("colgroup")
		{
		}
	}

	[ElementType(ElementType.Form)]
	[Reference("http://www.w3schools.com/tags/tag_datalist.asp")]
	internal class DataList : ElementDefinition
	{
		internal DataList() : base("datalist")
		{
		}
	}

	[ElementType(ElementType.ContentGrouping)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Dd : ElementDefinition
	{
		internal Dd() : base("dd")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Del : ElementDefinition
	{
		internal Del() : base("del")
		{
		}
	}

	[ElementType(ElementType.Interactive)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Details : ElementDefinition
	{
		internal Details() : base("details")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Dfn : ElementDefinition
	{
		internal Dfn() : base("dfn")
		{
		}
	}

	[ElementType(ElementType.ContentGrouping, ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Div : ElementDefinition
	{
		internal Div() : base("div")
		{
		}
	}

	[ElementType(ElementType.ContentGrouping)]
	[Reference("http://www.w3schools.com/tags/tag_dl.asp")]
	internal class Dl : ElementDefinition
	{
		internal Dl() : base("dl")
		{
		}
	}

	[ElementType(ElementType.ContentGrouping)]
	[Reference("http://www.w3schools.com/tags/tag_dt.asp")]
	internal class Dt : ElementDefinition
	{
		internal Dt() : base("dt")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Em : ElementDefinition
	{
		internal Em() : base("em")
		{
		}
	}

	[ElementType(ElementType.EmbeddedContent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Embed : ElementDefinition
	{
		internal Embed() : base("embed", Structure.Condensed)
		{
		}
	}

	[ElementType(ElementType.Form, ElementType.Frequent)]
	[Reference("http://www.w3schools.com/tags/tag_fieldset.asp")]
	internal class FieldSet : ElementDefinition
	{
		internal FieldSet() : base("fieldset")
		{
		}
	}

	[ElementType(ElementType.ContentGrouping)]
	[Reference("http://www.w3schools.com/tags/tag_figcaption.asp")]
	internal class FigCaption : ElementDefinition
	{
		internal FigCaption() : base("figcaption")
		{
		}
	}

	[ElementType(ElementType.ContentGrouping)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Figure : ElementDefinition
	{
		internal Figure() : base("figure")
		{
		}
	}

	[ElementType(ElementType.Table)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Footer : ElementDefinition
	{
		internal Footer() : base("footer")
		{
		}
	}

	[ElementType(ElementType.Form, ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Form : ElementDefinition
	{
		internal Form() : base("form")
		{
		}
	}

	[ElementType(ElementType.Section, ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class H1 : ElementDefinition
	{
		internal H1() : base("h1")
		{
		}
	}

	[ElementType(ElementType.Section, ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class H2 : ElementDefinition
	{
		internal H2() : base("h2")
		{
		}
	}

	[ElementType(ElementType.Section, ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class H3 : ElementDefinition
	{
		internal H3() : base("h3")
		{
		}
	}

	[ElementType(ElementType.Section, ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class H4 : ElementDefinition
	{
		internal H4() : base("h4")
		{
		}
	}

	[ElementType(ElementType.Section, ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class H5 : ElementDefinition
	{
		internal H5() : base("h5")
		{
		}
	}

	[ElementType(ElementType.Section, ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class H6 : ElementDefinition
	{
		internal H6() : base("h6")
		{
		}
	}

	[ElementType(ElementType.DocumentMetadata)]
	[Reference("http://www.w3schools.com/tags/tag_head.asp")]
	internal class Head : ElementDefinition
	{
		internal Head() : base("head")
		{
		}
	}

	[ElementType(ElementType.Section)]
	[Reference("http://www.w3schools.com/tags/tag_header.asp")]
	internal class Header : ElementDefinition
	{
		internal Header() : base("header")
		{
		}
	}

	[ElementType(ElementType.ContentGrouping, ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Hr : ElementDefinition
	{
		internal Hr() : base("hr", Structure.Condensed)
		{
		}
	}

	[ElementType(ElementType.Root)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Html : ElementDefinition
	{
		internal Html() : base("html")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class I : ElementDefinition
	{
		internal I() : base("i")
		{
		}
	}

	[RestrictToChild(typeof(TextNode))]
	[ElementType(ElementType.EmbeddedContent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class IFrame : ElementDefinition
	{
		internal IFrame() : base("iframe")
		{
		}
	}

	[ElementType(ElementType.EmbeddedContent, ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Img : ElementDefinition
	{
		internal Img() : base("img", Structure.Condensed)
		{
		}
	}

	[ElementType(ElementType.Form)]
	internal abstract class Input : ElementDefinition
	{
		public readonly string Type;

		protected Input(string type) : base("input", Structure.Condensed)
		{
			Type = type;
		}
	}

	internal abstract class VisibleInput : Input
	{
		protected VisibleInput(string type) : base(type)
		{
		}
	}

	internal abstract class DateTypeInput : VisibleInput
	{
		protected DateTypeInput(string type) : base(type)
		{
		}
	}

	internal abstract class TextTypeInput : VisibleInput
	{
		protected TextTypeInput(string type) : base(type)
		{
		}
	}

	internal abstract class ButtonTypeInput : VisibleInput
	{
		protected ButtonTypeInput(string type) : base(type)
		{
		}
	}

	[ElementType(ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class ButtonInput : ButtonTypeInput
	{
		internal ButtonInput() : base("button")
		{
		}
	}

	[ElementType(ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class CheckboxInput : VisibleInput
	{
		internal CheckboxInput() : base("checkbox")
		{
		}
	}

	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class ColorInput : VisibleInput
	{
		internal ColorInput() : base("color")
		{
		}
	}

	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class DateInput : DateTypeInput
	{
		internal DateInput() : base("date")
		{
		}
	}

	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class DateTimeLocalInput : DateTypeInput
	{
		internal DateTimeLocalInput() : base("datetime-local")
		{
		}
	}

	
	[ElementType(ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class EmailInput : TextTypeInput
	{
		internal EmailInput() : base("email")
		{
		}
	}

	[ElementType(ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class FileInput : VisibleInput
	{
		internal FileInput() : base("file")
		{
		}
	}

	[ElementType(ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class HiddenInput : Input
	{
		internal HiddenInput() : base("hidden")
		{
		}
	}

	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class ImageInput : VisibleInput
	{
		internal ImageInput() : base("image")
		{
		}
	}

	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class MonthInput : DateTypeInput
	{
		internal MonthInput() : base("month")
		{
		}
	}

	[ElementType(ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class NumberInput : VisibleInput
	{
		internal NumberInput() : base("number")
		{
		}
	}

	[ElementType(ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class PasswordInput : TextTypeInput
	{
		internal PasswordInput() : base("password")
		{
		}
	}

	[ElementType(ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class RadioInput : VisibleInput
	{
		internal RadioInput() : base("radio")
		{
		}
	}

	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class RangeInput : VisibleInput
	{
		internal RangeInput() : base("range")
		{
		}
	}

	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class ResetInput : ButtonTypeInput
	{
		internal ResetInput() : base("reset")
		{
		}
	}

	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class SearchInput : TextTypeInput
	{
		internal SearchInput() : base("search")
		{
		}
	}

	[ElementType(ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class SubmitInput : ButtonTypeInput
	{
		internal SubmitInput() : base("submit")
		{
		}
	}
	
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class TelInput : TextTypeInput
	{
		internal TelInput() : base("tel")
		{
		}
	}

	[ElementType(ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class TextInput : TextTypeInput
	{
		internal TextInput() : base("text")
		{
		}
	}

	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class TimeInput : DateTypeInput
	{
		internal TimeInput() : base("time")
		{
		}
	}

	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class UrlInput : TextTypeInput
	{
		internal UrlInput() : base("url")
		{
		}
	}

	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class WeekInput : DateTypeInput
	{
		internal WeekInput() : base("button")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Ins : ElementDefinition
	{
		internal Ins() : base("ins")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Kbd : ElementDefinition
	{
		internal Kbd() : base("kbd")
		{
		}
	}

	[ElementType(ElementType.Form)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class KeyGen : ElementDefinition
	{
		internal KeyGen() : base("kengen", Structure.Condensed)
		{
		}
	}

	[ElementType(ElementType.Form, ElementType.Frequent)]
	[Reference("http://www.w3schools.com/tags/tag_label.asp")]
	internal class Label : ElementDefinition
	{
		internal Label() : base("label")
		{
		}
	}

	[ElementType(ElementType.Form, ElementType.Frequent)]
	[Reference("http://www.w3schools.com/tags/tag_legend.asp")]
	internal class Legend : ElementDefinition
	{
		internal Legend() : base("legend")
		{
		}
	}

	[ElementType(ElementType.ContentGrouping)]
	[Reference("http://www.w3schools.com/tags/tag_li.asp")]
	internal class Li : ElementDefinition
	{
		internal Li() : base("li")
		{
		}
	}

	[ElementType(ElementType.DocumentMetadata)]
	[Reference("http://www.w3schools.com/tags/tag_link.asp")]
	internal class Link : ElementDefinition
	{
		internal Link() : base("link", Structure.Condensed)
		{
		}
	}

	[ElementType(ElementType.Section)]
	[Reference("http://www.w3schools.com/tags/tag_main.asp")]
	internal class Main : ElementDefinition
	{
		internal Main() : base("main")
		{
		}
	}

	[ElementType(ElementType.EmbeddedContent)]
	[Reference("http://www.w3schools.com/tags/tag_map.asp")]
	internal class Map : ElementDefinition
	{
		internal Map() : base("map")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Mark : ElementDefinition
	{
		internal Mark() : base("mark")
		{
		}
	}

	[ElementType(ElementType.DocumentMetadata)]
	[Reference("http://www.w3schools.com/tags/tag_meta.asp")]
	internal class Meta : ElementDefinition
	{
		internal Meta() : base("meta", Structure.Condensed)
		{
		}
	}

	[ElementType(ElementType.Form)]
	[Reference("http://www.w3schools.com/tags/tag_meter.asp")]
	internal class Meter : ElementDefinition
	{
		internal Meter() : base("meter")
		{
		}
	}

	[ElementType(ElementType.Section)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Nav : ElementDefinition
	{
		internal Nav() : base("nav")
		{
		}
	}

	[ElementType(ElementType.Scripting)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class NoScript : ElementDefinition
	{
		internal NoScript() : base("noscript")
		{
		}
	}

	[ElementType(ElementType.EmbeddedContent)]
	[Reference("http://www.w3schools.com/tags/tag_object.asp")]
	internal class Object : ElementDefinition
	{
		internal Object() : base("object")
		{
		}
	}

	[ElementType(ElementType.ContentGrouping, ElementType.Frequent)]
	[Reference("http://www.w3schools.com/tags/tag_ol.asp")]
	internal class Ol : ElementDefinition
	{
		internal Ol() : base("ol")
		{
		}
	}

	[ElementType(ElementType.Form)]
	[Reference("http://www.w3schools.com/tags/tag_option.asp")]
	internal class OptGroup : ElementDefinition
	{
		internal OptGroup() : base("optgroup")
		{
		}
	}

	[ElementType(ElementType.Form, ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Option : ElementDefinition
	{
		internal Option() : base("option")
		{
		}
	}

	[ElementType(ElementType.Form)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Output : ElementDefinition
	{
		internal Output() : base("output")
		{
		}
	}

	[ElementType(ElementType.ContentGrouping, ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class P : ElementDefinition
	{
		internal P() : base("p")
		{
		}
	}

	[ElementType(ElementType.EmbeddedContent)]
	[Reference("http://www.w3schools.com/tags/tag_param.asp")]
	internal class Param : ElementDefinition
	{
		internal Param() : base("param", Structure.Condensed)
		{
		}
	}

	[ElementType(ElementType.ContentGrouping)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Pre : ElementDefinition
	{
		internal Pre() : base("pre")
		{
		}
	}

	[ElementType(ElementType.Form)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Progress : ElementDefinition
	{
		internal Progress() : base("progress")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Q : ElementDefinition
	{
		internal Q() : base("q")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("http://www.w3schools.com/tags/tag_rp.asp")]
	internal class Rp : ElementDefinition
	{
		internal Rp() : base("rp")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("http://www.w3schools.com/tags/tag_rt.asp")]
	internal class Rt : ElementDefinition
	{
		internal Rt() : base("rt")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Ruby : ElementDefinition
	{
		internal Ruby() : base("ruby")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class S : ElementDefinition
	{
		internal S() : base("s")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Samp : ElementDefinition
	{
		internal Samp() : base("samp")
		{
		}
	}

	[ElementType(ElementType.Scripting)]
	[Reference("http://www.w3schools.com/tags/tag_script.asp")]
	internal class Script : ElementDefinition
	{
		internal Script() : base("script")
		{
		}
	}

	[ElementType(ElementType.Section)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Section : ElementDefinition
	{
		internal Section() : base("section")
		{
		}
	}

	[ElementType(ElementType.Form, ElementType.Frequent)]
	[Reference("http://www.w3schools.com/tags/tag_select.asp")]
	internal class Select : ElementDefinition
	{
		internal Select() : base("select")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Small : ElementDefinition
	{
		internal Small() : base("small")
		{
		}
	}

	[ElementType(ElementType.EmbeddedContent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Source : ElementDefinition
	{
		internal Source() : base("source", Structure.Condensed)
		{
		}
	}

	[ElementType(ElementType.SemanticText, ElementType.Frequent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Span : ElementDefinition
	{
		internal Span() : base("span")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Strong : ElementDefinition
	{
		internal Strong() : base("strong")
		{
		}
	}

	[ElementType(ElementType.DocumentMetadata)]
	[Reference("http://www.w3schools.com/tags/tag_style.asp")]
	internal class Style : ElementDefinition
	{
		internal Style() : base("style")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Sub : ElementDefinition
	{
		internal Sub() : base("sub")
		{
		}
	}

	[ElementType(ElementType.Interactive)]
	[Reference("http://www.w3schools.com/tags/tag_summary.asp")]
	internal class Summary : ElementDefinition
	{
		internal Summary() : base("summary")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Sup : ElementDefinition
	{
		internal Sup() : base("sup")
		{
		}
	}

	[ElementType(ElementType.Table, ElementType.Frequent)]
	[Reference("http://www.w3schools.com/tags/tag_table.asp")]
	internal class Table : ElementDefinition
	{
		internal Table() : base("table")
		{
		}
	}

	[ElementType(ElementType.Table, ElementType.Frequent)]
	[Reference("http://www.w3schools.com/tags/tag_tbody.asp")]
	internal class Tbody : ElementDefinition
	{
		internal Tbody() : base("tbody")
		{
		}
	}

	[ElementType(ElementType.Table, ElementType.Frequent)]
	[Reference("http://www.w3schools.com/tags/tag_td.asp")]
	internal class Td : ElementDefinition
	{
		internal Td() : base("td")
		{
		}
	}

	[RestrictToChild(typeof(TextNode))]
	[ElementType(ElementType.Form, ElementType.Frequent)]
	[Reference("http://www.w3schools.com/tags/tag_tr.asp")]
	internal class TextArea : ElementDefinition
	{
		internal TextArea() : base("textarea")
		{
		}
	}

	[ElementType(ElementType.Table)]
	[Reference("http://www.w3schools.com/tags/tag_tfoot.asp")]
	internal class Tfoot : ElementDefinition
	{
		internal Tfoot() : base("tfoot")
		{
		}
	}

	[ElementType(ElementType.Table, ElementType.Frequent)]
	[Reference("http://www.w3schools.com/tags/tag_th.asp")]
	internal class Th : ElementDefinition
	{
		internal Th() : base("th")
		{
		}
	}

	[ElementType(ElementType.Table, ElementType.Frequent)]
	[Reference("http://www.w3schools.com/tags/tag_thead.asp")]
	internal class Thead : ElementDefinition
	{
		internal Thead() : base("thead")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Time : ElementDefinition
	{
		internal Time() : base("time")
		{
		}
	}

	[ElementType(ElementType.DocumentMetadata)]
	[Reference("http://www.w3schools.com/tags/tag_title.asp")]
	internal class Title : ElementDefinition
	{
		internal Title() : base("title")
		{
		}
	}

	[ElementType(ElementType.Table, ElementType.Frequent)]
	[Reference("http://www.w3schools.com/tags/tag_tr.asp")]
	internal class Tr : ElementDefinition
	{
		internal Tr() : base("tr")
		{
		}
	}

	[ElementType(ElementType.EmbeddedContent)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Track : ElementDefinition
	{
		internal Track() : base("track", Structure.Condensed)
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class U : ElementDefinition
	{
		internal U() : base("u")
		{
		}
	}

	[ElementType(ElementType.ContentGrouping, ElementType.Frequent)]
	[Reference("http://www.w3schools.com/tags/tag_ul.asp")]
	internal class Ul : ElementDefinition
	{
		internal Ul() : base("ul")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Var : ElementDefinition
	{
		internal Var() : base("var")
		{
		}
	}

	[ElementType(ElementType.EmbeddedContent)]
	[Reference("http://www.w3schools.com/tags/tag_video.asp")]
	internal class Video : ElementDefinition
	{
		internal Video() : base("video")
		{
		}
	}

	[ElementType(ElementType.SemanticText)]
	[Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
	internal class Wbr : ElementDefinition
	{
		internal Wbr() : base("wbr", Structure.Condensed)
		{
		}
	}
}
