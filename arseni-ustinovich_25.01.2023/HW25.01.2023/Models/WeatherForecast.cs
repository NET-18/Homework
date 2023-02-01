using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW25._01._2023.Models
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TempC { get; set; }
        public int TempF => 32 + (int)(TempC / 0.5556);
        public string Summary { get; set; }
    }
}

