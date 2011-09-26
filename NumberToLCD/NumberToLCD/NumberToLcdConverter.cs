using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberToLCD
{
    public class NumberToLcdConverter
    {
        private const string NONE = @"   ";
        private const string RIGHT = @"  |";
        private const string MIDDLE = @" - ";
        private const string LEFT = @"|  ";
        private const string BOTH = @"| |";

        private Dictionary<int, string[]> numbers = new Dictionary<int, string[]>();

        public NumberToLcdConverter()
        {
            numbers.Add(1, new[] { NONE, RIGHT, NONE, RIGHT, NONE });
            numbers.Add(2, new[] { MIDDLE, RIGHT, MIDDLE, LEFT, MIDDLE });
            numbers.Add(3, new[] { MIDDLE, RIGHT, MIDDLE, RIGHT, MIDDLE });
            numbers.Add(4, new[] { NONE, BOTH, MIDDLE, RIGHT, NONE });
            numbers.Add(5, new[] { MIDDLE, LEFT, MIDDLE, RIGHT, MIDDLE });
            numbers.Add(6, new[] { MIDDLE, LEFT, MIDDLE, BOTH, MIDDLE });
            numbers.Add(7, new[] { MIDDLE, RIGHT, NONE, RIGHT, NONE });
            numbers.Add(8, new[] { MIDDLE, BOTH, MIDDLE, BOTH, MIDDLE });
            numbers.Add(9, new[] { MIDDLE, BOTH, MIDDLE, RIGHT, MIDDLE });
            numbers.Add(0, new[] { MIDDLE, BOTH, NONE, BOTH, MIDDLE });
        }

        public string ConvertNumber(int numberToConvert)
        {
            var digits = ToDigits(numberToConvert);
            var lcdNumbers = DigitsToLCDNumberArrays(digits);

            var result = GetLineListForLCDNumbers(lcdNumbers);

            return string.Join(Environment.NewLine,result.ToArray());
        }

        private List<string> GetLineListForLCDNumbers(IEnumerable<string[]> lcdNumbers)
        {
            var result = new List<string>();
            for (var i = 0; i < 5; i++)
            {
                var line = string.Empty;
                foreach (var lcdNumber in lcdNumbers)
                {
                    line += lcdNumber[i];
                }
                result.Add(line);
            }
            return result;
        }

        private char[] ToDigits(int numberToConvert)
        {
            return numberToConvert.ToString().ToArray();
        }

        private IEnumerable<string[]> DigitsToLCDNumberArrays(char[] digits)
        {
            return digits.Select(digit => numbers[int.Parse(digit.ToString())]).ToList();
        }
    }
}