using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo.Models
{
    public class RenameProjectRequest
    {
        [JsonProperty("project_name")]
        public string Project_name { get; set; }
    }
}
