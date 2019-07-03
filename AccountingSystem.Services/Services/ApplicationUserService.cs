using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingSystem.Models;
using AccountingSystem.Models.DB;
using AccountingSystem.Models.Dto.AccountModelDtos;
using AccountingSystem.Services.Interfaces.Service;
using AccountingSystem.Services.Interfaces.RepositoryInterfaces;
using AccountingSystem.Services.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AccountingSystem.Services.Services
{
    public class ApplicationUserService: IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthenticateService _authenticateService;
        private readonly IMapper _mapper;

        public ApplicationUserService(IMapper mapper,UserManager<ApplicationUser> userManager,
            IAuthenticateService authenticateService ) //: base(mapper)
        {
            _userManager = userManager;
               _mapper = mapper;
               _authenticateService = authenticateService;
        }

        public async Task<UserDto> Create(RegisterModelDto model)
        {
            var user = _mapper.Map<RegisterModelDto, ApplicationUser>(model);

                       
            var result =  await _userManager.CreateAsync(user, model.Password);
          
            if (result.Succeeded)
            {
             
             var resultRole= await _userManager.AddToRoleAsync(user, model.Role);
                if (!resultRole.Succeeded)
                {
                    throw new Exception("Exception added roles!");
                }
            }
          
            var userDto = _mapper.Map<ApplicationUser, UserDto>(user);
            userDto.Password = user.PasswordHash;
            userDto.Message = result.Succeeded.ToString();
            return userDto;
        }

       
    }
}
