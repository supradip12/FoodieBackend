using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderServicesss.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string RestaurantEmail { get; set; }
        public string UserName { get; set; }
        public string DishName { get; set; }
        public string Address { get; set; }

    }
}
