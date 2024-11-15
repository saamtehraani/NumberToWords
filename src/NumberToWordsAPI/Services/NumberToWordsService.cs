using NumberToWordsAPI.Controllers;
using NumberToWordsAPI.Model;

namespace NumberToWordsAPI.Services
{
    public class NumberToWordsService : INumberToWordsService
    {
        private readonly ILogger<NumberToWordsService> _logger;
        public NumberToWordsService(ILogger<NumberToWordsService> logger)
        {
            _logger = logger;
        }

        public NumberToWordsResultModel Convert(decimal value)
        {
            try
            {
                int dollars = (int)Math.Floor(value);
                int cents = (int)((value - dollars) * 100);

                string dollarWords = dollars == 0 ? "ZERO DOLLARS" : $"{NumberToWords(dollars)} DOLLARS";
                string centWords = cents == 0 ? "ZERO CENTS" : $"{NumberToWords(cents)} CENTS";

                return new NumberToWordsResultModel() { Result = $"{dollarWords} AND {centWords}" };
            }
            catch (OverflowException ex)
            {
                _logger.LogError(ex.Message);
                return new NumberToWordsResultModel() { Result = $"{ex.Message}" };
            }
        }

        private string NumberToWords(int number)
        {
            if (number == 0) return "ZERO";

            if (number < 0) return "MINUS " + NumberToWords(Math.Abs(number));

            string[] units = { "", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE" };
            string[] teens = { "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
            string[] tens = { "", "", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };
            string[] thousands = { "", "THOUSAND", "MILLION", "BILLION" };

            string words = "";
            int thousandIndex = 0;

            while (number > 0)
            {
                int currentChunk = number % 1000;

                if (currentChunk > 0)
                {
                    string chunkWords = "";

                    int hundreds = currentChunk / 100;
                    int remainder = currentChunk % 100;

                    if (hundreds > 0)
                    {
                        chunkWords += units[hundreds] + " HUNDRED";
                    }

                    if (remainder > 0)
                    {
                        if (chunkWords != "") chunkWords += " AND ";
                        if (remainder < 10)
                        {
                            chunkWords += units[remainder];
                        }
                        else if (remainder < 20)
                        {
                            chunkWords += teens[remainder - 10];
                        }
                        else
                        {
                            chunkWords += tens[remainder / 10];
                            if (remainder % 10 > 0)
                            {
                                chunkWords += "-" + units[remainder % 10];
                            }
                        }
                    }

                    if (thousands[thousandIndex] != "")
                    {
                        chunkWords += " " + thousands[thousandIndex];
                    }

                    words = chunkWords + (words == "" ? "" : " ") + words;
                }

                number /= 1000;
                thousandIndex++;
            }

            return words.Trim();
        }
    }
}
