using System;
using Newtonsoft.Json;

namespace SendMessage
{
    [JsonObject]
    public class ApplicationMessage
    {
        [JsonProperty("userId")]
        public Guid? UserId { get; set; }

        [JsonProperty("arguments")]
        public object Arguments { get; set; }
    }
}
