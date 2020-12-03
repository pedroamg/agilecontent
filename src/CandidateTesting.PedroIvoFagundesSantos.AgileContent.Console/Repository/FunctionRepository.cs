using CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Domain.Entities;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Domain.Interfaces.Repositories;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Repository
{
    public class FunctionRepository : IFunctionRepository
    {
        public int GetMaxAdjacentValue(int[] adjacentValues)
        {
            var distance = new Distance(adjacentValues);
            return distance.GetMaxAdjacentDistance();
        }
    }
}