using AccountingSystem.Models.DB;
using AccountingSystem.Models.Dto.ContactInfoDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystem.Services.Interfaces.Service
{
    public interface IContactInfoService:IBaseService<ContactInfo, ContactInfoDto>
    {
        ContactInfoDto GetByCompanyId(Guid companyId);
        ContactInfoDto GetByBayerId(Guid bayerId);
       
    }
}
