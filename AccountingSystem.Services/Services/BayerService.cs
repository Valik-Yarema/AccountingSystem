using AccountingSystem.Models.DB;
using AccountingSystem.Models.Dto.BuyerDtos;
using AccountingSystem.Services.Interfaces.RepositoryInterfaces;
using AccountingSystem.Services.Interfaces.Service;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AccountingSystem.Services.Services
{
    public class BayerService:BaseService<Buyer,BuyerDto>, IBayerService
    {

        private readonly IMapper _mapper;
        private readonly IBaseRepository<Buyer> _buyerRepository;
        private readonly IBaseRepository<ContactInfo> _contactInfoRepository;
        public BayerService(IMapper mapper, IBaseRepository<Buyer> baseRepository, IBaseRepository<ContactInfo> contactInfoRepository) : base(mapper, baseRepository)
        {
            _mapper = mapper;
               _buyerRepository = baseRepository;
            _contactInfoRepository = contactInfoRepository;
        }
        public IEnumerable<BuyerDto> GetAllWithInfo(int page,int countOfPage,out int maxOfElement)
        {
            var entities = _buyerRepository.GetAll(page,countOfPage,out maxOfElement);

            var entitiesDto = _mapper.Map<IEnumerable<Buyer>, IEnumerable<BuyerDto>>(entities);

            foreach (var item in entitiesDto)
            {
                var contInfo = _contactInfoRepository.GetFiltered(b => b.BuyerId == item.Id).FirstOrDefault();
                item.Name = contInfo.Name;
                item.Phone = contInfo.Phone;
                item.PostalCode = contInfo.PostalCode;
                item.AddressLine = contInfo.AddressLine;
            }

            return entitiesDto;
        }

       public BuyerDto GetFilteredWithInfo(Expression<Func<Buyer, bool>> filter, Func<IQueryable<Buyer>, IOrderedQueryable<Buyer>> orderBy, string includeProperties)
       {
            var entity = _buyerRepository.GetFiltered(filter, orderBy, includeProperties).First();

            var viewDto=  _mapper.Map<Buyer, BuyerDto>(entity);
            try
            {
                var inf = _contactInfoRepository.GetFiltered(c => c.BuyerId == entity.Id).FirstOrDefault();

                viewDto.Name = inf.Name;
                viewDto.Phone = inf.Phone;
                viewDto.PostalCode = inf.PostalCode;
                viewDto.AddressLine = inf.AddressLine;

            }catch(Exception ex)
            {
                throw ex;
            }


            return viewDto;
       }
    }
}
