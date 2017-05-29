using System;
using System.Configuration;
using System.Reflection;

namespace POPC_TRACEABILITY
{
    public class SettingHelper
    {
        private static string SettingLocation()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            return location;
        }

        private static Configuration AppConfig()
        {
            return ConfigurationManager.OpenExeConfiguration(SettingLocation());
        }
        private static object GetCreateSetting(string parameter, string value)
        {
            var kk = AppConfig();
            try
            {
                return kk.AppSettings.Settings[parameter].Value;
            }
            catch (Exception)
            {
                kk.AppSettings.Settings.Add(new KeyValueConfigurationElement(parameter, value));
                kk.Save();
                return kk.AppSettings.Settings[parameter].Value;
            }
        }
        private static void SetCreateSetting(string parameter, string value)
        {
            var kk = AppConfig();
            try
            {
                kk.AppSettings.Settings[parameter].Value = value;
                kk.Save();
            }
            catch (Exception)
            {
                kk.AppSettings.Settings.Add(new KeyValueConfigurationElement(parameter, value));
                kk.Save();
            }
        }
        private static object GetSetting(string key)
        {
            try
            {
                return AppConfig().AppSettings.Settings[key].Value;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public static string PlcIpAddress()
        {
            return (string)GetCreateSetting("PlcIpAddress","192.168.0.1");
        }
        public static int PlcPort()
        {
            return Convert.ToInt32(GetCreateSetting("PlcPort","502"));
        }
        public static int PlcReadInterval()
        {
            return Convert.ToInt32(GetCreateSetting("PlcReadInterval","500"));
        }
        public static void SetPlcIpAddress(string value)
        {
            SetCreateSetting("PlcIpAddress", value);
        }
        public static void SetReadInterval(int value)
        {
            SetCreateSetting("PlcReadInterval", value.ToString());
        }
        public static void SetPlcPort(int value)
        {
            SetCreateSetting("PlcPort", value.ToString());
        }
    }
}
