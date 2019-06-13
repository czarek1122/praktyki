using System;
using System.Collections.Generic;
using System.Text;

namespace Eastbot.Objects
{
    public class Clauds
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "all")]
        public double ClaudsValue { get; set; }

        public Clauds(double clauds)
        {
            this.ClaudsValue = clauds;
        }

        public Clauds()
        {
        }
    }
}
