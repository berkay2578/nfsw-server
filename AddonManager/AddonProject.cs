using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AddonManager
{
    [Serializable()]
    public class AddonProject
    {
        #region nested classes
        public class Catalog
        {
            public String addonCreator;
            public String addonDescription;
            public String addonName;
            public String addonVersion;

            public List<String> catalog_products = new List<String>();
            public List<String> catalog_categories = new List<String>();
            public List<String> basket_definitions = new List<String>();

            public static String getFileLocation(String listBoxEntry)
            {
                int startIndex = listBoxEntry.IndexOf('(') + 1;
                int endIndex = listBoxEntry.IndexOf(')');
                int numToCrop = endIndex - startIndex;

                return listBoxEntry.Substring(startIndex, numToCrop);
            }
            public static String getListBoxEntryText(String listBoxEntry)
            {
                return listBoxEntry.Split(' ')[0];
            }

            public Catalog()
            {
                addonCreator = "Smarty McSmartyFace";
                addonDescription = "A simple description of my new addon!\r\n<p>Look at <u>all</u> this <i>fancy</i> <b>HTML</b>!</p>";
                addonName = "My New Addon";
                addonVersion = "v1.33.7";
            }
        }
        public class GameplayMod
        {
            public String addonCreator;
            public String addonDescription;
            public String addonName;
            public String addonVersion;

            public List<String> mods = new List<String>();

            public static String getFileLocation(String listBoxEntry)
            {
                int startIndex = listBoxEntry.IndexOf('(') + 1;
                int endIndex = listBoxEntry.IndexOf(')');
                int numToCrop = endIndex - startIndex;

                return listBoxEntry.Substring(startIndex, numToCrop);
            }
            public static String getListBoxEntryText(String listBoxEntry)
            {
                return listBoxEntry.Split(' ')[0];
            }

            public GameplayMod()
            {
                addonCreator = "Smarty McSmartyFace";
                addonDescription = "A simple description of my new addon!\r\n<p>Look at <u>all</u> this <i>fancy</i> <b>HTML</b>!</p>";
                addonName = "My New Addon";
                addonVersion = "v1.33.7";
            }
        }
        public class Accent
        {
            public String addonCreator;
            public String addonDescription;
            public String addonName;
            public String addonVersion;

            public Byte[] accentXamlBytes;
            [XmlIgnore]
            public String accentXaml
            {
                get
                {
                    return new UTF8Encoding(false, false).GetString(accentXamlBytes);
                }
                set
                {
                    byte[] valueInBytes = new UTF8Encoding(false, false).GetBytes(value);
                    if (accentXamlBytes != valueInBytes)
                    {
                        accentXamlBytes = valueInBytes;
                    }
                }
            }
            [XmlIgnore]
            public static String defaultAccentXaml;

            public Accent()
            {
                defaultAccentXaml = Properties.Resources.CustomAccentSample;
                accentXaml = defaultAccentXaml;

                addonCreator = "Smarty McSmartyFace";
                addonDescription = "A simple description of my new addon!\r\n<p>Look at <u>all</u> this <i>fancy</i> <b>HTML</b>!</p>";
                addonName = "My New Addon";
                addonVersion = "v1.33.7";
            }
        }
        public class Theme
        {
            public String addonCreator;
            public String addonDescription;
            public String addonName;
            public String addonVersion;

            public Byte[] themeXamlBytes;
            [XmlIgnore]
            public String themeXaml
            {
                get
                {
                    return new UTF8Encoding(false, false).GetString(themeXamlBytes);
                }
                set
                {
                    byte[] valueInBytes = new UTF8Encoding(false, false).GetBytes(value);
                    if (themeXamlBytes != valueInBytes)
                    {
                        themeXamlBytes = valueInBytes;
                    }
                }
            }
            [XmlIgnore]
            public static String defaultThemeXaml;

            public Theme()
            {
                defaultThemeXaml = Properties.Resources.CustomThemeSample;
                themeXaml = defaultThemeXaml;

                addonCreator = "Smarty McSmartyFace";
                addonDescription = "A simple description of my new addon!\r\n<p>Look at <u>all</u> this <i>fancy</i> <b>HTML</b>!</p>";
                addonName = "My New Addon";
                addonVersion = "v1.33.7";
            }
        }
        public class Language
        {
            public String addonCreator;
            public String addonDescription;
            public String addonName;
            public String addonVersion;

            public Byte[] languageFileBytes;
            [XmlIgnore]
            public String languageFileText
            {
                get
                {
                    return new UTF8Encoding(false, false).GetString(languageFileBytes);
                }
                set
                {
                    byte[] valueInBytes = new UTF8Encoding(false, false).GetBytes(value);
                    if (languageFileBytes != valueInBytes)
                    {
                        languageFileBytes = valueInBytes;
                    }
                }
            }
            [XmlIgnore]
            public static String defaultLanguageFileText;

            public Language()
            {
                defaultLanguageFileText = Properties.Resources.English;
                languageFileText = defaultLanguageFileText;

                addonCreator = "Smarty McSmartyFace";
                addonDescription = "A simple description of my new addon!\r\n<p>Look at <u>all</u> this <i>fancy</i> <b>HTML</b>!</p>";
                addonName = "My New Addon";
                addonVersion = "v1.33.7";
            }
        }
        #endregion

        [XmlIgnore]
        public String projectLocation { get; set; }

        public Catalog catalog { get; set; }
        public GameplayMod gameplayMod { get; set; }
        public Accent accent { get; set; }
        public Theme theme { get; set; }
        public Language language { get; set; }

        public AddonProject()
        {
            projectLocation = null;

            catalog = new Catalog();
            gameplayMod = new GameplayMod();
            accent = new Accent();
            theme = new Theme();
            language = new Language();
        }
    }
}