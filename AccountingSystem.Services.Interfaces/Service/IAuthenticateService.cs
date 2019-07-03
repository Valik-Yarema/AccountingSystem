using AccountingSystem.Models.Dto.Token;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystem.Services.Interfaces.Service
{
   public interface IAuthenticateService
   {
        string GenerateToken(ClaimsIdentity identity);
        Task<ClaimsIdentity> GetIdentity(string userName, string password);
   }
}
