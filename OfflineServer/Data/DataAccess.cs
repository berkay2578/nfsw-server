using Microsoft.Win32;
using OfflineServer.Data.Settings;
using System;
using System.IO;
using System.Reflection;
using System.Security;
using System.Windows;

namespace OfflineServer.Data
{
    public class DataAccess
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
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
            for (int i = appSettings.NFSWorldExecutables.Count - 1; i >= 0; i--)
            {
                if (!File.Exists(appSettings.NFSWorldExecutables[i]))
                    appSettings.NFSWorldExecutables.RemoveAt(i);
            }

            executablesAddNew();

            #region Registry Check @App-Start
            log.Info("Trying to read registy.");
            RegistryKey regBaseKey = null, nfswKey = null;
            try
            {
                regBaseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                nfswKey = regBaseKey.OpenSubKey(@"Software\Electronic Arts\Need For Speed World\", false);

                if (nfswKey == null)
                {
                    log.Info("Key doesn't exist in Registry32, checking Registry64.");
                    regBaseKey.Dispose();

                    regBaseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                    nfswKey = regBaseKey.OpenSubKey(@"Software\Electronic Arts\Need For Speed World\", false);
                    log.InfoFormat("Registry64 key status: {0}", nfswKey);
                }

                if (nfswKey != null)
                {
                    log.Info("Key found.");
                    Object installDir = nfswKey.GetValue("GameInstallDir");
                    if (installDir != null)
                    {
                        log.InfoFormat("GameInstallDir found: {0}", installDir.ToString());
                        String nfsw_exe = Path.Combine(installDir.ToString(), "Data", "nfsw.exe");
                        if (!appSettings.NFSWorldExecutables.Contains(nfsw_exe))
                        {
                            appSettings.NFSWorldExecutables.Add(nfsw_exe);
                        }
                    }
                }
            }
            catch (SecurityException sex) // ( ͡° ͜ʖ ͡°)
            {
                log.Error("A security exception occured while working on registry.", sex);
                MessageBox.Show("This user doesn't have the permissions required to read registry.\r\n" +
                    "OfflineServer won't be able to locate nfsw.exe automatically.",
                    "A security exception occured!",
                    MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
            }
            finally
            {
                if (regBaseKey != null)
                    regBaseKey.Dispose();
                if (nfswKey != null)
                    nfswKey.Dispose();
            }
            #endregion

            appSettings.saveInstance();
        }

        public DataAccess()
        {
            log.Info("Setting up DataAccess.");
            #region AppSettings
            if (DataEx.xml_SettingsExists)
            {
                log.Info("Reading from local AppSettings.");
                appSettings = DataEx.getInstanceFromXml<AppSettings>();
                if (appSettings == default(AppSettings))
                {
                    log.Warn("Instance is null! Creating new.");
                    appSettings = new AppSettings();
                    appSettings.saveInstance();
                }
            }
            else
            {
                log.Warn("AppSettings doesn't exist! Creating new.");
                appSettings = new AppSettings();
                appSettings.saveInstance();
            }
            executablesManage();
            #endregion
        }
    }
}