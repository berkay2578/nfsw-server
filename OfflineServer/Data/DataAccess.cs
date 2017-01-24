using Microsoft.Win32;
using OfflineServer.Data.Settings;
using System;
using System.IO;

namespace OfflineServer.Data
{
    public class DataAccess
    {
        public AppSettings appSettings { get; set; }

        public void executablesAddNew()
        {
            if (!appSettings.NFSWorldExecutables.Contains(appSettings.uiSettings.language.AddNew))
            {
                if (appSettings.NFSWorldExecutables.Count > 0)
                {
                    if (!appSettings.NFSWorldExecutables[0].EndsWith(".exe"))
                        appSettings.NFSWorldExecutables.RemoveAt(0);

                    appSettings.NFSWorldExecutables.Insert(0, appSettings.uiSettings.language.AddNew);
                    appSettings.saveInstance();
                }
                else
                {
                    appSettings.NFSWorldExecutables.Add(appSettings.uiSettings.language.AddNew);
                    appSettings.saveInstance();
                }
            }
        }

        private void executablesManage()
        {
            appSettings.NFSWorldExecutables.RemoveAll(e => !File.Exists(e));
            executablesAddNew();

            #region Registry Check @App-Start
            RegistryKey regBaseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            RegistryKey nfswKey = regBaseKey.OpenSubKey(@"Software\Electronic Arts\Need For Speed World\", false);

            if (nfswKey == null)
            {
                regBaseKey.Dispose();
                nfswKey.Dispose();
                regBaseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                nfswKey = regBaseKey.OpenSubKey(@"Software\Electronic Arts\Need For Speed World\", false);
            }

            if (nfswKey != null)
            {
                Object installDir = nfswKey.GetValue("GameInstallDir");
                if (installDir != null)
                {
                    String nfsw_exe = Path.Combine(installDir.ToString(), "Data", "nfsw.exe");
                    if (!appSettings.NFSWorldExecutables.Contains(nfsw_exe))
                    {
                        appSettings.NFSWorldExecutables.Add(nfsw_exe);
                    }
                }
            }
            regBaseKey.Dispose();
            nfswKey.Dispose();
            #endregion

            appSettings.saveInstance();
        }

        public DataAccess()
        {
            #region AppSettings
            if (DataEx.xml_SettingsExists)
            {
                appSettings = DataEx.getInstanceFromXml<AppSettings>();
                if (appSettings == default(AppSettings))
                {
                    appSettings = new AppSettings();
                    appSettings.saveInstance();
                }
            }
            else
            {
                appSettings = new AppSettings();
                appSettings.saveInstance();
            }
            executablesManage();
            #endregion
        }
    }
}