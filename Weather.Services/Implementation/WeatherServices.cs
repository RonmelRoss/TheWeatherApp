using System;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Services.Client;
using Weather.Services.Interface;
using Weather.Services.Model;

namespace Weather.Services.Implementaion
{
    public class WeatherServices : IWeatherServices
    {

        private readonly WeatherClient _client;
        private const string API_KEY = "0f638c44e35b435cc4c65380d6a07617";

        public WeatherServices(WeatherClient client) => _client = client;

        public async Task<ServiceResponse> GetWeatherInfoByZipCodeAsync(string zipCode)
        {
            var query = new Dictionary<string, string>
            {
                ["access_key"] = API_KEY,
                ["query"] = zipCode,
            };

            try
            {
                var response = await _client.GetAsync<WeatherApiResponse>(QueryHelpers.AddQueryString("/current", query));

                if (response.Success == false)
                {
                    return new ServiceResponse {
                            ZipCodeValid = false
                    };
                }
                else
                {
                    return new ServiceResponse
                    {
                        FlyKite = response.Current.Wind_Speed > 15 && !response.Current.Weather_Descriptions.Any(a => a.ToLower().Contains("rain")),
                        GoOutSide = !response.Current.Weather_Descriptions.Any(a => a.ToLower().Contains("rain")),
                        WearSunScreen = response.Current.UV_Index > 3
                    };
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
