using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Interfaces.Repositories;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Interfaces.Services;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Services
{
    public class AdjacentService : IAdjacentService
    {
        private readonly IAdjacentRepository _functionRepository;
        public AdjacentService(IAdjacentRepository functionRepository)
        {
            _functionRepository = functionRepository;
        }

        public int CalcAdjacentValue(int[] adjacentArray)
        {
            return _functionRepository.GetMaxAdjacentValue(adjacentArray);
        }
    }
}