using EastBot.Modules.Menu.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Modules.Plejada.Object
{
    public class FItems
    {
        public FItems()
        {
        }

        public FItems(int id, string createdDate, string uRLAddress, string message)
        {
            Id = id;
            CreatedDate = createdDate;
            URLAddress = uRLAddress;
            Message = message;
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "external_created_at")]
        public string CreatedDate { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "full_url")]
        public string URLAddress { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "source")]
        public FSource Source { get; set; }

        public string GetMessage()
        {
            return Message.Replace("<p>", "**").Replace("</p>", "**").Replace("<br />", "\n");
        }
    }
}
