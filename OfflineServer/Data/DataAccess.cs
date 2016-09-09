using OfflineServer.Data.Settings;

namespace OfflineServer.Data
{
    public class DataAccess
    {
        public AppSettings appSettings { get; set; }

        public DataAccess()
        {
            #region AppSettings
            if (DataEx.xml_SettingsExists)
            {
                appSettings = DataEx.getInstanceFromXml<AppSettings>();
            }
            else
            {
                appSettings = new AppSettings();
                appSettings.uiSettings.doDefault();
                appSettings.saveInstance();
            }
            #endregion
        }
    }
}
