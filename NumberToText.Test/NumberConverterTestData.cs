using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NumberToText.Test
{

    public class NumberConverterTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 0, "zero" };
            yield return new object[] { 1, "one" };
            yield return new object[] { 2, "two" };
            yield return new object[] { 3, "three" };
            yield return new object[] { 4, "four" };
            yield return new object[] { 5, "five" };
            yield return new object[] { 6, "six" };
            yield return new object[] { 7, "seven" };
            yield return new object[] { 8, "eight" };
            yield return new object[] { 9, "nine" };
            yield return new object[] { 10, "ten" };
            yield return new object[] { 11, "eleven" };
            yield return new object[] { 12, "twelve" };
            yield return new object[] { 13, "thirteen" };
            yield return new object[] { 14, "fourteen" };
            yield return new object[] { 15, "fifteen" };
            yield return new object[] { 16, "sixteen" };
            yield return new object[] { 17, "seventeen" };
            yield return new object[] { 18, "eighteen" };
            yield return new object[] { 19, "nineteen" };
            yield return new object[] { 20, "twenty" };
            yield return new object[] { 30, "thirty" };
            yield return new object[] { 40, "forty" };
            yield return new object[] { 50, "fifty" };
            yield return new object[] { 60, "sixty" };
            yield return new object[] { 70, "seventy" };
            yield return new object[] { 80, "eighty" };
            yield return new object[] { 90, "ninety" };
            yield return new object[] { 100, "one hundred" };
            yield return new object[] { 1000, "one thousand" };
            yield return new object[] { 1000000, "one million" };
            yield return new object[] { 1000000000, "one billion" };
            yield return new object[] { 1000000000000, "one trillion" };
            yield return new object[] { 1000000000000000, "one quadrillion" };
            yield return new object[] { 1234567891234567, "one quadrillion two hundred thirty four trillion five hundred sixty seven billion eight hundred ninety one million two hundred thirty four thousand five hundred sixty seven" };
            yield return new object[] { -1234567891234567, "minus one quadrillion two hundred thirty four trillion five hundred sixty seven billion eight hundred ninety one million two hundred thirty four thousand five hundred sixty seven" };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

       
    }
}
