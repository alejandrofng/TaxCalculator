using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculator.Models
{
    public class ItemType :Entity<int>   
    {
        public static ItemType Type1 = new ItemType(1,25M);
        public static ItemType Type2 = new ItemType(2,0M);

        public decimal VATPercentage { get; private set; }
        protected ItemType()
        {
        }
        public ItemType(int Id,decimal VATPercentage):base(Id)
        {
            this.VATPercentage = VATPercentage;
        }
    }
}
