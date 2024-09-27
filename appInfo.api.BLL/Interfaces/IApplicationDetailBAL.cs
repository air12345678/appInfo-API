using appInfo.api.common.models;
using Azure.Storage.Blobs.Models;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
namespace appInfo.API.BLL.Interfaces
{
    public interface IApplicationDetailBAL
    {
     public Task<HttpResponse<object>> AddApplicationDetails(ApplicationInfoDataSetWithDto filter);

    public Task <HttpResponse<List<ApplicationInfoDataSetWithDto>>> GetAllApplicationDetails();

    }
}