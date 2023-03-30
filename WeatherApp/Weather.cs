using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Weather
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
