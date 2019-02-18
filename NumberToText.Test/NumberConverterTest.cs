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
        [ClassData(typeof(NumberConverterTestData))]
        public void NumberToWordsConversionTest(long number, string expected)
        {
            string textNumber = NumberConverter.NumberToText(number);
            Assert.Equal(textNumber, expected);
        }

        [Theory]
        [ClassData(typeof(NumberConverterTestData))]
        public void WordsToNumberTest(long expected, string wordNumber)
        {
            long convertedNumeric = NumberConverter.TextToNumber(wordNumber);
            Assert.Equal(convertedNumeric, expected);
        }
    }
}
