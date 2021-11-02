using TaxCalculator.Models;

namespace TaxCalculator.Commands
{
    public abstract class Command
    {
        public OrderDTO order { get; protected set; }
        public Command(OrderDTO order)
        {
            this.order = order;
        }
        public abstract void Execute();
    }
}
