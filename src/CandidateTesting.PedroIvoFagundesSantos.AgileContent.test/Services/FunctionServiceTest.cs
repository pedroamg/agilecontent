using CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Domain.Interfaces.Repositories;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Domain.Interfaces.Services;
using FluentValidation;
using Xunit;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.test.Services
{
    public class FunctionServiceTest
    {

        private readonly IFunctionsService _functionsService;
        public FunctionServiceTest()
        {
            var repository = new FunctionRepository();
            _functionsService = new FunctionsService(repository);
        }

        [Fact]
        public void Should_return_Adjacent_values()
        {
            var arrayValues = new[] { 0, 3, 3, 12, 5, 3, 7, 1 };
            var adjacentValue = _functionsService.CalcAdjacentValue(arrayValues);
            Assert.Equal(5, adjacentValue);
        }

        [Fact]
        public void Should_return_at_least_two_values_should_be_informed()
        {
            var arrayValues = new[] { 0 };
            var exception = Assert.Throws<ValidationException>(() => _functionsService.CalcAdjacentValue(arrayValues));
            Assert.Contains("It should be informed at least two values to be calculated the adjacent value", exception.Message);
        }
    }
}