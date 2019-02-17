using System;
using System.Collections.Generic;
using System.Text;


namespace NumberToText.Api
{
    public static class NumberConverter
    {
        static readonly List<string> numbersUntil19 = new List<string>() { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        static readonly List<string> numbers10Powers = new List<string>() { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        static readonly List<Tuple<long, string>> numberSteps = new List<Tuple<long, string>>()
        {
            {new Tuple<long, string>(1000000000000000,  "quadrillion"  ) },
            {new Tuple<long, string>(1000000000000,  "trillion"  ) },
            {new Tuple<long, string>(1000000000,  "billion"  ) },
            {new Tuple<long, string>(1000000,  "million"  ) },
            {new Tuple<long, string>(1000,  "thousand"  ) },
            {new Tuple<long, string>(100,  "hundred"  ) },
        };

        private static long getSingleNumberValue(string word)
        {
            if (numbersUntil19.Contains(word))
                return numbersUntil19.IndexOf(word);

            if (numbers10Powers.Contains(word))
                return numbers10Powers.IndexOf(word) * 10;

            foreach (var item in numberSteps)
            {
                if (item.Item2 == word)
                {
                    return item.Item1;
                }
            }

            return -1;
        }
        public static string NumberToText(long number)
        {
            string convertedNumberInWords = "";
            if (number < 0)
            {
                number = Math.Abs(number);
                convertedNumberInWords = "minus ";
            }
            convertedNumberInWords += numberToTextConverter(number);
            return convertedNumberInWords.Trim();
        }

        private static string numberToTextConverter(long moneyNumber)
        {
            if (moneyNumber == 0)
                return "zero";


            string moneyText = "";

            for (int i = 0; i < numberSteps.Count; i++)
            {
                long stepDivide = moneyNumber / numberSteps[i].Item1;
                if (stepDivide > 0)
                {
                    moneyText += NumberToText(stepDivide) + $" {numberSteps[i].Item2} ";
                    moneyNumber %= numberSteps[i].Item1;
                }
            }

            if (moneyNumber > 0)
            {
                if (moneyNumber < 20)
                    moneyText += numbersUntil19[(int)moneyNumber];
                else
                {
                    moneyText += $"{numbers10Powers[(int)moneyNumber / 10]} ";
                    if ((moneyNumber % 10) > 0)
                        moneyText += numbersUntil19[(int)moneyNumber % 10];
                }
            }

            return moneyText;
        }

        static String[] spliter = new String[] {
        "tỉ", "triệu", "nghìn", "trăm", "mươi", "mười", "linh", "lẻ"};

        public static long WordsToNumber(String words)
        {
            if (words == "")
                return -1;
            long result = 0, temp;
            int pos = -1;
            bool found = false;
            StringBuilder strBuild = new StringBuilder(words);

            foreach (var s in numberSteps)
            {
                pos = words.IndexOf(s.Item2);
                if (pos >= 0)
                {
                    found = true;
                    temp = WordsToNumber(words.Substring(0, pos).Trim());
                    if (temp == -1)
                        result += getSingleNumberValue(s.Item2);
                    else
                        result += temp * getSingleNumberValue(s.Item2);
                    strBuild = strBuild.Remove(0, pos + s.Item2.Length);
                    while (strBuild.ToString().IndexOf(s.Item2) >= 0)
                    {
                        result *= getSingleNumberValue(s.Item2);
                        strBuild.Remove(0, strBuild.ToString().IndexOf(s.Item2) + s.Item2.Length);
                    }
                    words = strBuild.ToString();
                }
                if (words == "")
                    return result;
            }

            if (!found)
                return getSingleNumberValue(words);
            else
            {
                temp = WordsToNumber(words.Trim());
                if (temp != -1)
                    result += temp;
            }

            return result;
        }
    }
}
