using WeartherServeApi.Model;

namespace WeartherServeApi.Service
{
    public interface IServiceAirPolution
    {
        Task<GeoLocationModel> GetLocation(string city);
    }
}
