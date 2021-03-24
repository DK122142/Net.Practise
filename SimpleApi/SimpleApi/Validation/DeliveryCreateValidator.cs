using FluentValidation;
using SimpleApi.DataTransfer.DeliveriesDto;

namespace SimpleApi.Validation
{
    public class DeliveryCreateValidator : AbstractValidator<DeliveryCreateDto>
    {
        public DeliveryCreateValidator()
        {
            RuleFor(x => x.Address)
                .NotEmpty();

            RuleFor(x => x.TypeDelivery)
                .NotEmpty()
                .IsInEnum();
        }
    }
}
