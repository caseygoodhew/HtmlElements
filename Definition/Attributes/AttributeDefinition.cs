using System;
using System.Drawing;

using Definition.Elements;
using Definition.Enums;
using Definition.Validation;
using Definition.Validation.Enum;
using Definition.Validation.NotImplemented;
using Definition.Validation.Number;
using Definition.Validation.Regex;
using Object = Definition.Elements.Object;

namespace Definition.Attributes
{
    internal enum AttributeValueType
    {
        Required,
        Optional,
        Forbidden
    }

    internal abstract class AttributeDefinition
    {
        public readonly string Name;
        
        public readonly AttributeValueType AttributeValueType;
        
        protected AttributeDefinition(string name) : this(name, AttributeValueType.Required)
        {
        }
        
        protected AttributeDefinition(string name, AttributeValueType attributeValueType)
        {
            Name = name;
            AttributeValueType = attributeValueType;
        }

        
    }

    [OneCharacterValidator]
    [AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_accesskey.asp")]
    internal class AccessKeyAttribute : AttributeDefinition
    {
        public AccessKeyAttribute() : base("accesskey")
        {
        }
    }

    [ClassValidator]
    [AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_class.asp")]
    internal class ClassAttribute : AttributeDefinition
    {
        public ClassAttribute() : base("class")
        {
        }
    }

    [EditableEnumValidator]
    [AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_contenteditable.asp")]
    internal class ContentEditableAttribute : AttributeDefinition
    {
        public ContentEditableAttribute() : base("contenteditable")
        {
        }
    }

    [AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_data.asp")]
    internal class DataAttribute : AttributeDefinition
    {
        private string _dataName ;

        public DataAttribute() : base("dataFIXTHIS")
        {
            
        }
        
        public DataAttribute(string dataName) : base("data")
        {
            _dataName = dataName;
        }
    }

    [TextDirectionEnumValidator]
    [AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_dir.asp")]
    internal class DirAttribute : AttributeDefinition
    {
        public DirAttribute() : base("dir")
        {
        }
    }

    [DraggableEnumValidator]
    [AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_draggable.asp")]
    internal class DraggableAttribute : AttributeDefinition
    {
        public DraggableAttribute() : base("draggable")
        {
        }
    }

    [AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_hidden.asp")]
    internal class HiddenAttribute : AttributeDefinition
    {
        public HiddenAttribute() : base("hidden", AttributeValueType.Forbidden)
        {
        }
    }

    [IdValidator]
    [AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_id.asp")]
    internal class IdAttribute : AttributeDefinition
    {
        public IdAttribute() : base("id")
        {
        }
    }

    [LanguageCodeValidator]
    [AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_lang.asp")]
    internal class LangAttribute : AttributeDefinition
    {
        public LangAttribute() : base("lang")
        {
        }
    }

    [EditableEnumValidator]
    [AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_spellcheck.asp")]
    internal class SpellcheckAttribute: AttributeDefinition
    {
        public SpellcheckAttribute() : base("spellcheck")
        {
        }
    }

    [AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_style.asp")]
    internal class StyleAttribute: AttributeDefinition
    {
        public StyleAttribute() : base("style")
        {
        }
    }

    [MimimumOneIntegerValidator]
    [AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_tabindex.asp")]
    internal class TabIndexAttribute : AttributeDefinition
    {
        public TabIndexAttribute() : base("tabindex")
        {
        }
    }

    [AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_title.asp")]
    internal class TitleAttribute : AttributeDefinition
    {
        public TitleAttribute() : base("title")
        {
        }
    }

    [AppliesToElement(typeof(A), "http://www.w3schools.com/tags/att_a_download.asp")]
    [AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_download.asp")]
    internal class DownloadAttribute : AttributeDefinition
    {
        public DownloadAttribute() : base("download", AttributeValueType.Optional)
        {
        }
    }

    [UrlValidator]
    [AppliesToElement(typeof(A), "http://www.w3schools.com/tags/att_a_href.asp")]
    [AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_href.asp")]
    [AppliesToElement(typeof(Base), "http://www.w3schools.com/tags/att_base_href.asp")]
    [AppliesToElement(typeof(Link), "http://www.w3schools.com/tags/att_link_href.asp")]
    internal class HrefAttribute : AttributeDefinition
    {
        public HrefAttribute() : base("href")
        {
        }
    }

    [LanguageCodeValidator]
    [AppliesToElement(typeof(A), "http://www.w3schools.com/tags/att_a_hreflang.asp")]
    [AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_hreflang.asp")]
    [AppliesToElement(typeof(Link), "http://www.w3schools.com/tags/att_link_hreflang.asp")]
    internal class HrefLangAttribute : AttributeDefinition
    {
        public HrefLangAttribute() : base("hreflang")
        {
        }
    }

    [MediaExpressionValidator]
    [AppliesToElement(typeof(A), "http://www.w3schools.com/tags/att_a_media.asp")]
    [AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_media.asp")]
    [AppliesToElement(typeof(Link), "http://www.w3schools.com/tags/att_link_media.asp")]
    [AppliesToElement(typeof(Style), "http://www.w3schools.com/tags/att_style_media.asp")]
    internal class MediaAttribute : AttributeDefinition
    {
        public MediaAttribute() : base("media")
        {
        }
    }

    [LinkedRelEnumValidator]
    [AppliesToElement(typeof(A), "http://www.w3schools.com/tags/att_a_rel.asp")]
    [AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_rel.asp")]
    internal class LinkedRelAttribute : AttributeDefinition
    {
        public LinkedRelAttribute() : base("rel")
        {
        }
    }

    [ResourceRelEnumValidator]
    [AppliesToElement(typeof(Link), "http://www.w3schools.com/tags/att_link_rel.asp")]
    internal class ResourceRelAttribute : AttributeDefinition
    {
        public ResourceRelAttribute() : base("rel")
        {
        }
    }

    [TargetValidator]
    [AppliesToElement(typeof(A), "http://www.w3schools.com/tags/att_a_target.asp")]
    [AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_target.asp")]
    [AppliesToElement(typeof(Base), "http://www.w3schools.com/tags/att_base_target.asp")]
    [AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_target.asp")]
    internal class TargetAttribute : AttributeDefinition
    {
        public TargetAttribute() : base("target")
        {
        }
    }

    [MediaTypeValidator]
    [AppliesToElement(typeof(A), "http://www.w3schools.com/tags/att_a_type.asp")]
    [AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_type.asp")]
    [AppliesToElement(typeof(Embed), "http://www.w3schools.com/tags/att_embed_type.asp")]
    [AppliesToElement(typeof(Link), "http://www.w3schools.com/tags/att_link_type.asp")]
    [AppliesToElement(typeof(Object), "http://www.w3schools.com/tags/att_object_type.asp")]
    [AppliesToElement(typeof(Script), "http://www.w3schools.com/tags/att_script_type.asp")]
    [AppliesToElement(typeof(Source), "http://www.w3schools.com/tags/att_source_type.asp")]
    internal class MediaTypeAttribute : AttributeDefinition
    {
        public MediaTypeAttribute()
            : base("type")
        {
        }
    }

    [TextCssMediaTypeValidator]
    [AppliesToElement(typeof(Style), "http://www.w3schools.com/tags/att_style_type.asp")]
    internal class TextCssMediaTypeAttribute : AttributeDefinition
    {
        public TextCssMediaTypeAttribute()
            : base("type")
        {
        }
    }

    [OrderedListTypeEnumValidator]
    [AppliesToElement(typeof(Ol), "http://www.w3schools.com/tags/att_ol_type.asp")]
    internal class OrderedListTypeAttribute : AttributeDefinition
    {
        public OrderedListTypeAttribute() : base("type")
        {
        }
    }

    [AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/tag_area.asp")]
    [AppliesToElement(typeof(Img), "http://www.w3schools.com/tags/att_img_alt.asp")]
    [AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_alt.asp")]
    internal class AltAttribute : AttributeDefinition
    {
        public AltAttribute() : base("alt")
        {
        }
    }

    internal abstract class CoordsAttribute : AttributeDefinition
    {
        protected CoordsAttribute()
            : base("coords")
        {
        }
    }

    [CoordsValidator(typeof(Tuple<int, int, int>), typeof(ShapeAttribute), Shape.Circle)]
    [AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_coords.asp")]
    internal class ThreeIntCircleCoordsAttribute : CoordsAttribute
    {
    }

    [CoordsValidator(typeof(Tuple<Point, int>), typeof(ShapeAttribute), Shape.Circle)]
    internal class PointIntCircleCoordsAttribute : CoordsAttribute
    {
    }

    [CoordsValidator(typeof(Tuple<int, int, int, int>), typeof(ShapeAttribute), Shape.Rectangle)]
    [AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_coords.asp")]
    internal class FourIntRectangleCoordsAttribute : CoordsAttribute
    {
    }

    [CoordsValidator(typeof(Tuple<Point, Point>), typeof(ShapeAttribute), Shape.Rectangle)]
    [AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_coords.asp")]
    internal class TwoPointRectangleCoordsAttribute : CoordsAttribute
    {
    }

    [CoordsValidator(typeof(Point[]), typeof(ShapeAttribute), Shape.Polygon)]
    [AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_coords.asp")]
    internal class PointArrayPolygonCoordsAttribute : CoordsAttribute
    {
    }

    [ShapeEnumValidator(typeof(CoordsAttribute))]
    [AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_shape.asp")]
    internal class ShapeAttribute : AttributeDefinition
    {
        public ShapeAttribute() : base("shape")
        {
        }
    }

    [AppliesToElement(typeof(Audio), "http://www.w3schools.com/tags/att_audio_autoplay.asp")]
    [AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_autoplay.asp")]
    internal class AutoPlayAttribute : AttributeDefinition
    {
        public AutoPlayAttribute() : base("autoplay", AttributeValueType.Forbidden)
        {
        }
    }

    [AppliesToElement(typeof(Audio), "http://www.w3schools.com/tags/att_audio_controls.asp")]
    [AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_controls.asp")]
    internal class ControlsAttribute : AttributeDefinition
    {
        public ControlsAttribute() : base("controls", AttributeValueType.Forbidden)
        {
        }
    }

    [AppliesToElement(typeof(Audio), "http://www.w3schools.com/tags/att_audio_loop.asp")]
    [AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_loop.asp")]
    internal class LoopAttribute : AttributeDefinition
    {
        public LoopAttribute() : base("loop", AttributeValueType.Forbidden)
        {
        }
    }

    [AppliesToElement(typeof(Audio), "http://www.w3schools.com/tags/att_audio_muted.asp")]
    [AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_muted.asp")]
    internal class MutedAttribute : AttributeDefinition
    {
        public MutedAttribute() : base("muted", AttributeValueType.Forbidden)
        {
        }
    }

    [PreloadEnumValidator]
    [AppliesToElement(typeof(Audio), "http://www.w3schools.com/tags/att_audio_preload.asp")]
    [AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_preload.asp")]
    internal class PreloadAttribute : AttributeDefinition
    {
        public PreloadAttribute() : base("preload")
        {
        }
    }

    [UrlValidator]
    [AppliesToElement(typeof(Audio), "http://www.w3schools.com/tags/att_audio_src.asp")]
    [AppliesToElement(typeof(Embed), "http://www.w3schools.com/tags/att_embed_src.asp")]
    [AppliesToElement(typeof(IFrame), "http://www.w3schools.com/tags/att_iframe_src.asp")]
    [AppliesToElement(typeof(Img), "http://www.w3schools.com/tags/att_img_src.asp")]
    [AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_src.asp")]
    [AppliesToElement(typeof(Script), "http://www.w3schools.com/tags/att_script_src.asp")]
    [AppliesToElement(typeof(Source), "http://www.w3schools.com/tags/att_source_src.asp")]
    [AppliesToElement(typeof(Track), "http://www.w3schools.com/tags/att_track_src.asp")]
    [AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_src.asp")]
    internal class SrcAttribute : AttributeDefinition
    {
        public SrcAttribute() : base("src")
        {
        }
    }

    [UrlValidator]
    [AppliesToElement(typeof(BlockQuote), "http://www.w3schools.com/tags/att_blockquote_cite.asp")]
    [AppliesToElement(typeof(Del), "http://www.w3schools.com/tags/att_del_cite.asp")]
    [AppliesToElement(typeof(Ins), "http://www.w3schools.com/tags/att_ins_cite.asp")]
    [AppliesToElement(typeof(Q), "http://www.w3schools.com/tags/att_q_cite.asp")]
    internal class CiteAttribute : AttributeDefinition
    {
        public CiteAttribute() : base("cite")
        {
        }
    }

    [DateTimeValidator]
    [AppliesToElement(typeof(Del), "http://www.w3schools.com/tags/att_del_datetime.asp")]
    [AppliesToElement(typeof(Ins), "http://www.w3schools.com/tags/att_ins_datetime.asp")]
    [AppliesToElement(typeof(Time), "http://www.w3schools.com/tags/att_time_datetime.asp")]
    internal class DateTimeAttribute : AttributeDefinition
    {
        public DateTimeAttribute() : base("datetime")
        {
        }
    }

    [AppliesToElement(typeof(Details), "http://www.w3schools.com/tags/att_details_open.asp")]
    internal class OpenAttribute : AttributeDefinition
    {
        public OpenAttribute() : base("open", AttributeValueType.Forbidden)
        {
        }
    }

    [MimimumZeroIntegerValidator]
    [AppliesToElement(typeof(Embed), "http://www.w3schools.com/tags/att_embed_height.asp")]
    [AppliesToElement(typeof(IFrame), "http://www.w3schools.com/tags/att_iframe_height.asp")]
    [AppliesToElement(typeof(Img), "http://www.w3schools.com/tags/att_img_height.asp")]
    [AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_height.asp")]
    [AppliesToElement(typeof(Object), "http://www.w3schools.com/tags/att_object_height.asp")]
    [AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_height.asp")]
    internal class HeightAttribute : AttributeDefinition
    {
        public HeightAttribute() : base("height")
        {
        }
    }

    [MimimumZeroIntegerValidator]
    [AppliesToElement(typeof(Embed), "http://www.w3schools.com/tags/att_embed_width.asp")]
    [AppliesToElement(typeof(IFrame), "http://www.w3schools.com/tags/att_iframe_width.asp")]
    [AppliesToElement(typeof(Img), "http://www.w3schools.com/tags/att_img_width.asp")]
    [AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_width.asp")]
    [AppliesToElement(typeof(Object), "http://www.w3schools.com/tags/att_object_width.asp")]
    [AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_width.asp")]
    internal class WidthAttribute : AttributeDefinition
    {
        public WidthAttribute() : base("width")
        {
        }
    }

    [AppliesToElement(typeof(FieldSet), "http://www.w3schools.com/tags/att_fieldset_disabled.asp")]
    [AppliesToElement(typeof(VisibleInput), "http://www.w3schools.com/tags/att_input_disabled.asp")]
    [AppliesToElement(typeof(KeyGen), "http://www.w3schools.com/tags/att_keygen_disabled.asp")]
    [AppliesToElement(typeof(OptGroup), "http://www.w3schools.com/tags/att_optgroup_disabled.asp")]
    [AppliesToElement(typeof(Option), "http://www.w3schools.com/tags/att_option_disabled.asp")]
    [AppliesToElement(typeof(Select), "http://www.w3schools.com/tags/att_select_disabled.asp")]
    [AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_disabled.asp")]
    internal class DisabledAttribute : AttributeDefinition
    {
        public DisabledAttribute() : base("disabled", AttributeValueType.Forbidden)
        {
        }
    }

    [IdValidator]
    [AppliesToElement(typeof(FieldSet), "http://www.w3schools.com/tags/att_fieldset_form.asp")]
    [AppliesToElement(typeof(Input), "http://www.w3schools.com/tags/att_input_form.asp")]
    [AppliesToElement(typeof(KeyGen), "http://www.w3schools.com/tags/att_keygen_form.asp")]
    [AppliesToElement(typeof(Label), "http://www.w3schools.com/tags/att_label_form.asp")]
    [AppliesToElement(typeof(Select), "http://www.w3schools.com/tags/att_select_form.asp")]
    [AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_form.asp")]
    internal class FormAttribute : AttributeDefinition
    {
        public FormAttribute() : base("form")
        {
        }
    }

    [NameValidator]
    [AppliesToElement(typeof(FieldSet), "http://www.w3schools.com/tags/att_fieldset_name.asp")]
    [AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_name.asp")]
    [AppliesToElement(typeof(IFrame), "http://www.w3schools.com/tags/att_iframe_name.asp")]
    [AppliesToElement(typeof(Input), "http://www.w3schools.com/tags/att_input_name.asp")]
    [AppliesToElement(typeof(KeyGen), "http://www.w3schools.com/tags/att_keygen_name.asp")]
    [AppliesToElement(typeof(Map), "http://www.w3schools.com/tags/att_map_name.asp")]
    [AppliesToElement(typeof(Meta), "http://www.w3schools.com/tags/att_meta_name.asp")]
    [AppliesToElement(typeof(Object), "http://www.w3schools.com/tags/att_object_name.asp")]
    [AppliesToElement(typeof(Output), "http://www.w3schools.com/tags/att_output_name.asp")]
    [AppliesToElement(typeof(Param), "http://www.w3schools.com/tags/att_param_name.asp")]
    [AppliesToElement(typeof(Select), "http://www.w3schools.com/tags/att_select_name.asp")]
    [AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_name.asp")]
    internal class NameAttribute : AttributeDefinition
    {
        public NameAttribute() : base("name")
        {
        }
    }

    [CharSetValidator]
    [AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_accept_charset.asp")]
    [AppliesToElement(typeof(Script), "http://www.w3schools.com/tags/att_script_charset.asp")]
    internal class AcceptCharsetAttribute : AttributeDefinition
    {
        public AcceptCharsetAttribute()
            : base("accept-charset")
        {
        }
    }

    [UrlValidator]
    [AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_action.asp")]
    internal class ActionAttribute : AttributeDefinition
    {
        public ActionAttribute() : base("action")
        {
        }
    }

    [OnOffEnumValidator]
    [AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_autocomplete.asp")]
    [AppliesToElement(typeof(TextTypeInput), "http://www.w3schools.com/tags/att_input_autocomplete.asp")]
    [AppliesToElement(typeof(DateTypeInput), "http://www.w3schools.com/tags/att_input_autocomplete.asp")]
    [AppliesToElement(typeof(RangeInput), "http://www.w3schools.com/tags/att_input_autocomplete.asp")]
    [AppliesToElement(typeof(ColorInput), "http://www.w3schools.com/tags/att_input_autocomplete.asp")]
    internal class AutoCompleteAttribute : AttributeDefinition
    {
        public AutoCompleteAttribute() : base("autocomplete")
        {
        }
    }

    [EncodeTypeEnumValidator]
    [AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_enctype.asp")]
    internal class EncTypeAttribute : AttributeDefinition
    {
        public EncTypeAttribute() : base("enctype")
        {
        }
    }

    [GetPostEnumValidator]
    [AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_method.asp")]
    internal class MethodAttribute : AttributeDefinition
    {
        public MethodAttribute() : base("method")
        {
        }
    }

    [AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_novalidate.asp")]
    internal class NoValidateAttribute : AttributeDefinition
    {
        public NoValidateAttribute() : base("novalidate", AttributeValueType.Forbidden)
        {
        }
    }

    [UrlValidator]
    [AppliesToElement(typeof(Html), "http://www.w3schools.com/tags/att_html_manifest.asp")]
    internal class ManifestAttribute : AttributeDefinition
    {
        public ManifestAttribute() : base("manifest")
        {
        }
    }

    [XmlNsEnumValidator]
    [AppliesToElement(typeof(Html), "http://www.w3schools.com/tags/att_html_xmlns.asp")]
    internal class XmlNsAttribute : AttributeDefinition
    {
        public XmlNsAttribute() : base("xmlns")
        {
        }
    }

    [SandboxEnumValidator]
    [AppliesToElement(typeof(IFrame), "http://www.w3schools.com/tags/att_iframe_sandbox.asp")]
    internal class SandboxAttribute : AttributeDefinition
    {
        public SandboxAttribute() : base("sandbox")
        {
        }
    }

    [HtmlValidator]
    [AppliesToElement(typeof(IFrame), "http://www.w3schools.com/tags/att_iframe_srcdoc.asp")]
    internal class SrcDocAttribute : AttributeDefinition
    {
        public SrcDocAttribute() : base("srcdoc")
        {
        }
    }

    [HashIdValidator]
    [AppliesToElement(typeof(Img), "http://www.w3schools.com/tags/att_img_usemap.asp")]
    [AppliesToElement(typeof(Object), "http://www.w3schools.com/tags/att_object_usemap.asp")]
    internal class UseMapAttribute : AttributeDefinition
    {
        public UseMapAttribute() : base("usemap")
        {
        }
    }

    [AppliesToElement(typeof(Img), "http://www.w3schools.com/tags/att_img_ismap.asp")]
    internal class IsMapAttribute : AttributeDefinition
    {
        public IsMapAttribute() : base("ismap", AttributeValueType.Forbidden)
        {
        }
    }

    internal abstract class AcceptAttribute : AttributeDefinition
    {
        public AcceptAttribute()
            : base("accept")
        {
        }
    }

    [AcceptTypesEnumValidator]
    [AppliesToElement(typeof(FileInput), "http://www.w3schools.com/tags/att_input_accept.asp")]
    internal class StandardAcceptAttribute : AcceptAttribute
    {
    }

    [MediaTypeValidator]
    [AppliesToElement(typeof(FileInput), "http://www.w3schools.com/tags/att_input_accept.asp")]
    internal class MediatypeAcceptAttribute : AcceptAttribute
    {
    }

    [AppliesToElement(typeof(VisibleInput), "http://www.w3schools.com/tags/att_input_autofocus.asp")]
    [AppliesToElement(typeof(KeyGen), "http://www.w3schools.com/tags/att_keygen_autofocus.asp")]
    [AppliesToElement(typeof(Select), "http://www.w3schools.com/tags/att_select_autofocus.asp")]
    [AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_autofocus.asp")]
    internal class AutoFocusAttribute : AttributeDefinition
    {
        public AutoFocusAttribute() : base("autofocus", AttributeValueType.Forbidden)
        {
        }
    }

    [AppliesToElement(typeof(CheckboxInput), "http://www.w3schools.com/tags/att_input_checked.asp")]
    [AppliesToElement(typeof(RadioInput), "http://www.w3schools.com/tags/att_input_checked.asp")]
    internal class CheckedAttribute : AttributeDefinition
    {
        public CheckedAttribute() : base("checked", AttributeValueType.Forbidden)
        {
        }
    }

    [UrlValidator]
    [AppliesToElement(typeof(SubmitInput), "http://www.w3schools.com/tags/att_input_formaction.asp")]
    [AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_formaction.asp")]
    internal class FormActionAttribute : AttributeDefinition
    {
        public FormActionAttribute() : base("formaction")
        {
        }
    }

    [EncodeTypeEnumValidator]
    [AppliesToElement(typeof(SubmitInput), "http://www.w3schools.com/tags/att_input_formenctype.asp")]
    [AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_formenctype.asp")]
    internal class FormEncTypeAttribute : AttributeDefinition
    {
        public FormEncTypeAttribute() : base("formenctype")
        {
        }
    }

    [GetPostEnumValidator]
    [AppliesToElement(typeof(SubmitInput), "http://www.w3schools.com/tags/att_input_formmethod.asp")]
    [AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_formmethod.asp")]
    internal class FormMethodAttribute : AttributeDefinition
    {
        public FormMethodAttribute() : base("formmethod")
        {
        }
    }

    [AppliesToElement(typeof(SubmitInput), "http://www.w3schools.com/tags/att_input_formnovalidate.asp")]
    internal class FormNoValidateAttribute : AttributeDefinition
    {
        public FormNoValidateAttribute() : base("formnovalidate", AttributeValueType.Forbidden)
        {
        }
    }

    [TargetValidator]
    [AppliesToElement(typeof(SubmitInput), "http://www.w3schools.com/tags/att_input_formtarget.asp")]
    [AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_formtarget.asp")]
    internal class FormTargetAttribute : AttributeDefinition
    {
        public FormTargetAttribute() : base("formtarget")
        {
        }
    }

    [IdValidator]
    [AppliesToElement(typeof(VisibleInput), "http://www.w3schools.com/tags/att_input_list.asp")]
    internal class ListAttribute : AttributeDefinition
    {
        public ListAttribute() : base("list")
        {
        }
    }

    internal abstract class MaxNumberAttribute : AttributeDefinition
    {
        protected MaxNumberAttribute()
            : base("max")
        {
        }
    }

    [DecimalValidator]
    [AppliesToElement(typeof(NumberInput), "http://www.w3schools.com/tags/att_input_max.asp")]
    [AppliesToElement(typeof(RangeInput), "http://www.w3schools.com/tags/att_input_max.asp")]
    [AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_max.asp")]
    [AppliesToElement(typeof(Progress), "http://www.w3schools.com/tags/att_progress_max.asp")]
    internal class MaxDecimalAttribute : MaxNumberAttribute
    {
    }

    [IntegerValidator]
    [AppliesToElement(typeof(NumberInput), "http://www.w3schools.com/tags/att_input_max.asp")]
    [AppliesToElement(typeof(RangeInput), "http://www.w3schools.com/tags/att_input_max.asp")]
    [AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_max.asp")]
    [AppliesToElement(typeof(Progress), "http://www.w3schools.com/tags/att_progress_max.asp")]
    internal class MaxIntegerAttribute : MaxNumberAttribute
    {
    }

    [DateTimeValidator]
    [AppliesToElement(typeof(DateTypeInput), "http://www.w3schools.com/tags/att_input_max.asp")]
    internal class MaxDateAttribute : AttributeDefinition
    {
        public MaxDateAttribute() : base("max")
        {
        }
    }

    internal abstract class MinNumberAttribute : AttributeDefinition
    {
        protected MinNumberAttribute()
            : base("min")
        {
        }
    }

    [DecimalValidator]
    [AppliesToElement(typeof(NumberInput), "http://www.w3schools.com/tags/att_input_min.asp")]
    [AppliesToElement(typeof(RangeInput), "http://www.w3schools.com/tags/att_input_min.asp")]
    [AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_min.asp")]
    internal class MinDecimalAttribute : MinNumberAttribute
    {
    }

    [IntegerValidator]
    [AppliesToElement(typeof(NumberInput), "http://www.w3schools.com/tags/att_input_min.asp")]
    [AppliesToElement(typeof(RangeInput), "http://www.w3schools.com/tags/att_input_min.asp")]
    [AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_min.asp")]
    internal class MinIntegerAttribute : MinNumberAttribute
    {
    }

    [DateTimeValidator]
    [AppliesToElement(typeof(DateTypeInput), "http://www.w3schools.com/tags/att_input_min.asp")]
    internal class MinDateAttribute : AttributeDefinition
    {
        public MinDateAttribute() : base("min")
        {
        }
    }

    internal abstract class MaxLengthAttribute : AttributeDefinition
    {
        protected MaxLengthAttribute()
            : base("maxlength")
        {
        }
    }

    [DecimalValidator]
    [AppliesToElement(typeof(VisibleInput), "http://www.w3schools.com/tags/att_input_maxlength.asp")]
    [AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_maxlength.asp")]
    internal class MaxDecimalLengthAttribute : MaxLengthAttribute
    {
    }

    [IntegerValidator]
    [AppliesToElement(typeof(VisibleInput), "http://www.w3schools.com/tags/att_input_maxlength.asp")]
    [AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_maxlength.asp")]
    internal class MaxIntegerLengthAttribute : MaxLengthAttribute
    {
    }

    [AppliesToElement(typeof(EmailInput), "http://www.w3schools.com/tags/att_input_multiple.asp")]
    [AppliesToElement(typeof(FileInput), "http://www.w3schools.com/tags/att_input_multiple.asp")]
    [AppliesToElement(typeof(Select), "http://www.w3schools.com/tags/att_select_multiple.asp")]
    internal class MultipleAttribute : AttributeDefinition
    {
        public MultipleAttribute() : base("multiple", AttributeValueType.Forbidden)
        {
        }
    }

    [PatternValidator]
    [AppliesToElement(typeof(TextTypeInput), "http://www.w3schools.com/tags/att_input_pattern.asp")]
    internal class PatternAttribute : AttributeDefinition
    {
        public PatternAttribute() : base("pattern")
        {
        }
    }

    [AppliesToElement(typeof(TextTypeInput), "http://www.w3schools.com/tags/att_input_placeholder.asp")]
    [AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_placeholder.asp")]
    internal class PlaceHolderAttribute : AttributeDefinition
    {
        public PlaceHolderAttribute() : base("placeholder")
        {
        }
    }

    [AppliesToElement(typeof(VisibleInput), "http://www.w3schools.com/tags/att_input_readonly.asp")]
    [AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_readonly.asp")]
    internal class ReadonlyAttribute : AttributeDefinition
    {
        public ReadonlyAttribute() : base("readonly", AttributeValueType.Forbidden)
        {
        }
    }

    [AppliesToElement(typeof(TextTypeInput), "http://www.w3schools.com/tags/att_input_required.asp")]
    [AppliesToElement(typeof(DateTypeInput), "http://www.w3schools.com/tags/att_input_required.asp")]
    [AppliesToElement(typeof(NumberInput), "http://www.w3schools.com/tags/att_input_required.asp")]
    [AppliesToElement(typeof(CheckboxInput), "http://www.w3schools.com/tags/att_input_required.asp")]
    [AppliesToElement(typeof(RadioInput), "http://www.w3schools.com/tags/att_input_required.asp")]
    [AppliesToElement(typeof(FileInput), "http://www.w3schools.com/tags/att_input_required.asp")]
    [AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_required.asp")]
    internal class RequiredAttribute : AttributeDefinition
    {
        public RequiredAttribute() : base("required", AttributeValueType.Forbidden)
        {
        }
    }

    [MimimumOneIntegerValidator]
    [AppliesToElement(typeof(TextTypeInput), "http://www.w3schools.com/tags/att_input_size.asp")]
    [AppliesToElement(typeof(Select), "http://www.w3schools.com/tags/att_select_size.asp")]
    internal class SizeAttribute : AttributeDefinition
    {
        public SizeAttribute() : base("size")
        {
        }
    }

    [MimimumOneIntegerValidator]
    [AppliesToElement(typeof(NumberInput), "http://www.w3schools.com/tags/att_input_step.asp")]
    [AppliesToElement(typeof(RangeInput), "http://www.w3schools.com/tags/att_input_step.asp")]
    [AppliesToElement(typeof(DateTypeInput), "http://www.w3schools.com/tags/att_input_step.asp")]
    internal class StepAttribute : AttributeDefinition
    {
        public StepAttribute() : base("step")
        {
        }
    }

    [AppliesToElement(typeof(TextTypeInput), "http://www.w3schools.com/tags/att_input_value.asp")]
    [AppliesToElement(typeof(HiddenInput), "http://www.w3schools.com/tags/att_input_value.asp")]
    [AppliesToElement(typeof(CheckboxInput), "http://www.w3schools.com/tags/att_input_value.asp")]
    [AppliesToElement(typeof(RadioInput), "http://www.w3schools.com/tags/att_input_value.asp")]
    [AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_value.asp")]
    [AppliesToElement(typeof(ButtonTypeInput), "http://www.w3schools.com/tags/att_input_value.asp")]
    [AppliesToElement(typeof(Option), "http://www.w3schools.com/tags/att_option_value.asp")]
    [AppliesToElement(typeof(Param), "http://www.w3schools.com/tags/att_param_value.asp")]
    internal class TextValueAttribute : AttributeDefinition
    {
        public TextValueAttribute() : base("value")
        {
        }
    }

    [DateTimeValidator]
    [AppliesToElement(typeof(DateTypeInput), "http://www.w3schools.com/tags/att_input_value.asp")]
    internal class DateValueAttribute : AttributeDefinition
    {
        public DateValueAttribute() : base("value")
        {
        }
    }

    [ColorValidator]
    [AppliesToElement(typeof(ColorInput), "http://www.w3schools.com/tags/att_input_value.asp")]
    internal class ColorValueAttribute : AttributeDefinition
    {
        public ColorValueAttribute() : base("value")
        {
        }
    }

    internal abstract class NumberValueAttribute : AttributeDefinition
    {
        protected NumberValueAttribute()
            : base("value")
        {
        }
    }

    [DecimalValidator]
    [AppliesToElement(typeof(NumberInput), "http://www.w3schools.com/tags/att_input_value.asp")]
    [AppliesToElement(typeof(RangeInput), "http://www.w3schools.com/tags/att_input_value.asp")]
    [AppliesToElement(typeof(Li), "http://www.w3schools.com/tags/att_li_value.asp")]
    [AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_value.asp")]
    [AppliesToElement(typeof(Progress), "http://www.w3schools.com/tags/att_progress_value.asp")]
    internal class DecimalValueAttribute : NumberValueAttribute
    {
    }

    [IntegerValidator]
    [AppliesToElement(typeof(NumberInput), "http://www.w3schools.com/tags/att_input_value.asp")]
    [AppliesToElement(typeof(RangeInput), "http://www.w3schools.com/tags/att_input_value.asp")]
    [AppliesToElement(typeof(Li), "http://www.w3schools.com/tags/att_li_value.asp")]
    [AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_value.asp")]
    [AppliesToElement(typeof(Progress), "http://www.w3schools.com/tags/att_progress_value.asp")]
    internal class IntegerValueAttribute : NumberValueAttribute
    {
    }

    [KeyTypeEnumValidator]
    [AppliesToElement(typeof(KeyGen), "http://www.w3schools.com/tags/att_keygen_keytype.asp")]
    internal class KeyTypeAttribute : AttributeDefinition
    {
        public KeyTypeAttribute() : base("keytype")
        {
        }
    }

    [IdValidator]
    [AppliesToElement(typeof(Label), "http://www.w3schools.com/tags/att_label_for.asp")]
    internal class ForOneAttribute : AttributeDefinition
    {
        public ForOneAttribute() : base("for")
        {
        }
    }

    [IdListValidatorAttribute]
    [AppliesToElement(typeof(Output), "http://www.w3schools.com/tags/att_label_for.asp")]
    internal class ForManyAttribute : AttributeDefinition
    {
        public ForManyAttribute() : base("for")
        {
        }
    }

    [CharSetValidator]
    [AppliesToElement(typeof(Meta), "http://www.w3schools.com/tags/att_meta_charset.asp")]
    internal class CharSetAttribute : AttributeDefinition
    {
        public CharSetAttribute() : base("charset")
        {
        }
    }

    [AppliesToElement(typeof(Meta), "http://www.w3schools.com/tags/att_meta_content.asp")]
    internal class ContentAttribute : AttributeDefinition
    {
        public ContentAttribute() : base("content")
        {
        }
    }

    [HttpEquivEnumValidator]
    [AppliesToElement(typeof(Meta), "http://www.w3schools.com/tags/att_meta_http_equiv.asp")]
    internal class HttpEquivAttribute : AttributeDefinition
    {
        public HttpEquivAttribute() : base("http-equiv")
        {
        }
    }

    internal abstract class HighAttribute : AttributeDefinition
    {
        protected HighAttribute()
            : base("high")
        {
        }
    }

    [DecimalValidator]
    [AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_high.asp")]
    internal class HighIntegerAttribute : HighAttribute
    {
    }

    [DecimalValidator]
    [AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_high.asp")]
    internal class HighDecimalAttribute : HighAttribute
    {
    }

    internal abstract class LowAttribute : AttributeDefinition
    {
        protected LowAttribute()
            : base("low")
        {
        }
    }

    [DecimalValidator]
    [AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_low.asp")]
    internal class LowDecimalAttribute : LowAttribute
    {
    }

    [IntegerValidator]
    [AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_low.asp")]
    internal class LowIntegerAttribute : LowAttribute
    {
    }

    internal abstract class OptimumAttribute : AttributeDefinition
    {
        protected OptimumAttribute()
            : base("optimum")
        {
        }
    }

    [DecimalValidator]
    [AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_optimum.asp")]
    internal class OptimumDecimalAttribute : OptimumAttribute
    {
    }

    [IntegerValidator]
    [AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_optimum.asp")]
    internal class OptimumIntegerAttribute : OptimumAttribute
    {
    }

    [AppliesToElement(typeof(Ol), "http://www.w3schools.com/tags/att_ol_reversed.asp")]
    internal class ReversedAttribute : AttributeDefinition
    {
        public ReversedAttribute() : base("reversed", AttributeValueType.Forbidden)
        {
        }
    }

    internal abstract class StartAttribute : AttributeDefinition
    {
        protected StartAttribute()
            : base("start")
        {
        }
    }

    [DecimalValidator]
    [AppliesToElement(typeof(Ol), "http://www.w3schools.com/tags/att_ol_start.asp")]
    internal class StartDecimalAttribute : StartAttribute
    {
    }

    [IntegerValidator]
    [AppliesToElement(typeof(Ol), "http://www.w3schools.com/tags/att_ol_start.asp")]
    internal class StartIntegerAttribute : StartAttribute
    {
    }

    [AppliesToElement(typeof(OptGroup), "http://www.w3schools.com/tags/att_optgroup_label.asp")]
    [AppliesToElement(typeof(Option), "http://www.w3schools.com/tags/att_option_label.asp")]
    [AppliesToElement(typeof(Track), "http://www.w3schools.com/tags/att_track_label.asp")]
    internal class LabelAttribute : AttributeDefinition
    {
        public LabelAttribute() : base("label")
        {
        }
    }

    [AppliesToElement(typeof(Option), "http://www.w3schools.com/tags/att_option_selected.asp")]
    internal class SelectedAttribute : AttributeDefinition
    {
        public SelectedAttribute() : base("selected", AttributeValueType.Forbidden)
        {
        }
    }

    [AppliesToElement(typeof(Script), "http://www.w3schools.com/tags/att_script_async.asp")]
    internal class AsyncAttribute : AttributeDefinition
    {
        public AsyncAttribute() : base("async", AttributeValueType.Forbidden)
        {
        }
    }

    [AppliesToElement(typeof(Script), "http://www.w3schools.com/tags/att_script_defer.asp")]
    internal class DeferAttribute : AttributeDefinition
    {
        public DeferAttribute() : base("defer", AttributeValueType.Forbidden)
        {
        }
    }

    [MimimumZeroIntegerValidator]
    [AppliesToElement(typeof(Td), "http://www.w3schools.com/tags/att_td_colspan.asp")]
    [AppliesToElement(typeof(Th), "http://www.w3schools.com/tags/att_th_colspan.asp")]
    internal class ColSpanAttribute : AttributeDefinition
    {
        public ColSpanAttribute() : base("colspan")
        {
        }
    }

    [IdListValidator]
    [AppliesToElement(typeof(Td), "http://www.w3schools.com/tags/att_td_headers.asp")]
    [AppliesToElement(typeof(Th), "http://www.w3schools.com/tags/att_th_headers.asp")]
    internal class HeadersAttribute : AttributeDefinition
    {
        public HeadersAttribute() : base("headers")
        {
        }
    }

    [MimimumZeroIntegerValidator]
    [AppliesToElement(typeof(Td), "http://www.w3schools.com/tags/att_td_rowspan.asp")]
    [AppliesToElement(typeof(Th), "http://www.w3schools.com/tags/att_th_rowspan.asp")]
    internal class RowSpanAttribute : AttributeDefinition
    {
        public RowSpanAttribute() : base("rowspan")
        {
        }
    }

    [MimimumOneIntegerValidator]
    [AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_cols.asp")]
    internal class ColsAttribute : AttributeDefinition
    {
        public ColsAttribute() : base("cols")
        {
        }
    }

    [MimimumOneIntegerValidator]
    [AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_rows.asp")]
    internal class RowsAttribute : AttributeDefinition
    {
        public RowsAttribute() : base("rows")
        {
        }
    }

    [SoftHardEnumValidator]
    [AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_wrap.asp")]
    internal class WrapAttribute : AttributeDefinition
    {
        public WrapAttribute() : base("wrap")
        {
        }
    }

    [AppliesToElement(typeof(Th), "http://www.w3schools.com/tags/att_th_abbr.asp")]
    internal class AbbrAttribute : AttributeDefinition
    {
        public AbbrAttribute() : base("abbr")
        {
        }
    }

    [ScopeEnumValidator]
    [AppliesToElement(typeof(Th), "http://www.w3schools.com/tags/att_th_scope.asp")]
    internal class ScopeAttribute : AttributeDefinition
    {
        public ScopeAttribute() : base("scope")
        {
        }
    }

    [AppliesToElement(typeof(Track), "http://www.w3schools.com/tags/att_track_default.asp")]
    internal class DefaultAttribute : AttributeDefinition
    {
        public DefaultAttribute() : base("default", AttributeValueType.Forbidden)
        {
        }
    }

    [TrackKindEnumValidator]
    [AppliesToElement(typeof(Track), "http://www.w3schools.com/tags/att_track_kind.asp")]
    internal class KindAttribute : AttributeDefinition
    {
        public KindAttribute() : base("kind")
        {
        }
    }

    [LanguageCodeValidator]
    [AppliesToElement(typeof(Track), "http://www.w3schools.com/tags/att_track_srclang.asp")]
    internal class SrcLangAttribute : AttributeDefinition
    {
        public SrcLangAttribute() : base("srclang")
        {
        }
    }

    [UrlValidator]
    [AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_poster.asp")]
    internal class PosterAttribute : AttributeDefinition
    {
        public PosterAttribute() : base("poster")
        {
        }
    }
}
 