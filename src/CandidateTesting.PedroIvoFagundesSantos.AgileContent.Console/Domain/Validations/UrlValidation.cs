using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Validations
{
    public class UrlValidation : AbstractValidator<string>
    {
        public UrlValidation()
        {
            ValidateIfUrlIsValid();
        }


        protected override void EnsureInstanceNotNull(object instanceToValidate)
        {
            if (instanceToValidate != default)
                return;

            var errorFailure = new ValidationFailure(string.Empty, "SourceUrl should be informed.");
            throw new ValidationException(new List<ValidationFailure> { errorFailure });
        }

        protected void ValidateIfUrlIsValid()
        {
            RuleFor(x => x)
                .Must(x => Uri.TryCreate(x, UriKind.Absolute, out _));
        }
    }
}