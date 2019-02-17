using NumberToText.Api;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NumberToText.Test
{
    public class NumberConverterTest
    {
        [Theory]
        [InlineData(0, "zero")]
        [InlineData(1, "one")]
        [InlineData(2, "two")]
        [InlineData(3, "three")]
        [InlineData(4, "four")]
        [InlineData(5, "five")]
        [InlineData(6, "six")]
        [InlineData(7, "seven")]
        [InlineData(8, "eight")]
        [InlineData(9, "nine")]
        [InlineData(10, "ten")]
        [InlineData(11, "eleven")]
        [InlineData(12, "twelve")]
        [InlineData(13, "thirteen")]
        [InlineData(14, "fourteen")]
        [InlineData(15, "fifteen")]
        [InlineData(16, "sixteen")]
        [InlineData(17, "seventeen")]
        [InlineData(18, "eighteen")]
        [InlineData(19, "nineteen")]
        [InlineData(20, "twenty")]
        [InlineData(30, "thirty")]
        [InlineData(40, "forty")]
        [InlineData(50, "fifty")]
        [InlineData(60, "sixty")]
        [InlineData(70, "seventy")]
        [InlineData(80, "eighty")]
        [InlineData(90, "ninety")]
        [InlineData(100, "one hundred")]
        [InlineData(1000, "one thousand")]
        [InlineData(1000000, "one million")]
        [InlineData(1000000000, "one billion")]
        [InlineData(1000000000000, "one trillion")]
        [InlineData(1000000000000000, "one quadrillion")]
        [InlineData(1234567891234567, "one quadrillion two hundred thirty four trillion five hundred sixty seven billion eight hundred ninety one million two hundred thirty four thousand five hundred sixty seven")]
        [InlineData(-1234567891234567, "minus one quadrillion two hundred thirty four trillion five hundred sixty seven billion eight hundred ninety one million two hundred thirty four thousand five hundred sixty seven")]
        public void NumberToWordsConversionTest(long number, string expected)
        {
            string textNumber = NumberConverter.NumberToText(number);
            Assert.Equal(textNumber, expected);
        }

        [Fact]
        public void WordsToNumberTest()
        {
            long nmr = NumberConverter.WordsToNumber("one quadrillion two hundred thirty four trillion five hundred sixty seven billion eight hundred ninety one million two hundred thirty four thousand five hundred sixty seven");
        }
    }
}
