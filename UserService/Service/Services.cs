using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UserService.DTOS;
using UserService.Helper;
using UserService.Models;

namespace UserService.Service
{
    public class Services : IUserService
    {
        private readonly UserContext _context;

        public Services(UserContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user)
        {
            try
            {
                await _context.users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while creating user", ex);
            }
        }

        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                return await _context.users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching user details", ex);
            }
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            try
            {
                var res= await _context.users.FirstOrDefaultAsync(u => u.Email == email);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching user with email '{email}'", ex);
            }
        }

        public async Task<bool> ValidateUserAsync(UserLoginDTO info)
        {
            try
            {
                var user = await _context.users.FirstOrDefaultAsync(u => u.Email == info.Email && u.Password == info.Password);
                return user != null;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while validating user", ex);
            }
        }

        public async Task<User> UpdateUserAsync(string email, User user)
        {
            try
            {
                var existingUser = await _context.users.FirstOrDefaultAsync(u => u.Email == email);

                if (existingUser != null)
                {
                    existingUser.Email = user.Email;
                    existingUser.Password = user.Password;
                    existingUser.PhoneNumber = user.PhoneNumber;

                    await _context.SaveChangesAsync();
                    return existingUser;
                }
                else
                {
                    throw new Exception($"User with Email '{email}' not found. Update operation failed.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating user", ex);
            }
        }

        public async Task<string> DeleteUserAsync(string email)
        {
            try
            {
                var user = await _context.users.FirstOrDefaultAsync(u => u.Email == email);

                if (user != null)
                {
                    _context.users.Remove(user);
                    await _context.SaveChangesAsync();
                    return "The user account has been successfully deleted";
                }
                else
                {
                    return $"User with Email '{email}' not found. User information could not be deleted.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting user with email '{email}': {ex.Message}");
            }
        }
    }
}
