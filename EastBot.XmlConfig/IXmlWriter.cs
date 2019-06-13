using System;
using System.Collections.Generic;
using System.Text;

namespace XmlConfig
{
    public interface IXmlWriter
    {
        void SaveDataToXml<T>(T data, string path);
        void SaveDataToXml<T>(T data, string path, Encoding encoding);
    }
}
