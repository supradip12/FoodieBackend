using AdminService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminService.DTOS;

namespace AdminService.Services
{
    public class AdminService:IAdminService
    {
        // public AdminContext _context = new AdminContext(); 
        private readonly AdminContext _context;
        public AdminService(AdminContext adminContext)
        {
            _context = adminContext;
        }


        public bool CreateAdmin(Admin user)
        {
            try
            {
                _context.Admins.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
               return false;
            }
        }

        public async Task<List<Admin>> GetAllAdmins()
        {
            try
            {
                return await _context.Admins.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new ApplicationException("Error occurred while retrieving all users", ex);
            }
        }

        public Admin GetAdmin(string email)
        {
            try
            {
                return _context.Admins.FirstOrDefault(s => s.Email == email);
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                return null;
            }
        }
        public bool ValidateUser(AdminLoginDTO admin)
        {
            var result = _context.Admins
                  .Where(c => c.Email == admin.Email && c.password == admin.Password)
                  .FirstOrDefault(); //
            if (result != null)
                return true;
           return false;
        }


        //public async Task<bool> UpdateAdminAsync(string email, Admin updatedAdmin)
        //{
        //    try
        //    {
        //        var existingAdmin = await _context.Admins.FirstOrDefaultAsync(s => s.Email == email);

        //        if (existingAdmin != null)
        //        {
        //            existingAdmin.Name = updatedAdmin.Name;
        //            existingAdmin.Email = updatedAdmin.Email;
        //            existingAdmin.PhoneNumber = updatedAdmin.PhoneNumber;

        //            await _context.SaveChangesAsync();
        //            return true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle or log the exception as needed
        //        return false;
        //    }
        //}
    }
}

