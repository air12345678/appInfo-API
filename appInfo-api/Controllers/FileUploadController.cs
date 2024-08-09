using appInfo.API.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace appInfo.api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploadBAL ObjBal;

        public FileUploadController(IFileUploadBAL objBal)
        {
            ObjBal = objBal;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile files)
        {
            var response = await ObjBal.UploadFiles(files);
            return Ok(response);
        }
    }
}