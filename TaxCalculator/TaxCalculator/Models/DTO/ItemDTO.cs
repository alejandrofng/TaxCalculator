using System;

namespace TaxCalculator.Models
{
    public class ItemDTO
    {
        public string Code { get; private set; }
        public decimal PricePerUnit { get; private set; }
        public int Units { get; private set; }
        public int? Type { get; private set; }
        public decimal Subtotal => PricePerUnit * Units;
        public decimal VatPercentage => (Type==null||Type== ItemType.Type1.Id ? 25M:0M);
        public decimal TotalWithVat => Subtotal + (Subtotal * (VatPercentage / 100));
        public ItemDTO(string Code, decimal PricePerUnit, int Units, int? Type)
        {
            this.Code = Code;
            this.PricePerUnit = PricePerUnit;
            this.Units = Units;
            this.Type = Type;
        }
    }
}
