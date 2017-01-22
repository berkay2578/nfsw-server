using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;
using MahApps.Metro;
using OfflineServer.Servers;

namespace OfflineServer.Data.Settings
{
    public sealed class AppSettings : ObservableObject
    {
        public sealed class UISettings : ObservableObject
        {
            private static Persona activePersonaProxy { get { return Access.CurrentSession.ActivePersona; } }

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
                private String persona;
                private String nfsWorldRunningOverlayText;
                private String achievementTreasureHunt;
                private String achievementJumpDistance;
                private String personaInfo;
                private String name;
                private String motto;
                private String level;
                private String cash;
                private String detailedPersonaInfo;
                private String personaList;
                private String levelUpXPLeft;
                private String levelToolTip;
                private String cashToolTip;
                private String boostToolTip;
                private String amountOfCars;
                private String garageToolTip;
                private String timePlayedToolTip;
                private String garage;
                private String baseCarIdDefinition;
                private String noBaseCarIdDefinition;
                private String addACar;
                private String addACarText;
                private String removeCar;
                private String removeCarLastCarError;
                private String removeCarNoSelectedCarError;
                private String loadXElement;
                private String informUserError;
                private String informUserWarning;
                private String informUserInformation;
                private String informUserOther;
                private String errorEmptyPersonaName;
                private String informationSampleAccent;
                private String informationSampleTheme;
                private String settings;
                private String uISettings;
                private String accent;
                private String theme;
                private String displayLanguage;
                private String httpServerSettings;
                private String catalog;
                private String gameplayMod;
                private String addonManager;
                private String addonManagerNotFoundError;
                private String addonManagerAddonInstalled;
                private String select;
                private String cancel;

