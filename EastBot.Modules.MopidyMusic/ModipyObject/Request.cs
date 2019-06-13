using System;
using System.Collections.Generic;
using System.Text;

namespace Eastbot.Objects
{
    public class Request
    {
        public Request(string methodType, List<object> paramsList)
        {
            MethodType = methodType;
            JsonRpc = "2.0";
            ParamsList = paramsList;
            MopidyRequestId = 1;
        }

        public Request(string methodType): this(methodType, new List<object>()) { }

        [Newtonsoft.Json.JsonProperty(PropertyName = "method")]
        public string MethodType { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "jsonrpc")]
        public string JsonRpc { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "params")]
        public List<object> ParamsList { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int MopidyRequestId { get; set; }
    }
}
