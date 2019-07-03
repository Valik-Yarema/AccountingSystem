using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystem.Models.DB
{
    public class Provider
    { 
        public Guid Id { get; set; }
        public  string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
