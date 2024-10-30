using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeartherServeApi.Model;
using WeartherServeApi.Service;

namespace WeartherServeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirpolutionController : ControllerBase
    {
        private readonly IServiceAirPolution _serviceAirPolution;

        public AirpolutionController(IServiceAirPolution serviceAirPolution)
        {
            this._serviceAirPolution = serviceAirPolution;
        }
        
        [HttpGet("GeoLocation")]
        public async Task<ActionResult> GetAirPolution(string city) {

            List<GeoLocationModel> geo = await _serviceAirPolution.GetLocation(city);
            return Ok(geo);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<AirPolutionModel>>> GetAirPolutionCity(string city)
        {
            ServiceResponse<AirPolutionModel> response = new();
            try {
                response = await _serviceAirPolution.GetAirPolution(city);              
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
