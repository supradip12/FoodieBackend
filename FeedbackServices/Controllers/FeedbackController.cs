using FeedbackServices.Model;
using FeedbackServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FeedbackServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FeedbackController : ControllerBase
    {
        ILogger _logger;
        IFeedbackService _service;
        public FeedbackController(IFeedbackService service, ILogger<FeedbackController> log)
        {
            _service = service;
            _logger = log;
        }



        // GET: api/<FeedbackController>

        [HttpGet]

        public IActionResult Get()
        {
            _logger.LogInformation("Get called on :" + DateTime.Now.ToString() + Request.Host.Value);

            var res = _service.GetAllFeedBacks();
            if (res != null)
            {
                return new OkObjectResult(res);
            }
            else
            {
                return BadRequest("Not fetched");
            }
        }

        [HttpGet]
        [Route("GetRating/{rating}")]

        public ActionResult GetRating(string rating)
        {
            _logger.LogInformation("Get called on :" + DateTime.Now.ToString() + Request.Host.Value);

            var result = _service.GetByRating(rating);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            else
            {
                return BadRequest("Not Found");
            }
        }



        [HttpGet]
        [Route("Getbyemail/{Id}")]

        public ActionResult GetByEmail(string Id)
        {
            _logger.LogInformation("Get with id called on :" + DateTime.Now.ToString() + Request.Host.Value);
            var result = _service.GetByUserEmail(Id);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            else
            {
                return BadRequest("Not Found");
            }
        }



        // POST api/<FeedbackController>
        //A FeedBAck is Created
        [HttpPost]
        public IActionResult Post([FromBody] Feedback value)
        {
            if (value == null)
            {
                return BadRequest("not added");
            }
            //_logger.LogInformation("Post called on :" + DateTime.Now.ToString() + Request.Host.Value);

            if (_service.AddFeedBack(value))
            {
                return new OkObjectResult("added");
            }
            else
            {
                return BadRequest("not added");
            }
        }


        // PUT api/<FeedBackController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FeedBackController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}
