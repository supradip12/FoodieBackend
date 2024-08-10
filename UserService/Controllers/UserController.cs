using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.DTOS;
using UserService.Helper;
using UserService.Models;
using UserService.Service;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                await _userService.CreateUserAsync(user);
                return Ok("User created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/User/{email}
        [HttpGet("{email}")]
        [Authorize]

        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userService.GetUserByEmailAsync(email);

                if (user == null)
                    return NotFound($"User with Email '{email}' not found");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost]
        [Route("Validate")]
        public async Task<ActionResult<TokenResult>> Validate([FromBody] UserLoginDTO c)
        {
            try
            {
                var isValid = await _userService.ValidateUserAsync(c); // Assuming _services is your service class instance

                if (isValid)
                {
                    var token = new TokenHelper().GenerateToken(c);
                    return new TokenResult()
                    {
                        Status = "success",
                        Token = token
                    };
                }
                else
                {
                    return NotFound(new TokenResult()
                    {
                        Status = "failed",
                        Token = null
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while validating user.", error = ex.Message });
                // Handle or log the exception as needed
            }
        }


        // PUT: api/User/{email}
        [HttpPut("{email}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(string email, [FromBody] User user)
        {
            try
            {
                var updatedUser = await _userService.UpdateUserAsync(email, user);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/User/{email}
        [HttpDelete("{email}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(string email)
        {
            try
            {
                var result = await _userService.DeleteUserAsync(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/User/login
        [HttpPost("login")]
        
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLogin)
        {
            try
            {
                var isValid = await _userService.ValidateUserAsync(userLogin);
                if (isValid)
                    return Ok("Login successful");
                else
                    return Unauthorized("Invalid credentials");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
