using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace dotnet_site.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemperatureHumidityController : ControllerBase
    {
        private IMemoryCache cache;
        public TemperatureHumidityController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        [HttpPost]
        public async Task<IActionResult> SetData([FromBody]TemperatureHumidity tempH)
        {
            cache.Set("tempH", tempH);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            return Ok(cache.Get("tempH"));
        }
    }

    public class TemperatureHumidity
    {
        public float temp { get; set; }
        public int Humidity { get; set; }
    }
}