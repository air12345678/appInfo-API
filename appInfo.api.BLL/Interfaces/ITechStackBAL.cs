using appInfo.api.common.models;
namespace appInfo.API.BLL.Interfaces
{
    public interface ITechStackBAL
    {
        Task <HttpResponse<List<TechStack>>> GetAll();
    }
}