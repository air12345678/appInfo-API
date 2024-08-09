using appInfo.api.common.models;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
namespace appInfo.API.BLL.Interfaces
{
    public interface IFileUploadBAL
    {
         Task<BlobResponseDto>UploadFiles(IFormFile files);
    }
}