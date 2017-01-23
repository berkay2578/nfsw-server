using System;
using System.IO;
using System.Text;

namespace AddonManager
{
    public static class Access
    {
        public static AppSettings appSettings;

        static Access()
        {
            if (File.Exists(AddonEx.xml_Settings))
            {
                String plainXml = File.ReadAllText(AddonEx.xml_Settings, Encoding.UTF8);
                appSettings = DerivedFunctions.DeserializeObject<AppSettings>(plainXml);
            }
            else
            {
                appSettings = new AppSettings();
                appSettings.saveInstance();
            }
        }
    }
}
