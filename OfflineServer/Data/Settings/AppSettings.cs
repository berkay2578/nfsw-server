using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using MahApps.Metro;
using OfflineServer.Servers;

namespace OfflineServer.Data.Settings
{
    [Serializable()]
    [XmlRoot("OfflineServerSettings")]
    public sealed class AppSettings : ObservableObject
    {
        private object threadSafeDummy = new object();

        public sealed class UISettings : ObservableObject
        {
            private static Persona activePersonaProxy
            {
                get
                {
                    if (Access.CurrentSession != null)
                        return Access.CurrentSession.ActivePersona;

                    return null;
                }
            }

            public class Style : ObservableObject
            {
                [XmlElement("SeenCustomAccentMessage")]
                public Boolean haveSeenCustomAccentSampleMessage = false;
                [XmlElement("SeenCustomThemeMessage")]
                public Boolean haveSeenCustomThemeSampleMessage = false;

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

                private String background;
                [XmlElement("MainWindowBackground")]
                public String Background
                {
                    get
                    {
                        if (!String.IsNullOrWhiteSpace(background))
                        {
                            if (File.Exists(background))
                            {
                                return background;
                            }
                        }
                        return String.Empty;
                    }
                    set
                    {
                        if (!String.IsNullOrWhiteSpace(value))
                        {
                            if (File.Exists(value))
                            {
                                background = value;
                            }
                        }
                        else
                        {
                            background = String.Empty;
                        }
                        if (Access.dataAccess != null) Access.dataAccess.appSettings.saveInstance();
                        RaisePropertyChangedEvent("BGImage");
                    }
                }
                [XmlIgnore()]
                public ImageSource BGImage
                {
                    get
                    {
                        if (Background != String.Empty)
                            return new BitmapImage(new Uri(Background, UriKind.Absolute));
                        return null;
                    }
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

                public void applyNewStyle()
                {
                    ThemeManager.ChangeAppStyle(Application.Current, accent, theme);
                    if (Access.dataAccess != null) Access.dataAccess.appSettings.saveInstance();
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

            public class Language : ObservableObject
            {
                #region ViewModel
                public String Persona { get; set; }
                public String Car { get; set; }
                public String Event { get; set; }
                public String PersonaInformation { get; set; }
                public String Name { get; set; }
                public String Motto { get; set; }
                public String Level { get; set; }
                public String LevelUpXPLeft { get; set; }
                public String Cash { get; set; }
                public String DetailedPersonaInformation { get; set; }
                public String PersonaList { get; set; }
                public String AddFirstPersona { get; set; }
                public String StartNFSWorld { get; set; }
                public String AddNew { get; set; }
                public String NFSWorldLaunchingMessage { get; set; }
                public String NFSWorldRunningOverlayText { get; set; }
                public String AmountOfCars { get; set; }
                public String Garage { get; set; }
                public String BaseCarIdDefinition { get; set; }
                public String NoBaseCarIdDefinition { get; set; }
                public String AddACar { get; set; }
                public String AddACarText { get; set; }
                public String RemoveCar { get; set; }
                public String RemoveCarLastCarError { get; set; }
                public String RemoveCarNoSelectedCarError { get; set; }
                public String LoadXElement { get; set; }
                public String Times { get; set; }
                public String EventDuration { get; set; }
                public String FinishReason { get; set; }
                public String Ranking { get; set; }
                public String GainedExperience { get; set; }
                public String GainedCash { get; set; }
                public String BestLapDuration { get; set; }
                public String PerfectStart { get; set; }
                public String TopSpeed { get; set; }
                public String NoEventResultsToDisplay { get; set; }
                public String InformUserError { get; set; }
                public String InformUserWarning { get; set; }
                public String InformUserInformation { get; set; }
                public String InformUserOther { get; set; }
                public String ErrorEmptyPersonaName { get; set; }
                public String ErrorPersonaNameTooLong { get; set; }
                public String ErrorEmptyNFSWorldPath { get; set; }
                public String ErrorNFSWorldLaunch { get; set; }
                public String Settings { get; set; }
                public String UISettings { get; set; }
                public String Background { get; set; }
                public String Accent { get; set; }
                public String Theme { get; set; }
                public String DisplayLanguage { get; set; }
                public String HttpServerSettings { get; set; }
                public String Catalog { get; set; }
                public String GameplayMod { get; set; }
                public String AddonManager { get; set; }
                public String AddonManagerNotFoundError { get; set; }
                public String AddonManagerAddonInstalled { get; set; }
                public String Browse { get; set; }
                public String Select { get; set; }
                public String Cancel { get; set; }

                private String achievementTreasureHunt;
                private String achievementJumpDistance;
                private String levelToolTip;
                private String cashToolTip;
                private String boostToolTip;
                private String garageToolTip;
                private String timePlayedToolTip;
                private String informationSampleAccent;
                private String informationSampleTheme;

                public String AchievementTreasureHunt
                {
                    get
                    {
                        if (activePersonaProxy != null)
                            return String.Format(achievementTreasureHunt, "dummy1", "dummy2");
                        return String.Empty;
                    }
                    set
                    {
                        if (achievementTreasureHunt != value)
                        {
                            achievementTreasureHunt = value;
                            RaisePropertyChangedEvent("AchievementTreasureHunt");
                        }
                    }
                }
                public String AchievementJumpDistance
                {
                    get
                    {
                        if (activePersonaProxy != null)
                            return String.Format(achievementJumpDistance, "dummy1", "dummy2");
                        return String.Empty;
                    }
                    set
                    {
                        if (achievementJumpDistance != value)
                        {
                            achievementJumpDistance = value;
                            RaisePropertyChangedEvent("AchievementJumpDistance");
                        }
                    }
                }
                public String LevelToolTip
                {
                    get
                    {
                        if (activePersonaProxy != null)
                            return String.Format(levelToolTip, activePersonaProxy.Name, activePersonaProxy.Level);
                        return String.Empty;
                    }
                    set
                    {
                        if (levelToolTip != value)
                        {
                            levelToolTip = value;
                            RaisePropertyChangedEvent("LevelToolTip");
                        }
                    }
                }
                public String CashToolTip
                {
                    get
                    {
                        if (activePersonaProxy != null)
                            return String.Format(cashToolTip, activePersonaProxy.Name, activePersonaProxy.Cash);
                        return String.Empty;
                    }
                    set
                    {
                        if (cashToolTip != value)
                        {
                            cashToolTip = value;
                            RaisePropertyChangedEvent("CashToolTip");
                        }
                    }
                }
                public String BoostToolTip
                {
                    get
                    {
                        if (activePersonaProxy != null)
                            return String.Format(boostToolTip, activePersonaProxy.Name, activePersonaProxy.Boost);
                        return String.Empty;
                    }
                    set
                    {
                        if (boostToolTip != value)
                        {
                            boostToolTip = value;
                            RaisePropertyChangedEvent("BoostToolTip");
                        }
                    }
                }
                public String GarageToolTip
                {
                    get
                    {
                        if (activePersonaProxy != null)
                            return String.Format(garageToolTip, activePersonaProxy.Name, activePersonaProxy.Cars.Count);
                        return String.Empty;
                    }
                    set
                    {
                        if (garageToolTip != value)
                        {
                            garageToolTip = value;
                            RaisePropertyChangedEvent("GarageToolTip");
                        }
                    }
                }
                public String TimePlayedToolTip
                {
                    get
                    {
                        if (activePersonaProxy != null)
                            return String.Format(timePlayedToolTip, activePersonaProxy.Name, activePersonaProxy.TimePlayed);
                        return String.Empty;
                    }
                    set
                    {
                        if (timePlayedToolTip != value)
                        {
                            timePlayedToolTip = value;
                            RaisePropertyChangedEvent("TimePlayedToolTip");
                        }
                    }
                }
                public String InformationSampleAccent
                {
                    get
                    {
                        return String.Format(informationSampleAccent, DataEx.dir_Accents);
                    }
                    set
                    {
                        if (informationSampleAccent != value)
                        {
                            informationSampleAccent = value;
                            RaisePropertyChangedEvent("InformationSampleAccent");
                        }
                    }
                }
                public String InformationSampleTheme
                {
                    get
                    {
                        return String.Format(informationSampleTheme, DataEx.dir_Themes);
                    }
                    set
                    {
                        if (informationSampleTheme != value)
                        {
                            informationSampleTheme = value;
                            RaisePropertyChangedEvent("InformationSampleTheme");
                        }
                    }
                }
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
                        list_Languages.Add(Path.GetFileNameWithoutExtension(languageFile));
                    }
                }

                public Language()
                {
                    loadLanguages();
                }
            }

