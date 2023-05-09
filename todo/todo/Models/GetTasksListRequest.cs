using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo.Models
{
    public class GetTasksListRequest
    {
        [JsonProperty("project_id")]
        public int Project_id { get; set; }
    }
}
