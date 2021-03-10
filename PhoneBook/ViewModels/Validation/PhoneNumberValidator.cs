using System.Text.RegularExpressions;
using FluentValidation;

namespace PhoneBook.ViewModels.Validation
{
    public class PhoneNumberValidator : AbstractValidator<PhoneNumberViewModel>
    {
        public PhoneNumberValidator()
        {
            RuleFor(x => x.Address)
                .NotEmpty();
            RuleFor(x => x.Number)
                .NotEmpty()
                .Matches(new Regex(@"^[0-9]{10}$"));
        }
    }
}
