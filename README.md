NumberToText is small utility project for converting numbers or money amount to english words and vice versa. 



how to use: 

1. install nuget packet:
nuget install utils.NumberToText

2. usage:

Convert money numbers to text:

            string moneyInNumbers = "$1,234,567,891,234,567.23";
            MoneyCoverter moneyCoverter = new MoneyCoverter(new System.Globalization.CultureInfo("en-US"), 6, 2);//
            string moneyInWords = moneyCoverter.NumberToWords(moneyInNumbers);
            //moneyinWords = one quadrillion two hundred thirty four trillion five hundred sixty seven billion eight hundred ninety one million two hundred thirty four thousand five hundred sixty seven dollar(s) twenty three cent(s)" };

Convert money text back to number:

            string moneyInWords = "one quadrillion two hundred thirty four trillion five hundred sixty seven billion eight hundred ninety one million two hundred thirty four thousand five hundred sixty seven dollar(s) twenty three cent(s)";

            CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");
            MoneyCoverter moneyCoverter = new MoneyCoverter(cultureInfo, 6, 2);//
            string moneyInNumbers = moneyCoverter.WordsToNumber(moneyInWords);
            //moneyInNumbers = $1,234,567,891,234,567.23


Test Result:
Calculating coverage result...
Generating report 'C:\Users\cahitb1\cb\projects\ty\NumberToText\NumberToText.Test\coverage.json'

    +--------------------------------------------------+--------+--------+--------+
    | Module                                           | Line   | Branch | Method |
    +--------------------------------------------------+--------+--------+--------+
    | NumberToText                                     | 93,4%  | 87,5%  | 92,3%  |
    +--------------------------------------------------+--------+--------+--------+
    | xunit.runner.reporters.netcoreapp10              | 1,1%   | 0,5%   | 5,1%   |
    +--------------------------------------------------+--------+--------+--------+
    | xunit.runner.utility.netcoreapp10                | 15,7%  | 9,1%   | 21%    |
    +--------------------------------------------------+--------+--------+--------+
    | xunit.runner.visualstudio.dotnetcore.testadapter | 45,6%  | 35,7%  | 47,8%  |
    +--------------------------------------------------+--------+--------+--------+

    +---------+--------+--------+--------+
    |         | Line   | Branch | Method |
    +---------+--------+--------+--------+
    | Total   | 25,3%  | 19%    | 27,1%  |
    +---------+--------+--------+--------+
    | Average | 6,325% | 4,75%  | 6,775% |
    +---------+--------+--------+--------+


