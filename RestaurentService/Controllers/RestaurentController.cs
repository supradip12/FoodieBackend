using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using RestaurentService.DTOS;
using RestaurentService.Helpers;
using RestaurentService.Models;
using RestaurentService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RestaurentController : ControllerBase
    {
               
        IRestaurentServices res;
        ILogger _logger;
        public RestaurentController(IRestaurentServices service, ILogger<RestaurentController> log)
        {
            _logger = log;
            res = service;
        }

        //User Use It.
        //Get Request to fetch the Restaurent.
        [HttpGet]
        //[Authorize]       
        public ActionResult Get()
        {
            _logger.LogInformation("Get All Restaurent Called"+ DateTime.Now.ToString());
           

            var value = res.GetAllRestaurents();
            if (value != null) {
                return new OkObjectResult(value);
            }
            else
            {
                return BadRequest(value);
            }
      

        }


      

        //User need Use it.
        //Get Restaurents by location
        [HttpGet]
        [Route("getbylocation/{filter}")]
        
        public ActionResult GetByLocation(string filter)
        {
                _logger.LogInformation("Get Restaurents by location Called" + DateTime.Now.ToString());
          

                if (filter == null)
                {
                    return BadRequest("Not Found");
                }

                var value = res.FetchByLocation(filter);
                if (value != null)
                {
                    return new OkObjectResult(value);
                }
                else
                {
                    return BadRequest("Not Found");
                }
           
        }

        //User use it.
        //Get restaurent by Name.

        [HttpGet]
        [Route("getbyname/{filter}")]
       
        public ActionResult GetByName(string filter)
        {
            _logger.LogInformation("Get  restaurent by Name Called" + DateTime.Now.ToString());
           
                if (filter == null)
                {
                    return BadRequest("Not Found");
                }

                var value = res.FetchByName(filter);
                if (value != null)
                {
                    return new OkObjectResult(value);
                }
                else
                {
                    return BadRequest("Not Found");
                }
           
        }

        // Get RestaurentByEmail
        
        [HttpGet]
        [Route("Getrestaurentbyemail/{email}")]
        [Authorize]
        public IActionResult GetRestaurent(string email)
        {
            _logger.LogInformation("Get RestaurentByEmail Called" + DateTime.Now.ToString());
           
                if (email == null)
                {
                    return BadRequest("Not Found");
                }
                var val = res.GetRestaurentById(email);
                if (val != null)
                {

                    return new OkObjectResult(val);
                }
                else
                {
                    return BadRequest("Not Found");
                }
       
        }

        [HttpGet]
        [Route("Getrestaurenthygine")]
       
        public IActionResult Gethygine()
        {
            _logger.LogInformation("Get RestaurentByHygine Called" + DateTime.Now.ToString());
          
                var value = res.GetRestaurentByhygine();
                if (value != null)
                {
                    return new OkObjectResult(value);
                }
                else
                {
                    return BadRequest(value);
                }
            

        }




        //Restaurent Created
        [HttpPost]
        public IActionResult Post([FromBody] Restaurent restaurent)
        {
               _logger.LogInformation(" Restaurent Created" + DateTime.Now.ToString());

            if (restaurent == null)
            {
                return BadRequest("Not Added data");
            }
           var result =  res.CreateRestaurent(restaurent);
            if(result == true)return new OkObjectResult("Restaurent Created");
            return BadRequest("Invalid Credential");
        }


        //Validation
        [HttpPost]
        [Route("Validate")] /// attribute based routing
        public ActionResult<TokenResult> Validate([FromBody] RestaurentLoginDTO c)
        {
            _logger.LogInformation("Get Validation Called" + DateTime.Now.ToString());

            if (res.ValidateRestaurent(c))
                return new(new TokenResult()
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


        // 
        [HttpPut]
        [Route("ApproveRestaurent/{email}")]
        [Authorize]
        public IActionResult Put(string email)
        {
            _logger.LogInformation("Get ApprovedRestaurent Called" + DateTime.Now.ToString());
            if (this.User.FindFirst("Role")?.Value.ToString() == "Admin")
            {
                if (email == null)
                {
                    return BadRequest("Restaurent not Approved for listing");
                }
                var solve = res.ApproveRestaurent(email);
                if (solve != null)
                {
                    return new OkObjectResult("Restaurent Approved for listing");
                }
                else
                {
                    return BadRequest("Restaurent not Approved for listing");
                }
        }
            return BadRequest("UnAuthorised");
    }




        // Creating Put method to Diable Restaurent From Listing

        [HttpPut]
        [Route("DisableRestaurent/{email}")]
        [Authorize]
        public IActionResult Putted(string email)
        {
            _logger.LogInformation("Get DisableRestaurent Called" + DateTime.Now.ToString());
            if (this.User.FindFirst("Role")?.Value.ToString() == "Admin")
            {
                if (email == null)
                {
                    return BadRequest("Unable to Disable the Restaurent");
                }
                var val = res.DisableRestaurent(email);
                if (val != null)
                {
                    return new OkObjectResult("Disable restaurent from listing");
                }
                else
                {
                    return BadRequest("Unable to Disable the Restaurent");
                }
            }
            return BadRequest("UnAuthorised");
        }

        [HttpGet]
        [Route("Alldisablerestaurent")]
        [Authorize]
        public ActionResult Alldisablerestaurent()
        {
            _logger.LogInformation("Get All Disapproved Restaurent Called" + DateTime.Now.ToString());

            if (this.User.FindFirst("Role")?.Value.ToString() == "Admin")
            {
                var value = res.GetAllDisapproveRestaurents();
                if (value != null)
                {
                    return new OkObjectResult(value);
                }
                else
                {
                    return BadRequest(value);
                }
            
        }
            return BadRequest("UnAuthorised");
    }



            // DELETE api/<RestaurentController>/5

        }
    }
