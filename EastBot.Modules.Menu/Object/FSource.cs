using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Modules.Menu.Object
{
    public class FSource
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "term")]
        public string Name { get; set; }
    }
}
