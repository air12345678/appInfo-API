using System.Linq.Expressions;
using appInfo.api.common.models;
using appInfo.API.BLL.Interfaces;
using DnsClient.Protocol;
using Microsoft.AspNetCore.Mvc;

namespace appInfo.api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationDetailController : ControllerBase
    {
        private readonly IApplicationDetailBAL ObjBal;
        public ApplicationDetailController(IApplicationDetailBAL objBal)
        {
            ObjBal = objBal;
        }

        [HttpPost, Route("saveApplicationDataset")]
        public async Task<IActionResult> SaveApplicationDataSet([FromBody] ApplicationInfoDataSetDto requestPayload)
        {
            try
            {
                if (requestPayload == null)
                {
                    return BadRequest("Invalid data");
                }
                var result = await ObjBal.AddApplicationDetails(new ApplicationInfoDataSetDto
                {
                    ApplicationName = requestPayload.ApplicationName,
                    RolesName = requestPayload.RolesName,
                    ApplicationSMEName = requestPayload.ApplicationSMEName,
                    ApplicationType = requestPayload.ApplicationType,
                    Databases = requestPayload.Databases,
                    TechStack = requestPayload.TechStack,
                    GitRepoistoryPath = requestPayload.GitRepoistoryPath,
                    ApplicationURL = requestPayload.ApplicationURL,
                    SharepointLink = requestPayload.SharepointLink,
                    ExcelLink = requestPayload.ExcelLink
                });
                return Ok(new HttpResponse<object>
                {
                    IsSuccess = true,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }

        }
    }

}