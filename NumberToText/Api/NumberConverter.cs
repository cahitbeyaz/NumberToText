using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


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

        private static long getWordNumberValue(string strinNumber)
        {
            if (numbersUntil19.Contains(strinNumber))
                return numbersUntil19.IndexOf(strinNumber);

            if (numbers10Powers.Contains(strinNumber))
                return numbers10Powers.IndexOf(strinNumber) * 10;

            foreach (var item in numberSteps)
            {
                if (item.Item2 == strinNumber)
                {
                    return item.Item1;
                }
            }

            List<string> wordList = strinNumber.Split(' ').ToList();
            if (wordList.Count == 2 && numbers10Powers.Exists(a => a == wordList[0]) && numbersUntil19.Exists(b => b == wordList[1]))//fifty one
            {
                return numbers10Powers.IndexOf(wordList[0]) * 10 + numbersUntil19.IndexOf(wordList[1]);
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

        public static long TextToNumber(String textNumber)
        {
            textNumber = textNumber.Trim().ToLower();
            string minus = "minus";
            if (textNumber.StartsWith(minus))
            {
                string textNumberWithoutMinus = textNumber.Substring(minus.Length, textNumber.Length - minus.Length).Trim();
                return -textToNumberConverter(textNumberWithoutMinus);
            }
            return textToNumberConverter(textNumber);
        }

        private static long textToNumberConverter(String textNumber)
        {
            if (textNumber == "")
                return -1;

            long result = 0;
            long tempVal;
            bool stepFound = false;

            foreach (var step in numberSteps)
            {
                StringBuilder wordStrBuilder = new StringBuilder(textNumber);
                int sIdx = -1;
                sIdx = textNumber.IndexOf(step.Item2);
                if (sIdx >= 0)
                {
                    stepFound = true;
                    tempVal = textToNumberConverter(textNumber.Substring(0, sIdx).Trim());
                    if (tempVal == -1)
                        result += getWordNumberValue(step.Item2);
                    else
                        result += tempVal * getWordNumberValue(step.Item2);
                    wordStrBuilder = wordStrBuilder.Remove(0, sIdx + step.Item2.Length);

                    while (wordStrBuilder.ToString().IndexOf(step.Item2) >= 0)
                    {
                        result *= getWordNumberValue(step.Item2);
                        wordStrBuilder.Remove(0, wordStrBuilder.ToString().IndexOf(step.Item2) + step.Item2.Length);
                    }
                    textNumber = wordStrBuilder.ToString();
                }
                if (textNumber == "")
                    return result;
            }

            if (!stepFound)
                return getWordNumberValue(textNumber);
            else
            {
                tempVal = textToNumberConverter(textNumber.Trim());
                if (tempVal != -1)
                    result += tempVal;
            }

            return result;
        }
    }
}
