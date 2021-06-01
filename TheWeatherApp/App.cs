using System.Threading.Tasks;
using Weather.Services.Interface;

namespace TheWeatherApp
{
    class App
    {
        private readonly IWeatherServices _service;
        public App(IWeatherServices service)
        {
            _service = service;
        }

        public async Task RunAsync()
        {
            string zipCode = ConsoleWriter.InputZipCode();

            var resp = await _service.GetWeatherInfoByZipCodeAsync(zipCode);

            ConsoleWriter.Output(resp);
        }
    }
}
