using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_site.Database.Tables;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_site.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonsController : ControllerBase
    {
        public LessonsController()
        {

        }
        [HttpGet]
        public async Task<IActionResult> GetLessons()
        {
            List<Lesson> lesons = new()
            {
                new Lesson() { Order = 1, StartTime = "8:00", FinishTime = "8:45" },
                new Lesson() { Order = 2, StartTime = "9:00", FinishTime = "9:45" },
                new Lesson() { Order = 3, StartTime = "10:00", FinishTime = "10:45" },
                new Lesson() { Order = 4, StartTime = "11:00", FinishTime = "11:45" },
                new Lesson() { Order = 5, StartTime = "12:00", FinishTime = "12:45" },
                new Lesson() { Order = 6, StartTime = "13:00", FinishTime = "13:45" },
                new Lesson() { Order = 7, StartTime = "14:00", FinishTime = "14:45" },
                new Lesson() { Order = 8, StartTime = "15:00", FinishTime = "15:45" },
            };
            return Ok(lesons);
        } 
    }
}