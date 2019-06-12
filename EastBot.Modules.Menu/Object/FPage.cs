using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Modules.Plejada.Object
{
    public class FPage
    {
        public FPage()
        {
        }

        public FPage(int id, string name, FPost posts)
        {
            Id = id;
            Name = name;
            Posts = posts;
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "posts")]
        public FPost Posts { get; set; }
    }
}
