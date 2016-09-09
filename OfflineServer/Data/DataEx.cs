using OfflineServer.Data.Settings;
using OfflineServer.Servers;
using System;
using System.IO;
using System.Text;

namespace OfflineServer.Data
{
    public static class DataEx
    {
        #region dirs
        public static readonly String dir_Data = Path.Combine(Environment.CurrentDirectory, @"Data\");

        public static readonly String dir_Logs = Path.Combine(dir_Data, @"Logs\");

        public static readonly String dir_Database = Path.Combine(dir_Data, @"Database\");
        public static readonly String dir_Server = Path.Combine(dir_Data, @"Server\");
        public static readonly String dir_HttpServerFallback = Path.Combine(dir_Server, @"Files\");

        public static readonly String dir_UI = Path.Combine(dir_Data, @"UI\");
        public static readonly String dir_Accents = Path.Combine(dir_UI, @"Accents\");
        public static readonly String dir_Themes = Path.Combine(dir_UI, @"Themes\");
        #endregion
        #region databases
        public static readonly String db_Server = Path.Combine(dir_Database, "Server.db");
        #endregion
        #region xmls
        public static readonly String xml_Settings = Path.Combine(dir_Data, "AppSettings.xml");
        #endregion
        #region logs
        public static readonly String log_Events = Path.Combine(dir_Logs, "EventLog.log");
        #endregion
        #region fields
        public static Boolean db_ServerExists
        {
            get
            {
                return File.Exists(db_Server);
            }
        }
        public static Boolean xml_SettingsExists
        {
            get
            {
                return File.Exists(xml_Settings);
            }
        }
        #endregion
        #region functions
        public static T getInstanceFromXml<T>()
        {
            String xmlPath;

            if (typeof(T) == typeof(AppSettings))
                xmlPath = xml_Settings;
            else
                return default(T);

            String plainXml = File.ReadAllText(xmlPath, Encoding.UTF8);
            return Serialization.DeserializeObject<T>(plainXml);
        }
        #endregion
    }
}
