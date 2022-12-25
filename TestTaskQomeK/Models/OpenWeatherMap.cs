using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestTaskQomeK.Models
{
    public class OpenWeatherMap
    {
        public string apiResponse { get; set; }

        public Dictionary<string, string> cities
        {
            get; set;
        }
    }
}