using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomanCalcAPI.RomanCalcAPI.Application.Services;
using RomanCalcAPI.RomanCalcAPI.Domain.Models;

namespace RomanCalcAPI.RomanCalcAPI.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RomanCalculatorController : ControllerBase
    {
        private readonly IRomanCalculatorService _calculatorService;

        public RomanCalculatorController(IRomanCalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpPost("sum")]
        public IActionResult CalculateSum(RomanNumeralRequest request)
        {
            var result = _calculatorService.CalculateSum(request.Numeral1, request.Numeral2);
            return Ok(result);
        }
    }
}
