using UserService.Models;
using UserService.DTOS;

namespace UserService.Service
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> ValidateUserAsync(UserLoginDTO info);
        Task<User> UpdateUserAsync(string email, User user);
        Task<string> DeleteUserAsync(string email);
    }
}
