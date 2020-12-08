using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Entities;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Interfaces.Repositories;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Data.Repository
{
    public class AdjacentRepository : IAdjacentRepository
    {
        private readonly Distance _distance;
         public AdjacentRepository(Distance distance)
        {
            _distance = distance;
        }

        public int GetMaxAdjacentValue(int[] adjacentValues)
        {
            _distance.AdjcentValues = adjacentValues;
            return _distance.GetMaxAdjacentDistance();
        }
    }
}