using System;
using System.Collections.Generic;
using System.Text;

namespace Eastbot.Objects.ModipyObject
{
    public class Track
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "album")]
        public Album Album { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "__model__")]
        public string TrackModel { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string TrackName { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "disc_no")]
        public string TrackDiscNo { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "uri")]
        public string TrackUri { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "length")]
        public int TrackLength { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "track_no")]
        public int TrackNo { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "artists")]
        public List<Artists> ArtistsList { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "date")]
        public string TrackDate { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "birtrate")]
        public int TrackBirtrate { get; set; }

        public string GetAllArtists()
        {
            string temp = "";

            foreach (var item in ArtistsList)
            {
                temp = temp + item.ArtistsName + " ";
            }

            return temp;
        }
    }
}
