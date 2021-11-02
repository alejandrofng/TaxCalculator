using System;
using System.Collections.Generic;

namespace TaxCalculator.Models
{
    public class Order: Entity<string>
    {
        public virtual List<Item> Items { get; private set; }
        public decimal Total { get; private set; }
        protected Order() { }
        public Order(string Id,decimal Total): base(Id)
        {
            this.Total = Total;
        }
        public void AddItem(Item Item)
        {
            Items.Add(Item);
        }
    }
}
