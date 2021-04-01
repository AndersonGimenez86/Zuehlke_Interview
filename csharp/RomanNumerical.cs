using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public static class RomanNumerical
    {
        private static Dictionary<char, short> RomanNumeralMap = new Dictionary<char, short>()
            {
                {'I', 1 },
                {'V', 5 },
                {'X', 10 },
                {'L', 50 },
                {'C', 100 },
                {'D', 500 },
                {'M', 1000 }
            };

        private static Dictionary<char, short> RomanNumeralInvalidAsPreviousNumber = new Dictionary<char, short>()
            {
                {'V', 5 },
                {'L', 50 },
                {'D', 500 },
            };

        public static int ReturnDecimalNumbers(char currentNumeral)
        {
            if (RomanNumeralMap.ContainsKey(currentNumeral))
                return RomanNumeralMap.GetValueOrDefault(currentNumeral);

            throw new InvalidRomanNumericalException(currentNumeral);
        }

        public static (int, int) ReturnDecimalNumbers(char currentNumeral, char nextNumeral)
        {
            bool firstNumeralCorrect = false;

            if (RomanNumeralMap.ContainsKey(currentNumeral))
            {
                firstNumeralCorrect = true;

                if (RomanNumeralMap.ContainsKey(nextNumeral))
                {
                    var currentNumber = RomanNumeralMap.GetValueOrDefault(currentNumeral);
                    var nextNumber = RomanNumeralMap.GetValueOrDefault(nextNumeral);

                    ValidateIfRomanNumericalSequenceIsValid(currentNumeral, nextNumeral, currentNumber, nextNumber);

                    return (currentNumber, nextNumber);
                }
            }

            throw new InvalidRomanNumericalException(firstNumeralCorrect ? nextNumeral : currentNumeral);
        }

        public static int[] ReturnDecimalNumbers(string romanNumeral)
        {
            int totalLength = romanNumeral.Length;
            int penultimatePosition = (totalLength - 1);
            int[] allDecimalNumber = new int[totalLength];

            for (int i = 0; i < totalLength; i++)
            {
                char currentNumeral = romanNumeral[i];

                if (i == penultimatePosition)
                {
                    var number = ReturnDecimalNumbers(currentNumeral);
                    allDecimalNumber[i] = number;
                    return allDecimalNumber;
                }

                char nextNumeral = romanNumeral[i +1];
                var numbers = ReturnDecimalNumbers(currentNumeral, nextNumeral);
                allDecimalNumber[i++] = numbers.Item1;
                allDecimalNumber[i] = numbers.Item2;
            }

            return allDecimalNumber;
        }

        private static void ValidateIfRomanNumericalSequenceIsValid(char currentNumeral, char nextNumeral, int currentNumber, int nextNumber)
        {
            if(currentNumber < nextNumber)
            {
                var sequenceIsValid = !RomanNumeralInvalidAsPreviousNumber.ContainsKey(currentNumeral);

                if (sequenceIsValid)
                {
                    short currentNumeralIndex = default(short);
                    short nextNumeralIndex = default(short);
                    short index = 0;

                    foreach (var key  in RomanNumeralMap.Keys)
                    {
                        if (key == currentNumeral)
                            currentNumeralIndex = index;
                        else if (key == nextNumeral)
                            nextNumeralIndex = index;

                        index++;
                    }

                    //in case of numbers that move one position back
                    if (RomanNumeralInvalidAsPreviousNumber.ContainsKey(nextNumeral))
                        sequenceIsValid = (nextNumeralIndex - currentNumeralIndex) == 1;
                    else
                        sequenceIsValid = (nextNumeralIndex - currentNumeralIndex) == 2;

                    if(sequenceIsValid == false)
                        throw new InvalidRomanNumericalException($"Invalid sequence of numerals {currentNumeral}, {nextNumeral}!");
                }

                if (sequenceIsValid == false)
                    throw new InvalidRomanNumericalException($"Invalid sequence of numerals {currentNumeral}, {nextNumeral}!");
            }
        }
    }
}
