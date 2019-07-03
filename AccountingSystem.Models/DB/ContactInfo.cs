using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystem.Models.DB
{
    public class ContactInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  Guid Id { get; set; }
        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }
        public Guid? BuyerId { get; set; }
        public Buyer Buyer { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public bool IsCompany { get; set; }

    }
}
