using WeartherServeApi.Model;

namespace WeartherServeApi.Service
{
    public interface IServiceAirPolution
    {
        Task<List<GeoLocationModel>> GetLocation(string city);
        Task<ServiceResponse<AirPolutionModel>> GetAirPolution(string city);
    }
}
