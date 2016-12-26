using MahApps.Metro;
using OfflineServer.Servers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace OfflineServer.Data.Settings
{
    public sealed class AppSettings : ObservableObject
    {
        public sealed class UISettings : ObservableObject
        {
            private static Persona activePersonaProxy { get { return Access.CurrentSession.ActivePersona; } }

            public class Style : ObservableObject
            {
                [XmlIgnore]
                public List<String> list_Accents { get; set; } = new List<String>();
                [XmlIgnore]
                public List<String> list_Themes { get; set; } = new List<String>();

                private Accent accent;
                public String Accent
                {
                    get
                    {
                        return accent.Name;
                    }
                    set
                    {
                        if (!String.IsNullOrWhiteSpace(value))
                        {
                            if (Access.mainWindow != null && value == "CustomAccentSample" && !haveSeenCustomAccentSampleMessage)
                            {
                                Access.mainWindow.informUser(Access.dataAccess.appSettings.uiSettings.language.InformUserInformation,
                                            String.Format(Access.dataAccess.appSettings.uiSettings.language.InformationSampleAccent, DataEx.dir_Accents));
                                haveSeenCustomAccentSampleMessage = true;
                            }
                            accent = ThemeManager.GetAccent(value);
                            if (theme != null) applyNewStyle();
                            RaisePropertyChangedEvent("Accent");
                        }
                    }
                }

                private AppTheme theme;
                public String Theme
                {
                    get
                    {
                        return theme.Name;
                    }
                    set
                    {
                        if (!String.IsNullOrWhiteSpace(value))
                        {
                            if (Access.mainWindow != null && value == "CustomThemeSample" && !haveSeenCustomThemeSampleMessage)
                            {
                                Access.mainWindow.informUser(Access.dataAccess.appSettings.uiSettings.language.InformUserInformation,
                                            String.Format(Access.dataAccess.appSettings.uiSettings.language.InformationSampleTheme, DataEx.dir_Themes));
                                haveSeenCustomThemeSampleMessage = true;
                            }
                            theme = ThemeManager.GetAppTheme(value);
                            if (accent != null) applyNewStyle();
                            Application.Current.Resources["ThemeImageColor"] = new SolidColorBrush(value == "BaseDark" ? Color.FromArgb(255, 80, 80, 80) : Color.FromArgb(255, 0, 0, 0));
                            RaisePropertyChangedEvent("Theme");
                        }
                    }
                }

                public Boolean haveSeenCustomAccentSampleMessage = false;
                public Boolean haveSeenCustomThemeSampleMessage = false;

                public void applyNewStyle()
                {
                    ThemeManager.ChangeAppStyle(Application.Current, accent, theme);
                    if (Access.dataAccess != null) Access.dataAccess.appSettings.saveInstance();
                }

                public void loadStyles()
                {
                    list_Accents.Clear();
                    list_Themes.Clear();

                    String currentDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    String accentsDir = Path.Combine(currentDir, DataEx.dir_Accents);
                    String themesDir = Path.Combine(currentDir, DataEx.dir_Themes);

                    foreach (String accentXaml in Directory.GetFiles(accentsDir, "*.xaml", SearchOption.TopDirectoryOnly))
                    {
                        String accentName = accentXaml.Replace(accentsDir, String.Empty).Replace(".xaml", String.Empty);

                        ThemeManager.AddAccent(accentName, new Uri(accentXaml, UriKind.Absolute));
                        list_Accents.Add(accentName);
                    }

                    foreach (String themeXaml in Directory.GetFiles(themesDir, "*.xaml", SearchOption.TopDirectoryOnly))
                    {
                        String themeName = themeXaml.Replace(themesDir, String.Empty).Replace(".xaml", String.Empty);

                        ThemeManager.AddAppTheme(themeName, new Uri(themeXaml, UriKind.Absolute));
                        list_Themes.Add(themeName);
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

                public Style()
                {
                    loadStyles();
                    doDefault();
                }
            }

            public class Language
            {
                #region ViewModel
                public String Persona { get; set; }
                public String AchievementTreasureHunt { get; set; }
                public String AchievementJumpDistance { get; set; }
                public String PersonaInfo { get; set; }
                public String Name { get; set; }
                public String Motto { get; set; }
                public String Level { get; set; }
                public String Cash { get; set; }
                public String DetailedPersonaInfo { get; set; }
                public String PersonaList { get; set; }
                public String LevelXP { get; set; }
                public String LevelToolTip { get; set; }
                public String CashToolTip { get; set; }
                public String BoostToolTip { get; set; }
                public String AmountOfCars { get; set; }
                public String GarageToolTip { get; set; }
                public String TimePlayedToolTip { get; set; }
                public String Garage { get; set; }
                public String BaseCarIdDefinition { get; set; }
                public String NoBaseCarIdDefinition { get; set; }
                public String AddACar { get; set; }
                public String AddACarText { get; set; }
                public String RemoveCar { get; set; }
                public String RemoveCarLastCarError { get; set; }
                public String RemoveCarNoSelectedCarError { get; set; }
                public String LoadXElement { get; set; }
                public String InformUserError { get; set; }
                public String InformUserWarning { get; set; }
                public String InformUserInformation { get; set; }
                public String InformUserOther { get; set; }
                public String ErrorEmptyPersonaName { get; set; }
                public String InformationSampleAccent { get; set; }
                public String InformationSampleTheme { get; set; }
                public String Settings { get; set; }
                public String AddonManager { get; set; }
                public String AddonManagerNotFoundError { get; set; }
                public String AddonManagerAddonInstalled { get; set; }
                public String UISettings { get; set; }
                public String Accent { get; set; }
                public String Theme { get; set; }
                public String DisplayLanguage { get; set; }
                public String HttpServerSettings { get; set; }
                public String Catalog { get; set; }
                public String Select { get; set; }
                public String Cancel { get; set; }
                #endregion

                [XmlIgnore]
                public List<String> list_Languages { get; set; } = new List<String>();

                public static Language loadFromLanguageFile(String languageName)
                {
                    return DataEx.getInstanceFromXml<Language>(languageName + ".xml");
                }

                public void loadLanguages()
                {
                    list_Languages.Clear();

                    String currentDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    String languagesDir = Path.Combine(currentDir, DataEx.dir_Languages);

                    foreach (String languageFile in Directory.GetFiles(languagesDir, "*.xml", SearchOption.TopDirectoryOnly))
                    {
                        list_Languages.Add(languageFile.Replace(languagesDir, String.Empty).Replace(".xml", String.Empty));
                    }
                }

                public Language()
                {
                    loadLanguages();
                }
            }

            public Style style { get; set; }
            [XmlIgnore]
            public Language language { get; set; }

            private String languageFile;
            public String LanguageFile
            {
                get
                {
                    return languageFile;
                }
                set
                {
                    if (languageFile != value && !String.IsNullOrWhiteSpace(value))
                    {
                        languageFile = value;
                        language = Language.loadFromLanguageFile(languageFile);
                        if (language == null)
                        {
                            languageFile = "English";
                            language = Language.loadFromLanguageFile("English");
                        }
                        if (Access.dataAccess != null) Access.dataAccess.appSettings.saveInstance();
                        RaisePropertyChangedEvent("language");
                        RaisePropertyChangedEvent("LanguageFile");
                    }
                }
            }

            public UISettings()
            {
                style = new Style();
                LanguageFile = "English";
            }
        }
        public sealed class HttpServerSettings : ObservableObject
        {
            #region Catalog
            [XmlIgnore]
            public List<String> list_Catalogs { get; set; } = new List<String>();

            private String selectedCatalog;
            public String SelectedCatalog
            {
                get
                {
                    return selectedCatalog;
                }
                set
                {
                    if (selectedCatalog != value)
                    {
                        if (!Directory.Exists(Path.Combine(DataEx.dir_HttpServerCatalogs, value))) value = "Default";
                        selectedCatalog = value;
                        DataEx.currentHttpServerCatalog = value;
                        if (Access.dataAccess != null) Access.dataAccess.appSettings.saveInstance();
                        RaisePropertyChangedEvent("SelectedCatalog");
                    }
                }
            }
            #endregion

            public void loadCatalogs()
            {
                list_Catalogs.Clear();

                String currentDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                String catalogsDir = Path.Combine(currentDir, DataEx.dir_HttpServerCatalogs);

                foreach (String catalogDir in Directory.GetDirectories(catalogsDir))
                {
                    String catalogName = catalogDir.Replace(catalogsDir, String.Empty);
                    list_Catalogs.Add(catalogName);
                }
            }

            public void doDefault()
            {
                SelectedCatalog = "Default";
            }

            public HttpServerSettings()
            {
                loadCatalogs();
                doDefault();
            }
        }

        public UISettings uiSettings { get; set; }
        public HttpServerSettings httpServerSettings { get; set; }

        public void reloadAllLists()
        {
            uiSettings.style.loadStyles();
            uiSettings.language.loadLanguages();
            httpServerSettings.loadCatalogs();
        }

        public void saveInstance()
        {
            File.WriteAllText(DataEx.xml_Settings, this.SerializeObject(), Encoding.UTF8);
        }

        public AppSettings()
        {
            uiSettings = new UISettings();
            httpServerSettings = new HttpServerSettings();
        }
    }
}