using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo.Models
{
    public class MarkTaskRequest
    {
        [JsonProperty("done")]
        public int Done { get; set; }
    }
}
