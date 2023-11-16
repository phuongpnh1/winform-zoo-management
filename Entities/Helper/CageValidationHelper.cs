using Entities.Models;
using FluentValidation;

namespace Entities.Helper
{
	public class CageValidationHelper : AbstractValidator<Cage>
	{
        public CageValidationHelper()
        {
            RuleFor(c => c.CageName).NotNull().NotEmpty().WithMessage("Cage name can not be empty!");
            RuleFor(c => c.AreaId).NotNull().NotEmpty().WithMessage("Area can not be empty!");
        }
    }
}
