using Microsoft.AspNetCore.Mvc;
using AdminService.Models;
using AdminService.DTOS;
using AdminService.Helpers;
using AdminService.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        ILogger _logger;
        IAdminService _res;
        public AdminController(IAdminService service,
           ILogger<AdminController> log)
        {
            _res = service;
            _logger = log;
        }

        //private readonly AdminService _res;
        //public AdminController(AdminService adminService, ILogger <AdminController> logger)
        //{
        //    _logger = logger;
        //    _res = adminService;
        //}
        // GET: api/<AdminController>

        [HttpGet]
        //public Task<List<Admin>> Get()
        //{
        //    _logger.LogInformation("Admin called get request");

        //    return _res.GetAllAdmins();
        //}

        // GET api/<AdminController>/5
        //[HttpGet("{id}")]
        //public IActionResult Get(string id)
        //{
        //    //_logger.LogInformation("Get with EmailId called on :" + DateTime.Now.ToString() + Request.Host.Value);
        //    if(id == null)
        //    {
        //        return BadRequest("Admin not found");
        //    }
        //    var value = _res.GetAdmin(id);
        //    if(value != null) { 
        //    return new OkObjectResult(value);
        //    }
        //    else
        //    {
        //        return BadRequest("admin not found");
        //        //return BadRequest(value);
        //    }
        //}

        // POST api/<AdminController>
        [HttpPost]
        public IActionResult Post([FromBody] Admin value)
        {
            if (value == null)
            {
                return BadRequest("Invalid admin data"); // Return 400 Bad Request with an error message
            }

            var admin = _res.CreateAdmin(value);
            if (admin == true)
            {
                return new OkObjectResult("Admin created"); // Return 200 OK with a success message
            }
            else
            {
                return BadRequest("Failed to create admin"); // Return 400 Bad Request with an error message
            }
        }
        //public string Post([FromBody] Admin value)
        //{
        //    var admin = _res.CreateAdmin(value);
        //    if (_res != null) return "Admin created";
        //    return "Admin not created";
        //}

        [HttpPost]
        [Route("Validate")] /// attribute based routing
        public ActionResult<TokenResult> Validate([FromBody] AdminLoginDTO c)
        {
            if (_res.ValidateUser(c))
                return new OkObjectResult(new TokenResult()
                {
                    Status = "success",
                    Token = new TokenHelper().GenerateToken(c)
                });
            return new NotFoundObjectResult(new TokenResult()
            {
                Status = "failed",
                Token = null
            });
        }


       
        }
    }
