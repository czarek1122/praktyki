using System;
using System.Collections.Generic;
using System.Text;

namespace Eastbot.Objects
{
    public class PostsList
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "order")]
        public List<string> PostId { get; set; }

        public PostsList(List<string> id)
        {
            this.PostId = id;
        }
    }
}
