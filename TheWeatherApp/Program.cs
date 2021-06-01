using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Weather.Services.Client;
using Weather.Services.Implementaion;
using Weather.Services.Interface;

namespace TheWeatherApp
{
    class Program
    {
        public static async Task Main(string[] args) =>
            await ConfigureServices(args). 
                  GetService<App>().
                  RunAsync();

        private static ServiceProvider ConfigureServices(string[] args)
        {
            var service = new ServiceCollection();

            service.AddHttpClient<WeatherClient>(c => c.BaseAddress = new System.Uri("http://api.weatherstack.com"));

            service.AddTransient<IWeatherServices, WeatherServices>();

            service.AddTransient<App>();

            return service.BuildServiceProvider();
        }
    }
}
