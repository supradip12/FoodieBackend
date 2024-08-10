using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class User
    {
        [Key]
        [Required(ErrorMessage ="Email is required ,It cannot be null")]
        [EmailAddress(ErrorMessage ="Invalid email address format")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Name is required")]
        [StringLength(100,MinimumLength =2,ErrorMessage ="name must be between 2 to 100 characters")]
        public string Name { get; set; } = string.Empty;


        [Required(ErrorMessage = "Phone Number is required , It cannot be null")]
        [RegularExpression(@"^(\d{10})$",ErrorMessage ="Invalid Phone format, Please use correct phone format")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required, It cannot be null ")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, one special character, and be at least 8 characters long.")]
        public string Password { get; set; } = string.Empty;

    }
}
