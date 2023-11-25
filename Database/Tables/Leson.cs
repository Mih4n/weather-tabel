using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_site.Database.Tables
{
    public class Lesson
    {
        public int Order { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
    }
}