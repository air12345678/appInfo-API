using appInfo.API.BLL.Interfaces;
using CloudinaryDotNet.Actions;
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

        // [HttpPost]
        // public ActionResult<ImageUploadResult> UploadFile(IFormFile files)
        // {
        //     var res = new ImageUploadResult();
        //      res =  ObjBal.UploadFiles(files);
        //     return Ok(res);
        // }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile files)
        {
            if (files?.FileName == null || files.FileName.Length <= 0)
            {
                return BadRequest("No file was uploaded.");
            }
            var response = await ObjBal.UploadFiles(files);
            return Ok(response);
        }
    }
}