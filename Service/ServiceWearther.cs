using System.Text.Json;
using WeartherServeApi.Model;


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

        public async Task<ServiceResponse<WeartherMonthModel>> GetWeartherMonthService(string city)
        {
            string url = $"https://pro.openweathermap.org/data/2.5/forecast/climate?q={city}&appid={ApiKey}&units=metric&lang=pt_br";

            ServiceResponse<WeartherMonthModel> response = new();

            try {

                HttpResponseMessage httpResponse = await client.GetAsync(url);

                if(!httpResponse.IsSuccessStatusCode)
                {
                    response.Success = false;
                    response.Message = $"erro ao consumir api: {httpResponse.RequestMessage}";
                }

                string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                var ApiResponse = JsonSerializer.Deserialize<WeartherMonthModel>(jsonResponse);

                response.Data = ApiResponse;
                response.Success = ApiResponse != null;
                response.Message = ApiResponse != null ? "Weather data retrieved successfully." : "Error deserializing weather data.";


            }
            catch (Exception ex) {

                response.Data = null;
                response.Success = false;
                response.Message = $"Exception occurred: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<WeartherNowModel>> GetWeartherService(string city)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={ApiKey}&lang=pt_br&units=metric";

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
