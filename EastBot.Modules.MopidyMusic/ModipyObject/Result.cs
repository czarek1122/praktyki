namespace EastBot.Modules.MopidyMusic.ModipyObject
{
    public class Result<T>
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "jsonrpc")]
        public string JsonRPC { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int SongId { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "result")]
        public T Value { get; set; }
    }
}
