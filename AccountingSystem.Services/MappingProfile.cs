using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using AccountingSystem.Models.DB;
using AccountingSystem.Models.Dto.AccountModelDtos;
using AccountingSystem.Models.Dto.CompanyDtos;
using AccountingSystem.Models.Dto.ContactInfoDtos;
using AccountingSystem.Models.Dto.CommodityDtos;

namespace AccountingSystem.Services
{
    /// <summary>
    ///  Mapper class for each mapping that is performed, inherited from Automapper Profile class
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Constructor with all mappings
        /// </summary>
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ApplicationUser, RegisterModelDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>().ReverseMap();

            CreateMap<ContactInfo,ContactInfoDto>().ReverseMap();

          
            CreateMap<Commodity, CommodityDto>().ReverseMap();
            CreateMap<Commodity, CommodityChangeAmount>().ReverseMap();
            CreateMap<CompanyCreateDto, Company>().ReverseMap();
            CreateMap<CompanyCreateDto, ContactInfo>()
                .ForMember(contInf => contInf.IsCompany, otp => otp.MapFrom(ccd => true));

            CreateMap<CompanyDto, ContactInfo>().ReverseMap();
            CreateMap<Company,CompanyDto>().ReverseMap();

            //.ForMember(contInf=>contInf.CompanyId,otp=>otp.MapFrom(ccd=>ccd.Id));

        }

       


        
    }
}