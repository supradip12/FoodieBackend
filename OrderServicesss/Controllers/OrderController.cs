using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderServicesss.Models;
using OrderServicesss.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderServicesss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        ILogger _logger;
        // GET: api/<OrderController>

        public OrderController(IOrderService service, ILogger<OrderController> log)
        {
            _service = service;
            _logger = log;
        }



        [HttpGet]
        public ActionResult Get()
        {
            _logger.LogInformation("Get called on :" + DateTime.Now.ToString() + Request.Host.Value);
            var value = _service.GetAllOrders();
            if (value != null)
            {
                return new OkObjectResult(value);
            }
            else
            {
                return BadRequest("Not fetched");
            }
        }



        // GET api/<OrderController>/5
        [HttpGet]
        [Route("GetOrder/{email}")]
        public ActionResult OrderForRestaurant(string email)
        {
            if (email == null)
            {
                return BadRequest("No data found");
            }
            _logger.LogInformation("Get called on :" + DateTime.Now.ToString() + Request.Host.Value);
            var result = _service.GetOrderByMail(email);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            else
            {
                return BadRequest("Not fetched");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order value)
        {
            if (value == null)
            {
                return BadRequest("No data added");
            }
            var res = _service.CreateOrder(value);
            if (res != null)
            {
                return new OkObjectResult(res); ;
            }
            else
            {
                return BadRequest("Not Created");
            }
        }


    }
}
