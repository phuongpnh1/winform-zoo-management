using Entities.Models;
using FluentValidation;

namespace Entities.Helper
{
	public class ApplicationUserValidationHelper : AbstractValidator<ApplicationUser>
	{
		public ApplicationUserValidationHelper() 
		{
			RuleFor(u => u.FullName).NotNull().NotEmpty().WithMessage("Full name can not be empty");
			RuleFor(u => u.Password).NotNull().NotEmpty().WithMessage("Password can not be empty");
			RuleFor(u => u.UserName).NotNull().NotEmpty().WithMessage("User name can not be empty");
			RuleFor(u => u.Email).EmailAddress();
			RuleFor(u => u.PhoneNumber).MaximumLength(11).WithMessage("Phone number must have length 10 - 11 number");
			RuleFor(u => u.Dob).NotNull().NotEmpty().WithMessage("Date of birth can not be empty");
			RuleFor(u => u.Gender).NotNull().NotEmpty().WithMessage("Gender can not be empty");
			RuleFor(u => u.Role).NotNull().NotEmpty().WithMessage("Role can not be empty");
		}
	}
}