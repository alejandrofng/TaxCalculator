using System;
using System.Collections.Generic;

namespace TaxCalculator.Models
{
    public class OrderDTO
    {
        public string OrderId { get; private set; }
        public List<ItemDTO> Items { get; private set; }
        public decimal Total { get; private set; }
        public OrderDTO(string OrderId, List<ItemDTO> Items,decimal Total)
        {
            this.OrderId = OrderId;
            this.Items = Items;
            this.Total = Math.Round(Total, 2);
        }
        public void setTotal(decimal Total)
        {
            this.Total = Math.Round(Total, 2);
        }
    }
}
