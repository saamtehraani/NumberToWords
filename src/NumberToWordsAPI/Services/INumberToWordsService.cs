using NumberToWordsAPI.Model;

namespace NumberToWordsAPI.Services
{
    public interface INumberToWordsService
    {
        NumberToWordsResultModel Convert(decimal value);
    }
}
