using System;
using Xunit;

using pillepalle1.Text;

namespace dotnet_pillepalle1_test
{
    public class StringTokenizer_RFC4180_ConfirmityTest
    {
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

        [Fact]
        public void Test_Unescaped_QuotesInToken()
        {
            Assert.Throws<FormatException>(() => "aaa,b\"bb,ccc".SplitRespectingQuotation(',', '"'));
        }

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

        [Fact]
        public void Test_Escaped_QuotesOnly()
        {
            // Testing uneven amoutns of "
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

        [Fact]
        public void Test_Escaped_QuotesInToken()
        {
            var tokens = "\"aaa\",\"b\"\"bb\",\"ccc\"".SplitRespectingQuotation(',', '"');

            Assert.NotNull(tokens);

            Assert.Equal(3, tokens.Count);
            Assert.Equal("aaa", tokens[0]);
            Assert.Equal("b\"bb", tokens[1]);
            Assert.Equal("ccc", tokens[2]);
        }

        [Fact]
        public void Test_Escaped_QuotesInsideTokenNotEscaped()
        {
            Assert.Throws<FormatException>(() => "\"aaa\",\"bb\"b\",\"ccc\"".SplitRespectingQuotation(',', '"'));
        }

        [Fact]
        public void Test_Escaped_QuotesNotClosed()
        {
            Assert.Throws<FormatException>(() => "\"aaa\",\"bbb\",\"ccc".SplitRespectingQuotation(',', '"'));
        }
    }
}
