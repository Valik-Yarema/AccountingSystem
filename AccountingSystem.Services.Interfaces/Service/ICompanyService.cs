using AccountingSystem.Models.DB;
using AccountingSystem.Models.Dto.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AccountingSystem.Services.Interfaces.Service
{
    /// <summary>
    /// interface Company does not use IBaseService, but implementation use BaseService
    /// </summary>
    /// <param></param>
    public interface ICompanyService
    { 
        void Create(CompanyCreateDto model);
        void Delete(Guid id);
        void Delete(CompanyDto entityDto);
        void Update(CompanyDto entityDto);

        void Delete(IEnumerable<Guid> entitiesDto);
        CompanyDto GetById(Guid entityId);
        IEnumerable<CompanyDto> GetAll(int page, int countOnPage, out int maxOfElement);
        IEnumerable<CompanyDto> GetAllWithInfo(int page, int countOnPage,out int maxOfElement);
        IEnumerable<CompanyDto> GetByUserIdWithInfo(string userId, int page, int countOnPage,out int maxOfElement);
    }
}
