using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystem.Models.DB
{
    public class Commodity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }// = Guid.NewGuid();
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public  int Amount { get; set; }
        public int MinAmount { get; set; }
        public int Place { get; set; }
        public TypeCommodity TypeCommodity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CommoditiesBuyers> CommoditiesBuyerses { get; set; }
    }
}
