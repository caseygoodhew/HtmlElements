using System.CodeDom;
using System.Security.Policy;
using System.Xml.Schema;

using HtmlElements.Elements;
using HtmlElements.Meta;

namespace HtmlElements
{
	public enum AttributeValue
	{
		Required,
		Optional,
		Forbidden
	}

    public enum AttributeValidation
	{
		[Validator(typeof(NoValidator))]
		NoValidation,

		[Validator(typeof(OneCharacterValidator))]
		OneCharacter,
		
		[Validator(typeof(EnumValidator<Editable>))]
		Editable,

        [Validator(typeof(EnumValidator<Draggable>))]
        Draggable,

        [Validator(typeof(EnumValidator<TextDirection>))]
		TextDirection,

        [Validator(typeof(ClassValidator))]
		Class,

        [Validator(typeof(IdValidator))]
        Id,

        [Validator(typeof(LanguageCodeValidator))]
        LanguageCode,

        [Validator(typeof(UrlValidator))]
        Url,

        [Validator(typeof(MediaExpressionValidator))]
		MediaExpression,

        [Validator(typeof(EnumValidator<LinkedRel>))]
        LinkedRel,

        [Validator(typeof(EnumValidator<ResourceRel>))]
        ResourceRel,

        [Validator(typeof(MediaTypeValidator))]
		MediaType,

        [ValidatorForEnum(typeof(CoordValidators))]
		Coords,
		
        Shape,
		Preload,
		DateTime,
		Name,
		CharSet,
		OnOff,
		EncodeType,
		GetPost,
		XmlNs,
		Sandbox,
		Html,
		HashId,
		AcceptTypes,
		Target,
		Number,
		Regex,
		Color,
		KeyType,
		HttpEquiv,
		OrderedListType,
		IdList,
		PositiveIntegerBaseZero,
		PositiveIntegerBaseOne,
		SoftHard,
		HeaderScope,
		TrackKind,
		Custom
	}
	
	public abstract class ElementAttribute
	{
		public readonly string Name;
		
		private readonly AttributeValue _attributeValue;
		
		private readonly AttributeValidation _validator;

		protected ElementAttribute(string name)
			: this(name, AttributeValue.Required, AttributeValidation.NoValidation)
		{
		}
		
		protected ElementAttribute(string name, AttributeValidation validator) 
			: this(name, AttributeValue.Required, validator)
		{
		}
		
		protected ElementAttribute(string name, AttributeValue attributeValue) 
			: this(name, attributeValue, AttributeValidation.NoValidation)
		{
		}
		
		protected ElementAttribute(string name, AttributeValue attributeValue, AttributeValidation validator)
		{
			Name = name;
			_attributeValue = attributeValue;
			_validator = validator;
		}

        
	}

	[AppliesToElement(typeof(Element), "http://www.w3schools.com/tags/att_global_accesskey.asp")]
	public class AccessKeyAttribute : ElementAttribute
	{
		public AccessKeyAttribute() : base("accesskey", AttributeValidation.OneCharacter)
		{
		}
	}

	[AppliesToElement(typeof(Element), "http://www.w3schools.com/tags/att_global_class.asp")]
	public class ClassAttribute : ElementAttribute
	{
		public ClassAttribute() : base("class", AttributeValidation.Class)
		{
		}
	}

	[AppliesToElement(typeof(Element), "http://www.w3schools.com/tags/att_global_contenteditable.asp")]
	public class ContentEditableAttribute : ElementAttribute
	{
		public ContentEditableAttribute() : base("contenteditable", AttributeValidation.Editable)
		{
		}
	}

	[AppliesToElement(typeof(Element), "http://www.w3schools.com/tags/att_global_data.asp")]
	public class DataAttribute : ElementAttribute
	{
		private string _dataName ;
		
		public DataAttribute(string dataName) : base("data", AttributeValidation.NoValidation)
		{
			_dataName = dataName;
		}
	}

	[AppliesToElement(typeof(Element), "http://www.w3schools.com/tags/att_global_dir.asp")]
	public class DirAttribute : ElementAttribute
	{
		public DirAttribute() : base("dir", AttributeValidation.TextDirection)
		{
		}
	}

	[AppliesToElement(typeof(Element), "http://www.w3schools.com/tags/att_global_draggable.asp")]
	public class DraggableAttribute : ElementAttribute
	{
		public DraggableAttribute() : base("draggable", AttributeValidation.Draggable)
		{
		}
	}

