using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystem.Models.DB
{
    public class Buyer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public ICollection<CommoditiesBuyers> CommoditiesBuyerses { get; set; }

    }
}
