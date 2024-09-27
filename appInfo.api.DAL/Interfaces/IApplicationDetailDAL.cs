using appInfo.api.common.models;
namespace appInfo.API.DAL.Interfaces
{
    public interface IApplicationDetailDAL
    {
        Task AddApplicationDetails(ApplicationInfoDataSetWithDto filter);
         Task <List<ApplicationInfoDataSetWithDto>> GetAllApplicationDetails();
    }

}