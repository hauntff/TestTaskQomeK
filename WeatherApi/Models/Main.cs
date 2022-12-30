using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApi.Models
{
    public class Main
    {
        public double K = 273.15;
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }

        public void ConToC()
        {
            temp = temp - K;
            temp_max = temp_max - K;
            temp_min = temp_min - K;
            feels_like = feels_like - K;
        }
    }
}
