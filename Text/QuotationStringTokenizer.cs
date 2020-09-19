using System.Collections.Immutable;

namespace pillepalle1.Text
{
    public class QuotationStringTokenizer : AStringTokenizer
    {
        /// <summary>
        /// Indicates which character is used to encapsulate tokens
        /// </summary>
        public char Quotes
        {
            get
            {
                return _quotes;
            }
            set
            {
                if (value != _quotes)
                {
                    _quotes = value;
                    _InvalidateTokens();
                }
            }
        }
        private char _quotes = '"';

        protected override ImmutableList<string> Tokenize()
        {
            return SourceString.SplitRespectingQuotation(Delimiter, Quotes);
        }
    }
}
