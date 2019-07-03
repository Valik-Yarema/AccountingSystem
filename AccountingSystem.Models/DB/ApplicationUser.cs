using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystem.Models.DB
{
    public class ApplicationUser : IdentityUser
    {
     // public Guid? ProviderId { get; set; }
      public Provider Provider { get; set; }

    //  public Guid? BuyerId{ get; set; }
      public Buyer Buyer { get; set; }

     // public Guid? CompanyId { get; set; }
      public ICollection<Company> Company { get; set; }
    }
}
