using RestaurentService.DTOS;
using RestaurentService.Models;

namespace RestaurentService.Services
{
    public interface IRestaurentServices
    {
        bool ApproveRestaurent(string Id);
        bool CreateRestaurent(Restaurent restaurent);
        List<Restaurent> GetRestaurentByhygine();
        bool DisableRestaurent(string Id);
        Task<Restaurent> FetchByLocation(string filter);
        Task<Restaurent> FetchByName(string filter);
        List<Restaurent> GetAllRestaurents();
        List<Restaurent> GetAllDisapproveRestaurents();
        Task<Restaurent> GetRestaurentById(string id);
        bool ValidateRestaurent(RestaurentLoginDTO customer);
    }
}