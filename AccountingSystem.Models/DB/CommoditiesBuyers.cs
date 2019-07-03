using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystem.Models.DB
{
    public class CommoditiesBuyers
    {
        public Guid CommodityId { get; set; }
        public Commodity Commodity { get; set; }
        public Guid BuyerId { get; set; }
        public Buyer Buyer { get; set; } 

        public int Amount { get; set; }
    }
}