                public String Persona
                {
                    get
                    {
                        return persona;
                    }
                    set
                    {
                        if (persona != value)
                        {
                            persona = value;
                            RaisePropertyChangedEvent("Persona");
                        }
                    }
                }
                public String NFSWorldRunningOverlayText
                {
                    get
                    {
                        return nfsWorldRunningOverlayText;
                    }
                    set
                    {
                        if (nfsWorldRunningOverlayText != value)
                        {
                            nfsWorldRunningOverlayText = value;
                            RaisePropertyChangedEvent("NFSWorldRunningOverlayText");
                        }
                    }
                }
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
                public String PersonaInfo
                {
                    get
                    {
                        return personaInfo;
                    }
                    set
                    {
                        if (personaInfo != value)
                        {
                            personaInfo = value;
                            RaisePropertyChangedEvent("PersonaInfo");
                        }
                    }
                }
                public String Name
                {
                    get
                    {
                        return name;
                    }
                    set
                    {
                        if (name != value)
                        {
                            name = value;
                            RaisePropertyChangedEvent("Name");
                        }
                    }
                }
                public String Motto
                {
                    get
                    {
                        return motto;
                    }
                    set
                    {
                        if (motto != value)
                        {
                            motto = value;
                            RaisePropertyChangedEvent("Motto");
                        }
                    }
                }
                public String Level
                {
                    get
                    {
                        return level;
                    }
                    set
                    {
                        if (level != value)
                        {
                            level = value;
                            RaisePropertyChangedEvent("Level");
                        }
                    }
                }
                public String Cash
                {
                    get
                    {
                        return cash;
                    }
                    set
                    {
                        if (cash != value)
                        {
                            cash = value;
                            RaisePropertyChangedEvent("Cash");
                        }
                    }
                }
                public String DetailedPersonaInfo
                {
                    get
                    {
                        return detailedPersonaInfo;
                    }
                    set
                    {
                        if (detailedPersonaInfo != value)
                        {
                            detailedPersonaInfo = value;
                            RaisePropertyChangedEvent("DetailedPersonaInfo");
                        }
                    }
                }
                public String PersonaList
                {
                    get
                    {
                        return personaList;
                    }
                    set
                    {
                        if (personaList != value)
                        {
                            personaList = value;
                            RaisePropertyChangedEvent("PersonaList");
                        }
                    }
                }
                public String LevelUpXPLeft
                {
                    get
                    {
                        if (activePersonaProxy != null)
                            return String.Format(levelUpXPLeft, "CALCULATE FROM LEVEL REPS");
                        return String.Empty;
                    }
                    set
                    {
                        if (levelUpXPLeft != value)
                        {
                            levelUpXPLeft = value;
                            RaisePropertyChangedEvent("LevelUpXPLeft");
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
                public String AmountOfCars
                {
                    get
                    {
                        return amountOfCars;
                    }
                    set
                    {
                        if (amountOfCars != value)
                        {
                            amountOfCars = value;
                            RaisePropertyChangedEvent("AmountOfCars");
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
                public String Garage
                {
                    get
                    {
                        return garage;
                    }
                    set
                    {
                        if (garage != value)
                        {
                            garage = value;
                            RaisePropertyChangedEvent("Garage");
                        }
                    }
                }
                public String BaseCarIdDefinition
                {
                    get
                    {
                        return baseCarIdDefinition;
                    }
                    set
                    {
                        if (baseCarIdDefinition != value)
                        {
                            baseCarIdDefinition = value;
                            RaisePropertyChangedEvent("BaseCarIdDefinition");
                        }
                    }
                }
                public String NoBaseCarIdDefinition
                {
                    get
                    {
                        return noBaseCarIdDefinition;
                    }
                    set
                    {
                        if (noBaseCarIdDefinition != value)
                        {
                            noBaseCarIdDefinition = value;
                            RaisePropertyChangedEvent("NoBaseCarIdDefinition");
                        }
                    }
                }
                public String AddACar
                {
                    get
                    {
                        return addACar;
                    }
                    set
                    {
                        if (addACar != value)
                        {
                            addACar = value;
                            RaisePropertyChangedEvent("AddACar");
                        }
                    }
                }
                public String AddACarText
                {
                    get
                    {
                        return addACarText;
                    }
                    set
                    {
                        if (addACarText != value)
                        {
                            addACarText = value;
                            RaisePropertyChangedEvent("AddACarText");
                        }
                    }
                }
                public String RemoveCar
                {
                    get
                    {
                        return removeCar;
                    }
                    set
                    {
                        if (removeCar != value)
                        {
                            removeCar = value;
                            RaisePropertyChangedEvent("RemoveCar");
                        }
                    }
                }
                public String RemoveCarLastCarError
                {
                    get
                    {
                        return removeCarLastCarError;
                    }
                    set
                    {
                        if (removeCarLastCarError != value)
                        {
                            removeCarLastCarError = value;
                            RaisePropertyChangedEvent("RemoveCarLastCarError");
                        }
                    }
                }
                public String RemoveCarNoSelectedCarError
                {
                    get
                    {
                        return removeCarNoSelectedCarError;
                    }
                    set
                    {
                        if (removeCarNoSelectedCarError != value)
                        {
                            removeCarNoSelectedCarError = value;
                            RaisePropertyChangedEvent("RemoveCarNoSelectedCarError");
                        }
                    }
                }
                public String LoadXElement
                {
                    get
                    {
                        return loadXElement;
                    }
                    set
                    {
                        if (loadXElement != value)
                        {
                            loadXElement = value;
                            RaisePropertyChangedEvent("LoadXElement");
                        }
                    }
                }
                public String InformUserError
                {
                    get
                    {
                        return informUserError;
                    }
                    set
                    {
                        if (informUserError != value)
                        {
                            informUserError = value;
                            RaisePropertyChangedEvent("InformUserError");
                        }
                    }
                }
                public String InformUserWarning
                {
                    get
                    {
                        return informUserWarning;
                    }
                    set
                    {
                        if (informUserWarning != value)
                        {
                            informUserWarning = value;
                            RaisePropertyChangedEvent("InformUserWarning");
                        }
                    }
                }
                public String InformUserInformation
                {
                    get
                    {
                        return informUserInformation;
                    }
                    set
                    {
                        if (informUserInformation != value)
                        {
                            informUserInformation = value;
                            RaisePropertyChangedEvent("InformUserInformation");
                        }
                    }
                }
                public String InformUserOther
                {
                    get
                    {
                        return informUserOther;
                    }
                    set
                    {
                        if (informUserOther != value)
                        {
                            informUserOther = value;
                            RaisePropertyChangedEvent("InformUserOther");
                        }
                    }
                }
                public String ErrorEmptyPersonaName
                {
                    get
                    {
                        return errorEmptyPersonaName;
                    }
                    set
                    {
                        if (errorEmptyPersonaName != value)
                        {
                            errorEmptyPersonaName = value;
                            RaisePropertyChangedEvent("ErrorEmptyPersonaName");
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
                public String Settings
                {
                    get
                    {
                        return settings;
                    }
                    set
                    {
                        if (settings != value)
                        {
                            settings = value;
                            RaisePropertyChangedEvent("Settings");
                        }
                    }
                }
                public String UISettings
                {
                    get
                    {
                        return uISettings;
                    }
                    set
                    {
                        if (uISettings != value)
                        {
                            uISettings = value;
                            RaisePropertyChangedEvent("UISettings");
                        }
                    }
                }
                public String Accent
                {
                    get
                    {
                        return accent;
                    }
                    set
                    {
                        if (accent != value)
                        {
                            accent = value;
                            RaisePropertyChangedEvent("Accent");
                        }
                    }
                }
                public String Theme
                {
                    get
                    {
                        return theme;
                    }
                    set
                    {
                        if (theme != value)
                        {
                            theme = value;
                            RaisePropertyChangedEvent("Theme");
                        }
                    }
                }
                public String DisplayLanguage
                {
                    get
                    {
                        return displayLanguage;
                    }
                    set
                    {
                        if (displayLanguage != value)
                        {
                            displayLanguage = value;
                            RaisePropertyChangedEvent("DisplayLanguage");
                        }
                    }
                }
                public String HttpServerSettings
                {
                    get
                    {
                        return httpServerSettings;
                    }
                    set
                    {
                        if (httpServerSettings != value)
                        {
                            httpServerSettings = value;
                            RaisePropertyChangedEvent("HttpServerSettings");
                        }
                    }
                }
                public String Catalog
                {
                    get
                    {
                        return catalog;
                    }
                    set
                    {
                        if (catalog != value)
                        {
                            catalog = value;
                            RaisePropertyChangedEvent("Catalog");
                        }
                    }
                }
                public String GameplayMod
                {
                    get
                    {
                        return gameplayMod;
                    }
                    set
                    {
                        if (gameplayMod != value)
                        {
                            gameplayMod = value;
                            RaisePropertyChangedEvent("GameplayMod");
                        }
                    }
                }
                public String AddonManager
                {
                    get
                    {
                        return addonManager;
                    }
                    set
                    {
                        if (addonManager != value)
                        {
                            addonManager = value;
                            RaisePropertyChangedEvent("AddonManager");
                        }
                    }
                }
                public String AddonManagerNotFoundError
                {
                    get
                    {
                        return addonManagerNotFoundError;
                    }
                    set
                    {
                        if (addonManagerNotFoundError != value)
                        {
                            addonManagerNotFoundError = value;
                            RaisePropertyChangedEvent("AddonManagerNotFoundError");
                        }
                    }
                }
                public String AddonManagerAddonInstalled
                {
                    get
                    {
                        return addonManagerAddonInstalled;
                    }
                    set
                    {
                        if (addonManagerAddonInstalled != value)
                        {
                            addonManagerAddonInstalled = value;
                            RaisePropertyChangedEvent("AddonManagerAddonInstalled");
                        }
                    }
                }
                public String Select
                {
                    get
                    {
                        return select;
                    }
                    set
                    {
                        if (select != value)
                        {
                            select = value;
                            RaisePropertyChangedEvent("Select");
                        }
                    }
                }
                public String Cancel
                {
                    get
                    {
                        return cancel;
                    }
                    set
                    {
                        if (cancel != value)
                        {
                            cancel = value;
                            RaisePropertyChangedEvent("Cancel");
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
                        list_Languages.Add(languageFile.Replace(languagesDir, String.Empty).Replace(".xml", String.Empty));
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
        [XmlElement("NFSWorldExePath")]
        public String nfsw_exe { get; set; }

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