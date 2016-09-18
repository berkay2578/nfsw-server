using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public class Accent
        {

        }
        public class Theme
        {

        }
        public class Language
        {

        }
        public class MemoryPatch
        {

        }
        #endregion

        public Catalog catalog { get; set; }
        public Accent accent { get; set; }
        public Theme theme { get; set; }
        public Language language { get; set; }
        public MemoryPatch memoryPatch { get; set; }

        public AddonProject()
        {
            catalog = new Catalog();
            accent = new Accent();
            theme = new Theme();
            language = new Language();
            memoryPatch = new MemoryPatch();
        }
    }
}