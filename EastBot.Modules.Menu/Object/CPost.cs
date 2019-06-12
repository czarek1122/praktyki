using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Modules.Menu.Object
{
    public class CPost
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int ID { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "text")]
        public string Message { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "user_screen_name")]
        public string Name { get; set; }
    }
}
