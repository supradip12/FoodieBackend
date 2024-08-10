using DishService.DTOS;
using DishService.Models;

namespace DishService.Services
{
    public interface IDishServices
    {
      
        bool CreateDish(DishDTO dish,string value);
        void Dispose();
        List<Dish> GetDishes();
        List<Dish> GetRestaurent(string email);
        Task<bool> GrantPermission(string Code);
        Task<bool> RemoveDish(string Code);
        Task<bool> UpdateAvaliableTime(string code, UpdateTimeDTO avaliableTime);
        Task<bool> UpdateDescription(string code,DescriptionDTO description);
        Task<bool> UpdateDishImage(string code, ImageDTO dishImage);
        Task<bool> UpdatePrice(string code, PriceDTO price);
        Task<bool> WithdrawPermission(string Code);
    }
}