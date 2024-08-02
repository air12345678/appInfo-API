using appInfo.api.common.models;
namespace appInfo.API.DAL.Interfaces
{
    public interface ITechStackDAL
    {
        Task <List<TechStack>> GetAll();
    }
}