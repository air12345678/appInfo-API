using appInfo.api.common.models;
using Azure.Storage.Blobs.Models;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
namespace appInfo.API.DAL.Interfaces
{
    public interface IFileUploadDAL
    {
      //  ImageUploadResult UploadFiles(IFormFile files);
          Task<BlobResponseDto>UploadFiles(IFormFile files);

    }
}