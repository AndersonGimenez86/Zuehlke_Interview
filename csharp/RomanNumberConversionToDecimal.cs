using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class RomanNumberConversionToDecimal
    {
        public decimal ConvertRomanToDecimalNumber(string romanNumeral)
        {
            var number = RomanNumerical.ReturnDecimalNumbers(romanNumeral);
            int totalLength = number.Length;
            int penultimatePosition = (totalLength - 1);

            decimal finalDecimalNumber = 0;

            for (int i = 0; i < totalLength; i++)
            {
                var currentNumber = number[i];

                if (i == penultimatePosition && totalLength % 3 == 0)
                {
                    finalDecimalNumber += currentNumber;
                    break;
                }

                var nextNumber = number[(i + 1)];

                if (currentNumber > nextNumber || currentNumber == nextNumber)
                {
                    if(i % 2 == 0)
                    {
                        finalDecimalNumber += (currentNumber + nextNumber);
                        i++;
                    }
                    else
                        finalDecimalNumber += nextNumber;
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        finalDecimalNumber += (nextNumber - currentNumber);
                        i++;
                    }
                    else
                        finalDecimalNumber += nextNumber;
                        
                }
            }

            return finalDecimalNumber;
        }
      
    }
}

