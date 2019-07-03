using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystem.Models.Dto.CompanyDtos
{
    public class CompanyCreateDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; }
        public string NameCompany { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
    }
}
