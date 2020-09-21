using System;
using Xunit;

using pillepalle1.Text;

namespace dotnet_pillepalle1_test
{
    public class StringTokenizer_EscapeStrategyTest
    {
        [Fact]
        public void Test_Unescaped()
        {
            var tokens1 = "aaa,bbb,ccc".SplitRespectingEscapes(',', '\\');

            Assert.NotNull(tokens1);
            Assert.Equal(3, tokens1.Count);
            Assert.Equal("aaa", tokens1[0]);
            Assert.Equal("bbb", tokens1[1]);
            Assert.Equal("ccc", tokens1[2]);

            var token2 = "\"aaa\",\"bbb\",\"ccc\"".SplitRespectingEscapes(',', '\\');

            Assert.NotNull(token2);
            Assert.Equal(3, token2.Count);
            Assert.Equal("\"aaa\"", token2[0]);
            Assert.Equal("\"bbb\"", token2[1]);
            Assert.Equal("\"ccc\"", token2[2]);
        }

        [Fact]
        public void Test_EscapedDelimiter()
        {
            var tokens1 = "aaa\\,bbb\\,ccc".SplitRespectingEscapes(',', '\\');
            Assert.NotNull(tokens1);
            Assert.Single(tokens1);
            Assert.Equal("aaa,bbb,ccc", tokens1[0]);

            var token2 = "\"aaa\"\\,\"bbb\"\\,\"ccc\"".SplitRespectingEscapes(',', '\\');
            Assert.NotNull(token2);
            Assert.Single(token2);
            Assert.Equal("\"aaa\",\"bbb\",\"ccc\"", token2[0]);
        }

        [Fact]
        public void Test_EscapedEscape()
        {
            var tokens1 = "aaa\\\\,bbb\\\\,ccc".SplitRespectingEscapes(',', '\\');
            Assert.NotNull(tokens1);
            Assert.Equal(3, tokens1.Count);
            Assert.Equal("aaa\\", tokens1[0]);
            Assert.Equal("bbb\\", tokens1[1]);
            Assert.Equal("ccc", tokens1[2]);

            var token2 = "\"aaa\"\\\\,\"bbb\"\\\\,\"ccc\"".SplitRespectingEscapes(',', '\\');
            Assert.NotNull(token2);
            Assert.Equal(3, token2.Count);
            Assert.Equal("\"aaa\"\\", token2[0]);
            Assert.Equal("\"bbb\"\\", token2[1]);
            Assert.Equal("\"ccc\"", token2[2]);
        }

        [Fact]
        public void Test_EscapedBoth()
        {
            var tokens = "aaa\\\\\\,bbb\\\\\\,ccc".SplitRespectingEscapes(',', '\\');
            Assert.NotNull(tokens);
            Assert.Single(tokens);
            Assert.Equal("aaa\\,bbb\\,ccc", tokens[0]);
        }
    }
}
