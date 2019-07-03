using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AccountingSystem.Models;
using AccountingSystem.Models.DB;
using AccountingSystem.Models.Dto.AccountModelDtos;
using AccountingSystem.Models.Dto.Token;
using AccountingSystem.Services.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AccountingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController: ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUserService _applicationUserService;
        public AccountController(IAuthenticateService authService, UserManager<ApplicationUser> userManager, IApplicationUserService applicationUserService)
        {
            _authenticateService = authService;
           
            _userManager = userManager;
            _applicationUserService = applicationUserService;
        }


      
        [AllowAnonymous]
        [HttpPost("GetToken")]
        public async Task GetToken(string username,string password)
        {
          
            var identity =await _authenticateService.GetIdentity(username,password);

            var token = _authenticateService.GenerateToken(identity);
            
            await Response.WriteAsync(JsonConvert.SerializeObject("Token : "+ token,
                new JsonSerializerSettings { Formatting = Formatting.Indented }
            ));
        }


        [AllowAnonymous]
        [HttpPost("Register")]
       // [ValidateAntiForgeryToken]
        public async Task Register(RegisterModelDto model)
        {

             var result = await _applicationUserService.Create(model);

             await Response.WriteAsync(JsonConvert.SerializeObject(result,
                new JsonSerializerSettings { Formatting = Formatting.Indented }
            )); 
        }


    }
}
