using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TaxCalculator.Models;
using TaxCalculator.Invokers;
namespace TaxCalculatorTest
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void CalculateVAT_ValidateResult()
        {
            var items = new List<ItemDTO> { new ItemDTO("ItemA1", 2.5M, 6, 1), new ItemDTO("ItemA2", 5M, 12, 2) };
            var order = new OrderDTO("newOrder", items,0);
            VATCalculator VATCalculator = new VATCalculator();
            VATCalculator.Calculate(order);
            Assert.AreEqual(78.75M, order.Total);
        }
    }
}
