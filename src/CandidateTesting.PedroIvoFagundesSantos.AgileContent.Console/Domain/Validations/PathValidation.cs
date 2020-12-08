using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.IO;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Validations
{
    public class PathValidation : AbstractValidator<string>
    {
        public PathValidation()
        {
            ValidateIfPathIsValid();
        }

        protected override void EnsureInstanceNotNull(object instanceToValidate)
        {
            if (instanceToValidate != default)
                return;

            var errorFailure = new ValidationFailure(string.Empty, "Target Path should be informed.");
            throw new ValidationException(new List<ValidationFailure> { errorFailure });
        }

        protected void ValidateIfPathIsValid()
        {
            RuleFor(x => x)
                .Must(CheckPath);
        }

        private static bool CheckPath(string targetPath)
        {
            try
            {
                Path.GetFullPath(targetPath);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}