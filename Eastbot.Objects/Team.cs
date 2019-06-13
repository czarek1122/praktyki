using System;
using System.Collections.Generic;
using System.Text;

namespace Eastbot.Objects
{
    public class Team
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        

        public Team(string Id)
        {
            this.Id = Id;
        }
    }
}
