using EastBot.Modules.Plejada.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Modules.Menu.Object
{
    public class CResult
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "posts")]
        public List<CPost> Posts { get; set; }
    }
}
