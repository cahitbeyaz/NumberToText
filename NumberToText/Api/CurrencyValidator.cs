using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace NumberToText
{
    public class CurrencyValidator
    {
        CultureInfo cultureInfo;
        NumberFormatInfo nf;
        string cachedRegexString;
        int maxGroupCount;
        int maxCurrnecyDigits;

        /// <summary>
        /// Validate currencies
        /// </summary>
        /// <param name="cultureInfo">culture decimal seperator, group seperators changes according to culture</param>
        /// <param name="maxCurrencyGroupCount">maximum group number in currency for instance 123,345.11 has two groups</param>
        /// <param name="maxCurrnecyDigits">maxCurrnecyDigits maximum number of numbers after currencydigitseperator for instance 121.33 has two currency digits</param>
        public CurrencyValidator(CultureInfo cultureInfo, int maxCurrencyGroupCount, int maxCurrnecyDigits)
        {
            this.cultureInfo = cultureInfo;
            nf = NumberFormatInfo.GetInstance(cultureInfo);
            if (maxCurrnecyDigits < 1)
                throw new ArgumentException($"{nameof(maxCurrnecyDigits)} can not be less than 1");
            this.maxCurrnecyDigits = maxCurrnecyDigits;

            if (maxCurrencyGroupCount < 1)
                throw new ArgumentException($"{nameof(maxCurrencyGroupCount)} can not be less than 1");
            this.maxGroupCount = maxCurrencyGroupCount;

            cachedRegexString = GetCurrencyValidationRegex();

        }

        public string GetCurrencyValidationRegex()
        {
            return $"^\\{nf.CurrencySymbol}?([1-9]{{1}}[0-9]{{0,2}}(\\{nf.CurrencyGroupSeparator}[0-9]{{3}}){{0,{this.maxGroupCount - 1}}}(\\{nf.CurrencyDecimalSeparator}[0-9]{{0,{maxCurrnecyDigits}}})?|" +
                $"[1-9]{{1}}[0-9]{{0,{this.maxGroupCount * 3 - 1}}}(\\{nf.CurrencyDecimalSeparator}[0-9]{{0,{maxCurrnecyDigits}}})?|" +
                $"0(\\{nf.CurrencyDecimalSeparator}[0-9]{{0,{maxCurrnecyDigits}}})?|" +
                $"(\\{nf.CurrencyDecimalSeparator}[0-9]{{1,{maxCurrnecyDigits}}})?)$";
        }
        
        /// <summary>
        /// Returns whether amountString is valid or not for specified culture
        /// For example $1.22, 123,456,22 are valid
        /// Numbers after decimal seperator is set to 2 therefore $1.234 is not valid.
        /// currency symbol is also taken from cultureInfo
        /// </summary>
        /// <param name="amountString">
        /// amountString to validate
        /// </param>
        public bool IsValid(string amountString)
        {
            return Regex.IsMatch(amountString, cachedRegexString);
        }
    }
}
