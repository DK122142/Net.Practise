using FluentValidation;
using PhoneBook.ViewModels;

namespace PhoneBook.Validation
{
    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(40);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(60);

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(60)
                .Equal(user => user.Password);
        }
    }
}
