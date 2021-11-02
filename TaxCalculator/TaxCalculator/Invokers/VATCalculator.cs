using TaxCalculator.Models;
using TaxCalculator.Commands;

namespace TaxCalculator.Invokers
{
    public class VATCalculator
    {
        public void Calculate(OrderDTO order)
        {
            CalculateVAT cvc = new CalculateVAT(order);
            cvc.Execute();
        }
    }
}
