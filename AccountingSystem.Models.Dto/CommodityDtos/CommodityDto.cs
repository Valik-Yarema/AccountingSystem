using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystem.Models.Dto.CommodityDtos
{
   public class CommodityDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CompanyId { get; set; }
        public int Amount { get; set; }
        public int MinAmount { get; set; }
        public int Place { get; set; }
        public TypeCommodity TypeCommodity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
