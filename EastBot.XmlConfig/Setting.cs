using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XmlConfig
{
    public class Setting
    {
        [XmlAttribute]
        public string Module { get; set; }
        [XmlAttribute]
        public string Key { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
}
