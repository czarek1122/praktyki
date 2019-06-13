using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XmlConfig
{
        public interface IXmlReader
        {
            T LoadDataFromXml<T>(FileInfo file);
            T LoadDataFromXml<T>(FileInfo file, Encoding encoding);
            T LoadDataFromXml<T>(string path);
            T LoadDataFromXml<T>(string path, Encoding encoding);
        }
}
