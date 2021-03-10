using FluentValidation;

namespace PhoneBook.ViewModels.Validation
{
    public class AuthValidator : AbstractValidator<AuthViewModel>
    {
        public AuthValidator()
        {
            RuleFor(x => x.UserName)
                .MinimumLength(6)
                .MaximumLength(40);
            RuleFor(x => x.Password)
                .MinimumLength(6)
                .MaximumLength(66)
                .NotEmpty()
                .Equal(user => user.ConfirmPassword);
        }
    }
}
