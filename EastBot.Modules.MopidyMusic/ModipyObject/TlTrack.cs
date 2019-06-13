using System;
using System.Collections.Generic;
using System.Text;

namespace Eastbot.Objects.ModipyObject
{
    public class TlTrack
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "track")]
        public Track Track { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "__model__")]
        public string ResultModel { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "tlid")]
        public int ResultId { get; set; }
    }
}