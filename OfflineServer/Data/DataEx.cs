using OfflineServer.Data.Settings;
using OfflineServer.Servers;
using System;
using System.IO;
using System.Text;
using static OfflineServer.Data.Settings.AppSettings.UISettings;

namespace OfflineServer.Data
{
    public static class DataEx
    {
        #region dirs
        public static readonly String dir_Data = @"Data\";

        public static readonly String dir_Logs = Path.Combine(dir_Data, @"Logs\");

        public static readonly String dir_Database = Path.Combine(dir_Data, @"Database\");
        public static readonly String dir_Server = Path.Combine(dir_Data, @"Server\");

        public static readonly String dir_HttpServerFiles = Path.Combine(dir_Server, @"Files\");
        public static readonly String dir_HttpServerFallback = Path.Combine(dir_HttpServerFiles, @"Fallback\");
        public static readonly String dir_HttpServerCatalogs = Path.Combine(dir_HttpServerFiles, @"Catalogs\");
        public static readonly String dir_HttpServerBaskets = Path.Combine(dir_HttpServerFiles, @"Baskets\");

        public static String dir_CurrentHttpServerCatalog;
        public static String dir_CurrentHttpServerCategories;
        public static String dir_CurrentHttpServerProducts;
        public static String dir_CurrentHttpServerBaskets;

        public static readonly String dir_MemoryPatches = Path.Combine(dir_Data, @"Memory Patches\");

        public static readonly String dir_UI = Path.Combine(dir_Data, @"UI\");
        public static readonly String dir_Accents = Path.Combine(dir_UI, @"Accents\");
        public static readonly String dir_Themes = Path.Combine(dir_UI, @"Themes\");
        public static readonly String dir_Languages = Path.Combine(dir_UI, @"Languages\");
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
        public static String currentHttpServerCatalog
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    dir_CurrentHttpServerCatalog = Path.Combine(dir_HttpServerCatalogs, value + "\\");
                    dir_CurrentHttpServerCategories = Path.Combine(dir_CurrentHttpServerCatalog, @"Categories\");
                    dir_CurrentHttpServerProducts = Path.Combine(dir_CurrentHttpServerCatalog, @"Products\");
                    dir_CurrentHttpServerBaskets = Path.Combine(dir_HttpServerBaskets, value + "\\");
                }
            }
        }
        #endregion
        #region functions
        public static T getInstanceFromXml<T>(String identifier = "")
        {
            String xmlPath;

            if (typeof(T) == typeof(AppSettings))
                xmlPath = xml_Settings;
            else if (typeof(T) == typeof(Language))
                xmlPath = Path.Combine(dir_Languages, identifier);
            else
                return default(T);

            if (!File.Exists(xmlPath)) return default(T);

            String plainXml = File.ReadAllText(xmlPath, Encoding.UTF8);
            return Serialization.DeserializeObject<T>(plainXml);
        }
        public static String getDataHierarchy()
        {
            String hierarchy = "Data Hierarchy:";
            foreach (String folderItem in Directory.GetFiles(dir_Data, "*.*", SearchOption.AllDirectories))
            {
                hierarchy += "\r\n" + folderItem;
            }
            return hierarchy + "\r\n<END>";
        }
        #endregion
    }
}