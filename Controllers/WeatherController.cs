using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace dotnet_site.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private IMemoryCache cache;
        private IConfiguration configuration;
        public WeatherController(IMemoryCache cache, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.cache = cache;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetWeather()
        {
            Console.WriteLine(configuration.GetValue<string>("WeatherMapKey")+"is it ex");
            var cachedData = (string)cache.Get("weather");
            string result;
            if(cachedData != null)
            {
                Console.WriteLine(cachedData);
                return Ok(cachedData); 
            }
            else
            {
                using (HttpClient client = new HttpClient())
                {
                    result = (await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?lat=53.1384&lon=29.2214&appid={configuration.GetValue<string>("WeatherMapKey")}")).ToString();
                    cache.Set("weather", (object)result, DateTime.Now.AddMinutes(5));
                    Console.WriteLine("Im there" + DateTime.Now.ToShortTimeString());
                }
            }
            return Ok(result);
        }
    }
}