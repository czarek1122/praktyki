using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XmlConfig
{
    [XmlRoot("ApplicationSettings")]
    public class RootElement
    {
        [XmlArray(ElementName = "MainSettings")]
        public List<Setting> MainSettings { get; set; }

        [XmlArray(ElementName = "ModuleSettings")]
        public List<Setting> ModuleSettings { get; set; }
    }
}
