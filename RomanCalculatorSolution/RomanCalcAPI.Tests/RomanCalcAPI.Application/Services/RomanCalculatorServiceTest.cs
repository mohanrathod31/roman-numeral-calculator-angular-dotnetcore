using RomanCalcAPI.RomanCalcAPI.Application.Services;
using RomanCalcAPI.RomanCalcAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanCalcAPI.Tests.RomanCalcAPI.Application.Services
{
    public class RomanCalculatorServiceTest
    {
        [Theory]
        [InlineData("I", "I", "II")]
        [InlineData("V", "I", "VI")]
        [InlineData("I", "V", "VI")]
        [InlineData("IX", "I", "X")]
        [InlineData("V", "V", "X")]
        [InlineData("CM", "C", "M")]
        [InlineData("MCLI", "DXV", "MDCLXVI")]
        //[InlineData("LXXIV", "DII", "DLXXVI")]
        [InlineData("IIX", "I", "INVALID")]
        [InlineData("IVX", "I", "INVALID")]
        public void CalculateSum_ValidInputs_ReturnsExpectedResult(string numeral1, string numeral2, string expected)
        {
            // Arrange
            var service = new RomanCalculatorService();

            // Act
            var result = service.CalculateSum(numeral1, numeral2 );

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
