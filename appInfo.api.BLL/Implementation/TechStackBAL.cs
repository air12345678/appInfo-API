using appInfo.api.common.models;
using appInfo.API.BLL.Interfaces;
using appInfo.API.DAL.Interfaces;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;

namespace appInfo.api.BLL.Implementation
{
    public class TechStackBAL : ITechStackBAL
    {
        private readonly ITechStackDAL ObjDal;

         public TechStackBAL(ITechStackDAL _objDal)
        {
            ObjDal = _objDal;
        }
        public async Task<HttpResponse<List<TechStack>>> GetAll()
        {
            var returnVal = new HttpResponse<List<TechStack>>();
            returnVal.Result = await ObjDal.GetAll();
            return returnVal;
        }

    }
}