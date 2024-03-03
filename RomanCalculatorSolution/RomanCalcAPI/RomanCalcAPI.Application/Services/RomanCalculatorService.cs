using RomanCalcAPI.RomanCalcAPI.Domain.Models;
using System.Text;

namespace RomanCalcAPI.RomanCalcAPI.Application.Services
{
    public class RomanCalculatorService : IRomanCalculatorService
    {
        private readonly Dictionary<char, int> _romanValues = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        public string CalculateSum(string numeral1, string numeral2)
        {
            int number1 = RomanToDecimal(numeral1);
            int number2 = RomanToDecimal(numeral2);

            if (number1 == -1 || number2 == -1)
                return "INVALID";

            int sum = number1 + number2;

            if (sum <= 0 || sum >= 4000)
                return "INVALID";

            return DecimalToRoman(sum);
        }

        private int RomanToDecimal(string roman)
        {
            int result = 0;
            int previousValue = 0;
            int consecutiveCount = 1; // Initialize count for consecutive identical symbols

            foreach (char c in roman.Reverse())
            {
                if (!_romanValues.ContainsKey(c))
                    return -1; // Invalid character in Roman numeral

                int value = _romanValues[c];

                // Check for more than three consecutive identical symbols
                if (value == previousValue)
                {
                    consecutiveCount++;
                    if (consecutiveCount > 3)
                        return -1; // Return -1 for invalid input
                }
                else
                {
                    consecutiveCount = 1; // Reset count for new symbol
                }

                // Check for invalid combinations ("IIX" and "IVX")
                if ((value == 1 && previousValue == 1) || (value == 5 && previousValue == 1))
                    return -1; // Return -1 for invalid input

                if (value < previousValue)
                {
                    // Check for invalid subtraction (e.g., "IIX")
                    if (previousValue / value > 10)
                        return -1; // Return -1 for invalid input

                    // Check for invalid combination (e.g., "IVX")
                    if (value == 5 && previousValue == 10 ||
                        value == 50 && previousValue == 100 ||
                        value == 500 && previousValue == 1000)
                        return -1; // Return -1 for invalid input

                    result -= value;
                }
                else
                {
                    result += value;
                }

                previousValue = value;
            }

            return result;
        }

        private string DecimalToRoman(int number)
        {
            if (number < 1 || number > 3999)
                return "INVALID";

            string[] romanNumerals = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

            StringBuilder roman = new StringBuilder();

            for (int i = 0; i < 13; i++)
            {
                while (number >= values[i])
                {
                    number -= values[i];
                    roman.Append(romanNumerals[i]);
                }
            }

            return roman.ToString();
        }
    }
}
