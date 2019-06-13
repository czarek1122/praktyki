using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace XmlConfig
{
    public class XmlReader : IXmlReader
    {
        public T LoadDataFromXml<T>(String path)
        {
            return LoadDataFromXml<T>(path, Encoding.GetEncoding("UTF-8"));
        }

        public T LoadDataFromXml<T>(FileInfo file)
        {
            return LoadDataFromXml<T>(file, Encoding.GetEncoding("UTF-8"));
        }

        public T LoadDataFromXml<T>(String path, Encoding encoding)
        {
            return LoadDataFromXml<T>(new FileInfo(path), encoding);
        }

        public T LoadDataFromXml<T>(FileInfo file, Encoding encoding)
        {
            if (!file.Exists)
                throw new FileNotFoundException(file.FullName);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T data = (T)serializer.Deserialize(file.OpenRead());
            return data;
        }
    }
}
