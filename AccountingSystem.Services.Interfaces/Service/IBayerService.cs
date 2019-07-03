using AccountingSystem.Models.DB;
using AccountingSystem.Models.Dto.BuyerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AccountingSystem.Services.Interfaces.Service
{
    public interface IBayerService
    {
        void Create(BuyerDto model);

        void Delete(Guid id);
        void Delete(BuyerDto entityDto);
        void Update(BuyerDto entityDto);

        void Delete(IEnumerable<Guid> entitiesDto);
        BuyerDto GetById(Guid entityId);

        BuyerDto GetFilteredWithInfo(
         Expression<Func<Buyer, bool>> filter = null,
         Func<IQueryable<Buyer>,
             IOrderedQueryable<Buyer>> orderBy = null,
         string includeProperties = "");
        IEnumerable<BuyerDto> GetAll(int page, int countOnPage ,out int maxOfElement);
        IEnumerable<BuyerDto> GetAllWithInfo(int page, int countOnPage,out int maxOfElement);
    }
}
