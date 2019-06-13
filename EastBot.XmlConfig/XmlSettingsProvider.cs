using System;
using System.Linq;

namespace XmlConfig
{
    public class XmlSettingsProvider : ISettingsProvider
    {
        private RootElement rootElement;
        public XmlSettingsProvider(IXmlReader reader/*, IXmlWriter writer*/)
        {
            rootElement = reader.LoadDataFromXml<RootElement>("eastbot.config");
        }

        #region ISettingsProvider Members
        public decimal GetDecimal(string key)
        {
            var value = getSetting(null, key).Value;
            try
            {
                return Convert.ToDecimal(value);

            }
            catch (System.FormatException)
            {
                throw new Exception("cos");
                //throw new CannotGetSettingException(key, value);
            }
        }

        public decimal GetDecimal(string module, string key)
        {
            var value = getSetting(module, key).Value;
            try
            {
                return Convert.ToDecimal(value);

            }
            catch (System.FormatException)
            {
                throw new Exception("cos");
                //throw new CannotGetSettingException(key, value);
            }
        }

        public int GetInt(string key)
        {
            var value = getSetting(null, key).Value;
            try
            {
                return Convert.ToInt32(value);

            }
            catch (System.FormatException)
            {
                throw new Exception("cos");
                //throw new CannotGetSettingException(key, value);
            }
        }

        public int GetInt(string module, string key)
        {
            var value = getSetting(module, key).Value;
            try
            {
                return Convert.ToInt32(value);

            }
            catch (System.FormatException)
            {
                throw new Exception("cos");
                //throw new CannotGetSettingException(key, value);
            }
        }

        public string GetString(string key)
        {
            return getSetting(null, key).Value;
        }

        public string GetString(string module, string key)
        {
            return getSetting(module, key).Value;
        }

        public DateTime GetDateTime(string module, string key)
        {
            var value = getSetting(module, key).Value;
            try
            {
                return Convert.ToDateTime(value);

            }
            catch (System.FormatException)
            {
                throw new Exception("cos");
                //new CannotGetSettingException(key, value);
            }
        }

        public DateTime GetDateTime(string key)
        {
            var value = getSetting(null, key).Value;
            try
            {
                return Convert.ToDateTime(value);

            }
            catch (System.FormatException)
            {
                throw new Exception("cos");
                //throw new CannotGetSettingException(key, value);
            }
        }
        #endregion

        #region Helpers
        private Setting getSetting(string module, string key)
        {
            Setting elem = null;
            if (module == null)
            {
                elem = rootElement.MainSettings.FirstOrDefault(x => x.Key == key);
                if (elem == null)
                {
                    throw new Exception("cos");
                    //throw new SettingNotFoundException(key);
                }
            }
            else
            {
                elem = rootElement.ModuleSettings.FirstOrDefault(x => x.Module == module && x.Key == key);
                if (elem == null)
                {
                    throw new Exception("cos");
                    //throw new SettingNotFoundException(module, key);
                }
            }
            return elem;
        }
        #endregion
    }
}
