using FluentValidation;
using SimpleApi.DataTransfer.ItemsDto;

namespace SimpleApi.Validation
{
    public class ItemCreateValidator : AbstractValidator<ItemCreateDto>
    {
        public ItemCreateValidator()
        {
            RuleFor(x => x.Cost)
                .NotEmpty()
                .GreaterThan(0.0m);
            
            RuleFor(x => x.Description)
                .NotEmpty();
            
            RuleFor(x => x.Manufacturer)
                .NotEmpty();
            
            RuleFor(x => x.Name)
                .NotEmpty();
            
            RuleFor(x => x.Nds)
                .NotEmpty();
            
            RuleFor(x => x.Refrigerate)
                .NotNull();
        }
    }
}
