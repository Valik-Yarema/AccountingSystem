using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystem.Models.Dto.ContactInfoDtos
{
    public class ContactInfoDto
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? BuyerId { get; set; }
        public Guid? CompanyId { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public bool IsCompany { get; set; }
    }
}
