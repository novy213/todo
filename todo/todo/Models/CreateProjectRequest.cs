using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace todo.Models
{
    public class CreateProjectRequest
    {
        [JsonProperty("project_name")]
        public string Project_name { get; set; }
        [JsonProperty("user_id")]
        public int User_id { get; set; }
    }
}
