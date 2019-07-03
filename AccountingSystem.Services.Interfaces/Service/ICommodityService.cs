using AccountingSystem.Models.DB;
using AccountingSystem.Models.Dto.CommodityDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystem.Services.Interfaces.Service
{
    /// <summary>
    /// interface use IBaseService, implementation use BaseService
    /// </summary>
    /// <param> IBaseService<,Commodity,CommodityDto></param>
    public interface ICommodityService:IBaseService<Commodity,CommodityDto>
    {
        
        void ChangedAmount(CommodityChangeAmount model);
        void ChangedAmount(IEnumerable<CommodityChangeAmount> models);
              
        IEnumerable<CommodityDto> GetByName(string name,int page, int countOnPage,out int maxElement);
        IEnumerable<CommodityDto> NotInWarehouse(int page, int countOnPage, out int maxElement);
        IEnumerable<CommodityDto> MustBeCompleted(Guid companyId, int page, int countOnPage, out int maxElement);
        IEnumerable<CommodityDto> GetByCommpanyId(Guid companyId, int page, int countOnPage, out int maxElement);
        IEnumerable<CommodityDto> GetByTypeComoodity(TypeCommodity typeCommodity, int page, int countOnPage, out int maxElement);
        IEnumerable<CommodityChangeAmount> GetChangedAmount(Guid companyId, int page, int countOnPage, out int maxElement);
        void Update(CommodityDto model);
        void Update(IEnumerable<CommodityDto> models);
    }
}
