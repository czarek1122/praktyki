using System;
using System.Collections.Generic;
using System.Text;

namespace Eastbot.Objects
{
    public class Channel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "team_id")]
        public string TeamId { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "channel_id")]
        public string ChannelId { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "msg_count")]
        public int UnreadMessageCount { get; set; }

        public Channel(string TeamId, string ChannelId, int unread)
        {
            this.TeamId = TeamId;
            this.ChannelId = ChannelId;
            this.UnreadMessageCount = unread;
        }
    }
}
