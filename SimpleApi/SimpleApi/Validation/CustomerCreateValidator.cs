using FluentValidation;
using SimpleApi.DataTransfer.CustomersDto;

namespace SimpleApi.Validation
{
    public class CustomerCreateValidator : AbstractValidator<CustomerCreateDto>
    {
        public CustomerCreateValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.FullName)
                .NotEmpty();

            RuleFor(x => x.PhoneNumber)
                .NotEmpty();
        }
    }
}
