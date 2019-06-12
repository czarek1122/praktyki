using System;
using System.Collections.Generic;
using System.Text;

namespace XmlConfig
{
    public interface ISettingsProvider
    {
        string GetString(string key);
        int GetInt(string key);
        decimal GetDecimal(string key);
        DateTime GetDateTime(string key);

        string GetString(string module, string key);
        int GetInt(string module, string key);
        decimal GetDecimal(string module, string key);
        DateTime GetDateTime(string module, string key);
    }
}
