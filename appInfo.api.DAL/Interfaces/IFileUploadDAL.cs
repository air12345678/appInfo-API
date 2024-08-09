using appInfo.api.common.models;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
namespace appInfo.API.DAL.Interfaces
{
    public interface IFileUploadDAL
    {
        Task<BlobResponseDto>UploadFiles(IFormFile files);
    }
}