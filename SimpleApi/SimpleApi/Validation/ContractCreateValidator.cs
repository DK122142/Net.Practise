using FluentValidation;
using SimpleApi.DataTransfer.ContractsDto;

namespace SimpleApi.Validation
{
    public class ContractCreateValidator : AbstractValidator<ContractCreateDto>
    {
        public ContractCreateValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty();

            RuleFor(x => x.DeliveryId)
                .NotEmpty();

            RuleFor(x => x.Date)
                .NotEmpty();
        }
    }
}
