using System.ComponentModel.DataAnnotations;

namespace RestaurentService.Models
{
    public class Restaurent
    {
        [Key] 
        public string Email { get; set; }
        public string Name { get; set; }
        public string Category { get;set; }
        public string Location { get; set; }
        public string RestaurentImage { get; set; }
        public string ContactDetails { get; set; }
        public string IsApproved { get; set; } ="true" ;

    }
}
