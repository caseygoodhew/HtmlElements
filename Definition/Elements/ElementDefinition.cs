
using Definition.Enums;

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
        public A() : base("a")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Abbr : ElementDefinition
    {
        public Abbr()
            : base("abbr")
        {
        }
    }

    [ElementType(ElementType.Section)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Address : ElementDefinition
    {
        public Address()
            : base("address")
        {
        }
    }

    [ElementType(ElementType.EmbeddedContent)]
    [Reference("http://www.w3schools.com/tags/tag_area.asp")]
    internal class Area : ElementDefinition
    {
        public Area()
            : base("area", Structure.Condensed)
        {
        }
    }

    [ElementType(ElementType.Section)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Article : ElementDefinition
    {
        public Article()
            : base("article")
        {
        }
    }

    [ElementType(ElementType.Section)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Aside : ElementDefinition
    {
        public Aside()
            : base("aside")
        {
        }
    }

    [ElementType(ElementType.EmbeddedContent)]
    [Reference("http://www.w3schools.com/tags/tag_audio.asp")]
    internal class Audio : ElementDefinition
    {
        public Audio()
            : base("audio")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class B : ElementDefinition
    {
        public B()
            : base("b")
        {
        }
    }

    [ElementType(ElementType.DocumentMetadata)]
    [Reference("http://www.w3schools.com/tags/tag_base.asp")]
    internal class Base : ElementDefinition
    {
        public Base()
            : base("base", Structure.Condensed)
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Bdo : ElementDefinition
    {
        public Bdo()
            : base("bdo")
        {
        }
    }

    [ElementType(ElementType.ContentGrouping)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class BlockQuote : ElementDefinition
    {
        public BlockQuote()
            : base("blockquote")
        {
        }
    }

    [ElementType(ElementType.Section)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Body : ElementDefinition
    {
        public Body()
            : base("body")
        {
        }
    }

    [ElementType(ElementType.ContentGrouping, ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Br : ElementDefinition
    {
        public Br()
            : base("br", Structure.Condensed)
        {
        }
    }

    [ElementType(ElementType.Form, ElementType.Frequent)]
    [Reference("http://www.w3schools.com/tags/tag_button.asp")]
    internal class Button : ElementDefinition
    {
        public Button()
            : base("button")
        {
        }
    }

    [RestrictChildrenTo(typeof(TextNode))]
    [ElementType(ElementType.EmbeddedContent, ElementType.Frequent)]
    [Reference("http://www.w3schools.com/tags/tag_canvas.asp")]
    internal class Canvas : ElementDefinition
    {
        public Canvas()
            : base("canvas")
        {
        }
    }

    [RestrictChildrenTo(typeof(TextNode))]
    [ElementType(ElementType.Table)]
    [Reference("http://www.w3schools.com/tags/tag_caption.asp")]
    internal class Caption : ElementDefinition
    {
        public Caption()
            : base("caption")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Cite : ElementDefinition
    {
        public Cite()
            : base("cite")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("http://www.w3schools.com/tags/tag_code.asp")]
    internal class Code : ElementDefinition
    {
        public Code()
            : base("code")
        {
        }
    }

    [ElementType(ElementType.Table)]
    [Reference("http://www.w3schools.com/tags/tag_col.asp")]
    internal class Col : ElementDefinition
    {
        public Col()
            : base("col", Structure.Condensed)
        {
        }
    }

    [ElementType(ElementType.Table)]
    [Reference("http://www.w3schools.com/tags/tag_colgroup.asp")]
    internal class ColGroup : ElementDefinition
    {
        public ColGroup()
            : base("colgroup")
        {
        }
    }

    [ElementType(ElementType.Form)]
    [Reference("http://www.w3schools.com/tags/tag_datalist.asp")]
    internal class DataList : ElementDefinition
    {
        public DataList()
            : base("datalist")
        {
        }
    }

    [ElementType(ElementType.ContentGrouping)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Dd : ElementDefinition
    {
        public Dd()
            : base("dd")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Del : ElementDefinition
    {
        public Del()
            : base("del")
        {
        }
    }

    [ElementType(ElementType.Interactive)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Details : ElementDefinition
    {
        public Details()
            : base("details")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Dfn : ElementDefinition
    {
        public Dfn()
            : base("dfn")
        {
        }
    }

    [ElementType(ElementType.ContentGrouping, ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Div : ElementDefinition
    {
        public Div()
            : base("div")
        {
        }
    }

    [ElementType(ElementType.ContentGrouping)]
    [Reference("http://www.w3schools.com/tags/tag_dl.asp")]
    internal class Dl : ElementDefinition
    {
        public Dl()
            : base("dl")
        {
        }
    }

    [ElementType(ElementType.ContentGrouping)]
    [Reference("http://www.w3schools.com/tags/tag_dt.asp")]
    internal class Dt : ElementDefinition
    {
        public Dt()
            : base("dt")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Em : ElementDefinition
    {
        public Em()
            : base("em")
        {
        }
    }

    [ElementType(ElementType.EmbeddedContent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Embed : ElementDefinition
    {
        public Embed()
            : base("embed", Structure.Condensed)
        {
        }
    }

    [ElementType(ElementType.Form, ElementType.Frequent)]
    [Reference("http://www.w3schools.com/tags/tag_fieldset.asp")]
    internal class FieldSet : ElementDefinition
    {
        public FieldSet()
            : base("fieldset")
        {
        }
    }

    [ElementType(ElementType.ContentGrouping)]
    [Reference("http://www.w3schools.com/tags/tag_figcaption.asp")]
    internal class FigCaption : ElementDefinition
    {
        public FigCaption()
            : base("figcaption")
        {
        }
    }

    [ElementType(ElementType.ContentGrouping)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Figure : ElementDefinition
    {
        public Figure()
            : base("figure")
        {
        }
    }

    [ElementType(ElementType.Table)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Footer : ElementDefinition
    {
        public Footer()
            : base("footer")
        {
        }
    }

    [ElementType(ElementType.Form, ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Form : ElementDefinition
    {
        public Form()
            : base("form")
        {
        }
    }

    [ElementType(ElementType.Section, ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class H1 : ElementDefinition
    {
        public H1()
            : base("h1")
        {
        }
    }

    [ElementType(ElementType.Section, ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class H2 : ElementDefinition
    {
        public H2()
            : base("h2")
        {
        }
    }

    [ElementType(ElementType.Section, ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class H3 : ElementDefinition
    {
        public H3()
            : base("h3")
        {
        }
    }

    [ElementType(ElementType.Section, ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class H4 : ElementDefinition
    {
        public H4()
            : base("h4")
        {
        }
    }

    [ElementType(ElementType.Section, ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class H5 : ElementDefinition
    {
        public H5()
            : base("h5")
        {
        }
    }

    [ElementType(ElementType.Section, ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class H6 : ElementDefinition
    {
        public H6()
            : base("h6")
        {
        }
    }

    [ElementType(ElementType.DocumentMetadata)]
    [Reference("http://www.w3schools.com/tags/tag_head.asp")]
    internal class Head : ElementDefinition
    {
        public Head()
            : base("head")
        {
        }
    }

    [ElementType(ElementType.Section)]
    [Reference("http://www.w3schools.com/tags/tag_header.asp")]
    internal class Header : ElementDefinition
    {
        public Header()
            : base("header")
        {
        }
    }

    [ElementType(ElementType.ContentGrouping, ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Hr : ElementDefinition
    {
        public Hr()
            : base("hr", Structure.Condensed)
        {
        }
    }

    [ElementType(ElementType.Root)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Html : ElementDefinition
    {
        public Html()
            : base("html")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class I : ElementDefinition
    {
        public I()
            : base("i")
        {
        }
    }

    [RestrictChildrenTo(typeof(TextNode))]
    [ElementType(ElementType.EmbeddedContent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class IFrame : ElementDefinition
    {
        public IFrame()
            : base("iframe")
        {
        }
    }

    [ElementType(ElementType.EmbeddedContent, ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Img : ElementDefinition
    {
        public Img()
            : base("img", Structure.Condensed)
        {
        }
    }

    [ElementType(ElementType.Form)]
    internal abstract class Input : ElementDefinition
    {
        public readonly string Type;

        public Input(string type)
            : base("input", Structure.Condensed)
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
        public ButtonInput()
            : base("button")
        {
        }
    }

    [ElementType(ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class CheckboxInput : VisibleInput
    {
        public CheckboxInput()
            : base("checkbox")
        {
        }
    }

    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class ColorInput : VisibleInput
    {
        public ColorInput()
            : base("color")
        {
        }
    }

    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class DateInput : DateTypeInput
    {
        public DateInput()
            : base("date")
        {
        }
    }

    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class DateTimeLocalInput : DateTypeInput
    {
        public DateTimeLocalInput()
            : base("datetime-local")
        {
        }
    }

    
    [ElementType(ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class EmailInput : TextTypeInput
    {
        public EmailInput()
            : base("email")
        {
        }
    }

    [ElementType(ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class FileInput : VisibleInput
    {
        public FileInput()
            : base("file")
        {
        }
    }

    [ElementType(ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class HiddenInput : Input
    {
        public HiddenInput()
            : base("hidden")
        {
        }
    }

    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class ImageInput : VisibleInput
    {
        public ImageInput()
            : base("image")
        {
        }
    }

    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class MonthInput : DateTypeInput
    {
        public MonthInput()
            : base("month")
        {
        }
    }

    [ElementType(ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class NumberInput : VisibleInput
    {
        public NumberInput()
            : base("number")
        {
        }
    }

    [ElementType(ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class PasswordInput : TextTypeInput
    {
        public PasswordInput()
            : base("password")
        {
        }
    }

    [ElementType(ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class RadioInput : VisibleInput
    {
        public RadioInput()
            : base("radio")
        {
        }
    }

    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class RangeInput : VisibleInput
    {
        public RangeInput()
            : base("range")
        {
        }
    }

    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class ResetInput : ButtonTypeInput
    {
        public ResetInput()
            : base("reset")
        {
        }
    }

    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class SearchInput : TextTypeInput
    {
        public SearchInput()
            : base("search")
        {
        }
    }

    [ElementType(ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class SubmitInput : ButtonTypeInput
    {
        public SubmitInput()
            : base("submit")
        {
        }
    }
    
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class TelInput : TextTypeInput
    {
        public TelInput()
            : base("tel")
        {
        }
    }

    [ElementType(ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class TextInput : TextTypeInput
    {
        public TextInput()
            : base("text")
        {
        }
    }

    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class TimeInput : DateTypeInput
    {
        public TimeInput()
            : base("time")
        {
        }
    }

    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class UrlInput : TextTypeInput
    {
        public UrlInput()
            : base("url")
        {
        }
    }

    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class WeekInput : DateTypeInput
    {
        public WeekInput()
            : base("button")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Ins : ElementDefinition
    {
        public Ins()
            : base("ins")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Kbd : ElementDefinition
    {
        public Kbd()
            : base("kbd")
        {
        }
    }

    [ElementType(ElementType.Form)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class KeyGen : ElementDefinition
    {
        public KeyGen()
            : base("kengen", Structure.Condensed)
        {
        }
    }

    [ElementType(ElementType.Form, ElementType.Frequent)]
    [Reference("http://www.w3schools.com/tags/tag_label.asp")]
    internal class Label : ElementDefinition
    {
        public Label()
            : base("label")
        {
        }
    }

    [ElementType(ElementType.Form, ElementType.Frequent)]
    [Reference("http://www.w3schools.com/tags/tag_legend.asp")]
    internal class Legend : ElementDefinition
    {
        public Legend()
            : base("legend")
        {
        }
    }

    [ElementType(ElementType.ContentGrouping)]
    [Reference("http://www.w3schools.com/tags/tag_li.asp")]
    internal class Li : ElementDefinition
    {
        public Li()
            : base("li")
        {
        }
    }

    [ElementType(ElementType.DocumentMetadata)]
    [Reference("http://www.w3schools.com/tags/tag_link.asp")]
    internal class Link : ElementDefinition
    {
        public Link()
            : base("link", Structure.Condensed)
        {
        }
    }

    [ElementType(ElementType.Section)]
    [Reference("http://www.w3schools.com/tags/tag_main.asp")]
    internal class Main : ElementDefinition
    {
        public Main()
            : base("main")
        {
        }
    }

    [ElementType(ElementType.EmbeddedContent)]
    [Reference("http://www.w3schools.com/tags/tag_map.asp")]
    internal class Map : ElementDefinition
    {
        public Map()
            : base("map")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Mark : ElementDefinition
    {
        public Mark()
            : base("mark")
        {
        }
    }

    [ElementType(ElementType.DocumentMetadata)]
    [Reference("http://www.w3schools.com/tags/tag_meta.asp")]
    internal class Meta : ElementDefinition
    {
        public Meta()
            : base("meta", Structure.Condensed)
        {
        }
    }

    [ElementType(ElementType.Form)]
    [Reference("http://www.w3schools.com/tags/tag_meter.asp")]
    internal class Meter : ElementDefinition
    {
        public Meter()
            : base("meter")
        {
        }
    }

    [ElementType(ElementType.Section)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Nav : ElementDefinition
    {
        public Nav()
            : base("nav")
        {
        }
    }

    [ElementType(ElementType.Scripting)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class NoScript : ElementDefinition
    {
        public NoScript()
            : base("noscript")
        {
        }
    }

    [ElementType(ElementType.EmbeddedContent)]
    [Reference("http://www.w3schools.com/tags/tag_object.asp")]
    internal class Object : ElementDefinition
    {
        public Object()
            : base("object")
        {
        }
    }

    [ElementType(ElementType.ContentGrouping, ElementType.Frequent)]
    [Reference("http://www.w3schools.com/tags/tag_ol.asp")]
    internal class Ol : ElementDefinition
    {
        public Ol()
            : base("ol")
        {
        }
    }

    [ElementType(ElementType.Form)]
    [Reference("http://www.w3schools.com/tags/tag_option.asp")]
    internal class OptGroup : ElementDefinition
    {
        public OptGroup()
            : base("optgroup")
        {
        }
    }

    [ElementType(ElementType.Form, ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Option : ElementDefinition
    {
        public Option()
            : base("option")
        {
        }
    }

    [ElementType(ElementType.Form)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Output : ElementDefinition
    {
        public Output()
            : base("output")
        {
        }
    }

    [ElementType(ElementType.ContentGrouping, ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class P : ElementDefinition
    {
        public P()
            : base("p")
        {
        }
    }

    [ElementType(ElementType.EmbeddedContent)]
    [Reference("http://www.w3schools.com/tags/tag_param.asp")]
    internal class Param : ElementDefinition
    {
        public Param()
            : base("param", Structure.Condensed)
        {
        }
    }

    [ElementType(ElementType.ContentGrouping)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Pre : ElementDefinition
    {
        public Pre()
            : base("pre")
        {
        }
    }

    [ElementType(ElementType.Form)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Progress : ElementDefinition
    {
        public Progress()
            : base("progress")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Q : ElementDefinition
    {
        public Q()
            : base("q")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("http://www.w3schools.com/tags/tag_rp.asp")]
    internal class Rp : ElementDefinition
    {
        public Rp()
            : base("rp")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("http://www.w3schools.com/tags/tag_rt.asp")]
    internal class Rt : ElementDefinition
    {
        public Rt()
            : base("rt")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Ruby : ElementDefinition
    {
        public Ruby()
            : base("ruby")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class S : ElementDefinition
    {
        public S()
            : base("s")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Samp : ElementDefinition
    {
        public Samp()
            : base("samp")
        {
        }
    }

    [ElementType(ElementType.Scripting)]
    [Reference("http://www.w3schools.com/tags/tag_script.asp")]
    internal class Script : ElementDefinition
    {
        public Script()
            : base("script")
        {
        }
    }

    [ElementType(ElementType.Section)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Section : ElementDefinition
    {
        public Section()
            : base("section")
        {
        }
    }

    [ElementType(ElementType.Form, ElementType.Frequent)]
    [Reference("http://www.w3schools.com/tags/tag_select.asp")]
    internal class Select : ElementDefinition
    {
        public Select()
            : base("select")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Small : ElementDefinition
    {
        public Small()
            : base("small")
        {
        }
    }

    [ElementType(ElementType.EmbeddedContent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Source : ElementDefinition
    {
        public Source()
            : base("source", Structure.Condensed)
        {
        }
    }

    [ElementType(ElementType.SemanticText, ElementType.Frequent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Span : ElementDefinition
    {
        public Span()
            : base("span")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Strong : ElementDefinition
    {
        public Strong()
            : base("strong")
        {
        }
    }

    [ElementType(ElementType.DocumentMetadata)]
    [Reference("http://www.w3schools.com/tags/tag_style.asp")]
    internal class Style : ElementDefinition
    {
        public Style()
            : base("style")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Sub : ElementDefinition
    {
        public Sub()
            : base("sub")
        {
        }
    }

    [ElementType(ElementType.Interactive)]
    [Reference("http://www.w3schools.com/tags/tag_summary.asp")]
    internal class Summary : ElementDefinition
    {
        public Summary()
            : base("summary")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Sup : ElementDefinition
    {
        public Sup()
            : base("sup")
        {
        }
    }

    [ElementType(ElementType.Table, ElementType.Frequent)]
    [Reference("http://www.w3schools.com/tags/tag_table.asp")]
    internal class Table : ElementDefinition
    {
        public Table()
            : base("table")
        {
        }
    }

    [ElementType(ElementType.Table, ElementType.Frequent)]
    [Reference("http://www.w3schools.com/tags/tag_tbody.asp")]
    internal class Tbody : ElementDefinition
    {
        public Tbody()
            : base("tbody")
        {
        }
    }

    [ElementType(ElementType.Table, ElementType.Frequent)]
    [Reference("http://www.w3schools.com/tags/tag_td.asp")]
    internal class Td : ElementDefinition
    {
        public Td()
            : base("td")
        {
        }
    }

    [RestrictChildrenTo(typeof(TextNode))]
    [ElementType(ElementType.Form, ElementType.Frequent)]
    [Reference("http://www.w3schools.com/tags/tag_tr.asp")]
    internal class TextArea : ElementDefinition
    {
        public TextArea()
            : base("textarea")
        {
        }
    }

    [ElementType(ElementType.Table)]
    [Reference("http://www.w3schools.com/tags/tag_tfoot.asp")]
    internal class Tfoot : ElementDefinition
    {
        public Tfoot()
            : base("tfoot")
        {
        }
    }

    [ElementType(ElementType.Table, ElementType.Frequent)]
    [Reference("http://www.w3schools.com/tags/tag_th.asp")]
    internal class Th : ElementDefinition
    {
        public Th()
            : base("th")
        {
        }
    }

    [ElementType(ElementType.Table, ElementType.Frequent)]
    [Reference("http://www.w3schools.com/tags/tag_thead.asp")]
    internal class Thead : ElementDefinition
    {
        public Thead()
            : base("thead")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Time : ElementDefinition
    {
        public Time()
            : base("time")
        {
        }
    }

    [ElementType(ElementType.DocumentMetadata)]
    [Reference("http://www.w3schools.com/tags/tag_title.asp")]
    internal class Title : ElementDefinition
    {
        public Title()
            : base("title")
        {
        }
    }

    [ElementType(ElementType.Table, ElementType.Frequent)]
    [Reference("http://www.w3schools.com/tags/tag_tr.asp")]
    internal class Tr : ElementDefinition
    {
        public Tr()
            : base("tr")
        {
        }
    }

    [ElementType(ElementType.EmbeddedContent)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Track : ElementDefinition
    {
        public Track()
            : base("track", Structure.Condensed)
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class U : ElementDefinition
    {
        public U()
            : base("u")
        {
        }
    }

    [ElementType(ElementType.ContentGrouping, ElementType.Frequent)]
    [Reference("http://www.w3schools.com/tags/tag_ul.asp")]
    internal class Ul : ElementDefinition
    {
        public Ul()
            : base("ul")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Var : ElementDefinition
    {
        public Var()
            : base("var")
        {
        }
    }

    [ElementType(ElementType.EmbeddedContent)]
    [Reference("http://www.w3schools.com/tags/tag_video.asp")]
    internal class Video : ElementDefinition
    {
        public Video()
            : base("video")
        {
        }
    }

    [ElementType(ElementType.SemanticText)]
    [Reference("XXXXXXXXXXXXXXXXXXXXXXXX")]
    internal class Wbr : ElementDefinition
    {
        public Wbr()
            : base("wbr", Structure.Condensed)
        {
        }
    }
}
