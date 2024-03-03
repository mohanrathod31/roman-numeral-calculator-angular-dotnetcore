using RomanCalcAPI.RomanCalcAPI.Domain.Models;

namespace RomanCalcAPI.RomanCalcAPI.Application.Services
{
    public interface IRomanCalculatorService
    {
        string CalculateSum(string numeral1, string numeral2);
    }
}
