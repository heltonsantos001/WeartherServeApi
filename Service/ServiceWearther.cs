using System.Text.Json;
using WeartherServeApi.Model;
using static System.Net.WebRequestMethods;


namespace WeartherServeApi.Service
{
    public class ServiceWearther : IServiceWearther
    {
         
        private readonly string ApiKey = "c773e0683a1b0eb97feec80c561d87ce";


        private readonly HttpClient client;

        public ServiceWearther(HttpClient httpClient)
        {
            client = httpClient;

        }

        public async Task<ServiceResponse<WeartherNowModel>> GetWeartherService(string city)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={ApiKey}&lang=pt&units=metric";

            ServiceResponse<WeartherNowModel> response = new();

            try { 

                    HttpResponseMessage httpResponse = await client.GetAsync(url);

                 if (httpResponse.IsSuccessStatusCode)
                 {
                    string jsonResponse = await httpResponse.Content.ReadAsStringAsync();                 

                    var ApiResponse = JsonSerializer.Deserialize<WeartherNowModel>(jsonResponse);
                   

                    if (ApiResponse != null)
                    {
                       
                        response.Data = ApiResponse;
                        response.Success = true;
                        response.Message = "Weather data retrieved successfully.";
                    }
                    else
                    {
                        response.Data = null;
                        response.Success = false;
                        response.Message = "Error deserializing weather data.";
                    }

                }
                else
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = $"Error retrieving weather data. Status code: {httpResponse.StatusCode}";
                }

                


            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Success = false;
                response.Message = $"Exception occurred: {ex.Message}";
            }

            return response;
        }

       
    }
}
