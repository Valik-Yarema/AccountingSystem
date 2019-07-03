using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystem.Models.DB
{
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  Guid Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string NameCompany { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public ICollection<Provider> Providers { get; set; }
        public ICollection<Commodity> Commodities { get; set; }
     
    }
}
