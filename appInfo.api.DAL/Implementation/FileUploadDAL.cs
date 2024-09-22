using appInfo.api.common.models;
using appInfo.API.DAL.Interfaces;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace appInfo.api.DAL.Implementation
{
    public class FileUploadDAL : IFileUploadDAL
    {
        private readonly IOptions<AzureBlobSettings> _blobSettings;
        private readonly BlobContainerClient _containerClient;
        public FileUploadDAL(IOptions<AzureBlobSettings> azureBlobSettings)
        {
            _blobSettings = azureBlobSettings;
            var blobClient = new BlobServiceClient(azureBlobSettings.Value.BlobConnectionString);
             _containerClient = blobClient.GetBlobContainerClient(azureBlobSettings.Value.BlobContainerName);
        }
        public async Task<BlobResponseDto> UploadFiles(IFormFile files)
        {
            var returnVal =  new BlobResponseDto();
            try{
                BlobClient client =_containerClient.GetBlobClient(files.FileName);
                await client.DeleteIfExistsAsync();
                await using(Stream? data = files.OpenReadStream())
                {
                    await client.UploadAsync(data);
                }
                returnVal.Status = $"File{files.FileName} uploaded Successfully";
                returnVal.Error = false;
                returnVal.Blob.Uri = client.Uri;
                returnVal.Blob.Name = files.FileName;
            }
            catch(Exception ex){
                returnVal.Status = $"File is not uploaded :{ex.Message}";
                returnVal.Error = true;
                return returnVal;
            }
            return returnVal;
        }
    }
}