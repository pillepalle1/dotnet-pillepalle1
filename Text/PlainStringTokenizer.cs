using System.Collections.Immutable;

namespace pillepalle1.Text
{
    public class PlainStringTokenizer : AStringTokenizer
    {
        protected override ImmutableList<string> Tokenize()
        {
            return SourceString.SplitPlain(Delimiter);
        }
    }
}
