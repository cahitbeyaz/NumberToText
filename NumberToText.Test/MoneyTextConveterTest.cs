using NumberToText.Api;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xunit;

namespace NumberToText.Test
{
    public class MoneyTextConveterTest
    {
        [Theory]
        [ClassData(typeof(MoneyTextConveterTestData))]
        public void NumberToWordsTest(string moneyInNumbers, string expected)
        {
            MoneyCoverter moneyCoverter = new MoneyCoverter(new System.Globalization.CultureInfo("en-US"), 6, 2);//
            string moneyInWords = moneyCoverter.NumberToWords(moneyInNumbers);
            Assert.Equal(moneyInWords, expected);
        }

        [Theory]
        [ClassData(typeof(MoneyTextConveterTestData))]
        public void WordsToNumberTest(string expected, string moneyInWords)
        {
            CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");
            MoneyCoverter moneyCoverter = new MoneyCoverter(cultureInfo, 6, 2);//
            string moneyInNumbers = moneyCoverter.WordsToNumber(moneyInWords);
            decimal actual = decimal.Parse(moneyInNumbers.Replace(cultureInfo.NumberFormat.CurrencySymbol, ""), cultureInfo);
            decimal exp = decimal.Parse(expected.Replace(cultureInfo.NumberFormat.CurrencySymbol, ""), cultureInfo);

            Assert.Equal(actual, exp);
        }
    }
}
