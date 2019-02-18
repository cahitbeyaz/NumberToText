using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace NumberToText.Api
{
    public class MoneyCoverter
    {
        CultureInfo cultureInfo;
        CurrencyValidator currencyValidator;
        const int maxGroupCount = 6;//quadrillion
        const int maxCurrencyDigits = 2;

        int groupCount;
        int currencyDigits;
        //uses currentculture
        public MoneyCoverter() : this(CultureInfo.CurrentCulture, maxGroupCount, maxCurrencyDigits)
        {

        }


        public MoneyCoverter(CultureInfo cultureInfo, int maxGroupCount, int maxCurrencyDigits)
        {
            this.cultureInfo = cultureInfo;
            groupCount = maxGroupCount;
            currencyDigits = maxCurrencyDigits;
            currencyValidator = new CurrencyValidator(this.cultureInfo, groupCount, currencyDigits);
        }



        /// <summary>
        /// Converts numbers to english speaking text. 
        /// </summary>
        /// <param name="amountInNumbers">Eg: $123,567.11 or $123.567,11 depending on your culture</param>
        /// <returns>For english speking words for given number. For instance: one quadrillion two hundred thirty four trillion five hundred sixty seven billion eight hundred ninety one million two hundred thirty four thousand five hundred sixty seven</returns>
        public string NumberToWords(string amountInNumbers)
        {
            if (!currencyValidator.IsValid(amountInNumbers))
                throw new ArgumentException($"{nameof(amountInNumbers)} is not a valid money numbers");

            amountInNumbers = amountInNumbers.Replace(cultureInfo.NumberFormat.CurrencySymbol, string.Empty).ToLower().Trim();
            List<string> dollarsAndCents = amountInNumbers.Split(cultureInfo.NumberFormat.CurrencyDecimalSeparator.ToCharArray()[0]).ToList();
            string amountIntText = "";
            amountIntText = $"{NumberConverter.NumberToText(long.Parse(dollarsAndCents[0].Replace(cultureInfo.NumberFormat.CurrencyGroupSeparator, "")))} dollar(s)";
            if (dollarsAndCents.Count > 1)
            {
                amountIntText += $" {NumberConverter.NumberToText(long.Parse(dollarsAndCents[1]))} cent(s)";
            }
            return amountIntText;
        }


        public string WordsToNumber(string amountInWords)
        {
            //todo: validation
            amountInWords = amountInWords.ToLower().Trim();

            List<string> dollarsAndCents = amountInWords.Split(new String[] { "dollar(s)" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string amountIntText = "";
            amountIntText = $"${decimal.Parse(NumberConverter.TextToNumber(dollarsAndCents[0]).ToString()).ToString(cultureInfo)}";
            if (dollarsAndCents.Count > 1)
            {
                amountIntText += $"{cultureInfo.NumberFormat.CurrencyDecimalSeparator}{NumberConverter.TextToNumber(dollarsAndCents[1].Replace("cent(s)",""))}";
            }
            else
            {
                amountIntText += $"{cultureInfo.NumberFormat.CurrencyDecimalSeparator}00";
            }
            return amountIntText;
        }

    }
}
