using AccountingSystem.Services.Interfaces.Service;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using AccountingSystem.Models.DB;
using AccountingSystem.Models.Dto.CompanyDtos;
using AccountingSystem.Services.Interfaces.RepositoryInterfaces;
using System.Linq;

namespace AccountingSystem.Services.Services
{
    public class CompanyService :BaseService<Company,CompanyDto> , ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Company> _companyRepository;
        private readonly IBaseRepository<ContactInfo> _contactInfoRepository;
        public CompanyService(IMapper mapper, IBaseRepository<Company> baseRepository, IBaseRepository<ContactInfo> contactInfoRepository) : base(mapper,baseRepository)
        {
            _mapper = mapper;
            _companyRepository = baseRepository;
            _contactInfoRepository = contactInfoRepository;
        }

      
        public void Create(CompanyCreateDto model)
        {
           var contactInfo = _mapper.Map<CompanyCreateDto, ContactInfo>(model);

            Company company = new Company()
            {
                UserId=model.UserId,
                NameCompany = model.NameCompany,
                ContactInfo = contactInfo

            };
            _companyRepository.Insert(company);
            _companyRepository.Save();

        }

        public override IEnumerable<CompanyDto> GetAll(int page, int countOnPage,out int maxOfElement)
        {
           
            var entities = _companyRepository.GetAll(page, countOnPage, out maxOfElement);

            return _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyDto>>(entities);

        }
        public IEnumerable<CompanyDto> GetAllWithInfo(int page, int countOnPage, out int maxOfElement)
        {
          
            var entities = _companyRepository.GetAll(page, countOnPage, out maxOfElement);

            var entitiesDto = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyDto>>(entities);

            foreach (var item in entitiesDto)
            {
                var contInfo = _contactInfoRepository.GetFiltered(c => c.CompanyId == item.Id).FirstOrDefault();
                item.Name = contInfo.Name;
                item.Phone = contInfo.Phone;
                item.PostalCode = contInfo.PostalCode;
                item.AddressLine = contInfo.AddressLine;
            }

            return entitiesDto;
        }

        public IEnumerable<CompanyDto> GetByUserIdWithInfo(string userId,int page, int countOnPage,out int maxOfElement)
        {
            IEnumerable<Company> entities = _companyRepository.GetFiltered(page, countOnPage, out maxOfElement, c => c.UserId==userId);

            var entitiesDto = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyDto>>(entities);

            foreach (var item in entitiesDto)
            {
                var contInfo = _contactInfoRepository.GetFiltered(c => c.CompanyId == item.Id).FirstOrDefault();
                item.Name = contInfo.Name;
                item.Phone = contInfo.Phone;
                item.PostalCode = contInfo.PostalCode;
                item.AddressLine = contInfo.AddressLine;
            }

            return entitiesDto;
        }
    }
}
