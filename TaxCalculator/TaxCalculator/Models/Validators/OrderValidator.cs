using FluentValidation;

namespace TaxCalculator.Models.Validators
{
    public class OrderValidator: AbstractValidator<OrderDTO>
    {
        public OrderValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty();
            RuleFor(x => x.OrderId).MaximumLength(10);
        }
    }
}
