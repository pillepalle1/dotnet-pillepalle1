using System;
using System.Collections.Immutable;

namespace pillepalle1.Text
{
    public abstract class AStringTokenizer
    {
        public AStringTokenizer()
        {

        }

        public AStringTokenizer(string sourceString)
        {
            SourceString = sourceString;
        }

        /// <summary>
        /// String that is supposed to be split in tokens
        /// </summary>
        public string SourceString
        {
            get
            {
                return _sourceString;
            }
            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException("Cannot split null in tokens");
                }
                else if (_sourceString.Equals(value))
                {
                    // nop
                }
                else
                {
                    _sourceString = value;
                    _InvalidateTokens();
                }
            }
        }
        private string _sourceString = String.Empty;

        /// <summary>
        /// Character indicating how the source string is supposed to be split
        /// </summary>
        public char Delimiter
        {
            get
            {
                return _delimiter;
            }
            set
            {
                if (value != _delimiter)
                {
                    _delimiter = value;
                    _InvalidateTokens();
                }
            }
        }
        private char _delimiter = ' ';

        /// <summary>
        /// Flag indicating whether whitespaces should be removed from start and end of each token
        /// </summary>
        public bool TrimTokens
        {
            get
            {
                return _trimTokens;
            }
            set
            {
                if (value != _trimTokens)
                {
                    _trimTokens = value;
                    _InvalidateTokens();
                }
            }
        }
        private bool _trimTokens = false;

        /// <summary>
        /// Result of tokenization
        /// </summary>
        public ImmutableList<string> Tokens
        {
            get
            {
                if (null == _tokens)
                {
                    _tokens = Tokenize();

                    if (TrimTokens)
                    {
                        _tokens = _TrimTokens(_tokens);
                    }
                }

                return _tokens;
            }
        }
        private ImmutableList<string> _tokens = null;

        /// <summary>
        /// Split SourceString into tokens
        /// </summary>
        protected abstract ImmutableList<string> Tokenize();

        /// <summary>
        /// Trims whitespaces from tokens
        /// </summary>
        /// <param name="candidates">List of tokens</param>
        private ImmutableList<string> _TrimTokens(ImmutableList<string> candidates)
        {
            var trimmedTokens = ImmutableList<string>.Empty;

            foreach (var token in candidates)
            {
                trimmedTokens = trimmedTokens.Add(token.Trim());
            }

            return trimmedTokens;
        }

        /// <summary>
        /// Invalidate and recompute tokens if necessary
        /// </summary>
        protected void _InvalidateTokens()
        {
            _tokens = null;
        }
    }
}
