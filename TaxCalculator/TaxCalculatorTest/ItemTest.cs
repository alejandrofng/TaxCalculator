using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalculator.Models;

namespace TaxCalculatorTest
{
    [TestClass]
    public class ItemTest
    {
        [TestMethod]
        public void VATCalculation_WhenTypeIsNULL_ItShouldHaveType1VatPercentage()
        {
            int Units = 1;
            int? Type = null;
            decimal PricePerUnit = 100;
            string Code = "sampleCode";
            var itemLine = new ItemDTO(Code, PricePerUnit, Units, Type);
            Assert.AreEqual(ItemType.Type1.VATPercentage, itemLine.VatPercentage);
        }
        public void VATCalculationWithItemType1()
        {
            int Units = 6;
            int? Type = 1;
            decimal PricePerUnit = 2.5M;
            string Code = "sampleCode";
            var itemLine = new ItemDTO(Code, PricePerUnit, Units, Type);
            Assert.AreEqual(18.75M, itemLine.TotalWithVat);
        }
        [TestMethod]
        public void VATCalculationWithItemType2()
        {
            int Units = 12;
            int? Type = 2;
            decimal PricePerUnit = 5;
            string Code = "sampleCode";
            var itemLine = new ItemDTO(Code, PricePerUnit, Units, Type);
            Assert.AreEqual(60, itemLine.TotalWithVat);
        }
    }
}
