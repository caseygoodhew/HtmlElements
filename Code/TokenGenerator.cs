using System;

namespace Coding
{
	internal static class TokenGenerator
	{
		public static Token Get(Tokens token)
		{
			switch (token)
			{
				case Tokens.EndSection:
				case Tokens.NewLine:
					return new NewLineToken();
				case Tokens.Space:
					return new SpaceToken();
				case Tokens.TerminatingComma:
				case Tokens.Comma:
					return new CommaToken();
				case Tokens.Colon:
					return new ColonToken();
				case Tokens.SemiColon:
					return new SemiColonToken();
				case Tokens.OpenBracket:
					return new OpenBracketToken();
				case Tokens.CloseBracket:
					return new CloseBracketToken();
				case Tokens.OpenAngle:
					return new OpenAngleToken();
				case Tokens.CloseAngle:
					return new CloseAngleToken();
				case Tokens.OpenCurly:
					return new OpenCurlyToken();
				case Tokens.CloseCurly:
					return new CloseCurlyToken();
				case Tokens.Dot:
					return new DotToken();
				case Tokens.QuestionMark:
					return new QuestionMarkToken();
				case Tokens.Equals:
					return new EqualsToken();
				case Tokens.NotEquals:
					return new NotEqualsToken();
				case Tokens.GreaterThan:
					return new GreaterThanToken();
				case Tokens.GreaterThanOrEqual:
					return new GreaterThanOrEqualToken();
				case Tokens.LessThan:
					return new LessThanToken();
				case Tokens.LessThanOrEqual:
					return new LessThanOrEqualToken();
				case Tokens.Null:
					return new NullToken();
				case Tokens.Nullable:
					return new NullableToken();
				case Tokens.True:
					return new TrueToken();
				case Tokens.False:
					return new FalseToken();
				case Tokens.Return:
					return new ReturnToken();
				case Tokens.New:
					return new NewToken();
				case Tokens.If:
					return new IfToken();
				case Tokens.ElseIf:
					return new ElseIfToken();
				case Tokens.Else:
					return new ElseToken();
				case Tokens.Switch:
					return new SwitchToken();
				case Tokens.Case:
					return new CaseToken();
				case Tokens.Default:
					return new DefaultToken();
				case Tokens.Override:
					return new OverrideToken();
				case Tokens.Public:
					return new PublicToken();
				case Tokens.Internal:
					return new InternalToken();
				case Tokens.Private:
					return new PrivateToken();
				case Tokens.Protected:
					return new ProtectedToken();
				case Tokens.Class:
					return new ClassToken();
				case Tokens.Enum:
					return new EnumToken();
				case Tokens.Namespace:
					return new NamespaceToken();
				case Tokens.Using:
					return new UsingToken();
				case Tokens.Var:
					return new VarToken();
				case Tokens.Readonly:
					return new ReadonlyToken();
				case Tokens.Static:
					return new StaticToken();
				case Tokens.Abstract:
					return new AbstractToken();
				case Tokens.Get:
					return new GetToken();
				case Tokens.Set:
					return new SetToken();
				case Tokens.Tab:
					return new TabToken();
				case Tokens.StaticReadonly:
					return new StaticReadonlyToken();
				case Tokens.Empty:
					return new EmptyToken();
				case Tokens.Base:
					return new BaseToken();
				case Tokens.This:
					return new ThisToken();
				case Tokens.Interface:
					return new InterfaceToken();
				case Tokens.Struct:
					return new StructToken();
				case Tokens.Where:
					return new WhereToken();
				case Tokens.GenericNew:
					return new GenericNewToken();
				default:
					throw new ArgumentOutOfRangeException("token");
			}
		}
		
		public static Token GetPrefix(Tokens token)
		{
			switch (token)
			{
				case Tokens.Colon:
				case Tokens.QuestionMark:
				case Tokens.Equals:
				case Tokens.NotEquals:
				case Tokens.GreaterThan:
				case Tokens.GreaterThanOrEqual:
				case Tokens.LessThan:
				case Tokens.LessThanOrEqual:
				case Tokens.Null:
				case Tokens.True:
				case Tokens.False:
				case Tokens.Return:
				case Tokens.New:
				case Tokens.If:
				case Tokens.ElseIf:
				case Tokens.Else:
				case Tokens.Switch:
				case Tokens.Case:
				case Tokens.Override:
				case Tokens.Class:
				case Tokens.Enum:
				case Tokens.Var:
				case Tokens.Readonly:
				case Tokens.Static:
				case Tokens.Abstract:
				case Tokens.Get:
				case Tokens.Set:
				case Tokens.StaticReadonly:
				case Tokens.Base:
				case Tokens.This:
				case Tokens.Interface:
				case Tokens.Struct:
				case Tokens.Where:
				case Tokens.GenericNew:
					return new SpaceToken();
				case Tokens.Namespace:
				case Tokens.Using:
				case Tokens.Public:
				case Tokens.Internal:
				case Tokens.Private:
				case Tokens.Protected:
				case Tokens.OpenCurly:
				case Tokens.CloseCurly:
					return new NewLineToken();
				default:
					return new EmptyToken();
			}
		}

		public static Token GetPostfix(Tokens token)
		{
			switch (token)
			{
				case Tokens.Colon:
				case Tokens.Comma:
				case Tokens.QuestionMark:
				case Tokens.Nullable:
				case Tokens.Equals:
				case Tokens.NotEquals:
				case Tokens.GreaterThan:
				case Tokens.GreaterThanOrEqual:
				case Tokens.LessThan:
				case Tokens.LessThanOrEqual:
				case Tokens.Return:
				case Tokens.New:
				case Tokens.If:
				case Tokens.ElseIf:
				case Tokens.Else:
				case Tokens.Switch:
				case Tokens.Case:
				case Tokens.Override:
				case Tokens.Public:
				case Tokens.Internal:
				case Tokens.Private:
				case Tokens.Protected:
				case Tokens.Class:
				case Tokens.Enum:
				case Tokens.Namespace:
				case Tokens.Using:
				case Tokens.Var:
				case Tokens.Readonly:
				case Tokens.Static:
				case Tokens.Abstract:
				case Tokens.Get:
				case Tokens.Set:
				case Tokens.Interface:
				case Tokens.Struct:
				case Tokens.StaticReadonly:
				case Tokens.Where:
					return new SpaceToken();
				case Tokens.OpenCurly:
				case Tokens.CloseCurly:
				case Tokens.TerminatingComma:
					return new NewLineToken();
				default:
					return new EmptyToken();
			}
		}
	}
}