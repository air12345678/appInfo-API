using appInfo.api.common.models;
using appInfo.API.BLL.Interfaces;
using appInfo.API.DAL.Interfaces;
using Microsoft.AspNetCore.Http;

namespace appInfo.api.BLL.Implementation
{
    public class ApplicationInfoDetailBAL : IApplicationDetailBAL
    {
        private readonly IApplicationDetailDAL ObjDal;

        public ApplicationInfoDetailBAL(IApplicationDetailDAL _objDal)
        {
            ObjDal = _objDal;
        }


        public async Task AddApplicationDetails(ApplicationInfoDataSetDto detailParams)
        {
            try
            {
                await ObjDal.AddApplicationDetails(detailParams);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
            }
        }
    }
}