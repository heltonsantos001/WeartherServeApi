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

            ServiceResponse<WeartherNowModel> response = new();
            try { 
                response = await _serviceWearther.GetWeartherService(city);
            } 
            catch (Exception ex) 
            {
                response.Message = ex.Message;
            }
            if (!response.Success) return BadRequest(response);
            return Ok(response);
            
        }

        [HttpGet("WeartherMonth")]
        public async Task<ActionResult<ServiceResponse<WeartherMonthModel>>> GetWeartherMonth(string city)
        {
            ServiceResponse<WeartherMonthModel> response = new();
            try 
            { 
                response = await _serviceWearther.GetWeartherMonthService(city);
            }
            catch (Exception ex) 
            {
                response.Message = ex.Message;
            }
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }
    }
}
