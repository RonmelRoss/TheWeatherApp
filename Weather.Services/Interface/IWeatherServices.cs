using System;
using System.Threading.Tasks;
using Weather.Services.Model;

namespace Weather.Services.Interface
{
    public interface IWeatherServices
    {
        Task<ServiceResponse> GetWeatherInfoByZipCodeAsync(string zipCode);
    }
}
