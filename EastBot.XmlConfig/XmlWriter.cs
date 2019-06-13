using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace XmlConfig
{
    public class XmlWriter : IXmlWriter
    {
        public void SaveDataToXml<T>(T data, String path)
        {
            Encoding utf8WithoutBom = new UTF8Encoding(true);
            SaveDataToXml<T>(data, path, utf8WithoutBom);
        }
        public void SaveDataToXml<T>(T data, String path, Encoding encoding)
        {
            if (path.Contains("\\"))
            {
                var s = path.Split('\\');
                string curPath = "";
                for (int i = 0; i < s.Length - 1; i++)
                {
                    if (!Directory.Exists(curPath + s[i]))
                        Directory.CreateDirectory(curPath + s[i]);
                    curPath += s[i] + "\\";
                }
            }
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StreamWriter writer = new StreamWriter(path, false, encoding);
            serializer.Serialize(writer, data);
            writer.Close();
        }
    }
}
