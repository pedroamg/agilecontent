using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Entities;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Interfaces.Services;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Services;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Data.Repository;
using Xunit;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.test.Services
{
    public class AdjacentServiceTest 
    {
        private readonly IAdjacentService _functionsService;
        public AdjacentServiceTest()
        {
            var distance = new Distance();
            var repository = new AdjacentRepository(distance);
            _functionsService = new AdjacentService(repository);
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