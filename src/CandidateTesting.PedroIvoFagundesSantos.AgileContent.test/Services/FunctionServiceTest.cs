using CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Domain.Interfaces.Repositories;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Domain.Interfaces.Services;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Domain.Services;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Repository;
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
            var adjacentArray = new[] { 0, 3, 3, 12, 5, 3, 7, 1 };
            var adjacentValue = _functionsService.CalcAdjacentValue(adjacentArray);
            Assert.Equal(5, adjacentValue);
        }

        [Theory]
        [InlineData(new[]{ 0 })]
        [InlineData(null)]
        public void Should_return_at_least_two_values_should_be_informed(int[] adjacentArray)
        {
            var adjacentValue = _functionsService.CalcAdjacentValue(adjacentArray);
            Assert.Equal(-2, adjacentValue);
        }
    }
}