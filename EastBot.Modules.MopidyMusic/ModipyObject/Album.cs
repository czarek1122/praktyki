using System;
using System.Collections.Generic;
using System.Text;

namespace Eastbot.Objects.ModipyObject
{
    public class Album
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "__model__")]
        public string Model { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "artists")]
        public List<Artists> ArtistsList { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string AlbumName { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "uri")]
        public string AlbumURI { get; set; }
    }
}
