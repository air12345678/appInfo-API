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
        public async Task<bool> SaveApplicationDataSet([FromBody] ApplicationInfoDataSetDto requestPayload)
        {
            bool result = false;
            try
            {
                // if(requestPayload == null){
                // return BadRequest("Invalid data");
                // }
              await ObjBal.AddApplicationDetails(new ApplicationInfoDataSetDto
                {
                    ApplicationName = requestPayload.ApplicationName,
                    RolesName = requestPayload.RolesName,
                    ApplicationSMEName = requestPayload.ApplicationSMEName,
                    ApplicationType = requestPayload.ApplicationType,
                    Databases = new DatabaseDetail
                    {
                        DatabaseName = requestPayload.Databases?.DatabaseName,
                        ServerName = requestPayload.Databases?.ServerName
                    },
                    TechStack = requestPayload.TechStack,
                    GitRepoistoryPath = new RepoistoryDetails
                    {
                        ClientURL = requestPayload.GitRepoistoryPath?.ClientURL,
                        APIURL = requestPayload.GitRepoistoryPath?.APIURL
                    },
                    ApplicationURL = requestPayload.ApplicationURL,
                    SharepointLink = requestPayload.SharepointLink,
                    ExcelLink = requestPayload.ExcelLink
                });
                 result = true;
                 
               // return CreatedAtAction();
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
               // return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
            return result;
        }
    }

}