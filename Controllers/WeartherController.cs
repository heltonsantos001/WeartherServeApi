using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeartherServeApi.Model;
using WeartherServeApi.Service;

namespace WeartherServeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : Controller
    {

        private readonly IServiceWearther _serviceWearther;

       
        public WeatherController(IServiceWearther serviceWearther)
        {
            _serviceWearther = serviceWearther;
        }

        [HttpGet("WeartherNow")]
        public async Task<ActionResult<ServiceResponse<WeartherNowModel>>> GetWearther(string city)
        {

            var response = await _serviceWearther.GetWeartherService(city);
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }
    }
}
