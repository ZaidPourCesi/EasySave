using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;

namespace easySaveV3
{
    
    public class ConfigHelper
    {

        String Attr;
        public void ReadAllSettings()
        {
            try
            {
                NameValueCollection appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (String key in appSettings.AllKeys)
                    {
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        public string GetParticularKeyValue(String l)
        {
            return (Attr = ConfigurationManager.AppSettings.Get(l));
        }

        public void ReadSetting(string key)
        {
            try
            {
                NameValueCollection appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                Console.WriteLine("Key: {0} Value: {1}", key, result);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        public void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;

                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        public void AddUpdateExtensionSettings(string key, string value)
        {
            try
            {
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection extensionsSection = (AppSettingsSection)configFile.GetSection("ExtensionsSettings");

                if (extensionsSection.Settings[key] == null)
                {
                    extensionsSection.Settings.Add(key, value);
                }
                else
                {
                    extensionsSection.Settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        public void RemoveExtensionSettings(string key)
        {
            try
            {
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection extensionsSection = (AppSettingsSection)configFile.GetSection("ExtensionsSettings");

                if (extensionsSection.Settings[key] == null)
                {
                    Console.WriteLine("Error removing extension settings : wrong attribute name");
                }
                else
                {
                    extensionsSection.Settings.Remove(key);
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing extension settings");
            }
        }
        public void ReadExtension(string key)
        {
            try
            {
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection extensionsSection = (AppSettingsSection)configFile.GetSection("ExtensionsSettings");
                string result = extensionsSection.Settings[key].Value;
                Console.WriteLine("Key: {0} Value: {1}", key, result);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        public List<string> ListExtension(int ext)
        {
            List<string> listext = new List<string>();
            String extType = "ErrorExtension";

            if (ext == 0)
            {
                extType = "ExtensionsSettings";
            }else if (ext == 1)
            {
                extType = "ExtensionsBanSettings";
            }

            try
            {
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection extensionsSection = (AppSettingsSection)configFile.GetSection(extType);

                foreach (var key in extensionsSection.Settings.AllKeys)
                {
                    //Console.WriteLine("Key: {0} Value: {1}", key, extensionsSection.Settings[key].Value);
                    listext.Add(key + " : " + extensionsSection.Settings[key].Value);
                    // string value = extensionsSection.Settings[key].Value;
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading extentions app settings");
            }

            return listext;
        }

        public bool AddExtension(string key, string value, int ext)
        {

            String extType = "ErrorExtension";

            if (ext == 0)
            {
                extType = "ExtensionsSettings";
            }
            else if (ext == 1)
            {
                extType = "ExtensionsBanSettings";
            }


            try
            {
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection extensionsSection = (AppSettingsSection)configFile.GetSection(extType);

                if (extensionsSection.Settings[key] == null)
                {
                    extensionsSection.Settings.Add(key, value);
                }
                else
                {
                    //extensionsSection.Settings.Add("non", "non");
                    //extensionsSection.Settings[key].Value = value;
                    return false;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
            return true;
        }

        public bool RemoveExtension(string key, int ext)
        {

            String extType = "ErrorExtension";

            if (ext == 0)
            {
                extType = "ExtensionsSettings";
            }
            else if (ext == 1)
            {
                extType = "ExtensionsBanSettings";
            }

            try
            {
                Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection extensionsSection = (AppSettingsSection)configFile.GetSection(extType);

                if (extensionsSection.Settings[key] == null)
                {
                    //Console.WriteLine("Error removing extension settings : wrong attribute name");
                    return false;
                }
                else
                {
                    extensionsSection.Settings.Remove(key);
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                return false;
                //Console.WriteLine("Error writing extension settings");
            }

            return true;
        }

    }

}