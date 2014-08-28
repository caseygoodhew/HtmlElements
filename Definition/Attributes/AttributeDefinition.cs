using System;
using System.Drawing;

using Definition.Elements;
using Definition.Validation;
using Definition.Validation.Enum;
using Definition.Validation.NotImplemented;
using Definition.Validation.Number;
using Definition.Validation.Regex;
using Object = Definition.Elements.Object;

namespace Definition.Attributes
{
	internal enum AttributeValue
	{
		Required,
		Optional,
		Forbidden
	}

	internal abstract class AttributeDefinition
	{
		internal readonly string Name;
		
		internal readonly AttributeValue AttributeValue;
		
		protected AttributeDefinition(string name) : this(name, AttributeValue.Required)
		{
		}
		
		protected AttributeDefinition(string name, AttributeValue attributeValue)
		{
			Name = name;
			AttributeValue = attributeValue;
		}

        
	}

	[OneCharacterValidator]
	[AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_accesskey.asp")]
	internal class AccessKeyAttribute : AttributeDefinition
	{
		internal AccessKeyAttribute() : base("accesskey")
		{
		}
	}

	[ClassValidator]
	[AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_class.asp")]
	internal class ClassAttribute : AttributeDefinition
	{
		internal ClassAttribute() : base("class")
		{
		}
	}

	[EditableEnumValidator]
	[AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_contenteditable.asp")]
	internal class ContentEditableAttribute : AttributeDefinition
	{
		internal ContentEditableAttribute() : base("contenteditable")
		{
		}
	}

	[AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_data.asp")]
	internal class DataAttribute : AttributeDefinition
	{
		private string _dataName ;
		
		internal DataAttribute(string dataName) : base("data")
		{
			_dataName = dataName;
		}
	}

	[TextDirectionEnumValidator]
	[AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_dir.asp")]
	internal class DirAttribute : AttributeDefinition
	{
		internal DirAttribute() : base("dir")
		{
		}
	}

	[DraggableEnumValidator]
	[AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_draggable.asp")]
	internal class DraggableAttribute : AttributeDefinition
	{
		internal DraggableAttribute() : base("draggable")
		{
		}
	}

	[AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_hidden.asp")]
	internal class HiddenAttribute : AttributeDefinition
	{
		internal HiddenAttribute() : base("hidden", AttributeValue.Forbidden)
		{
		}
	}

	[IdValidator]
	[AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_id.asp")]
	internal class IdAttribute : AttributeDefinition
	{
		internal IdAttribute() : base("id")
		{
		}
	}

	[LanguageCodeValidator]
	[AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_lang.asp")]
	internal class LangAttribute : AttributeDefinition
	{
		internal LangAttribute() : base("lang")
		{
		}
	}

	[EditableEnumValidator]
	[AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_spellcheck.asp")]
	internal class SpellcheckAttribute: AttributeDefinition
	{
		internal SpellcheckAttribute() : base("spellcheck")
		{
		}
	}

	[AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_style.asp")]
	internal class StyleAttribute: AttributeDefinition
	{
		internal StyleAttribute() : base("style")
		{
		}
	}

	[PositiveIntegerBaseOneValidator]
	[AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_tabindex.asp")]
	internal class TabIndexAttribute : AttributeDefinition
	{
		internal TabIndexAttribute() : base("tabindex")
		{
		}
	}

	[AppliesToElement(typeof(ElementDefinition), "http://www.w3schools.com/tags/att_global_title.asp")]
	internal class TitleAttribute : AttributeDefinition
	{
		internal TitleAttribute() : base("title")
		{
		}
	}

	[AppliesToElement(typeof(A), "http://www.w3schools.com/tags/att_a_download.asp")]
	[AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_download.asp")]
	internal class DownloadAttribute : AttributeDefinition
	{
		internal DownloadAttribute() : base("download", AttributeValue.Optional)
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
		internal HrefAttribute() : base("href")
		{
		}
	}

	[LanguageCodeValidator]
	[AppliesToElement(typeof(A), "http://www.w3schools.com/tags/att_a_hreflang.asp")]
	[AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_hreflang.asp")]
	[AppliesToElement(typeof(Link), "http://www.w3schools.com/tags/att_link_hreflang.asp")]
	internal class HrefLangAttribute : AttributeDefinition
	{
		internal HrefLangAttribute() : base("hreflang")
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
		internal MediaAttribute() : base("media")
		{
		}
	}

	[LinkedRelEnumValidator]
	[AppliesToElement(typeof(A), "http://www.w3schools.com/tags/att_a_rel.asp")]
    [AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_rel.asp")]
    [AttributeName("Rel")]
    internal class LinkedRelAttribute : AttributeDefinition
    {
        internal LinkedRelAttribute() : base("rel")
        {
        }
    }

	[ResourceRelEnumValidator]
	[AppliesToElement(typeof(Link), "http://www.w3schools.com/tags/att_link_rel.asp")]
    [AttributeName("Rel")]
    internal class ResourceRelAttribute : AttributeDefinition
    {
        internal ResourceRelAttribute() : base("rel")
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
		internal TargetAttribute() : base("target")
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
	[AppliesToElementWithoutAttach(typeof(Style), "text/css", "http://www.w3schools.com/tags/att_style_type.asp")]
	[AttributeName("Type")]
	internal class MediaTypeAttribute : AttributeDefinition
	{
		internal MediaTypeAttribute()
			: base("type")
		{
		}
	}

	[OrderedListTypeEnumValidator]
	[AppliesToElement(typeof(Ol), "http://www.w3schools.com/tags/att_ol_type.asp")]
	[AttributeName("Type")]
	internal class OrderedListTypeAttribute : AttributeDefinition
	{
		internal OrderedListTypeAttribute() : base("type")
		{
		}
	}

	[AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/tag_area.asp")]
	[AppliesToElement(typeof(Img), "http://www.w3schools.com/tags/att_img_alt.asp")]
	[AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_alt.asp")]
	internal class AltAttribute : AttributeDefinition
	{
		internal AltAttribute() : base("alt")
		{
		}
	}

	[CoordsValidator(typeof(Tuple<int, int, int>), typeof(ShapeAttribute), Shape.Circle)]
    [CoordsValidator(typeof(Tuple<Point, int>), typeof(ShapeAttribute), Shape.Circle)]
	[CoordsValidator(typeof(Tuple<int, int, int, int>), typeof(ShapeAttribute), Shape.Rectangle)]
    [CoordsValidator(typeof(Tuple<Point, Point>), typeof(ShapeAttribute), Shape.Rectangle)]
	[CoordsValidator(typeof(Point[]), typeof(ShapeAttribute), Shape.Polygon)]
	[AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_coords.asp")]
	internal class CoordsAttribute : AttributeDefinition
	{
		internal CoordsAttribute() : base("coords")
		{
		}
	}

	[ShapeEnumValidator(typeof(CoordsAttribute))]
	[AppliesToElement(typeof(Area), "http://www.w3schools.com/tags/att_area_shape.asp")]
	internal class ShapeAttribute : AttributeDefinition
	{
		internal ShapeAttribute() : base("shape")
		{
		}
	}

	[AppliesToElement(typeof(Audio), "http://www.w3schools.com/tags/att_audio_autoplay.asp")]
	[AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_autoplay.asp")]
	internal class AutoPlayAttribute : AttributeDefinition
	{
		internal AutoPlayAttribute() : base("autoplay", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(Audio), "http://www.w3schools.com/tags/att_audio_controls.asp")]
	[AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_controls.asp")]
	internal class ControlsAttribute : AttributeDefinition
	{
		internal ControlsAttribute() : base("controls", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(Audio), "http://www.w3schools.com/tags/att_audio_loop.asp")]
	[AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_loop.asp")]
	internal class LoopAttribute : AttributeDefinition
	{
		internal LoopAttribute() : base("loop", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(Audio), "http://www.w3schools.com/tags/att_audio_muted.asp")]
	[AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_muted.asp")]
	internal class MutedAttribute : AttributeDefinition
	{
		internal MutedAttribute() : base("muted", AttributeValue.Forbidden)
		{
		}
	}

	[PreloadEnumValidator]
	[AppliesToElement(typeof(Audio), "http://www.w3schools.com/tags/att_audio_preload.asp")]
	[AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_preload.asp")]
	internal class PreloadAttribute : AttributeDefinition
	{
		internal PreloadAttribute() : base("preload")
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
		internal SrcAttribute() : base("src")
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
		internal CiteAttribute() : base("cite")
		{
		}
	}

	[DateTimeValidator]
	[AppliesToElement(typeof(Del), "http://www.w3schools.com/tags/att_del_datetime.asp")]
	[AppliesToElement(typeof(Ins), "http://www.w3schools.com/tags/att_ins_datetime.asp")]
	[AppliesToElement(typeof(Time), "http://www.w3schools.com/tags/att_time_datetime.asp")]
	internal class DateTimeAttribute : AttributeDefinition
	{
		internal DateTimeAttribute() : base("datetime")
		{
		}
	}

	[AppliesToElement(typeof(Details), "http://www.w3schools.com/tags/att_details_open.asp")]
	internal class OpenAttribute : AttributeDefinition
	{
		internal OpenAttribute() : base("open", AttributeValue.Forbidden)
		{
		}
	}

	[PositiveIntegerBaseZeroValidator]
	[AppliesToElement(typeof(Embed), "http://www.w3schools.com/tags/att_embed_height.asp")]
	[AppliesToElement(typeof(IFrame), "http://www.w3schools.com/tags/att_iframe_height.asp")]
	[AppliesToElement(typeof(Img), "http://www.w3schools.com/tags/att_img_height.asp")]
	[AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_height.asp")]
	[AppliesToElement(typeof(Object), "http://www.w3schools.com/tags/att_object_height.asp")]
	[AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_height.asp")]
	internal class HeightAttribute : AttributeDefinition
	{
		internal HeightAttribute() : base("height")
		{
		}
	}

	[PositiveIntegerBaseZeroValidator]
	[AppliesToElement(typeof(Embed), "http://www.w3schools.com/tags/att_embed_width.asp")]
	[AppliesToElement(typeof(IFrame), "http://www.w3schools.com/tags/att_iframe_width.asp")]
	[AppliesToElement(typeof(Img), "http://www.w3schools.com/tags/att_img_width.asp")]
	[AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_width.asp")]
	[AppliesToElement(typeof(Object), "http://www.w3schools.com/tags/att_object_width.asp")]
	[AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_width.asp")]
	internal class WidthAttribute : AttributeDefinition
	{
		internal WidthAttribute() : base("width")
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
		internal DisabledAttribute() : base("disabled", AttributeValue.Forbidden)
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
		internal FormAttribute() : base("form")
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
		internal NameAttribute() : base("name")
		{
		}
	}

	[CharSetValidator]
	[AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_accept_charset.asp")]
	[AppliesToElement(typeof(Script), "http://www.w3schools.com/tags/att_script_charset.asp")]
	internal class AcceptCharsetAttribute : AttributeDefinition
	{
		internal AcceptCharsetAttribute() : base("accept-charset")
		{
		}
	}

	[UrlValidator]
	[AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_action.asp")]
	internal class ActionAttribute : AttributeDefinition
	{
		internal ActionAttribute() : base("action")
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
		internal AutoCompleteAttribute() : base("autocomplete")
		{
		}
	}

	[EncodeTypeEnumValidator]
	[AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_enctype.asp")]
	internal class EncTypeAttribute : AttributeDefinition
	{
		internal EncTypeAttribute() : base("enctype")
		{
		}
	}

	[GetPostEnumValidator]
	[AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_method.asp")]
	internal class MethodAttribute : AttributeDefinition
	{
		internal MethodAttribute() : base("method")
		{
		}
	}

	[AppliesToElement(typeof(Form), "http://www.w3schools.com/tags/att_form_novalidate.asp")]
	internal class NoValidateAttribute : AttributeDefinition
	{
		internal NoValidateAttribute() : base("novalidate", AttributeValue.Forbidden)
		{
		}
	}

	[UrlValidator]
	[AppliesToElement(typeof(Html), "http://www.w3schools.com/tags/att_html_manifest.asp")]
	internal class ManifestAttribute : AttributeDefinition
	{
		internal ManifestAttribute() : base("manifest")
		{
		}
	}

	[XmlNsEnumValidator]
	[AppliesToElement(typeof(Html), "http://www.w3schools.com/tags/att_html_xmlns.asp")]
	internal class XmlNsAttribute : AttributeDefinition
	{
		internal XmlNsAttribute() : base("xmlns")
		{
		}
	}

	[SandboxEnumValidator]
	[AppliesToElement(typeof(IFrame), "http://www.w3schools.com/tags/att_iframe_sandbox.asp")]
	internal class SandboxAttribute : AttributeDefinition
	{
		internal SandboxAttribute() : base("sandbox")
		{
		}
	}

	[HtmlValidator]
	[AppliesToElement(typeof(IFrame), "http://www.w3schools.com/tags/att_iframe_srcdoc.asp")]
	internal class SrcDocAttribute : AttributeDefinition
	{
		internal SrcDocAttribute() : base("srcdoc")
		{
		}
	}

	[HashIdValidator]
	[AppliesToElement(typeof(Img), "http://www.w3schools.com/tags/att_img_usemap.asp")]
	[AppliesToElement(typeof(Object), "http://www.w3schools.com/tags/att_object_usemap.asp")]
	internal class UseMapAttribute : AttributeDefinition
	{
		internal UseMapAttribute() : base("usemap")
		{
		}
	}

	[AppliesToElement(typeof(Img), "http://www.w3schools.com/tags/att_img_ismap.asp")]
	internal class IsMapAttribute : AttributeDefinition
	{
		internal IsMapAttribute() : base("ismap", AttributeValue.Forbidden)
		{
		}
	}

	[AcceptTypesEnumValidator]
	[MediaTypeValidator]
	[AppliesToElement(typeof(FileInput), "http://www.w3schools.com/tags/att_input_accept.asp")]
	internal class AcceptAttribute : AttributeDefinition
	{
		internal AcceptAttribute() : base("accept")
		{
		}
	}

	[AppliesToElement(typeof(VisibleInput), "http://www.w3schools.com/tags/att_input_autofocus.asp")]
	[AppliesToElement(typeof(KeyGen), "http://www.w3schools.com/tags/att_keygen_autofocus.asp")]
	[AppliesToElement(typeof(Select), "http://www.w3schools.com/tags/att_select_autofocus.asp")]
	[AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_autofocus.asp")]
	internal class AutoFocusAttribute : AttributeDefinition
	{
		internal AutoFocusAttribute() : base("autofocus", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(CheckboxInput), "http://www.w3schools.com/tags/att_input_checked.asp")]
	[AppliesToElement(typeof(RadioInput), "http://www.w3schools.com/tags/att_input_checked.asp")]
	internal class CheckedAttribute : AttributeDefinition
	{
		internal CheckedAttribute() : base("checked", AttributeValue.Forbidden)
		{
		}
	}

	[UrlValidator]
	[AppliesToElement(typeof(SubmitInput), "http://www.w3schools.com/tags/att_input_formaction.asp")]
	[AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_formaction.asp")]
	internal class FormActionAttribute : AttributeDefinition
	{
		internal FormActionAttribute() : base("formaction")
		{
		}
	}

	[EncodeTypeEnumValidator]
	[AppliesToElement(typeof(SubmitInput), "http://www.w3schools.com/tags/att_input_formenctype.asp")]
	[AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_formenctype.asp")]
	internal class FormEncTypeAttribute : AttributeDefinition
	{
		internal FormEncTypeAttribute() : base("formenctype")
		{
		}
	}

	[GetPostEnumValidator]
	[AppliesToElement(typeof(SubmitInput), "http://www.w3schools.com/tags/att_input_formmethod.asp")]
	[AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_formmethod.asp")]
	internal class FormMethodAttribute : AttributeDefinition
	{
		internal FormMethodAttribute() : base("formmethod")
		{
		}
	}

	[AppliesToElement(typeof(SubmitInput), "http://www.w3schools.com/tags/att_input_formnovalidate.asp")]
	internal class FormNoValidateAttribute : AttributeDefinition
	{
		internal FormNoValidateAttribute() : base("formnovalidate", AttributeValue.Forbidden)
		{
		}
	}

	[TargetValidator]
	[AppliesToElement(typeof(SubmitInput), "http://www.w3schools.com/tags/att_input_formtarget.asp")]
	[AppliesToElement(typeof(ImageInput), "http://www.w3schools.com/tags/att_input_formtarget.asp")]
	internal class FormTargetAttribute : AttributeDefinition
	{
		internal FormTargetAttribute() : base("formtarget")
		{
		}
	}

	[IdValidator]
	[AppliesToElement(typeof(VisibleInput), "http://www.w3schools.com/tags/att_input_list.asp")]
	internal class ListAttribute : AttributeDefinition
	{
		internal ListAttribute() : base("list")
		{
		}
	}

	[DecimalValidator]
	[IntegerValidator]
	[AppliesToElement(typeof(NumberInput), "http://www.w3schools.com/tags/att_input_max.asp")]
	[AppliesToElement(typeof(RangeInput), "http://www.w3schools.com/tags/att_input_max.asp")]
	[AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_max.asp")]
	[AppliesToElement(typeof(Progress), "http://www.w3schools.com/tags/att_progress_max.asp")]
	[AttributeName("Max")]
	internal class MaxNumberAttribute : AttributeDefinition
	{
		internal MaxNumberAttribute() : base("max")
		{
		}
	}

	[DateTimeValidator]
	[AppliesToElement(typeof(DateTypeInput), "http://www.w3schools.com/tags/att_input_max.asp")]
	[AttributeName("Max")]
	internal class MaxDateAttribute : AttributeDefinition
	{
		internal MaxDateAttribute() : base("max")
		{
		}
	}

	[DecimalValidator]
	[IntegerValidator]
	[AppliesToElement(typeof(NumberInput), "http://www.w3schools.com/tags/att_input_min.asp")]
	[AppliesToElement(typeof(RangeInput), "http://www.w3schools.com/tags/att_input_min.asp")]
	[AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_min.asp")]
	[AttributeName("Min")]
	internal class MinNumberAttribute : AttributeDefinition
	{
		internal MinNumberAttribute() : base("min")
		{
		}
	}

	[DateTimeValidator]
	[AppliesToElement(typeof(DateTypeInput), "http://www.w3schools.com/tags/att_input_min.asp")]
	[AttributeName("Min")]
	internal class MinDateAttribute : AttributeDefinition
	{
		internal MinDateAttribute() : base("min")
		{
		}
	}

	[DecimalValidator]
	[IntegerValidator]
	[AppliesToElement(typeof(VisibleInput), "http://www.w3schools.com/tags/att_input_maxlength.asp")]
	[AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_maxlength.asp")]
	internal class MaxLengthAttribute : AttributeDefinition
	{
		internal MaxLengthAttribute() : base("maxlength")
		{
		}
	}

	[AppliesToElement(typeof(EmailInput), "http://www.w3schools.com/tags/att_input_multiple.asp")]
	[AppliesToElement(typeof(FileInput), "http://www.w3schools.com/tags/att_input_multiple.asp")]
	[AppliesToElement(typeof(Select), "http://www.w3schools.com/tags/att_select_multiple.asp")]
	internal class MultipleAttribute : AttributeDefinition
	{
		internal MultipleAttribute() : base("multiple", AttributeValue.Forbidden)
		{
		}
	}

	[PatternValidator]
    [AppliesToElement(typeof(TextTypeInput), "http://www.w3schools.com/tags/att_input_pattern.asp")]
	internal class PatternAttribute : AttributeDefinition
	{
		internal PatternAttribute() : base("pattern")
		{
		}
	}

	[AppliesToElement(typeof(TextTypeInput), "http://www.w3schools.com/tags/att_input_placeholder.asp")]
	[AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_placeholder.asp")]
	internal class PlaceHolderAttribute : AttributeDefinition
	{
		internal PlaceHolderAttribute() : base("placeholder")
		{
		}
	}

	[AppliesToElement(typeof(VisibleInput), "http://www.w3schools.com/tags/att_input_readonly.asp")]
	[AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_readonly.asp")]
	internal class ReadonlyAttribute : AttributeDefinition
	{
		internal ReadonlyAttribute() : base("readonly", AttributeValue.Forbidden)
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
		internal RequiredAttribute() : base("required", AttributeValue.Forbidden)
		{
		}
	}

	[PositiveIntegerBaseOneValidator]
    [AppliesToElement(typeof(TextTypeInput), "http://www.w3schools.com/tags/att_input_size.asp")]
	[AppliesToElement(typeof(Select), "http://www.w3schools.com/tags/att_select_size.asp")]
	internal class SizeAttribute : AttributeDefinition
	{
		internal SizeAttribute() : base("size")
		{
		}
	}

	[PositiveIntegerBaseOneValidator]
    [AppliesToElement(typeof(NumberInput), "http://www.w3schools.com/tags/att_input_step.asp")]
	[AppliesToElement(typeof(RangeInput), "http://www.w3schools.com/tags/att_input_step.asp")]
	[AppliesToElement(typeof(DateTypeInput), "http://www.w3schools.com/tags/att_input_step.asp")]
	internal class StepAttribute : AttributeDefinition
	{
		internal StepAttribute() : base("step")
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
	internal class TextValueAttribute : AttributeDefinition
	{
		internal TextValueAttribute() : base("value")
		{
		}
	}

	[DateTimeValidator]
    [AppliesToElement(typeof(DateTypeInput), "http://www.w3schools.com/tags/att_input_value.asp")]
	[AttributeName("Value")]
	internal class DateValueAttribute : AttributeDefinition
	{
		internal DateValueAttribute() : base("value")
		{
		}
	}

	[ColorValidator]
    [AppliesToElement(typeof(ColorInput), "http://www.w3schools.com/tags/att_input_value.asp")]
	[AttributeName("Value")]
	internal class ColorValueAttribute : AttributeDefinition
	{
		internal ColorValueAttribute() : base("value")
		{
		}
	}

	[DecimalValidator]
	[IntegerValidator]
	[AppliesToElement(typeof(NumberInput), "http://www.w3schools.com/tags/att_input_value.asp")]
	[AppliesToElement(typeof(RangeInput), "http://www.w3schools.com/tags/att_input_value.asp")]
	[AppliesToElement(typeof(Li), "http://www.w3schools.com/tags/att_li_value.asp")]
	[AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_value.asp")]
	[AppliesToElement(typeof(Progress), "http://www.w3schools.com/tags/att_progress_value.asp")]
	[AttributeName("Value")]
	internal class NumberValueAttribute : AttributeDefinition
	{
		internal NumberValueAttribute() : base("value")
		{
		}
	}

	[KeyTypeEnumValidator]
    [AppliesToElement(typeof(KeyGen), "http://www.w3schools.com/tags/att_keygen_keytype.asp")]
	internal class KeyTypeAttribute : AttributeDefinition
	{
		internal KeyTypeAttribute() : base("keytype")
		{
		}
	}

	[IdValidator]
    [AppliesToElement(typeof(Label), "http://www.w3schools.com/tags/att_label_for.asp")]
	[AttributeName("For")]
	internal class ForOneAttribute : AttributeDefinition
	{
		internal ForOneAttribute() : base("for")
		{
		}
	}

    [IdListValidatorAttribute]
    [AppliesToElement(typeof(Output), "http://www.w3schools.com/tags/att_label_for.asp")]
	[AttributeName("For")]
	internal class ForManyAttribute : AttributeDefinition
	{
		internal ForManyAttribute() : base("for")
		{
		}
	}

	[CharSetValidator]
    [AppliesToElement(typeof(Meta), "http://www.w3schools.com/tags/att_meta_charset.asp")]
	internal class CharSetAttribute : AttributeDefinition
	{
		internal CharSetAttribute() : base("charset")
		{
		}
	}

	[AppliesToElement(typeof(Meta), "http://www.w3schools.com/tags/att_meta_content.asp")]
	internal class ContentAttribute : AttributeDefinition
	{
		internal ContentAttribute() : base("content")
		{
		}
	}

	[HttpEquivEnumValidator]
    [AppliesToElement(typeof(Meta), "http://www.w3schools.com/tags/att_meta_http_equiv.asp")]
	internal class HttpEquivAttribute : AttributeDefinition
	{
		internal HttpEquivAttribute() : base("http-equiv")
		{
		}
	}

	[DecimalValidator]
	[IntegerValidator]
	[AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_high.asp")]
	internal class HighAttribute : AttributeDefinition
	{
		internal HighAttribute() : base("high")
		{
		}
	}

	[DecimalValidator]
	[IntegerValidator]
	[AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_low.asp")]
	internal class LowAttribute : AttributeDefinition
	{
		internal LowAttribute() : base("low")
		{
		}
	}

	[DecimalValidator]
	[IntegerValidator]
	[AppliesToElement(typeof(Meter), "http://www.w3schools.com/tags/att_meter_optimum.asp")]
	internal class OptimumAttribute : AttributeDefinition
	{
		internal OptimumAttribute() : base("optimum")
		{
		}
	}

	[AppliesToElement(typeof(Ol), "http://www.w3schools.com/tags/att_ol_reversed.asp")]
	internal class ReversedAttribute : AttributeDefinition
	{
		internal ReversedAttribute() : base("reversed", AttributeValue.Forbidden)
		{
		}
	}

	[DecimalValidator]
	[IntegerValidator]
	[AppliesToElement(typeof(Ol), "http://www.w3schools.com/tags/att_ol_start.asp")]
	internal class StartAttribute : AttributeDefinition
	{
		internal StartAttribute() : base("start")
		{
		}
	}

	[AppliesToElement(typeof(OptGroup), "http://www.w3schools.com/tags/att_optgroup_label.asp")]
	[AppliesToElement(typeof(Option), "http://www.w3schools.com/tags/att_option_label.asp")]
	[AppliesToElement(typeof(Track), "http://www.w3schools.com/tags/att_track_label.asp")]
	internal class LabelAttribute : AttributeDefinition
	{
		internal LabelAttribute() : base("label")
		{
		}
	}

	[AppliesToElement(typeof(Option), "http://www.w3schools.com/tags/att_option_selected.asp")]
	internal class SelectedAttribute : AttributeDefinition
	{
		internal SelectedAttribute() : base("selected", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(Script), "http://www.w3schools.com/tags/att_script_async.asp")]
	internal class AsyncAttribute : AttributeDefinition
	{
		internal AsyncAttribute() : base("async", AttributeValue.Forbidden)
		{
		}
	}

	[AppliesToElement(typeof(Script), "http://www.w3schools.com/tags/att_script_defer.asp")]
	internal class DeferAttribute : AttributeDefinition
	{
		internal DeferAttribute() : base("defer", AttributeValue.Forbidden)
		{
		}
	}

	[PositiveIntegerBaseZeroValidator]
    [AppliesToElement(typeof(Td), "http://www.w3schools.com/tags/att_td_colspan.asp")]
	[AppliesToElement(typeof(Th), "http://www.w3schools.com/tags/att_th_colspan.asp")]
	internal class ColSpanAttribute : AttributeDefinition
	{
		internal ColSpanAttribute() : base("colspan")
		{
		}
	}

	[IdListValidator]
    [AppliesToElement(typeof(Td), "http://www.w3schools.com/tags/att_td_headers.asp")]
	[AppliesToElement(typeof(Th), "http://www.w3schools.com/tags/att_th_headers.asp")]
	internal class HeadersAttribute : AttributeDefinition
	{
		internal HeadersAttribute() : base("headers")
		{
		}
	}

	[PositiveIntegerBaseZeroValidator]
    [AppliesToElement(typeof(Td), "http://www.w3schools.com/tags/att_td_rowspan.asp")]
	[AppliesToElement(typeof(Th), "http://www.w3schools.com/tags/att_th_rowspan.asp")]
	internal class RowSpanAttribute : AttributeDefinition
	{
		internal RowSpanAttribute() : base("rowspan")
		{
		}
	}

	[PositiveIntegerBaseOneValidator]
    [AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_cols.asp")]
	internal class ColsAttribute : AttributeDefinition
	{
		internal ColsAttribute() : base("cols")
		{
		}
	}

	[PositiveIntegerBaseOneValidator]
    [AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_rows.asp")]
	internal class RowsAttribute : AttributeDefinition
	{
		internal RowsAttribute() : base("rows")
		{
		}
	}

	[SoftHardEnumValidator]
    [AppliesToElement(typeof(TextArea), "http://www.w3schools.com/tags/att_textarea_wrap.asp")]
	internal class WrapAttribute : AttributeDefinition
	{
		internal WrapAttribute() : base("wrap")
		{
		}
	}

	[AppliesToElement(typeof(Th), "http://www.w3schools.com/tags/att_th_abbr.asp")]
	internal class AbbrAttribute : AttributeDefinition
	{
		internal AbbrAttribute() : base("abbr")
		{
		}
	}

	[ScopeEnumValidator]
    [AppliesToElement(typeof(Th), "http://www.w3schools.com/tags/att_th_scope.asp")]
	internal class ScopeAttribute : AttributeDefinition
	{
		internal ScopeAttribute() : base("scope")
		{
		}
	}

	[AppliesToElement(typeof(Track), "http://www.w3schools.com/tags/att_track_default.asp")]
	internal class DefaultAttribute : AttributeDefinition
	{
		internal DefaultAttribute() : base("default", AttributeValue.Forbidden)
		{
		}
	}

	[TrackKindEnumValidator]
    [AppliesToElement(typeof(Track), "http://www.w3schools.com/tags/att_track_kind.asp")]
	internal class KindAttribute : AttributeDefinition
	{
		internal KindAttribute() : base("kind")
		{
		}
	}

	[LanguageCodeValidator]
    [AppliesToElement(typeof(Track), "http://www.w3schools.com/tags/att_track_srclang.asp")]
	internal class SrcLangAttribute : AttributeDefinition
	{
		internal SrcLangAttribute() : base("srclang")
		{
		}
	}

    [UrlValidator]
	[AppliesToElement(typeof(Video), "http://www.w3schools.com/tags/att_video_poster.asp")]
	internal class PosterAttribute : AttributeDefinition
	{
		internal PosterAttribute() : base("poster")
		{
		}
	}
}
 