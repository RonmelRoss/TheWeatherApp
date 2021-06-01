using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Weather.Services.Client
{
    public class WeatherClient
    {
        private readonly HttpClient _client;
        public WeatherClient(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<Response> GetAsync<Response>(string requestUri)
        {
            try
            {
                var resp = await _client.GetAsync(requestUri);
                var content = await resp.Content.ReadFromJsonAsync<Response>();
                return content;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}