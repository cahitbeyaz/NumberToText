using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NumberToText.Api
{
    public class MoneyTextConveter
    {
        CultureInfo cultureInfo;
        CurrencyValidator currencyValidator;
        const int maxGroupCount = 6;//quadrillion
        const int maxCurrencyDigits = 2;

        int groupCount;
        int currencyDigits;
        //uses currentculture
        public MoneyTextConveter() : this(CultureInfo.CurrentCulture, maxGroupCount, maxCurrencyDigits)
        {

        }


        public MoneyTextConveter(CultureInfo cultureInfo, int maxGroupCount, int maxCurrencyDigits)
        {
            this.cultureInfo = cultureInfo;
            groupCount = maxGroupCount;
            currencyDigits = maxCurrencyDigits;
            currencyValidator = new CurrencyValidator(this.cultureInfo, groupCount, currencyDigits);
        }




        public string NumberToWords(string amountInNumbers)
        {
            if (!currencyValidator.IsValid(amountInNumbers))
                throw new ArgumentException($"{nameof(amountInNumbers)} is not a valid money numbers");

            return NumberConverter.NumberToText(long.Parse(amountInNumbers));

        }

        public string WordsToNumber(string amountInWords)
        {
            throw new NotImplementedException();
        }

    }
}
