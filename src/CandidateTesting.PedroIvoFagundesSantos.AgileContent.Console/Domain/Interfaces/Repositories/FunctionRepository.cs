using CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Domain.Entities;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Domain.Interfaces.Repositories
{
    public class FunctionRepository : IFunctionRepository
    {
        public FunctionRepository()
        {
        }

        public int GetMaxAdjacentValue(int[] adjacentValues)
        {
            var distance = new Distance(adjacentValues);
            return distance.CalcMaxAdjacentDistance();
        }

        public int GetMinAdjacentValue(int[] adjacentValues)
        {
            var distance = new Distance(adjacentValues);
            return distance.CalcMinAdjancetDistance();
        }
    }

    public interface IFunctionRepository
    {
        int GetMaxAdjacentValue(int[] adjacentValues);
        int GetMinAdjacentValue(int[] adjacentValues);
    }
}