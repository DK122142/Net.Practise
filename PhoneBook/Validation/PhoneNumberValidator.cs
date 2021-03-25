using FluentValidation;
using PhoneBook.ViewModels;

namespace PhoneBook.Validation
{
    public class PhoneNumberValidator : AbstractValidator<PhoneNumberViewModel>
    {
        public PhoneNumberValidator()
        {
            RuleFor(x => x.Address)
                .NotEmpty();

            RuleFor(x => x.Number)
                .NotEmpty();
        }
    }
}
