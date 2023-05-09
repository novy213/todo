using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo.Models
{
    public class GetTasksListResponse : APIResponse
    {
        [JsonProperty("tasks")]
        public List<Task> Tasks { get; set; }
    }
}
