using AccountingSystem.Models.DB;
using AccountingSystem.Models.Dto.AccountModelDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystem.Services.Interfaces.Service
{
    public interface IApplicationUserService
    {
       Task<UserDto> Create(RegisterModelDto model);
     

    }
}
