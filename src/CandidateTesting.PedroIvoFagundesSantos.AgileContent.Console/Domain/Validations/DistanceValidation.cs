using CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.Console.Domain.Validations
{
    public class DistanceValidation : AbstractValidator<Distance>
    {
        public DistanceValidation()
        {
            ValidateArray();
        }
        protected override void EnsureInstanceNotNull(object instanceToValidate)
        {
           //throw new ValidationResult(new[] { new ValidationFailure("Customer", "Customer cannot be null") })
           //return new ValidationResult(new List<ValidationFailure>
           //{
           //    new ValidationFailure
           //    {
           //        ErrorMessage = ""
           //    }
           //});
           //var failure = new ValidationFailure();

           //throw new ValidationException(new List<ValidationFailure>{
           //    new ValidationFailure("")
           //{
           //    ErrorMessage = ""
           //}});
        }

        protected void ValidateArray()
        {
            RuleFor(x => x.AdjcentDistance)
                .Must(MinimumLenghtRequired).WithMessage("It should be informed at least two values to be calculated the adjacent value");
        }

        private static bool MinimumLenghtRequired(IReadOnlyCollection<int> adjacentDistance)
        {
            return adjacentDistance.Count >= 2;
        }
    }
}