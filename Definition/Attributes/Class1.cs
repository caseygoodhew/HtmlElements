using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Definition.Validation;

namespace Definition.Attributes
{
	internal enum XAttributeValidation
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
}