	[AppliesToElement(typeof(Element), "http://www.w3schools.com/tags/att_global_hidden.asp")]
	public class HiddenAttribute : ElementAttribute
	{
		public HiddenAttribute() : base("hidden", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(Element), "http://www.w3schools.com/tags/att_global_id.asp")]
	public class IdAttribute : ElementAttribute
	{
		public IdAttribute() : base("id", AttributeValidation.Id)
		{
		}
	}

	[AppliesToElement(typeof(Element), "http://www.w3schools.com/tags/att_global_lang.asp")]
	public class LangAttribute : ElementAttribute
	{
		public LangAttribute() : base("lang", AttributeValidation.LanguageCode)
		{
		}
	}

	[AppliesToElement(typeof(Element), "http://www.w3schools.com/tags/att_global_spellcheck.asp")]
	public class SpellcheckAttribute: ElementAttribute
	{
		public SpellcheckAttribute() : base("spellcheck", AttributeValidation.Editable)
		{
		}
	}

	[AppliesToElement(typeof(Element), "http://www.w3schools.com/tags/att_global_style.asp")]
	public class StyleAttribute: ElementAttribute
	{
		public StyleAttribute() : base("style", AttributeValidation.NoValidation)
		{
		}
	}

	[AppliesToElement(typeof(Element), "http://www.w3schools.com/tags/att_global_tabindex.asp")]
	public class TabIndexAttribute : ElementAttribute
	{
		public TabIndexAttribute() : base("tabindex", AttributeValidation.PositiveIntegerBaseOne)
		{
		}
	}

	[AppliesToElement(typeof(Element), "http://www.w3schools.com/tags/att_global_title.asp")]
	public class TitleAttribute : ElementAttribute
	{
		public TitleAttribute() : base("title", AttributeValidation.NoValidation)
		{
		}
	}

