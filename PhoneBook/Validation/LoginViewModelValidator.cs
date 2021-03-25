using FluentValidation;
using PhoneBook.ViewModels;

namespace PhoneBook.Validation
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(40);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(60);
        }
    }
}
