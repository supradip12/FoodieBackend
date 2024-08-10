using DishService.DTOS;
using DishService.Models;
using DishService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DishService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DishController : ControllerBase
    {

        IDishServices res;
        ILogger _logger;
        public DishController(IDishServices service, ILogger<DishController> log)
        {
            _logger = log;
            res = service;
        }

       

        //Get Request to fetch the Restaurent.
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Get All Dish Called" + DateTime.Now.ToString());

            var value = res.GetDishes();
            if(value != null)
            {
                return new OkObjectResult(value);
            }
            else
            {
                return BadRequest("Not fetched");
            }
        }

        //GET : Get by Email
        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            _logger.LogInformation(" Get by Email Called" + DateTime.Now.ToString());

            if (email == null) return BadRequest("Not found");
            var value = res.GetRestaurent(email);
            if(value != null)
            {
                return new OkObjectResult(value);
            }
            else
            {
                return BadRequest("Not found");
            }
        }

        // DishCreation
        [HttpPost]
        public IActionResult Post([FromBody] DishDTO value)
        {
            _logger.LogInformation(" Dishcreation Called" + DateTime.Now.ToString());


            //if (value == null) return BadRequest("Not created");
            //var email = this.User.FindFirst("Email")?.Value.ToString();
            //if (email == null)
            //{
            //    return BadRequest("Restaurant email not found in authorization token.");
            //}
            var email = "hrekfher";

            var val = res.CreateDish(value,email);
            if (val)
            {
                return new OkObjectResult("Dish Creatde");
            }
            else
            {
                return BadRequest("Not Created");
            }
        }
    
        // EnablePermison for Modification
        [HttpPut]
        [Route("EnablePermission/{code}")]
        public IActionResult Put(string code)
        {
            _logger.LogInformation(" EnablePermison for Modification Called" + DateTime.Now.ToString());

            if (code == null) return BadRequest("Not Granted");
            var response = res.GrantPermission(code).GetAwaiter().GetResult();
            if (response == true)
            {
                return new OkObjectResult("Permission Gransted");
            }
            return BadRequest("Not Granted");
        }

        //Disable Dish
        [HttpPut]
        [Route("DisablePermission/{code}")]
        public IActionResult Putted(string code)
        {
            _logger.LogInformation(" DisablePermission for Modification Called" + DateTime.Now.ToString());

            if (code == null) return BadRequest("Not Granted");
            var response = res.WithdrawPermission(code).GetAwaiter().GetResult();
            if (response == true)
            {
                return new OkObjectResult("Updation Permission Gransted");
            }
            return BadRequest("Not Granted");
        }


        //Price Updation of a Dish
        [HttpPut]
        [Route("UpdatePrice/{code}")]
        public IActionResult UpdatePrice(string code, [FromBody] PriceDTO filter)
        {
            _logger.LogInformation(" UpdationPrice  Called" + DateTime.Now.ToString());


            if (code == null) return BadRequest("Not Granted");
            var response = res.UpdatePrice(code,filter).GetAwaiter().GetResult();
            if (response == true)
            {
                return new OkObjectResult("Updated price");
            }
            return BadRequest("Not Granted");
        }

        //Description Updation of a Dish
        [HttpPut]
        [Route("UpdateDescription/{code}")]
        public IActionResult UDescription(string code, [FromBody] DescriptionDTO filter)
        {
            _logger.LogInformation(" UpdationDescription  Called" + DateTime.Now.ToString());

            if (code == null) return BadRequest("Not Granted");
            var response = res.UpdateDescription(code, filter).GetAwaiter().GetResult();
            if (response == true)
            {
                return new OkObjectResult("Updated Description");
            }
            return BadRequest("Not Granted");
        }

        //Image Updation of a Dish
        [HttpPut]
        [Route("UpdateImage/{code}")]
        public IActionResult UDishImage(string code, [FromBody] ImageDTO filter)
        {
            _logger.LogInformation(" UpdationImage Called" + DateTime.Now.ToString());

            if (code == null) return BadRequest("Not Granted");
            var response = res.UpdateDishImage(code, filter).GetAwaiter().GetResult();
            if (response == true)
            {
                return new OkObjectResult("Updated DishImage");
            }
            return BadRequest("Not Granted");
        }

        //AvaliableTime Updation of a Dish
        [HttpPut]
        [Route("UpdateAvaliableTime/{code}")]
        public IActionResult UAvaliableTime(string code, [FromBody] UpdateTimeDTO filter)
        {
            _logger.LogInformation(" UpdationAvaliable  Called" + DateTime.Now.ToString());


            if (code == null) return BadRequest("Not Granted");

            var response = res.UpdateAvaliableTime(code, filter).GetAwaiter().GetResult();
            if (response == true)
            {
                return new OkObjectResult("Updated AvaliableTime");
            }
            return BadRequest("Not Granted");
        }


        // DELETE api/<DishController>/5
        //[HttpDelete]
        //[Route("DeleteDish/{code}")]
        //public IActionResult Delete(string code)
        //{
        //    if (code == null) return BadRequest("NOT Found");
           
        //    var val = res.RemoveDish(code);
        //    if (val != null) return new OkObjectResult("Dish Deleted");
        //    else
        //    {
        //        return BadRequest("Not Found");
        //    }
        //}
    }
}
