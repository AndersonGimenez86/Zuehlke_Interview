using Xunit;

namespace Interview
{
    public class CodingChallenge
    {
        [Theory]
        [InlineData('I', 1)]
        [InlineData('V', 5)]
        [InlineData('X', 10)]
        [InlineData('L', 50)]
        [InlineData('C', 100)]
        [InlineData('D', 500)]
        [InlineData('M', 1000)]
        public void ConvertRomanNumericalToNumber_Success(char romanNumerical, int expect)
        {
            var number = RomanNumerical.ReturnDecimalNumbers(romanNumerical);

            Assert.Equal(expect, number);
        }

        [Theory]
        [InlineData("VI", new int[2]{5, 1})]
        [InlineData("LXX", new int[3] { 50, 10, 10 })]
        [InlineData("MCC", new int[3] { 1000, 100, 100 })]
        [InlineData("XC", new int[2] { 10, 100 })]
        [InlineData("XCIX", new int[4] { 10, 100, 1, 10 })]
        [InlineData("XXX", new int[3] { 10, 10, 10 })]
        public void ConvertRomanNumeralToNumber_Success(string romanNumerical, int[] expect)
        {
            var numbers = RomanNumerical.ReturnDecimalNumbers(romanNumerical);

            Assert.Equal(expect, numbers);
        }

        [Theory]
        [InlineData("BVI")]
        [InlineData("ZLXX")]
        [InlineData("MCCA")]
        public void ConvertRomanNumeralToNumber_InvalidNumeral_Error_Exception(string romanNumerical)
        {
            Assert.Throws<InvalidRomanNumericalException>(() => RomanNumerical.ReturnDecimalNumbers(romanNumerical));
        }

        [Theory]
        [InlineData("VI", new int[2] { 5, 1 })]
        [InlineData("LXX", new int[3] { 50, 10, 10 })]
        [InlineData("CC", new int[2] { 100, 100 })]
        [InlineData("MCC", new int[3] { 1000, 100, 100 })]
        [InlineData("CM", new int[2] { 100, 1000 })]
        [InlineData("XCV", new int[3] { 10, 100, 5 })]
        [InlineData("XCIX", new int[4] { 10, 100, 1, 10 })]
        [InlineData("XXX", new int[3] { 10, 10, 10 })]
        public void ValidateIfRomanNumericalSequenceIsValid_Success(string romanNumerical, int[] expected)
        {
            int totalLength = romanNumerical.Length;
            int penultimatePosition = (totalLength - 1);

            for (int i = 0; i < totalLength; i++)
            {
                if (i == penultimatePosition)
                    break;

                char currentNumeral = romanNumerical[i];
                char nextNumeral = romanNumerical[i +1];

                var response = RomanNumerical.ReturnDecimalNumbers(currentNumeral, nextNumeral);

                Assert.Equal(expected[i], response.Item1);
                Assert.Equal(expected[i+1], response.Item2);
            }
        }

        [Theory]
        [InlineData("DM", new int[2] { 500, 1000})]
        [InlineData("VL", new int[2] { 5, 50 })]
        [InlineData("LC", new int[2] { 50, 100})]
        [InlineData("XM", new int[2] { 10, 1000 })]
        public void ValidateIfRomanNumericalSequenceIsValid_InvalidSequence_Error_Exception(string romanNumerical, int[] expected)
        {
            int totalLength = romanNumerical.Length;
            int penultimatePosition = (totalLength - 1);

            for (int i = 0; i < totalLength; i++)
            {
                if (i == penultimatePosition)
                    break;

                char currentNumeral = romanNumerical[i];
                char nextNumeral = romanNumerical[i + 1];

                Assert.Throws<InvalidRomanNumericalException>(() => RomanNumerical.ReturnDecimalNumbers(currentNumeral, nextNumeral));
            }
        }


        [Theory]
        [InlineData("VI", new int[2] { 55, 101 })]
        [InlineData("LXX", new int[3] { 57, 12, 17 })]
        [InlineData("CC", new int[2] { 10, 11 })]
        public void ValidateIfRomanNumericalSequenceIsValid_InvalidResult_Fail(string romanNumerical, int[] expected)
        {
            int totalLength = romanNumerical.Length;
            int penultimatePosition = (totalLength - 1);

            for (int i = 0; i < totalLength; i++)
            {
                if (i == penultimatePosition)
                    break;

                char currentNumeral = romanNumerical[i];
                char nextNumeral = romanNumerical[i + 1];

                var response = RomanNumerical.ReturnDecimalNumbers(currentNumeral, nextNumeral);

                Assert.NotEqual(expected[i], response.Item1);
                Assert.NotEqual(expected[i + 1], response.Item2);
            }
        }

        [Theory]
        [InlineData("VI", 6)]
        [InlineData("LXX", 70)]
        [InlineData("MCC", 1200)]
        [InlineData("MDCX", 1610)]
        [InlineData("XCIX", 99)]
        [InlineData("XCV", 95)]
        public void ConvertToDecimalNumber_WhenNextNumberIsBiggerThanCurrentOne_Success(string romanNumerical, int expected)
        {
            RomanNumberConversionToDecimal romanNumberConversionToDecimal = new RomanNumberConversionToDecimal();

            var result = romanNumberConversionToDecimal.ConvertRomanToDecimalNumber(romanNumerical);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("IV", 4)]
        [InlineData("XC", 90)]
        [InlineData("CM", 900)]

        public void ConvertToDecimalNumber_WhenNextNumberIsSmallerThanCurrentOne_Success(string romanNumerical, int expected)
        {
            RomanNumberConversionToDecimal romanNumberConversionToDecimal = new RomanNumberConversionToDecimal();

            var result = romanNumberConversionToDecimal.ConvertRomanToDecimalNumber(romanNumerical);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("XX", 20)]
        [InlineData("XXVV", 30)]
        [InlineData("MMC", 2100)]

        public void ConvertToDecimalNumber_WhenNextNumberIsEqualCurrentOne_Success(string romanNumerical, int expected)
        {
            RomanNumberConversionToDecimal romanNumberConversionToDecimal = new RomanNumberConversionToDecimal();

            var result = romanNumberConversionToDecimal.ConvertRomanToDecimalNumber(romanNumerical);

            Assert.Equal(expected, result);
        }
    }
}
