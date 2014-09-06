using System;
using Coding.Tokens;

namespace Coding
{
    internal static class TokenGenerator
    {
        public static TokenBase Get(Token token)
        {
            switch (token)
            {
                case Token.EndSection:
                case Token.NewLine:
                    return new NewLineToken();
                case Token.Space:
                    return new SpaceToken();
                case Token.TerminatingComma:
                case Token.Comma:
                    return new CommaToken();
                case Token.Colon:
                    return new ColonToken();
                case Token.TerminatingSemiColon:
                case Token.SemiColon:
                    return new SemiColonToken();
                case Token.OpenBracket:
                    return new OpenBracketToken();
                case Token.CloseBracket:
                    return new CloseBracketToken();
                case Token.OpenAngle:
                    return new OpenAngleToken();
                case Token.CloseAngle:
                    return new CloseAngleToken();
                case Token.OpenCurly:
                    return new OpenCurlyToken();
                case Token.CloseCurly:
                    return new CloseCurlyToken();
                case Token.Dot:
                    return new DotToken();
                case Token.QuestionMark:
                    return new QuestionMarkToken();
                case Token.Equals:
                    return new EqualsToken();
                case Token.NotEquals:
                    return new NotEqualsToken();
                case Token.GreaterThan:
                    return new GreaterThanToken();
                case Token.GreaterThanOrEqual:
                    return new GreaterThanOrEqualToken();
                case Token.LessThan:
                    return new LessThanToken();
                case Token.LessThanOrEqual:
                    return new LessThanOrEqualToken();
                case Token.Null:
                    return new NullToken();
                case Token.Nullable:
                    return new NullableToken();
                case Token.True:
                    return new TrueToken();
                case Token.False:
                    return new FalseToken();
                case Token.Return:
                    return new ReturnToken();
                case Token.New:
                    return new NewToken();
                case Token.If:
                    return new IfToken();
                case Token.ElseIf:
                    return new ElseIfToken();
                case Token.Else:
                    return new ElseToken();
                case Token.Switch:
                    return new SwitchToken();
                case Token.Case:
                    return new CaseToken();
                case Token.Default:
                    return new DefaultToken();
                case Token.Override:
                    return new OverrideToken();
                case Token.Public:
                    return new PublicToken();
                case Token.Internal:
                    return new InternalToken();
                case Token.Private:
                    return new PrivateToken();
                case Token.Protected:
                    return new ProtectedToken();
                case Token.Class:
                    return new ClassToken();
                case Token.Enum:
                    return new EnumToken();
                case Token.Namespace:
                    return new NamespaceToken();
                case Token.Using:
                    return new UsingToken();
                case Token.Var:
                    return new VarToken();
                case Token.Readonly:
                    return new ReadonlyToken();
                case Token.Static:
                    return new StaticToken();
                case Token.Abstract:
                    return new AbstractToken();
                case Token.Get:
                    return new GetToken();
                case Token.Set:
                    return new SetToken();
                case Token.Tab:
                    return new TabToken();
                case Token.StaticReadonly:
                    return new StaticReadonlyToken();
                case Token.Empty:
                    return new EmptyToken();
                case Token.Base:
                    return new BaseToken();
                case Token.This:
                    return new ThisToken();
                case Token.Interface:
                    return new InterfaceToken();
                case Token.Struct:
                    return new StructToken();
                case Token.Where:
                    return new WhereToken();
                case Token.GenericNew:
                    return new GenericNewToken();
                case Token.Void:
                    return new VoidToken();
                case Token.Virtual:
                    return new VirtualToken();
                case Token.UShort:
                    return new UShortToken();
                case Token.Int:
                    return new IntToken();
                case Token.UInt:
                    return new UIntToken();
                case Token.Long:
                    return new LongToken();
                case Token.Char:
                    return new CharToken();
                case Token.Byte:
                    return new ByteToken();
                case Token.Bool:
                    return new BoolToken();
                case Token.ULong:
                    return new ULongToken();
                case Token.Short:
                    return new ShortToken();
                case Token.SByte:
                    return new SByteToken();
                case Token.Float:
                    return new FloatToken();
                case Token.String:
                    return new StringToken();
                case Token.Double:
                    return new DoubleToken();
                case Token.Decimal:
                    return new DecimalToken();
                case Token.Object:
                    return new ObjectToken();
                case Token.Dynamic:
                    return new DynamicToken();
                case Token.Delegate:
                    return new DelegateToken();
                default:
                    throw new ArgumentOutOfRangeException("token");
            }
        }
        
