using appInfo.api.common.models;
namespace appInfo.API.DAL.Interfaces
{
    public interface IApplicationDetailDAL
    {
        Task AddApplicationDetails(ApplicationInfoDataSetDto filter);
    }

}