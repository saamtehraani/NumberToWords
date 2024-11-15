using NumberToWordsAPI.Services;

namespace NumberToWordsTest
{
    public class NumberToWordsServiceTest
    {
        private readonly NumberToWordsService _numberToWordsService = new();

        [Fact]
        public void ConvertNumberToWords_WholeDollars_ReturnsWords()
        {
            // Arrange
            decimal input = 123;
            string expected = "ONE HUNDRED AND TWENTY-THREE DOLLARS AND ZERO CENTS";

            // Act
            string result = _numberToWordsService.Convert(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertNumberToWords_DollarsAndCents_ReturnsWords()
        {
            // Arrange
            decimal input = 123.45m;
            string expected = "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS";

            // Act
            string result = _numberToWordsService.Convert(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertNumberToWords_ZeroDollarsAndZeroCents_ReturnsZeroDollarsAndZeroCents()
        {
            // Arrange
            decimal input = 0.00m;
            string expected = "ZERO DOLLARS AND ZERO CENTS";

            // Act
            string result = _numberToWordsService.Convert(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertNumberToWords_OnlyCents_ReturnsWordsForCents()
        {
            // Arrange
            decimal input = 0.25m;
            string expected = "ZERO DOLLARS AND TWENTY-FIVE CENTS";

            // Act
            string result = _numberToWordsService.Convert(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertNumberToWords_LargeNumber_ReturnsWords()
        {
            // Arrange
            decimal input = 1234567.89m;
            string expected = "ONE MILLION TWO HUNDRED AND THIRTY-FOUR THOUSAND FIVE HUNDRED AND SIXTY-SEVEN DOLLARS AND EIGHTY-NINE CENTS";

            // Act
            string result = _numberToWordsService.Convert(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void NumberToWords_SingleDigit_ReturnsSingleDigitWord()
        {
            // Arrange
            decimal number = 7;
            string expected = "SEVEN DOLLARS AND ZERO CENTS";

            // Act
            string result = _numberToWordsService.Convert(number);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void NumberToWords_Tens_ReturnsTensWord()
        {
            // Arrange
            decimal number = 45;
            string expected = "FORTY-FIVE DOLLARS AND ZERO CENTS";

            // Act
            string result = _numberToWordsService.Convert(number);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void NumberToWords_Hundreds_ReturnsHundredsWord()
        {
            // Arrange
            decimal number = 300;
            string expected = "THREE HUNDRED DOLLARS AND ZERO CENTS";

            // Act
            string result = _numberToWordsService.Convert(number);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void NumberToWords_Thousands_ReturnsThousandsWord()
        {
            // Arrange
            decimal number = 1234;
            string expected = "ONE THOUSAND TWO HUNDRED AND THIRTY-FOUR DOLLARS AND ZERO CENTS";

            // Act
            string result = _numberToWordsService.Convert(number);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
