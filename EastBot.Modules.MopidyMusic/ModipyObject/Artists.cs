using System;
using System.Collections.Generic;
using System.Text;

namespace Eastbot.Objects.ModipyObject
{
    public class Artists
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "__model__")]
        public string ArtistsModel { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string ArtistsName { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "uri")]
        public string AddressURI { get; set; }
    }
}
