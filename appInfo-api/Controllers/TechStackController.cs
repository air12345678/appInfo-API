using appInfo.api.common.models;
using appInfo.API.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace appInfo.api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TechStackController : ControllerBase
    {
        private readonly ITechStackBAL ObjBal;

        public TechStackController(ITechStackBAL objBal)
        {
            ObjBal = objBal;
        }

        [HttpGet]
        public async Task<IActionResult> GetTechStacks()
        {
            try
            {
                var resultVal = await ObjBal.GetAll();
                return this.Ok(new HttpResponse<List<TechStack>>
                {
                    Result = resultVal.Result,
                    IsSuccess = true,
                });
            
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, new HttpResponse<List<TechStack>>
                {
                    Result = null,
                    Errors = ex.Message
                });
            }
        }
    }

}