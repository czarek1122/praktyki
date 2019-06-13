using System;
using System.Collections.Generic;
using System.Text;

namespace Eastbot.Objects
{
    public class Channel2
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string ChannelId { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
