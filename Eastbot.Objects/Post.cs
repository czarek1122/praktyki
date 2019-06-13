namespace Eastbot.Objects
{
    public class Post
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "channel_id")]
        public string Channel { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }

        public Post(string channel, string message)
        {
            this.Channel = channel;
            this.Message = message;
        }

        public Post(string channel)
        {
            this.Channel = channel;
        }

        public Post() { }
    }
}
