using MMS.DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MMS.Helpers
{
    public interface IConfiguration
    {
        IDictionary<string, string> GetAllSettings();
        T GetSetting<T>(string key);
        void SetSetting<T>(string key, T value);
    }

    public class Configuration : IConfiguration
    {
        public ApplicationContext _db = new ApplicationContext();

        public IDictionary<string, string> GetAllSettings()
        {
            var settings = new Dictionary<string, string>();
            var appSettings = ConfigurationManager.AppSettings;

            foreach (var setting in appSettings.AllKeys)
            {
                settings.Add(setting, appSettings[setting]);
            }

            return settings;
        }

        public T GetSetting<T>(string key)
        {
            var result = default(T);
            var setting = ConfigurationManager.AppSettings[key];

            if (!string.IsNullOrEmpty(setting))
                result = CommonUtils.To<T>(setting);

            return result;
        }

        public void SetSetting<T>(string key, T value)
        {
            throw new InvalidOperationException("Cannot save settings to the application configuration file");
        }

        public IDictionary<string, string> GetAllDbSettings()
        {
            var data = (from r in this._db.Configs
                       select r).ToDictionary(r => r.Key, r => r.Value);

            return data;
        }

        public string GetDbSetting(string key)
        {
            var setting = from r in this._db.Configs
                          where r.Key.Equals(key)
                          select r;

            string result = null;

            if (! string.IsNullOrEmpty(setting.ToString()))
            {
                result = setting.ToString();
            }

            return result;
        }
    }
}