using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.Models.Dto.CommodityDtos;
using AccountingSystem.Services.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace AccountingSystem.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CommodityController:ControllerBase
    {
        private readonly ICommodityService _commodityService;
        public CommodityController(ICommodityService commodityService)
        {
            _commodityService = commodityService;
        }

        [HttpGet("Get")]
        [Authorize]
        public ActionResult Get(Guid commodityId)
        {
            try
            {
                var commodity = _commodityService.GetById(commodityId);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject(commodity,
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
            catch (Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex.Message,
                   new JsonSerializerSettings
                   {
                       Formatting = Formatting.Indented
                   })));
            }
        }

        [HttpGet("GetChangedAmount")]
        [Authorize(Roles = "Provider,Owner")]
        public ActionResult GetChangedAmount(Guid commodityId, int page,int countOnPage)
        {
            try
            {
                if (page < 1 || countOnPage < 1)
                {
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array. Page < 1 Or countOnPage < 1");
                }
                int maxOfElement = 0;

                var commodities = _commodityService.GetChangedAmount(commodityId, page, countOnPage,out maxOfElement);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject(new List<Object>()
            {
                commodities,
                "CountAllElement =" +maxOfElement ,
                "page ="+page,
                "countOnPage ="+countOnPage
            },
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
            catch (Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex,
                   new JsonSerializerSettings
                   {
                       Formatting = Formatting.Indented
                   })));
            }
        }

        [HttpGet("GetAll")]
        [Authorize]
        public ActionResult GetAll(int page,int countOnPage)
        {
        
            try
            {
                if (page < 1 || countOnPage < 1)
                {
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array. Page < 1 Or countOnPage < 1");
                }
                int maxOfElement = 0;
                var commodities = _commodityService.GetAll(page,countOnPage,out maxOfElement);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject(new List<Object>()
            {
                commodities,
                "CountAllElement =" +maxOfElement ,
                "page ="+page,
                "countOnPage ="+countOnPage
            },
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
            catch (Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex,
                   new JsonSerializerSettings
                   {
                       Formatting = Formatting.Indented
                   })));
            }
        }

        [HttpGet("GetByCompanyId")]
        [Authorize]
        public ActionResult GetByCompanyIdAll(Guid commodityId, int page, int countOnPage)
        {
          
            try
            {
                if (page < 1 || countOnPage < 1)
                {
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array. Page < 1 Or countOnPage < 1");
                }
                int maxOfElement = 0;
                var commodities = _commodityService.GetByCommpanyId(commodityId, page, countOnPage,out maxOfElement);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject(new List<Object>()
            {
                commodities,
                "CountAllElement =" +maxOfElement ,
                "page ="+page,
                "countOnPage ="+countOnPage
            },
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
            catch (Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex,
                   new JsonSerializerSettings
                   {
                       Formatting = Formatting.Indented
                   })));
            }
        }

        [HttpGet("GetByType")]
        [Authorize]
        public ActionResult GetByType(TypeCommodity typeCommodity, int page, int countOnPage)
        {
          
            try
            {
                if (page < 1 || countOnPage < 1)
                {
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array. Page < 1 Or countOnPage < 1");
                }
                int maxOfElement = 0;
                var commodities = _commodityService.GetByTypeComoodity(typeCommodity, page, countOnPage, out maxOfElement);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject(new List<Object>()
            {
                commodities,
                "CountAllElement =" +maxOfElement ,
                "page ="+page,
                "countOnPage ="+countOnPage
            },
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
            catch (Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex,
                   new JsonSerializerSettings
                   {
                       Formatting = Formatting.Indented
                   })));
            }
        }

        [HttpGet("MustBeCompleted")]
        [Authorize(Roles ="Provider,Owner,Admin")]
        public ActionResult MustBeCompleted(Guid commodityId, int page, int countOnPage)
        {
           
            try
            {
                if (page < 1 || countOnPage < 1)
                {
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array. Page < 1 Or countOnPage < 1");
                }
                int maxOfElement = 0;
                var commodities = _commodityService.MustBeCompleted(commodityId, page, countOnPage, out maxOfElement);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject(new List<Object>()
            {
                commodities,
                "CountAllElement =" +maxOfElement ,
                "page ="+page,
                "countOnPage ="+countOnPage
            },
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
            catch (Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex,
                   new JsonSerializerSettings
                   {
                       Formatting = Formatting.Indented
                   })));
            }
        }
        [HttpGet("NotInWarehouse")]
        [Authorize]
        public ActionResult NotInWarehouse(int page, int countOnPage)
        {
           
            try
            {
                if (page < 1 || countOnPage < 1)
                {
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array. Page < 1 Or countOnPage < 1");
                }
                int maxOfElement = 0;
                var commodities = _commodityService.NotInWarehouse(page, countOnPage, out maxOfElement);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject(new List<Object>()
            {
                commodities,
                "CountAllElement =" +maxOfElement ,
                "page ="+page,
                "countOnPage ="+countOnPage
            },
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
            catch (Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex,
                   new JsonSerializerSettings
                   {
                       Formatting = Formatting.Indented
                   })));
            }
        }
        [HttpGet("GetByName")]
        [Authorize]
        public ActionResult GetByName(string name,int page, int countOnPage)
        {
           
            try
            {
                if (page < 1 || countOnPage < 1)
                {
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array. Page < 1 Or countOnPage < 1");
                }
                int maxOfElement = 0;
                var commodities = _commodityService.GetByName(name,page, countOnPage, out maxOfElement);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject(new List<Object>()
            {
                commodities,
                "CountAllElement =" +maxOfElement ,
                "page ="+page,
                "countOnPage ="+countOnPage
            },
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
            catch (Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex,
                   new JsonSerializerSettings
                   {
                       Formatting = Formatting.Indented
                   })));
            }
        }

        [HttpPatch("ChangeAmount")]
        [Authorize(Roles = "Provider,Owner")]
        public ActionResult ChangeAmount(CommodityChangeAmount model)
        {
            try
            {
               _commodityService.ChangedAmount(model);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject(true,
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
            catch (Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex,
                   new JsonSerializerSettings
                   {
                       Formatting = Formatting.Indented
                   })));
            }
        }

        [HttpPatch("ChangedAmounts")]
        [Authorize(Roles = "Provider,Owner")]
        public ActionResult ChangedAmounts(List<CommodityChangeAmount> models)
        {
            try
            {
                _commodityService.ChangedAmount(models);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject(true,
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
            catch (Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex.Message,
                   new JsonSerializerSettings
                   {
                       Formatting = Formatting.Indented
                   })));
            }
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Provider,Owner")]
        public ActionResult Create(CommodityDto model)
        {
            try
            {
                _commodityService.Create(model);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject(model,
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
            catch(Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex,
                   new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }

        }
        [HttpPost("CreateMany")]
        [Authorize(Roles = "Provider,Owner")]
        public ActionResult CreateMany(List<CommodityDto> models)
        {
            try
            {
                _commodityService.Create(models);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject(true,
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
            catch (Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex,
                   new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }

        }

        [HttpPost("Update")]
        [Authorize(Roles = "Provider,Owner")]
        public ActionResult Update(CommodityDto model)
        {
            try
            {
                _commodityService.Update(model);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject(true,
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
            catch (Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex,
                   new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }

        }

        [HttpPost("Updates")]
        [Authorize(Roles = "Provider,Owner")]
        public ActionResult Update(IEnumerable<CommodityDto> models)
        {
            try
            {
                _commodityService.Update(models);

                return Ok(Response.WriteAsync(JsonConvert.SerializeObject(true,
                    new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }
            catch (Exception ex)
            {
                return BadRequest(Response.WriteAsync(JsonConvert.SerializeObject(ex,
                   new JsonSerializerSettings { Formatting = Formatting.Indented })));
            }

        }

    }
}
