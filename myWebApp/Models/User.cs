

namespace myWebApp.Models
{
    using Newtonsoft.Json;
    using System;
    public class User
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

    }
}