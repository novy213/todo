using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo.Models
{
    public class RegisterRequest
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("last_name")]
        public string Last_name { get; set; }
    }
}
