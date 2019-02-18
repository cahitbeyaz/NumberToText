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

