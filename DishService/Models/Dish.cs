using System.ComponentModel.DataAnnotations;

namespace DishService.Models
{
    public class Dish
    {
        [Key]
        public string Code { get; set; }
        public string DishName { get; set; }
        public string Category { get; set; }
        public string RestaurentEmail { get;set; }
        public string RestaurentName { get; set; }
        public string Price { get; set; }
        public string DishImage { get; set; }
        public string AvaliableTime { get; set; }
        public string Description { get; set; }
        public string IsDisable { get; set; }
    }
}
