using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NumberToText.Test
{
    public class MoneyTextConveterTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "$745.00", "seven hundred forty five dollar(s) zero cent(s)" };
            yield return new object[] { "$745", "seven hundred forty five dollar(s)" };
            yield return new object[] { "$1,234,567,891,234,567.23", "one quadrillion two hundred thirty four trillion five hundred sixty seven billion eight hundred ninety one million two hundred thirty four thousand five hundred sixty seven dollar(s) twenty three cent(s)" };
            yield return new object[] { "$0.12", "zero dollar(s) twelve cent(s)" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    }
}
