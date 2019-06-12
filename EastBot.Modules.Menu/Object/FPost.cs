using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Modules.Plejada.Object
{
    public class FPost
    {
        public FPost()
        {
        }

        public FPost(List<FItems> itemsList)
        {
            ItemsList = itemsList;
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "items")]
        public List<FItems> ItemsList { get; set; }
    }
}
