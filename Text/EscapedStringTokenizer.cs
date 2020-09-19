using System.Collections.Immutable;

namespace pillepalle1.Text
{
    public class EscapedStringTokenizer : AStringTokenizer
    {
        /// <summary>
        /// Indicates which character is used to escape characters
        /// </summary>
        public char Escape
        {
            get
            {
                return _escape;
            }
            set
            {
                if (value != _escape)
                {
                    _escape = value;
                    _InvalidateTokens();
                }
            }
        }
        private char _escape = '"';

        protected override ImmutableList<string> Tokenize()
        {
            return SourceString.SplitRespectingEscapes(Delimiter, Escape);
        }
    }
}
