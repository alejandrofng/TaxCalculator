using System;

namespace TaxCalculator.Models
{
    public class Item: Entity<string>
    {
        public int Units { get; private set; }
        public int? ItemTypeId { get; private set; }
        public virtual ItemType Type { get; private set; }
        public decimal PricePerUnit { get; private set; }
        public decimal VATPercentage { get; private set; } 
        public string OrderId { get; private set; }
        public virtual Order Order { get; private set; }
        public decimal Subtotal { get; private set; }
        public decimal TotalWithVat { get; private set; }
        protected Item() { }
        public Item(string Id, int Units, ItemType ItemType,decimal PricePerUnit,string OrderId):base(Id)
        {
            this.Units = Units;
            this.Type = Type;
            this.PricePerUnit = PricePerUnit;
            this.OrderId = OrderId;
            this.VATPercentage = (ItemType == null? 25M : ItemType.VATPercentage);
            this.Subtotal = PricePerUnit * Units;
            this.TotalWithVat = Subtotal + (Subtotal * (VATPercentage / 100));
            this.ItemTypeId = ItemType?.Id;
        }
    }
}
