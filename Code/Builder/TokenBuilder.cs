﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Coding.Tokens;

namespace Coding.Builder
{
    public class TokenBuilder
    {
        private readonly List<TokenBase> tokens = new List<TokenBase>();

        public TokenBuilder Literal(char value)
        {
            Add(Token.SingleQuote);
            tokens.Add(new WordToken(value.ToString(CultureInfo.InvariantCulture)));
            return Add(Token.SingleQuote); 
        }

        public TokenBuilder Literal(string value)
        {
            Add(Token.DoubleQuote);
            tokens.Add(new WordToken(value));
            return Add(Token.DoubleQuote);
        }
        
        public TokenBuilder Add(string value)
        {
            tokens.Add(new WordToken(value));
            return Add(Token.Space);
        }

        public TokenBuilder Add(Token token)
        {
            tokens.Add(TokenGenerator.GetPrefix(token));
            tokens.Add(TokenGenerator.Get(token));
            tokens.Add(TokenGenerator.GetPostfix(token));
            return this;
        }

        public TokenBuilder Join<T>(IEnumerable<T> items, Action<T> action, Token separator)
        {
            var itemList = items.ToList();
            for (var i = 0; i < itemList.Count; i++)
            {
                action.Invoke(itemList[i]);
                
                if (i + 1 < itemList.Count)
                {
                    Add(separator);
                }
            }

            return this;
        }

        public override string ToString()
        {
            return string.Concat(GetTidied().Select(x => x.GetValue()));
        }

        private IEnumerable<TokenBase> GetTidied()
        {
            return tokens
                .CleanEmptyTokens()
                .TrimWhitespace()
                .CleanExtraSpaces()
                .CleanRepeatingLineBreaks()
                .CleanCurlyLineBreaks()
                .CleanPunctuationSpacing()
                .AddIndentation()
                .Stub();
        }
    }
}