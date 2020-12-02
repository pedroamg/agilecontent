using CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Domain.Validations;
using FluentValidation;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Domain.Entities
{
    public class Distance
    {
        public int[] AdjcentDistance { get; }
        public Distance(int[] adjacentDistance)
        {
            AdjcentDistance = adjacentDistance;
        }

        public int CalcMinAdjancetDistance()
        {
            IsValid();
            return 5;
        }

        public int CalcMaxAdjacentDistance()
        {
            IsValid();
            return 5;
        }

        private void IsValid()
        {
            new DistanceValidation().ValidateAndThrow(this);
        }
    }
}