using System.ComponentModel.DataAnnotations;

namespace AdminService.Models
{
    public class Admin
    {
        [Key]
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string password { get; set; }


    }
}