	[AppliesToElement(typeof(A), "http://www.w3schools.com/tags/att_a_download.asp")]
	[AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_download.asp")]
	public class DownloadAttribute : ElementAttribute
	{
		public DownloadAttribute() : base("download", AttributeValue.Optional)
		{
		}
	}

	[AppliesToElement(typeof(A), "http://www.w3schools.com/tags/att_a_href.asp")]
	[AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_href.asp")]
	[AppliesToElement(typeof(Base), "http://www.w3schools.com/tags/att_base_href.asp")]
	[AppliesToElement(typeof(Link), "http://www.w3schools.com/tags/att_link_href.asp")]
	public class HrefAttribute : ElementAttribute
	{
		public HrefAttribute() : base("href", AttributeValidation.Url)
		{
		}
	}

	[AppliesToElement(typeof(A), "http://www.w3schools.com/tags/att_a_hreflang.asp")]
	[AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_hreflang.asp")]
	[AppliesToElement(typeof(Link), "http://www.w3schools.com/tags/att_link_hreflang.asp")]
	public class HrefLangAttribute : ElementAttribute
	{
		public HrefLangAttribute() : base("hreflang", AttributeValidation.LanguageCode)
		{
		}
	}

	[AppliesToElement(typeof(A), "http://www.w3schools.com/tags/att_a_media.asp")]
	[AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_media.asp")]
	[AppliesToElement(typeof(Link), "http://www.w3schools.com/tags/att_link_media.asp")]
	[AppliesToElement(typeof(Style), "http://www.w3schools.com/tags/att_style_media.asp")]
	public class MediaAttribute : ElementAttribute
	{
		public MediaAttribute() : base("media", AttributeValidation.MediaExpression)
		{
		}
	}

    [AppliesToElement(typeof(A), "http://www.w3schools.com/tags/att_a_rel.asp")]
    [AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_rel.asp")]
    [AttributeName("Rel")]
    public class LinkedRelAttribute : ElementAttribute
    {
        public LinkedRelAttribute() : base("rel", AttributeValidation.LinkedRel)
        {
        }
    }

    [AppliesToElement(typeof(Link), "http://www.w3schools.com/tags/att_link_rel.asp")]
    [AttributeName("Rel")]
    public class ResourceRelAttribute : ElementAttribute
    {
        public ResourceRelAttribute() : base("rel", AttributeValidation.ResourceRel)
        {
        }
    }

    [AppliesToElement(typeof(A), "http://www.w3schools.com/tags/att_a_target.asp")]
	[AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_target.asp")]
	[AppliesToElement(typeof(Base), "http://www.w3schools.com/tags/att_base_target.asp")]
	[AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_target.asp")]
	public class TargetAttribute : ElementAttribute
	{
		public TargetAttribute() : base("target", AttributeValidation.Target)
		{
		}
	}

	[AppliesToElement(typeof(A), "http://www.w3schools.com/tags/att_a_type.asp")]
	[AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_type.asp")]
	[AppliesToElement(typeof(Embed), "http://www.w3schools.com/tags/att_embed_type.asp")]
	[AppliesToElement(typeof(Link), "http://www.w3schools.com/tags/att_link_type.asp")]
	[AppliesToElement(typeof(Object), "http://www.w3schools.com/tags/att_object_type.asp")]
	[AppliesToElement(typeof(Script), "http://www.w3schools.com/tags/att_script_type.asp")]
	[AppliesToElement(typeof(Source), "http://www.w3schools.com/tags/att_source_type.asp")]
	[AppliesToElementWithoutAttach(typeof(Style), "text/css", "http://www.w3schools.com/tags/att_style_type.asp")]
	[AttributeName("Type")]
	public class MediaTypeAttribute : ElementAttribute
	{
		public MediaTypeAttribute()
			: base("type", AttributeValidation.MediaType)
		{
		}
	}

	[AppliesToElement(typeof(Ol), "http://www.w3schools.com/tags/att_ol_type.asp")]
	[AttributeName("Type")]
	public class OrderedListTypeAttribute : ElementAttribute
	{
		public OrderedListTypeAttribute() : base("type", AttributeValidation.OrderedListType)
		{
		}
	}

	[AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/tag_area.asp")]
	[AppliesToElement(typeof(Img), "http://www.w3schools.com/tags/att_img_alt.asp")]
	[AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_alt.asp")]
	public class AltAttribute : ElementAttribute
	{
		public AltAttribute() : base("alt")
		{
		}
	}

	[AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_coords.asp")]
	public class CoordsAttribute : ElementAttribute
	{
		public CoordsAttribute() : base("coords", AttributeValidation.Coords)
		{
		}
	}

	[AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_shape.asp")]
	public class ShapeAttribute : ElementAttribute
	{
		public ShapeAttribute() : base("shape", AttributeValidation.Shape)
		{
		}
	}

	[AppliesToElement(typeof(Audio), "http://www.w3schools.com/tags/att_audio_autoplay.asp")]
	[AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_autoplay.asp")]
	public class AutoPlayAttribute : ElementAttribute
	{
		public AutoPlayAttribute() : base("autoplay", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(Audio), "http://www.w3schools.com/tags/att_audio_controls.asp")]
	[AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_controls.asp")]
	public class ControlsAttribute : ElementAttribute
	{
		public ControlsAttribute() : base("controls", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(Audio), "http://www.w3schools.com/tags/att_audio_loop.asp")]
	[AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_loop.asp")]
	public class LoopAttribute : ElementAttribute
	{
		public LoopAttribute() : base("loop", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(Audio), "http://www.w3schools.com/tags/att_audio_muted.asp")]
	[AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_muted.asp")]
	public class MutedAttribute : ElementAttribute
	{
		public MutedAttribute() : base("muted", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(Audio), "http://www.w3schools.com/tags/att_audio_preload.asp")]
	[AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_preload.asp")]
	public class PreloadAttribute : ElementAttribute
	{
		public PreloadAttribute() : base("preload", AttributeValidation.Preload)
		{
		}
	}

	[AppliesToElement(typeof(Audio), "http://www.w3schools.com/tags/att_audio_src.asp")]
	[AppliesToElement(typeof(Embed), "http://www.w3schools.com/tags/att_embed_src.asp")]
	[AppliesToElement(typeof(IFrame), "http://www.w3schools.com/tags/att_iframe_src.asp")]
	[AppliesToElement(typeof(Img), "http://www.w3schools.com/tags/att_img_src.asp")]
	[AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_src.asp")]
	[AppliesToElement(typeof(Script), "http://www.w3schools.com/tags/att_script_src.asp")]
	[AppliesToElement(typeof(Source), "http://www.w3schools.com/tags/att_source_src.asp")]
	[AppliesToElement(typeof(Track), "http://www.w3schools.com/tags/att_track_src.asp")]
	[AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_src.asp")]
	public class SrcAttribute : ElementAttribute
	{
		public SrcAttribute() : base("src", AttributeValidation.Url)
		{
		}
	}

	[AppliesToElement(typeof(BlockQuote), "http://www.w3schools.com/tags/att_blockquote_cite.asp")]
	[AppliesToElement(typeof(Del), "http://www.w3schools.com/tags/att_del_cite.asp")]
	[AppliesToElement(typeof(Ins), "http://www.w3schools.com/tags/att_ins_cite.asp")]
	[AppliesToElement(typeof(Q), "http://www.w3schools.com/tags/att_q_cite.asp")]
	public class CiteAttribute : ElementAttribute
	{
		public CiteAttribute() : base("cite", AttributeValidation.Url)
		{
		}
	}

	[AppliesToElement(typeof(Del), "http://www.w3schools.com/tags/tag_del.asp")]
	[AppliesToElement(typeof(Ins), "http://www.w3schools.com/tags/att_ins_datetime.asp")]
	[AppliesToElement(typeof(Time), "http://www.w3schools.com/tags/att_time_datetime.asp")]
	public class DateTimeAttribute : ElementAttribute
	{
		public DateTimeAttribute() : base("datetime", AttributeValidation.DateTime)
		{
		}
	}

	[AppliesToElement(typeof(Details), "http://www.w3schools.com/tags/att_details_open.asp")]
	public class OpenAttribute : ElementAttribute
	{
		public OpenAttribute() : base("open", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(Embed), "http://www.w3schools.com/tags/att_embed_height.asp")]
	[AppliesToElement(typeof(IFrame), "http://www.w3schools.com/tags/att_iframe_height.asp")]
	[AppliesToElement(typeof(Img), "http://www.w3schools.com/tags/att_img_height.asp")]
	[AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_height.asp")]
	[AppliesToElement(typeof(Object), "http://www.w3schools.com/tags/att_object_height.asp")]
	[AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_height.asp")]
	public class HeightAttribute : ElementAttribute
	{
		public HeightAttribute() : base("height", AttributeValidation.PositiveIntegerBaseZero)
		{
		}
	}

	[AppliesToElement(typeof(Embed), "http://www.w3schools.com/tags/att_embed_width.asp")]
	[AppliesToElement(typeof(IFrame), "http://www.w3schools.com/tags/att_iframe_width.asp")]
	[AppliesToElement(typeof(Img), "http://www.w3schools.com/tags/att_img_width.asp")]
	[AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_width.asp")]
	[AppliesToElement(typeof(Object), "http://www.w3schools.com/tags/att_object_width.asp")]
	[AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_width.asp")]
	public class WidthAttribute : ElementAttribute
	{
		public WidthAttribute() : base("width", AttributeValidation.PositiveIntegerBaseZero)
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
	public class DisabledAttribute : ElementAttribute
	{
		public DisabledAttribute() : base("disabled", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(FieldSet), "http://www.w3schools.com/tags/att_fieldset_form.asp")]
	[AppliesToElement(typeof(Input), "http://www.w3schools.com/tags/att_input_form.asp")]
	[AppliesToElement(typeof(KeyGen), "http://www.w3schools.com/tags/att_keygen_form.asp")]
	[AppliesToElement(typeof(Label), "http://www.w3schools.com/tags/att_label_form.asp")]
	[AppliesToElement(typeof(Select), "http://www.w3schools.com/tags/att_select_form.asp")]
	[AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_form.asp")]
	public class FormAttribute : ElementAttribute
	{
		public FormAttribute() : base("form", AttributeValidation.Id)
		{
		}
	}

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
	public class NameAttribute : ElementAttribute
	{
		public NameAttribute() : base("name", AttributeValidation.Name)
		{
		}
	}

	[AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_accept_charset.asp")]
	[AppliesToElement(typeof(Script), "http://www.w3schools.com/tags/att_script_charset.asp")]
	public class AcceptCharsetAttribute : ElementAttribute
	{
		public AcceptCharsetAttribute() : base("accept-charset", AttributeValidation.CharSet)
		{
		}
	}

	[AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_action.asp")]
	public class ActionAttribute : ElementAttribute
	{
		public ActionAttribute() : base("action", AttributeValidation.Url)
		{
		}
	}

	[AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_autocomplete.asp")]
	[AppliesToElement(typeof(TextTypeInput), "http://www.w3schools.com/tags/att_input_autocomplete.asp")]
	[AppliesToElement(typeof(DateTypeInput), "http://www.w3schools.com/tags/att_input_autocomplete.asp")]
	[AppliesToElement(typeof(RangeInput), "http://www.w3schools.com/tags/att_input_autocomplete.asp")]
	[AppliesToElement(typeof(ColorInput), "http://www.w3schools.com/tags/att_input_autocomplete.asp")]
	public class AutoCompleteAttribute : ElementAttribute
	{
		public AutoCompleteAttribute() : base("autocomplete", AttributeValidation.OnOff)
		{
		}
	}

	[AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_enctype.asp")]
	public class EncTypeAttribute : ElementAttribute
	{
		public EncTypeAttribute() : base("enctype", AttributeValidation.EncodeType)
		{
		}
	}

	[AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_method.asp")]
	public class MethodAttribute : ElementAttribute
	{
		public MethodAttribute() : base("method", AttributeValidation.GetPost)
		{
		}
	}

	[AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_novalidate.asp")]
	public class NoValidateAttribute : ElementAttribute
	{
		public NoValidateAttribute() : base("novalidate", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(Html), "http://www.w3schools.com/tags/att_html_manifest.asp")]
	public class ManifestAttribute : ElementAttribute
	{
		public ManifestAttribute() : base("manifest", AttributeValidation.Url)
		{
		}
	}

	[AppliesToElement(typeof(Html), "http://www.w3schools.com/tags/att_html_xmlns.asp")]
	public class XmlNsAttribute : ElementAttribute
	{
		public XmlNsAttribute() : base("xmlns", AttributeValidation.XmlNs)
		{
		}
	}

	[AppliesToElement(typeof(IFrame), "http://www.w3schools.com/tags/att_iframe_sandbox.asp")]
	public class SandboxAttribute : ElementAttribute
	{
		public SandboxAttribute() : base("sandbox", AttributeValidation.Sandbox)
		{
		}
	}

	[AppliesToElement(typeof(IFrame), "http://www.w3schools.com/tags/att_iframe_srcdoc.asp")]
	public class SrcDocAttribute : ElementAttribute
	{
		public SrcDocAttribute() : base("srcdoc", AttributeValidation.Html)
		{
		}
	}

	[AppliesToElement(typeof(Img), "http://www.w3schools.com/tags/att_img_usemap.asp")]
	[AppliesToElement(typeof(Object), "http://www.w3schools.com/tags/att_object_usemap.asp")]
	public class UseMapAttribute : ElementAttribute
	{
		public UseMapAttribute() : base("usemap", AttributeValidation.HashId)
		{
		}
	}

	[AppliesToElement(typeof(Img), "http://www.w3schools.com/tags/att_img_ismap.asp")]
	public class IsMapAttribute : ElementAttribute
	{
		public IsMapAttribute() : base("ismap", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(FileInput), "http://www.w3schools.com/tags/att_input_accept.asp")]
	public class AcceptAttribute : ElementAttribute
	{
		public AcceptAttribute() : base("accept", AttributeValidation.AcceptTypes)
		{
		}
	}

	[AppliesToElement(typeof(VisibleInput), "http://www.w3schools.com/tags/att_input_autofocus.asp")]
	[AppliesToElement(typeof(KeyGen), "http://www.w3schools.com/tags/att_keygen_autofocus.asp")]
	[AppliesToElement(typeof(Select), "http://www.w3schools.com/tags/att_select_autofocus.asp")]
	[AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_autofocus.asp")]
	public class AutoFocusAttribute : ElementAttribute
	{
		public AutoFocusAttribute() : base("autofocus", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(CheckboxInput), "http://www.w3schools.com/tags/att_input_checked.asp")]
	[AppliesToElement(typeof(RadioInput), "http://www.w3schools.com/tags/att_input_checked.asp")]
	public class CheckedAttribute : ElementAttribute
	{
		public CheckedAttribute() : base("checked", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(SubmitInput), "http://www.w3schools.com/tags/att_input_formaction.asp")]
	[AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_formaction.asp")]
	public class FormActionAttribute : ElementAttribute
	{
		public FormActionAttribute() : base("formaction", AttributeValidation.Url)
		{
		}
	}

	[AppliesToElement(typeof(SubmitInput), "http://www.w3schools.com/tags/att_input_formenctype.asp")]
	[AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_formenctype.asp")]
	public class FormEncTypeAttribute : ElementAttribute
	{
		public FormEncTypeAttribute() : base("formenctype", AttributeValidation.EncodeType)
		{
		}
	}

	[AppliesToElement(typeof(SubmitInput), "http://www.w3schools.com/tags/att_input_formmethod.asp")]
	[AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_formmethod.asp")]
	public class FormMethodAttribute : ElementAttribute
	{
		public FormMethodAttribute() : base("formmethod", AttributeValidation.GetPost)
		{
		}
	}

	[AppliesToElement(typeof(SubmitInput), "http://www.w3schools.com/tags/att_input_formnovalidate.asp")]
	public class FormNoValidateAttribute : ElementAttribute
	{
		public FormNoValidateAttribute() : base("formnovalidate", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(SubmitInput), "http://www.w3schools.com/tags/att_input_formtarget.asp")]
	[AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_formtarget.asp")]
	public class FormTargetAttribute : ElementAttribute
	{
		public FormTargetAttribute() : base("formtarget", AttributeValidation.Target)
		{
		}
	}

	[AppliesToElement(typeof(VisibleInput), "http://www.w3schools.com/tags/att_input_list.asp")]
	public class ListAttribute : ElementAttribute
	{
		public ListAttribute() : base("list", AttributeValidation.Id)
		{
		}
	}

	[AppliesToElement(typeof(NumberInput), "http://www.w3schools.com/tags/att_input_max.asp")]
	[AppliesToElement(typeof(RangeInput), "http://www.w3schools.com/tags/att_input_max.asp")]
	[AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_max.asp")]
	[AppliesToElement(typeof(Progress), "http://www.w3schools.com/tags/att_progress_max.asp")]
	[AttributeName("Max")]
	public class MaxNumberAttribute : ElementAttribute
	{
		public MaxNumberAttribute() : base("max", AttributeValidation.Number)
		{
		}
	}

	[AppliesToElement(typeof(DateTypeInput), "http://www.w3schools.com/tags/att_input_max.asp")]
	[AttributeName("Max")]
	public class MaxDateAttribute : ElementAttribute
	{
		public MaxDateAttribute() : base("max", AttributeValidation.DateTime)
		{
		}
	}

	[AppliesToElement(typeof(NumberInput), "http://www.w3schools.com/tags/att_input_min.asp")]
	[AppliesToElement(typeof(RangeInput), "http://www.w3schools.com/tags/att_input_min.asp")]
	[AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_min.asp")]
	[AttributeName("Min")]
	public class MinNumberAttribute : ElementAttribute
	{
		public MinNumberAttribute() : base("min", AttributeValidation.Number)
		{
		}
	}

	[AppliesToElement(typeof(DateTypeInput), "http://www.w3schools.com/tags/att_input_min.asp")]
	[AttributeName("Min")]
	public class MinDateAttribute : ElementAttribute
	{
		public MinDateAttribute() : base("min", AttributeValidation.DateTime)
		{
		}
	}

	[AppliesToElement(typeof(VisibleInput), "http://www.w3schools.com/tags/att_input_maxlength.asp")]
	[AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_maxlength.asp")]
	public class MaxLengthAttribute : ElementAttribute
	{
		public MaxLengthAttribute() : base("maxlength", AttributeValidation.Number)
		{
		}
	}

	[AppliesToElement(typeof(EmailInput), "http://www.w3schools.com/tags/att_input_multiple.asp")]
	[AppliesToElement(typeof(FileInput), "http://www.w3schools.com/tags/att_input_multiple.asp")]
	[AppliesToElement(typeof(Select), "http://www.w3schools.com/tags/att_select_multiple.asp")]
	public class MultipleAttribute : ElementAttribute
	{
		public MultipleAttribute() : base("multiple", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(TextTypeInput), "http://www.w3schools.com/tags/att_input_pattern.asp")]
	public class PatternAttribute : ElementAttribute
	{
		public PatternAttribute() : base("pattern", AttributeValidation.Regex)
		{
		}
	}

	[AppliesToElement(typeof(TextTypeInput), "http://www.w3schools.com/tags/att_input_placeholder.asp")]
	[AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_placeholder.asp")]
	public class PlaceHolderAttribute : ElementAttribute
	{
		public PlaceHolderAttribute() : base("placeholder")
		{
		}
	}

	[AppliesToElement(typeof(VisibleInput), "http://www.w3schools.com/tags/att_input_readonly.asp")]
	[AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_readonly.asp")]
	public class ReadonlyAttribute : ElementAttribute
	{
		public ReadonlyAttribute() : base("readonly", AttributeValue.Forbidden)
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
	public class RequiredAttribute : ElementAttribute
	{
		public RequiredAttribute() : base("required", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(TextTypeInput), "http://www.w3schools.com/tags/att_input_size.asp")]
	[AppliesToElement(typeof(Select), "http://www.w3schools.com/tags/att_select_size.asp")]
	public class SizeAttribute : ElementAttribute
	{
		public SizeAttribute() : base("size", AttributeValidation.PositiveIntegerBaseOne)
		{
		}
	}

	[AppliesToElement(typeof(NumberInput), "http://www.w3schools.com/tags/att_input_step.asp")]
	[AppliesToElement(typeof(RangeInput), "http://www.w3schools.com/tags/att_input_step.asp")]
	[AppliesToElement(typeof(DateTypeInput), "http://www.w3schools.com/tags/att_input_step.asp")]
	public class StepAttribute : ElementAttribute
	{
		public StepAttribute() : base("step", AttributeValidation.PositiveIntegerBaseOne)
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
	[AttributeName("Value")]
	public class TextValueAttribute : ElementAttribute
	{
		public TextValueAttribute() : base("value")
		{
		}
	}

	[AppliesToElement(typeof(DateTypeInput), "http://www.w3schools.com/tags/att_input_value.asp")]
	[AttributeName("Value")]
	public class DateValueAttribute : ElementAttribute
	{
		public DateValueAttribute() : base("value", AttributeValidation.DateTime)
		{
		}
	}

	[AppliesToElement(typeof(ColorInput), "http://www.w3schools.com/tags/att_input_value.asp")]
	[AttributeName("Value")]
	public class ColorValueAttribute : ElementAttribute
	{
		public ColorValueAttribute() : base("value", AttributeValidation.Color)
		{
		}
	}

	[AppliesToElement(typeof(NumberInput), "http://www.w3schools.com/tags/att_input_value.asp")]
	[AppliesToElement(typeof(RangeInput), "http://www.w3schools.com/tags/att_input_value.asp")]
	[AppliesToElement(typeof(Li), "http://www.w3schools.com/tags/att_li_value.asp")]
	[AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_value.asp")]
	[AppliesToElement(typeof(Progress), "http://www.w3schools.com/tags/att_progress_value.asp")]
	[AttributeName("Value")]
	public class NumberValueAttribute : ElementAttribute
	{
		public NumberValueAttribute() : base("value", AttributeValidation.Number)
		{
		}
	}

	[AppliesToElement(typeof(KeyGen), "http://www.w3schools.com/tags/att_keygen_keytype.asp")]
	public class KeyTypeAttribute : ElementAttribute
	{
		public KeyTypeAttribute() : base("keytype", AttributeValidation.KeyType)
		{
		}
	}

	[AppliesToElement(typeof(Label), "http://www.w3schools.com/tags/att_label_for.asp")]
	[AttributeName("For")]
	public class ForOneAttribute : ElementAttribute
	{
		public ForOneAttribute() : base("for", AttributeValidation.Id)
		{
		}
	}

	[AppliesToElement(typeof(Output), "http://www.w3schools.com/tags/att_label_for.asp")]
	[AttributeName("For")]
	public class ForManyAttribute : ElementAttribute
	{
		public ForManyAttribute() : base("for", AttributeValidation.IdList)
		{
		}
	}

	[AppliesToElement(typeof(Meta), "http://www.w3schools.com/tags/att_meta_charset.asp")]
	public class CharSetAttribute : ElementAttribute
	{
		public CharSetAttribute() : base("charset", AttributeValidation.CharSet)
		{
		}
	}

	[AppliesToElement(typeof(Meta), "http://www.w3schools.com/tags/att_meta_content.asp")]
	public class ContentAttribute : ElementAttribute
	{
		public ContentAttribute() : base("content")
		{
		}
	}

	[AppliesToElement(typeof(Meta), "http://www.w3schools.com/tags/att_meta_http_equiv.asp")]
	public class HttpEquivAttribute : ElementAttribute
	{
		public HttpEquivAttribute() : base("http-equiv", AttributeValidation.HttpEquiv)
		{
		}
	}

	[AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_high.asp")]
	public class HighAttribute : ElementAttribute
	{
		public HighAttribute() : base("high", AttributeValidation.Number)
		{
		}
	}

	[AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_low.asp")]
	public class LowAttribute : ElementAttribute
	{
		public LowAttribute() : base("low", AttributeValidation.Number)
		{
		}
	}

	[AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_optimum.asp")]
	public class OptimumAttribute : ElementAttribute
	{
		public OptimumAttribute() : base("optimum", AttributeValidation.Number)
		{
		}
	}

	[AppliesToElement(typeof(Ol), "http://www.w3schools.com/tags/att_ol_reversed.asp")]
	public class ReversedAttribute : ElementAttribute
	{
		public ReversedAttribute() : base("reversed", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(Ol), "http://www.w3schools.com/tags/att_ol_start.asp")]
	public class StartAttribute : ElementAttribute
	{
		public StartAttribute() : base("start", AttributeValidation.Number)
		{
		}
	}

	[AppliesToElement(typeof(OptGroup), "http://www.w3schools.com/tags/att_optgroup_label.asp")]
	[AppliesToElement(typeof(Option), "http://www.w3schools.com/tags/att_option_label.asp")]
	[AppliesToElement(typeof(Track), "http://www.w3schools.com/tags/att_track_label.asp")]
	public class LabelAttribute : ElementAttribute
	{
		public LabelAttribute() : base("label")
		{
		}
	}

	[AppliesToElement(typeof(Option), "http://www.w3schools.com/tags/att_option_selected.asp")]
	public class SelectedAttribute : ElementAttribute
	{
		public SelectedAttribute() : base("selected", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(Script), "http://www.w3schools.com/tags/att_script_async.asp")]
	public class AsyncAttribute : ElementAttribute
	{
		public AsyncAttribute() : base("async", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(Script), "http://www.w3schools.com/tags/att_script_defer.asp")]
	public class DeferAttribute : ElementAttribute
	{
		public DeferAttribute() : base("defer", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(Td), "http://www.w3schools.com/tags/att_td_colspan.asp")]
	[AppliesToElement(typeof(Th), "http://www.w3schools.com/tags/att_th_colspan.asp")]
	public class ColSpanAttribute : ElementAttribute
	{
		public ColSpanAttribute() : base("colspan", AttributeValidation.PositiveIntegerBaseZero)
		{
		}
	}

	[AppliesToElement(typeof(Td), "http://www.w3schools.com/tags/att_td_headers.asp")]
	[AppliesToElement(typeof(Th), "http://www.w3schools.com/tags/att_th_headers.asp")]
	public class HeadersAttribute : ElementAttribute
	{
		public HeadersAttribute() : base("headers", AttributeValidation.IdList)
		{
		}
	}

	[AppliesToElement(typeof(Td), "http://www.w3schools.com/tags/att_td_rowspan.asp")]
	[AppliesToElement(typeof(Th), "http://www.w3schools.com/tags/att_th_rowspan.asp")]
	public class RowSpanAttribute : ElementAttribute
	{
		public RowSpanAttribute() : base("rowspan", AttributeValidation.PositiveIntegerBaseZero)
		{
		}
	}

	[AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_cols.asp")]
	public class ColsAttribute : ElementAttribute
	{
		public ColsAttribute() : base("cols", AttributeValidation.PositiveIntegerBaseOne)
		{
		}
	}

	[AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_rows.asp")]
	public class RowsAttribute : ElementAttribute
	{
		public RowsAttribute() : base("rows", AttributeValidation.PositiveIntegerBaseOne)
		{
		}
	}

	[AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_wrap.asp")]
	public class WrapAttribute : ElementAttribute
	{
		public WrapAttribute() : base("wrap", AttributeValidation.SoftHard)
		{
		}
	}

	[AppliesToElement(typeof(Th), "http://www.w3schools.com/tags/att_th_abbr.asp")]
	public class AbbrAttribute : ElementAttribute
	{
		public AbbrAttribute() : base("abbr")
		{
		}
	}

	[AppliesToElement(typeof(Th), "http://www.w3schools.com/tags/att_th_scope.asp")]
	public class ScopeAttribute : ElementAttribute
	{
		public ScopeAttribute() : base("scope", AttributeValidation.HeaderScope)
		{
		}
	}

	[AppliesToElement(typeof(Track), "http://www.w3schools.com/tags/att_track_default.asp")]
	public class DefaultAttribute : ElementAttribute
	{
		public DefaultAttribute() : base("default", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(Track), "http://www.w3schools.com/tags/att_track_kind.asp")]
	public class KindAttribute : ElementAttribute
	{
		public KindAttribute() : base("kind", AttributeValidation.TrackKind)
		{
		}
	}

	[AppliesToElement(typeof(Track), "http://www.w3schools.com/tags/att_track_srclang.asp")]
	public class SrcLangAttribute : ElementAttribute
	{
		public SrcLangAttribute() : base("srclang", AttributeValidation.LanguageCode)
		{
		}
	}

	[AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_poster.asp")]
	public class PosterAttribute : ElementAttribute
	{
		public PosterAttribute() : base("poster", AttributeValidation.Url)
		{
		}
	}
}
 