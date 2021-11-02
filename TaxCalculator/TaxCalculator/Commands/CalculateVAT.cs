using TaxCalculator.Models;

namespace TaxCalculator.Commands
{
    public class CalculateVAT : Command
    {
        public CalculateVAT(OrderDTO order): base(order)
        {
        }
        public override void Execute()
        {
            decimal auxTotal = 0;
            foreach (ItemDTO itemLine in order.Items)
            {
                auxTotal += itemLine.TotalWithVat;
            }
            order.setTotal(auxTotal);
        }        
    }
}
