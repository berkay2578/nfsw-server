using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace AddonManager
{
    [Serializable()]
    public class AppSettings
    {
        [XmlElement()]
        public Boolean hasRunAddonManagerBefore = false;

        public void saveInstance()
        {
            File.WriteAllText(AddonEx.xml_Settings, this.serializeObject(), Encoding.UTF8);
        }
    }
}
