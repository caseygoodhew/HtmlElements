using System.Collections.Generic;
using System.Linq;

using Coding.Tokens;

namespace Coding.Builder
{
    internal static class TidyExtensions
    {
        internal static List<TokenBase> CleanEmptyTokens(this List<TokenBase> source)
        {
            return source.Where(token => !token.Is<EmptyToken>()).ToList();
        }

        internal static List<TokenBase> TrimWhitespace(this List<TokenBase> source)
        {
            var start = 0;
            var end = source.Count - 1;

            for (var i = start; i < end; i++)
            {
                if (!source[i].Is<WhitespaceToken>())
                {
                    start = i;
                    break;
                }
            }

            for (var i = end; i > start; i--)
            {
                if (!source[i].Is<WhitespaceToken>())
                {
                    end = i;
                    break;
                }
            }

            return source.GetRange(start, end - start + 1);
        }
        
        internal static List<TokenBase> CleanExtraSpaces(this List<TokenBase> source)
        {
            var result = new List<TokenBase>();
            
            for (var i = 0; i < source.Count() - 1; i++)
            {
                var token = source[i];

                if (!token.Is<SpaceToken>())
                {
                    result.Add(token);
                    continue;
                }

                var nextToken = source[i + 1];

                if (!nextToken.Is<SpaceToken>())
                {
                    result.Add(token);
                }
            }

            result.Add(source[source.Count - 1]);

            return result;
        }

        internal static List<TokenBase> CleanRepeatingLineBreaks(this List<TokenBase> source)
        {
            var result = new List<TokenBase> { source[0] };

            for (var i = 1; i < source.Count() - 1; i++)
            {
                var token = source[i];
                
                if (!token.Is<NewLineToken>())
                {
                    result.Add(token);
                    continue;
                }

                var prevToken = source[i - 1];

                if (!prevToken.Is<NewLineToken>())
                {
                    result.Add(token);
                    continue;
                }
                
                var nextToken = source[i + 1];

                if (!nextToken.Is<NewLineToken>())
                {
                    result.Add(token);
                }
            }

            result.Add(source[source.Count - 1]);

            return result;
        }

        internal static List<TokenBase> CleanCurlyLineBreaks(this List<TokenBase> source)
        {
            var result = new List<TokenBase> { source[0] };

            for (var i = 1; i < source.Count() - 1; i++)
            {
                var token = source[i];
                
                if (token.Is<NewLineToken>())
                {
                    var prevToken = source[i - 1];
                    var nextToken = source[i + 1];

                    if (prevToken.Is<NewLineToken>() && nextToken.Is<CloseCurlyToken>())
                    {
                        continue;
                    }

                    if (prevToken.Is<OpenCurlyToken>() && nextToken.Is<NewLineToken>())
                    {
                        continue;
                    }
                }

                result.Add(token);
            }

            result.Add(source[source.Count - 1]);

            for (var i = result.Count - 2; i >= 0; i--)
            {
                var token = result[i];
                var nextToken = result[i+1];

                if (token.Is<OpenCurlyToken>() && nextToken.Is<CloseCurlyToken>())
                {
                    result.Insert(i+1, new NewLineToken());
                }
            }

            return result;
        }

        internal static List<TokenBase> CleanPunctuationSpacing(this List<TokenBase> source)
        {
            var result = new List<TokenBase>();

            for (var i = 0; i < source.Count; i++)
            {
                var token = source[i];
                var prevToken = i > 0 ? source[i - 1] : new EmptyToken();
                var nextToken = i + 1 < source.Count ? source[i + 1] : new EmptyToken();

                if (token.Is<SpaceToken>())
                {
                    if (nextToken.Is<DotToken>() ||
                        nextToken.Is<CommaToken>() ||
                        nextToken.Is<SemiColonToken>() ||
                        nextToken.Is<OpenSquareToken>() ||
                        nextToken.Is<OpenAngleToken>() ||
                        nextToken.Is<CloseAngleToken>())
                    {
                        continue;
                    }

                    if (nextToken.Is<OpenBracketToken>())
                    {
                        if (prevToken.Is<WordToken>() || 
                            prevToken.Is<CloseAngleToken>() || 
                            prevToken.Is<OpenBracketToken>() ||
                            prevToken.Is<CloseBracketToken>())
                        {
                            continue;
                        }
                    }

                    if (nextToken.Is<ThisToken>() || nextToken.Is<BaseToken>() || nextToken.Is<ParamsToken>())
                    {
                        if (prevToken.Is<OpenBracketToken>())
                        {
                            continue;
                        }
                    }

                    if (nextToken.Is<CloseBracketToken>())
                    {
                        if (prevToken.Is<CloseBracketToken>() ||
                            prevToken.Is<OpenBracketToken>() ||
                            prevToken.Is<WordToken>())
                        {
                            continue;
                        }
                    }

                    if (prevToken.Is<DotToken>() || prevToken.Is<TabToken>() || prevToken.Is<NewLineToken>() || prevToken.Is<ExclamationToken>() || prevToken.Is<OpenBracketToken>())
                    {
                        continue;
                    }
                }

                result.Add(token);
            }

            return result;
        }

        internal static List<TokenBase> AddIndentation(this List<TokenBase> source)
        {
            var result = new List<TokenBase>();
            var indent = 0;

            foreach (var token in source)
            {
                if (token.Is<EmptyToken>())
                {
                    continue;
                }

                if (token.Is<CloseCurlyToken>())
                {
                    var prevToken = result[result.Count - 1];
                    if (prevToken.Is<TabToken>())
                    {
                        result.RemoveAt(result.Count - 1);
                    }
                    indent--;
                }

                result.Add(token);

                if (token.Is<NewLineToken>())
                {
                    result.AddRange(Enumerable.Repeat(new TabToken(), indent));
                }

                if (token.Is<OpenCurlyToken>())
                {
                    indent++;
                }
            }

            return result;
        }

        internal static List<TokenBase> Stub(this List<TokenBase> source)
        {
            // just here so that we can comment out other tidy functions for testing
            return source;
        }
    }
}