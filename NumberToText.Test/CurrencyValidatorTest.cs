using System;
using System.Globalization;
using Xunit;

namespace NumberToText.Test
{
    public class CurrencyValidatorTest
    {
        [Theory]
        [InlineData("en-US", 6, 2, @"^\$?([1-9]{1}[0-9]{0,2}(\,[0-9]{3}){0,5}(\.[0-9]{0,2})?|[1-9]{1}[0-9]{0,17}(\.[0-9]{0,2})?|0(\.[0-9]{0,2})?|(\.[0-9]{1,2})?)$")]
        [InlineData("tr-TR", 6, 2, @"^\₺?([1-9]{1}[0-9]{0,2}(\.[0-9]{3}){0,5}(\,[0-9]{0,2})?|[1-9]{1}[0-9]{0,17}(\,[0-9]{0,2})?|0(\,[0-9]{0,2})?|(\,[0-9]{1,2})?)$")]
        [InlineData("en-US", 5, 2, @"^\$?([1-9]{1}[0-9]{0,2}(\,[0-9]{3}){0,4}(\.[0-9]{0,2})?|[1-9]{1}[0-9]{0,14}(\.[0-9]{0,2})?|0(\.[0-9]{0,2})?|(\.[0-9]{1,2})?)$")]
        [InlineData("en-US", 6, 1, @"^\$?([1-9]{1}[0-9]{0,2}(\,[0-9]{3}){0,5}(\.[0-9]{0,1})?|[1-9]{1}[0-9]{0,17}(\.[0-9]{0,1})?|0(\.[0-9]{0,1})?|(\.[0-9]{1,1})?)$")]
        public void GetCurrencyValidationRegexTest(string cultureInfoStr, int maxGoups, int maxDecimalPoints, string expected)
        {
            CultureInfo cultureInfo = new CultureInfo(cultureInfoStr);
            CurrencyValidator currencyValidator = new CurrencyValidator(cultureInfo, maxGoups, maxDecimalPoints);
            Assert.Equal(currencyValidator.GetCurrencyValidationRegex(), expected);
        }

        [Fact]
        public void GetCurrencyValidationRegexArguementTest()
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            Assert.Throws<ArgumentException>(() => { CurrencyValidator currencyValidator = new CurrencyValidator(cultureInfo, 0, 2); });
            Assert.Throws<ArgumentException>(() => { CurrencyValidator currencyValidator = new CurrencyValidator(cultureInfo, 1, 0); });
        }

        [Theory]
        [InlineData("en-US", "1.23", true)]
        [InlineData("en-US", "$1.23", true)]
        [InlineData("tr-TR", "₺1,23", true)]
        [InlineData("en-US", "123.23", true)]
        [InlineData("en-US", "1,123.23", true)]
        [InlineData("en-US", "666,555,444,333,222,111.23", true)]
        [InlineData("en-US", "7,666,555,444,333,222,111.23", false)]
        [InlineData("en-US", "1.2", true)]
        [InlineData("en-US", "1.234", false)]
        [InlineData("en-US", "0.1", true)]
        [InlineData("en-US", "0.12", true)]
        [InlineData("en-US", "0.123", false)]
        [InlineData("en-US", ".1", true)]
        [InlineData("en-US", ".12", true)]
        [InlineData("en-US", ".123", false)]
        [InlineData("en-US", "1234.12", true)]
        public void IsValidTest(string cultureInfoStr, string amountInNumbers, bool expected)
        {
            CultureInfo cultureInfo = new CultureInfo(cultureInfoStr);
            CurrencyValidator currencyValidator = new CurrencyValidator(cultureInfo, 6, 2);
            Assert.Equal(currencyValidator.IsValid(amountInNumbers), expected);
        }

    }
}
