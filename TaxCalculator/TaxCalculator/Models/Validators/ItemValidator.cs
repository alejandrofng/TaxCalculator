using FluentValidation;

namespace TaxCalculator.Models.Validators
{
    public class ItemValidator: AbstractValidator<ItemDTO>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Code).MaximumLength(10);
            RuleFor(x => x.PricePerUnit).NotNull();
            RuleFor(x => x.PricePerUnit).ScalePrecision(2,15);
            RuleFor(x => x.Type).InclusiveBetween(1,2);
            RuleFor(x => x.Units).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Units).NotEmpty();
            RuleFor(x => x.Units).NotNull();
        }
    }
}
