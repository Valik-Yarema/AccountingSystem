using AccountingSystem.Services.Interfaces.Service;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountingSystem.Models.DB;
using AccountingSystem.Models.Dto.ContactInfoDtos;
using AccountingSystem.Services.Interfaces.RepositoryInterfaces;

namespace AccountingSystem.Services.Services
{
    public class ContactInfoService :BaseService<ContactInfo, ContactInfoDto>, IContactInfoService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<ContactInfo> _contactRepository;

        public ContactInfoService(IMapper mapper, IBaseRepository<ContactInfo> baseRepository) : base(mapper,baseRepository)
        {
            _mapper = mapper;
            _contactRepository = baseRepository;
        }

     
        public ContactInfoDto GetByCompanyId(Guid companyId)
        {
            var contactInfo = _contactRepository.GetFiltered(c=>c.CompanyId==companyId).FirstOrDefault();

            return _mapper.Map<ContactInfo, ContactInfoDto>(contactInfo);
        }
        public ContactInfoDto GetByBayerId(Guid buyerId)
        {
            var contactInfo = _contactRepository.GetFiltered(c=>c.BuyerId==buyerId).FirstOrDefault();

            return _mapper.Map<ContactInfo, ContactInfoDto>(contactInfo);
        }

       
    }
}
