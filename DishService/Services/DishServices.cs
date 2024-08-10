using DishService.DTOS;
using DishService.Models;
using Microsoft.EntityFrameworkCore;

namespace DishService.Services
{
    public class DishServices : IDishServices
    {
        private readonly DishContext _context;

        public DishServices(DishContext context)
        {
            _context = context;
        }

        public List<Dish> GetDishes()
        {
            try
            {
                var res = _context.dishes.ToList();
                if(res != null)
                {

                return res;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public List<Dish> GetRestaurent(string email)
        {
            try
            {
                var res = _context.dishes.Where(d => d.RestaurentEmail == email).ToList();
               if(res.Count !=0)
                {
                   
                return res;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool CreateDish(DishDTO dish,string value)
        {
            try { 
                bool val = (_context.dishes.Any(r => r.Code == dish.Code));
                if (val)
                {
                    return false;
                }

                var newDish = new Dish();
                newDish.Code =dish.Code;
                newDish.DishName=dish.DishName;
                newDish.Category = dish.Category;
                newDish.RestaurentEmail = value;
                newDish.RestaurentName= dish.RestaurentName;
                newDish.Price = dish.Price;
                newDish.DishImage = dish.DishImage;
                newDish.AvaliableTime = dish.AvaliableTime;
                newDish.Description = dish.Description;
                newDish.IsDisable = dish.IsDisable;
                
               _context.dishes.Add(newDish);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }
                return true;

        }
     

        public async Task<bool> GrantPermission(string Code)
        {
            try
            {
                var res = await _context.dishes.FirstOrDefaultAsync(r => r.Code == Code);
               if(res != null)
                {

                res.IsDisable = "Enable";
                await _context.SaveChangesAsync();
                return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> WithdrawPermission(string Code)
        {
            try
            {
                var res = await _context.dishes.FirstOrDefaultAsync(r => r.Code == Code);
                if(res != null ) { 
                res.IsDisable = "Disable";
                await _context.SaveChangesAsync();
                return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdatePrice(string code, PriceDTO val)
        {
            try
            {
                var res = _context.dishes.FirstOrDefault(d => d.Code == code);
                if (res != null)
                {
                    if (res.IsDisable == "Disable") return false;
                    res.Price = val.Price;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateDescription(string code, DescriptionDTO description)
        {
            try
            {
                var res = _context.dishes.FirstOrDefault(d => d.Code == code);
                if (res != null)
                {
                    if (res.IsDisable == "Disable") return false;
                    res.Description = description.Description;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateDishImage(string code, ImageDTO dishImage)
        {
            try
            {
                var res = _context.dishes.FirstOrDefault(d => d.Code == code);
                if (res != null)
                {
                    if (res.IsDisable == "Disable") return false;
                    res.DishImage = dishImage.DishImage;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAvaliableTime(string code,UpdateTimeDTO avaliableTime)
        {
            try
            {
                var res = _context.dishes.FirstOrDefault(d => d.Code == code);
                if (res != null)
                {
                    if (res.IsDisable == "Disable") return false;
                    res.AvaliableTime = avaliableTime.AvaliableTime;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }


            catch { 
            
                return false;
            }
        }

        public async Task<bool> RemoveDish( string code)
        {
            try
            {

                var deleteDish = _context.dishes.FirstOrDefault(d => d.Code == code);
                if (deleteDish != null)
                {
                    _context.dishes.Remove(deleteDish);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

       
    }
}
