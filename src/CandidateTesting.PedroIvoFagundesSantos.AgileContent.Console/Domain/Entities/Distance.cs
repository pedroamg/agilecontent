using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Validations;
using System;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Entities
{
    public sealed class Distance
    {
        public int[] AdjcentValues { get; set; }

        public int GetMaxAdjacentDistance()
        {
            if(!IsValid())
                return - 2;
            
            return CalcMaxAdjacentDistance();
        }

        private int CalcMaxAdjacentDistance()
        {
            var adjacent = -2;
            Array.Sort(AdjcentValues);
            for (var i = 0; i < AdjcentValues.Length - 1; i++)
            {
                var difference = Math.Abs(AdjcentValues[i + 1] - AdjcentValues[i]);
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