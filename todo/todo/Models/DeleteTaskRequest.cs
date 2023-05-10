using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo.Models
{
    public class DeleteTaskRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
