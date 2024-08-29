using Newtonsoft.Json;

namespace Agit_ChairulHamid.Models
{
    public class ServiceResponse
    {
        [JsonProperty(PropertyName = "status")]
        public int status { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string message { get; set; }
        [JsonProperty(PropertyName = "data")]
        public Object data { get; set; }
    }
}