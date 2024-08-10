using AdminService.DTOS;
using AdminService.Models;

namespace AdminService.Services
{
    public interface IAdminService
    {
        bool CreateAdmin(Admin user);
        Task<List<Admin>> GetAllAdmins();
        Admin GetAdmin(string email);
        bool ValidateUser(AdminLoginDTO admin);

    }
}
