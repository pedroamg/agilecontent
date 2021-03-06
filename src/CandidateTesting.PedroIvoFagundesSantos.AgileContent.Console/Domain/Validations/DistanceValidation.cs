﻿using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Validations
{
    public class DistanceValidation : AbstractValidator<Distance>
    {
        public DistanceValidation()
        {
            ValidateIfAtLeastTwoValuesWereInformed();
        }

        protected override void EnsureInstanceNotNull(object instanceToValidate)
        {
            if (instanceToValidate != default)
                return;

            var errorFailure = new ValidationFailure(string.Empty, "AdjacentArray is a required field.");
            throw  new ValidationException(new List<ValidationFailure>{errorFailure});
        }

        protected void ValidateIfAtLeastTwoValuesWereInformed()
        {
            RuleFor(x => x.AdjcentValues)
                .Must(MinimumLenghtRequired).WithMessage("It should be informed at least two values to be calculated the adjacent value");
        }

        private static bool MinimumLenghtRequired(IReadOnlyCollection<int> adjacentDistance)
        {
            return adjacentDistance?.Count >= 2;
        }
    }
}