            [XmlElement("Style")]
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
                        if (Access.dataAccess != null)
                        {
                            Access.dataAccess.executablesAddNew();
                            Access.dataAccess.appSettings.saveInstance();
                        }
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
            #endregion
            #region Gameplay Mod
            [XmlIgnore]
            public List<String> list_GameplayMods { get; set; } = new List<String>();

            private String selectedGameplayMod;
            public String SelectedGameplayMod
            {
                get
                {
                    return selectedGameplayMod;
                }
                set
                {
                    if (selectedGameplayMod != value)
                    {
                        if (!Directory.Exists(Path.Combine(DataEx.dir_GameplayMods, value))) value = "Default";
                        selectedGameplayMod = value;
                        DataEx.currentGameplayMod = value;
                        if (Access.dataAccess != null) Access.dataAccess.appSettings.saveInstance();
                        RaisePropertyChangedEvent("SelectedGameplayMod");
                    }
                }
            }

            public void loadGameplayMods()
            {
                list_GameplayMods.Clear();

                String currentDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                String gamePlayModsDir = Path.Combine(currentDir, DataEx.dir_GameplayMods);

                foreach (String dirGamePlayMod in Directory.GetDirectories(gamePlayModsDir))
                {
                    String gameplayModName = dirGamePlayMod.Replace(gamePlayModsDir, String.Empty);
                    list_GameplayMods.Add(gameplayModName);
                }
            }
            #endregion

            public void doDefault()
            {
                SelectedCatalog = "Default";
                SelectedGameplayMod = "Default";
            }

            public HttpServerSettings()
            {
                loadCatalogs();
                loadGameplayMods();
                doDefault();
            }
        }

        [XmlElement("UISettings")]
        public UISettings uiSettings { get; set; }
        [XmlElement("HttpServerSettings")]
        public HttpServerSettings httpServerSettings { get; set; }
        [XmlArray("NFSWorldExecutables")]
        [XmlArrayItem("Executable")]
        public ObservableCollection<String> NFSWorldExecutables { get; set; }

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
            NFSWorldExecutables = new ObservableCollection<String>();
            System.Windows.Data.BindingOperations.EnableCollectionSynchronization(NFSWorldExecutables, threadSafeDummy);
        }
    }
}