        public static TokenBase GetPrefix(Token token)
        {
            switch (token)
            {
                case Token.Colon:
                case Token.QuestionMark:
                case Token.Equals:
                case Token.NotEquals:
                case Token.GreaterThan:
                case Token.GreaterThanOrEqual:
                case Token.LessThan:
                case Token.LessThanOrEqual:
                case Token.Null:
                case Token.True:
                case Token.False:
                case Token.Return:
                case Token.New:
                case Token.If:
                case Token.ElseIf:
                case Token.Else:
                case Token.Switch:
                case Token.Case:
                case Token.Override:
                case Token.Class:
                case Token.Enum:
                case Token.Var:
                case Token.Readonly:
                case Token.Static:
                case Token.Abstract:
                case Token.Get:
                case Token.Set:
                case Token.StaticReadonly:
                case Token.Base:
                case Token.This:
                case Token.Interface:
                case Token.Struct:
                case Token.Where:
                case Token.GenericNew:
                case Token.Void:
                case Token.Virtual:
                case Token.UShort:
                case Token.Int:
                case Token.UInt:
                case Token.Long:
                case Token.Char:
                case Token.Byte:
                case Token.Bool:
                case Token.ULong:
                case Token.Short:
                case Token.SByte:
                case Token.Float:
                case Token.String:
                case Token.Double:
                case Token.Decimal:
                case Token.Object:
                case Token.Dynamic:
                case Token.Delegate:
                    return new SpaceToken();
                case Token.Namespace:
                case Token.Public:
                case Token.Internal:
                case Token.Private:
                case Token.Protected:
                case Token.OpenCurly:
                case Token.CloseCurly:
                    return new NewLineToken();
                default:
                    return new EmptyToken();
            }
        }

        public static TokenBase GetPostfix(Token token)
        {
            switch (token)
            {
                case Token.Colon:
                case Token.Comma:
                case Token.QuestionMark:
                case Token.Nullable:
                case Token.Equals:
                case Token.NotEquals:
                case Token.GreaterThan:
                case Token.GreaterThanOrEqual:
                case Token.LessThan:
                case Token.LessThanOrEqual:
                case Token.Return:
                case Token.New:
                case Token.If:
                case Token.ElseIf:
                case Token.Else:
                case Token.Switch:
                case Token.Case:
                case Token.Override:
                case Token.Public:
                case Token.Internal:
                case Token.Private:
                case Token.Protected:
                case Token.Class:
                case Token.Enum:
                case Token.Namespace:
                case Token.Using:
                case Token.Var:
                case Token.Readonly:
                case Token.Static:
                case Token.Abstract:
                case Token.Get:
                case Token.Set:
                case Token.Interface:
                case Token.Struct:
                case Token.StaticReadonly:
                case Token.Where:
                case Token.Void:
                case Token.Virtual:
                case Token.This:
                case Token.Base:
                case Token.UShort:
                case Token.Int:
                case Token.UInt:
                case Token.Long:
                case Token.Char:
                case Token.Byte:
                case Token.Bool:
                case Token.ULong:
                case Token.Short:
                case Token.SByte:
                case Token.Float:
                case Token.String:
                case Token.Double:
                case Token.Decimal:
                case Token.Object:
                case Token.Dynamic:
                case Token.Delegate:
                    return new SpaceToken();
                case Token.OpenCurly:
                case Token.CloseCurly:
                case Token.TerminatingComma:
                case Token.TerminatingSemiColon:
                    return new NewLineToken();
                default:
                    return new EmptyToken();
            }
        }
    }
}