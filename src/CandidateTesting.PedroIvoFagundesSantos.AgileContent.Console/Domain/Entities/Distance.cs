using CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Domain.Validations;
using System;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Domain.Entities
{
    public class Distance
    {
        public int[] AdjcentDistance { get; }
        public Distance(int[] adjacentDistance)
        {
            AdjcentDistance = adjacentDistance;
        }
        
        public int GetMaxAdjacentDistance()
        {
            if(!IsValid())
                return - 2;
            
            return CalcMaxAdjacentDistance();
        }

        private int CalcMaxAdjacentDistance()
        {
            var adjacent = 0;
            Array.Sort(AdjcentDistance);
            for (var i = 0; i < AdjcentDistance.Length - 1; i++)
            {
                var difference = Math.Abs(AdjcentDistance[i + 1] - AdjcentDistance[i]);
                adjacent = Math.Max(difference, adjacent);
            }

            return adjacent;
        }

        private bool IsValid()
        {
           var result = new DistanceValidation().Validate(this);
           return result.IsValid;
        }
    }
}