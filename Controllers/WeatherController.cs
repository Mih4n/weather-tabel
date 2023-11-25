using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace dotnet_site.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private IMemoryCache cache;
        public WeatherController(IMemoryCache cache)
        {
            this.cache = cache;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetWeather()
        {
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
                    result = (await client.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?lat=53.1384&lon=29.2214&appid=03504050d0e1fddb0e834af230d931d8")).ToString();
                    cache.Set("weather", (object)result, DateTime.Now.AddMinutes(5));
                    Console.WriteLine("Im there" + DateTime.Now.ToShortTimeString());
                }
            }
            return Ok(result);
        }
    }
}