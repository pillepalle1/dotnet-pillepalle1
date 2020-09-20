using System;
using Xunit;

using pillepalle1.Text;

namespace dotnet_pillepalle1_test
{
    public class StringTokenizer_RFC4180_ConfirmityTest
    {
        /*
         * 1. Each record is located on a separate line, delimited by a line break (CRLF).  
         *    For example:
         *    
         *  > aaa,bbb,ccc CRLF
         *  > zzz,yyy,xxx CRLF
         */
        [Fact]
        public void Test_Unescaped_Plain()
        {
            var tokens = "aaa,bbb,ccc".SplitRespectingQuotation(',', '"');

            Assert.NotNull(tokens);

            Assert.Equal(3, tokens.Count);
            Assert.Equal("aaa", tokens[0]);
            Assert.Equal("bbb", tokens[1]);
            Assert.Equal("ccc", tokens[2]);
        }

        /*
         * 5.1. Each field may or may not be enclosed in double quotes
         *      For example:
         * 
         *  > "aaa","bbb","ccc" CRLF
         */
        [Fact]
        public void Test_Escaped_Plain()
        {
            var tokens = "\"aaa\",\"bbb\",\"ccc\"".SplitRespectingQuotation(',', '"');

            Assert.NotNull(tokens);

            Assert.Equal(3, tokens.Count);
            Assert.Equal("aaa", tokens[0]);
            Assert.Equal("bbb", tokens[1]);
            Assert.Equal("ccc", tokens[2]);
        }

        /*
         * 5.2. If fields are not enclosed with double quotes, then double quotes may not 
         *      appear inside the fields.  
         */
        [Fact]
        public void Test_Unescaped_QuotesInToken()
        {
            Assert.Throws<FormatException>(() => "aaa,b\"bb,ccc".SplitRespectingQuotation(',', '"'));
        }

        /*
         * 7. If double-quotes are used to enclose fields, then a double-quote appearing 
         *    inside a field must be escaped by preceding it with another double quote.
         *    For example:
         *    
         *  > "aaa","b""bb","ccc"
        */
        [Fact]
        public void Test_Escaped_QuotesInToken()
        {
            // Properly escaped
            var tokens = "\"aaa\",\"b\"\"bb\",\"ccc\"".SplitRespectingQuotation(',', '"');

            Assert.NotNull(tokens);

            Assert.Equal(3, tokens.Count);
            Assert.Equal("aaa", tokens[0]);
            Assert.Equal("b\"bb", tokens[1]);
            Assert.Equal("ccc", tokens[2]);

            // Not properly escaped
            Assert.Throws<FormatException>(() => "\"aaa\",\"bb\"b\",\"ccc\"".SplitRespectingQuotation(',', '"'));
        }

        /*
         * Testing corner cases: Token consists of " only
         */
        [Fact]
        public void Test_Escaped_QuotesOnly()
        {
            // Testing uneven amounts of "
            for (int i = 1; i < 10; i++)
            {
                Assert.Throws<FormatException>(() => String.Empty.PadLeft(1 + 2 * i, '\"').SplitRespectingQuotation(',', '"'));
            }

            // Testing even amounts of "
            for (int i = 1; i < 10; i++)
            {
                // # Quotes in Token = (#Quotes - 2) / 2
                // - 2 Quotes for escaping
                // - Remaining Quotes by 2
                var tokens = "".PadLeft(2 * i, '"').SplitRespectingQuotation(',', '"');

                Assert.Single(tokens);
                Assert.Equal("".PadLeft((i - 1), '"'), tokens[0]);
            }
        }

        /*
         * Testing corner cases: Malformed token string
         */
        [Fact]
        public void Test_Escaped_QuotesNotClosed()
        {
            Assert.Throws<FormatException>(() => "\"aaa\",\"bbb\",\"ccc".SplitRespectingQuotation(',', '"'));
        }
    }
}
