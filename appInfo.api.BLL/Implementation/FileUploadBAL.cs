using appInfo.api.common.models;
using appInfo.API.BLL.Interfaces;
using appInfo.API.DAL.Interfaces;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;

namespace appInfo.api.BLL.Implementation
{
    public class FileUploadBAL : IFileUploadBAL
    {
        private readonly IFileUploadDAL ObjDal;

         public FileUploadBAL(IFileUploadDAL _objDal)
        {
            ObjDal = _objDal;
        }

       public async Task<BlobResponseDto> UploadFiles(IFormFile files)
        {
            var returnVal =  new BlobResponseDto();
            returnVal = await ObjDal.UploadFiles(files);
            return returnVal;
        }
    }
}