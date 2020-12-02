using CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Domain.Interfaces.Repositories;
using System;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Domain.Interfaces.Services
{
    public class FunctionsService : IFunctionsService
    {
        private readonly IFunctionRepository _functionRepository;
        public FunctionsService(IFunctionRepository functionRepository)
        {
            _functionRepository = functionRepository;
        }

        public int CalcAdjacentValue(int[] adjacentArray)
        {
            return _functionRepository.GetMaxAdjacentValue(adjacentArray);
        }
    }


    public interface IFunctionsService
    {
        int CalcAdjacentValue(int[] adjacentArray);
    }
}