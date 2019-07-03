using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using AccountingSystem.Models.DB;
using AccountingSystem.Models.Dto.CommodityDtos;
using AccountingSystem.Services.Interfaces.RepositoryInterfaces;
using AccountingSystem.Services.Interfaces.Service;
using System.Linq;
using System.Linq.Expressions;

namespace AccountingSystem.Services.Services
{
    public class CommodityService:BaseService<Commodity,CommodityDto> ,ICommodityService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Commodity> _commodityRepository;
        public CommodityService(IMapper mapper, IBaseRepository<Commodity> baseRepository):base(mapper,baseRepository)
        {
            _mapper = mapper;
            _commodityRepository = baseRepository;
        }
                
       
        public IEnumerable<CommodityDto> GetByTypeComoodity(TypeCommodity typeCommodity, int page, int countOnPage,out int maxElement)
        {
            var comodities = _commodityRepository.GetFiltered(page,countOnPage,out maxElement, c=>c.TypeCommodity==typeCommodity);

            return _mapper.Map<IEnumerable<Commodity>, IEnumerable<CommodityDto>>(comodities);
        }
        public IEnumerable<CommodityDto> GetByCommpanyId(Guid companyId, int page, int countOnPage,out int maxElement)
        {
            var comodities = _commodityRepository.GetFiltered(page, countOnPage,out maxElement, c => c.CompanyId == companyId);

            return _mapper.Map<IEnumerable<Commodity>, IEnumerable<CommodityDto>>(comodities);
        }

        public IEnumerable<CommodityDto> NotInWarehouse(int page, int countOnPage,out int maxElement)
        {
            var comodities = _commodityRepository.GetFiltered(page, countOnPage,out maxElement, c => c.Amount == 0);

            return _mapper.Map<IEnumerable<Commodity>, IEnumerable<CommodityDto>>(comodities);
        }

         public IEnumerable<CommodityDto> MustBeCompleted(Guid companyId, int page, int countOnPage,out int maxElement)
        {
            var comodities = _commodityRepository.GetFiltered(page, countOnPage,out maxElement, c => c.CompanyId == companyId && c.Amount <= c.MinAmount);

            return _mapper.Map<IEnumerable<Commodity>, IEnumerable<CommodityDto>>(comodities);
        }

        public IEnumerable<CommodityDto> GetByName(string name, int page, int countOnPage,out int maxElement)
        {
            var comodities = _commodityRepository.GetFiltered(page, countOnPage,out maxElement, c => c.Name == name);

            return _mapper.Map<IEnumerable<Commodity>, IEnumerable<CommodityDto>>(comodities);
        }

      
        public void ChangedAmount(IEnumerable<CommodityChangeAmount> models)
        {
            
            foreach (var model in models)
            {
                try
                {
                    var commodity = _commodityRepository.GetById(model.Id);
                    commodity.Amount = model.Amount;
                    commodity.MinAmount = model.MinAmount;
                    _commodityRepository.Update(commodity);
                }
                catch
                {

                }
            }
            _commodityRepository.Save();
        }

        public void ChangedAmount(CommodityChangeAmount model)
        {
                    var commodity = _commodityRepository.GetById(model.Id);
                    commodity.Amount = model.Amount;
                    commodity.MinAmount = model.MinAmount;
                    _commodityRepository.Update(commodity);
                    _commodityRepository.Save();
               
        }

        public IEnumerable<CommodityChangeAmount> GetChangedAmount(Guid companyId, int page, int countOnPage,out int maxElement)
        {
            var commodities = _commodityRepository.GetFiltered(page, countOnPage,out maxElement, c=>c.CompanyId== companyId);

            return _mapper.Map<IEnumerable<Commodity>, IEnumerable<CommodityChangeAmount>>(commodities);
        }

    

       
    }
}
