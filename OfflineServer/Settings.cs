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
            saveInstance();
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
                    if (accent.Name != value)
                    {
                        accent = ThemeManager.GetAccent(value);
                        applyNewStyle();
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
                    if (theme.Name != "Base" + value)
                    {
                        theme = ThemeManager.GetAppTheme("Base" + value);
                        applyNewStyle();
                        RaisePropertyChangedEvent("Theme");
                    }
                }
            }

            public UISettings()
            {
                accent = ThemeManager.GetAccent("Cyan");
                theme = ThemeManager.GetAppTheme("BaseLight");
                Accent = "Cyan";
                Theme = "Light";
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
