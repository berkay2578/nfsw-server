using MahApps.Metro;
using OfflineServer.Servers;
using System;
using System.IO;
using System.Text;
using System.Windows;

namespace OfflineServer
{
    public class Settings : ObservableObject
    {
        public UISettings uiSettings { get; set; }
        public Settings()
        {
            uiSettings = new UISettings();
        }

        public void saveInstance()
        {
            File.WriteAllText("Settings.xml", this.SerializeObject(), Encoding.UTF8);
        }

        public class UISettings : ObservableObject
        {
            private Accent accent;
            private AppTheme theme;

            public String Accent
            {
                get
                {
                    return accent.Name;
                }
                set
                {
                    if (value != null)
                    {
                        accent = ThemeManager.GetAccent(value);
                        if (theme != null) applyNewStyle();
                        RaisePropertyChangedEvent("Accent");
                    }
                }
            }
            public String Theme
            {
                get
                {
                    return theme.Name.Replace("Base", "");
                }
                set
                {
                    if (value != null)
                    {
                        theme = ThemeManager.GetAppTheme("Base" + value);
                        if (accent != null) applyNewStyle();
                        RaisePropertyChangedEvent("Theme");
                    }
                }
            }

            public void doDefault()
            {
                accent = ThemeManager.GetAccent("Steel");
                theme = ThemeManager.GetAppTheme("BaseDark");
                RaisePropertyChangedEvent("Accent");
                RaisePropertyChangedEvent("Theme");
                applyNewStyle();
            }

            public void applyNewStyle()
            {
                ThemeManager.ChangeAppStyle(Application.Current, accent, theme);
                if (Access.Settings != null) Access.Settings.saveInstance();
            }
        }
    }
}
