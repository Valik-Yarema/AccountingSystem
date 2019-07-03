using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AccountingSystem.Models;
using AccountingSystem.Models.DB;
using AccountingSystem.Models.Dto.CompanyDtos;
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
    [Authorize]
    [ApiController]
    public class CompanyController:ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly UserManager<ApplicationUser> _userManager;
        public CompanyController(ICompanyService companyService, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _companyService = companyService;
        }

        [HttpGet("Get")]
        [Authorize(Roles = "Owner")]
        public ActionResult Get(Guid companyId)
        {
          try { 
          var company =  _companyService.GetById(companyId);

            return Ok(Response.WriteAsync(JsonConvert.SerializeObject(company,
                new JsonSerializerSettings { Formatting = Formatting.Indented })));
          }catch (Exception ex)
          {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex.Message,
                   new JsonSerializerSettings { Formatting = Formatting.Indented
                   })));
          }
        }

        [HttpGet("GetAllThisUser")]
        [Authorize(Roles = "Owner")]
        public ActionResult GetAll(int page,int countOnPage)
        {
            try
            {
                if (page <1 || countOnPage <1)
                {
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array. Page < 1 Or countOnPage < 1");
                }

                int maxOfElement = 0;
                var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var companies = _companyService.GetByUserIdWithInfo(userId, page, countOnPage, out maxOfElement);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject(new List<Object>()
            {
                companies,
                "CountAllElement =" +maxOfElement ,
                "page ="+page,
                "countOnPage ="+countOnPage
            },
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));


            }
            catch (Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex,
                   new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }

        }



        [HttpPost("Create")]
        [Authorize(Roles = "Owner")]
        public ActionResult Create(CompanyCreateDto model)
        {
            model.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _companyService.Create(model);

            return Ok(Response.WriteAsync(JsonConvert.SerializeObject(model,
                new JsonSerializerSettings { Formatting = Formatting.Indented })));
        }

        [HttpDelete("Delete")]
        [Authorize(Roles = "Owner,Admin")]
        public ActionResult Delete(Guid companyId)
        {
            try
            {
                _companyService.Delete(companyId);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject("Delete successed",
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }catch(Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex.Message,
                   new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
        }
        [HttpDelete("DeleteList")]
        [Authorize(Roles = "Owner,Admin")]
        public ActionResult Delete(IEnumerable<Guid> modelsId)
        {
            try
            {

                _companyService.Delete(modelsId);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject("Delete successed",
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
            catch (Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex.Message,
                   new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
        }

        [HttpPatch("Update")]
        [Authorize(Roles = "Owner")]
        public ActionResult Update(CompanyDto model)
        {
            try
            {
                _companyService.Update(model);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject("Update successed",
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
            catch (Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex.Message,
                   new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
        }

    }
}
