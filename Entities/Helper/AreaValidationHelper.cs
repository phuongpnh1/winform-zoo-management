using Entities.Models;
using FluentValidation;

namespace Entities.Helper
{
	public class AreaValidationHelper : AbstractValidator<Area>
	{
		public AreaValidationHelper() 
		{
			RuleFor(u => u.Name).NotNull().NotEmpty().WithMessage("Area name can not be empty!");
		}
	}
}
