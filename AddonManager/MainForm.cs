using AddonManager.IPCTalk;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using TheArtOfDev.HtmlRenderer.WinForms;
using static AddonManager.Addon;
using static AddonManager.CustomControls;
using static AddonManager.FunctionsEx;
using static AddonManager.IPCTalk.OfflineServerTalk;

namespace AddonManager
{
    public partial class MainForm : Form
    {
        private HtmlPanel htmlPanel;
        private AddonProject addonProject;
        private HelpLanguageForm helpLanguageForm;
        public OfflineServerTalk offlineServerTalk;
        public static String localOfflineServerVersion
        {
            get
            {
#if !DEBUG
                string offlineVersionLocation = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "OfflineServer.exe");
                if (!File.Exists(offlineVersionLocation))
                {
                    MessageBox.Show("It seems like you are running this manager standalone,it should be next to your 'OfflineServer.exe'!", "Hold your horses there, big guy!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show("AddonManager will now close, please place it next to the offline server and then run it again.", "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    return null;
                }
                else
                {
                    return System.Diagnostics.FileVersionInfo.GetVersionInfo(offlineVersionLocation).ProductVersion;
                }
#else
                return "DEVELOPER PREVIEW";
#endif
            }
        }
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region Functions and the necessities
        #region Catalog
        private void clearProductsListBox()
        {
            ActiveCheckedListBox.managingLists = true;
            var productsCheckedItems = productsListBox.CheckedItems.Cast<string>().ToList().AsReadOnly();
            foreach (string currentProduct in productsCheckedItems)
            {
                string productName = AddonProject.Catalog.getListBoxEntryText(currentProduct);
                int targetIndex = productsListBox.Items.IndexOf(productsListBox.Items.Cast<string>()
                        .Where(itemText => itemText.StartsWith(productName))
                        .First());
                productsListBox.Items[targetIndex] = productName;
                productsListBox.SetItemChecked(targetIndex, false);
            }
            ActiveCheckedListBox.managingLists = false;
        }
        private void clearCategoriesListBox()
        {
            ActiveCheckedListBox.managingLists = true;
            var categoriesCheckedItems = categoriesListBox.CheckedItems.Cast<string>().ToList().AsReadOnly();
            foreach (string currentCategory in categoriesCheckedItems)
            {
                string categoryName = AddonProject.Catalog.getListBoxEntryText(currentCategory);
                int targetIndex = categoriesListBox.Items.IndexOf(categoriesListBox.Items.Cast<string>()
                        .Where(itemText => itemText.StartsWith(categoryName))
                        .First());
                categoriesListBox.Items[targetIndex] = categoryName;
                categoriesListBox.SetItemChecked(targetIndex, false);
            }
            ActiveCheckedListBox.managingLists = false;
        }
        private void clearCatalogListBoxes()
        {
            clearProductsListBox();
            clearCategoriesListBox();
            basketsListBox.Items.Clear();
        }
        #endregion
        #region Project
        internal void loadAddonProject()
        {
            if (openProjectDialog.ShowDialog() == DialogResult.OK)
            {
                if (openProjectDialog.FileName.EndsWith(".addonmanager.project"))
                {
                    addonProject = File.ReadAllText(openProjectDialog.FileName, Encoding.UTF8).DeserializeObject<AddonProject>();
                    addonProject.projectLocation = openProjectDialog.FileName;

                    #region Catalog and Basket
                    clearCatalogListBoxes();
                    ActiveCheckedListBox.managingLists = true;

                    // Products
                    foreach (string product in addonProject.catalog.catalog_products)
                    {
                        if (product.Trim().IndexOf('(') != -1)
                        {
                            int targetIndex = productsListBox.Items.IndexOf(productsListBox.Items.Cast<string>()
                                .Where(itemText => itemText.StartsWith(AddonProject.Catalog.getListBoxEntryText(product)))
                                .First());
                            productsListBox.Items[targetIndex] = product;
                            productsListBox.SetItemChecked(targetIndex, true);
                        }
                    }

                    // Categories
                    foreach (string category in addonProject.catalog.catalog_categories)
                    {
                        if (category.Trim().IndexOf('(') != -1)
                        {
                            int targetIndex = categoriesListBox.Items.IndexOf(categoriesListBox.Items.Cast<string>()
                                .Where(itemText => itemText.StartsWith(AddonProject.Catalog.getListBoxEntryText(category)))
                                .First());
                            categoriesListBox.Items[targetIndex] = category;
                            categoriesListBox.SetItemChecked(targetIndex, true);
                        }
                    }

                    ActiveCheckedListBox.managingLists = false;

                    // Basket Files
                    List<string> basketFiles = new List<string>();
                    foreach (string basket in addonProject.catalog.basket_definitions)
                        basketFiles.Add(basket.Trim());

                    addItemsWithNaturalOrder(ref basketsListBox, basketFiles);

                    // Others
                    addonProject.catalog.addonCreator = addonProject.catalog.addonCreator
                                                        .Substring(0, Math.Min(addonProject.catalog.addonCreator.Length, Addon.addonCreatorDef[2] - 1));
                    addonProject.catalog.addonDescription = addonProject.catalog.addonDescription
                                                        .Substring(0, Math.Min(addonProject.catalog.addonDescription.Length, Addon.addonDescriptionDef[2] - 1));
                    addonProject.catalog.addonName = addonProject.catalog.addonName
                                                        .Substring(0, Math.Min(addonProject.catalog.addonName.Length, Addon.addonNameDef[2] - 1));
                    addonProject.catalog.addonVersion = addonProject.catalog.addonVersion
                                                        .Substring(0, Math.Min(addonProject.catalog.addonVersion.Length, Addon.addonVersionDef[2] - 1));
                    #endregion

                    #region Accent
                    if (addonProject.accent.accentXamlBytes != null)
                        avalonEditProxyAccent.textEditor.Text = addonProject.accent.accentXaml;

                    // Others
                    addonProject.accent.addonCreator = addonProject.accent.addonCreator
                                                        .Substring(0, Math.Min(addonProject.accent.addonCreator.Length, Addon.addonCreatorDef[2] - 1));
                    addonProject.accent.addonDescription = addonProject.accent.addonDescription
                                                        .Substring(0, Math.Min(addonProject.accent.addonDescription.Length, Addon.addonDescriptionDef[2] - 1));
                    addonProject.accent.addonName = addonProject.accent.addonName
                                                        .Substring(0, Math.Min(addonProject.accent.addonName.Length, Addon.addonNameDef[2] - 1));
                    addonProject.accent.addonVersion = addonProject.accent.addonVersion
                                                        .Substring(0, Math.Min(addonProject.accent.addonVersion.Length, Addon.addonVersionDef[2] - 1));
                    #endregion

                    #region Theme
                    if (addonProject.theme.themeXamlBytes != null)
                        avalonEditProxyTheme.textEditor.Text = addonProject.theme.themeXaml;

                    // Others
                    addonProject.theme.addonCreator = addonProject.theme.addonCreator
                                                        .Substring(0, Math.Min(addonProject.theme.addonCreator.Length, Addon.addonCreatorDef[2] - 1));
                    addonProject.theme.addonDescription = addonProject.theme.addonDescription
                                                        .Substring(0, Math.Min(addonProject.theme.addonDescription.Length, Addon.addonDescriptionDef[2] - 1));
                    addonProject.theme.addonName = addonProject.theme.addonName
                                                        .Substring(0, Math.Min(addonProject.theme.addonName.Length, Addon.addonNameDef[2] - 1));
                    addonProject.theme.addonVersion = addonProject.theme.addonVersion
                                                        .Substring(0, Math.Min(addonProject.theme.addonVersion.Length, Addon.addonVersionDef[2] - 1));
                    #endregion

                    #region Language
                    if (addonProject.language.languageFileBytes != null)
                        avalonEditProxyLanguage.textEditor.Text = addonProject.language.languageFileText;

                    // Others
                    addonProject.language.addonCreator = addonProject.language.addonCreator
                                                        .Substring(0, Math.Min(addonProject.language.addonCreator.Length, Addon.addonCreatorDef[2] - 1));
                    addonProject.language.addonDescription = addonProject.language.addonDescription
                                                        .Substring(0, Math.Min(addonProject.language.addonDescription.Length, Addon.addonDescriptionDef[2] - 1));
                    addonProject.language.addonName = addonProject.language.addonName
                                                        .Substring(0, Math.Min(addonProject.language.addonName.Length, Addon.addonNameDef[2] - 1));
                    addonProject.language.addonVersion = addonProject.language.addonVersion
                                                        .Substring(0, Math.Min(addonProject.language.addonVersion.Length, Addon.addonVersionDef[2] - 1));
                    #endregion

                    MessageBox.Show("The selected project was loaded successfully!", "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a file with the default extension '.addonmanager.project' and retry.",
                                "Hold your horses there, big guy!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        internal void saveAddonProject(String projectLocation = null)
        {
            #region Catalog and Basket
            addonProject.catalog.catalog_products = productsListBox.Items.Cast<String>().ToList();
            addonProject.catalog.catalog_categories = categoriesListBox.Items.Cast<String>().ToList();
            addonProject.catalog.basket_definitions = basketsListBox.Items.Cast<String>().ToList();
            #endregion

            #region Accent
            addonProject.accent.accentXaml = avalonEditProxyAccent.textEditor.Text;
            #endregion

            #region Theme
            addonProject.theme.themeXaml = avalonEditProxyTheme.textEditor.Text;
            #endregion

            #region Language
            addonProject.language.languageFileText = avalonEditProxyLanguage.textEditor.Text;
            #endregion

            if (String.IsNullOrWhiteSpace(projectLocation))
            {
                if (saveProjectDialog.ShowDialog() == DialogResult.OK)
                {
                    if (saveProjectDialog.FileName.EndsWith(".addonmanager.project"))
                    {
                        File.WriteAllText(saveProjectDialog.FileName, DerivedFunctions.serializeObject(addonProject), new UTF8Encoding(false, false));
                        addonProject.projectLocation = saveProjectDialog.FileName;
                        MessageBox.Show("The project has been saved successfully!", "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Please use the default extension '.addonmanager.project' and retry.",
                                    "Hold your horses there, big guy!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                File.WriteAllText(projectLocation, DerivedFunctions.serializeObject(addonProject), new UTF8Encoding(false, false));
                MessageBox.Show("The project has been saved successfully!", "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Other
        private void readAddon(String addonPath)
        {
            addonLocationLabel.Text = addonPath;
            addonInformationLabel.Text = String.Format(CultureInfo.InvariantCulture,
                "- Name: {0}\r\n- Type: {1}\r\n- Created by: {2}\r\n- Created on: {3}\r\n- Version: {4}\r\n- Made for offline server version: {5}",
                    addonPath.readAddonProperty(Addon.addonNameDef),
                    addonPath.readAddonProperty(Addon.addonTypeDef),
                    addonPath.readAddonProperty(Addon.addonCreatorDef),
                    addonPath.readAddonProperty(Addon.addonDateDef),
                    addonPath.readAddonProperty(Addon.addonVersionDef),
                    addonPath.readAddonProperty(Addon.addonForVersionDef)
                );
            htmlPanel.Text = addonPath.readAddonProperty(Addon.addonDescriptionDef);

            buttonAddonInstall.Enabled = true;
        }

        private void saveAddonProperties(String targetAddonFile,
                                        String addonName,
                                        String addonType,
                                        String addonCreator,
                                        String addonVersion,
                                        String addonDescription)
        {
            targetAddonFile.saveAddonProperty(Addon.addonNameDef, addonName, true);
            targetAddonFile.saveAddonProperty(Addon.addonTypeDef, addonType);
            targetAddonFile.saveAddonProperty(Addon.addonCreatorDef, addonCreator);
            targetAddonFile.saveAddonProperty(Addon.addonDateDef, DateTime.Now.ToShortDateString());
            targetAddonFile.saveAddonProperty(Addon.addonVersionDef, addonVersion);
            targetAddonFile.saveAddonProperty(Addon.addonForVersionDef, localOfflineServerVersion);
            targetAddonFile.saveAddonProperty(Addon.addonResDef, "RESERVED FOR LATER USE");
            targetAddonFile.saveAddonProperty(Addon.addonDescriptionDef, addonDescription);
        }
        #endregion
        #endregion

        #region UI Events
        #region Button Handlers
        private void tabButton_Click(object sender, EventArgs e)
        {
            Button source = (Button)sender;
            switch (source.Name.Substring(0, 4))
            {
                #region Open
                case "open":
                    {
                        string fromTab = source.Name.Replace("open", string.Empty);
                        switch (fromTab)
                        {
                            case "CatalogAddonDetails":
                                {
                                    using (AddonDetailsDialog addonDetailsDialog = new AddonDetailsDialog(addonProject.catalog.addonName,
                                                AddonType.catalogWithBaskets,
                                                addonProject.catalog.addonCreator,
                                                addonProject.catalog.addonVersion,
                                                addonProject.catalog.addonDescription))
                                    {
                                        if (addonDetailsDialog.ShowDialog() == DialogResult.OK)
                                        {

                                            addonProject.catalog.addonName = addonDetailsDialog.returnValues[0];
                                            addonProject.catalog.addonCreator = addonDetailsDialog.returnValues[1];
                                            addonProject.catalog.addonVersion = addonDetailsDialog.returnValues[2];
                                            addonProject.catalog.addonDescription = addonDetailsDialog.returnValues[3];
                                        }
                                    }
                                }
                                break;
                            case "AccentAddonDetails":
                                {
                                    using (AddonDetailsDialog addonDetailsDialog = new AddonDetailsDialog(addonProject.accent.addonName,
                                                AddonType.accent,
                                                addonProject.accent.addonCreator,
                                                addonProject.accent.addonVersion,
                                                addonProject.accent.addonDescription))
                                    {
                                        if (addonDetailsDialog.ShowDialog() == DialogResult.OK)
                                        {

                                            addonProject.accent.addonName = addonDetailsDialog.returnValues[0];
                                            addonProject.accent.addonCreator = addonDetailsDialog.returnValues[1];
                                            addonProject.accent.addonVersion = addonDetailsDialog.returnValues[2];
                                            addonProject.accent.addonDescription = addonDetailsDialog.returnValues[3];
                                        }
                                    }
                                }
                                break;
                            case "ThemeAddonDetails":
                                {
                                    using (AddonDetailsDialog addonDetailsDialog = new AddonDetailsDialog(addonProject.theme.addonName,
                                                AddonType.theme,
                                                addonProject.theme.addonCreator,
                                                addonProject.theme.addonVersion,
                                                addonProject.theme.addonDescription))
                                    {
                                        if (addonDetailsDialog.ShowDialog() == DialogResult.OK)
                                        {

                                            addonProject.theme.addonName = addonDetailsDialog.returnValues[0];
                                            addonProject.theme.addonCreator = addonDetailsDialog.returnValues[1];
                                            addonProject.theme.addonVersion = addonDetailsDialog.returnValues[2];
                                            addonProject.theme.addonDescription = addonDetailsDialog.returnValues[3];
                                        }
                                    }
                                }
                                break;
                            case "LanguageDefault":
                                {
                                    if (helpLanguageForm == null)
                                        helpLanguageForm = new HelpLanguageForm();
                                    helpLanguageForm.Show();
                                    helpLanguageForm.BringToFront();
                                }
                                break;
                            case "LanguageAddonDetails":
                                {
                                    using (AddonDetailsDialog addonDetailsDialog = new AddonDetailsDialog(addonProject.language.addonName,
                                                AddonType.language,
                                                addonProject.language.addonCreator,
                                                addonProject.language.addonVersion,
                                                addonProject.language.addonDescription))
                                    {
                                        if (addonDetailsDialog.ShowDialog() == DialogResult.OK)
                                        {

                                            addonProject.language.addonName = addonDetailsDialog.returnValues[0];
                                            addonProject.language.addonCreator = addonDetailsDialog.returnValues[1];
                                            addonProject.language.addonVersion = addonDetailsDialog.returnValues[2];
                                            addonProject.language.addonDescription = addonDetailsDialog.returnValues[3];
                                        }
                                    }
                                }
                                break;
                            case "MemoryPatchAddonDetails":
                                {
                                    using (AddonDetailsDialog addonDetailsDialog = new AddonDetailsDialog(addonProject.memoryPatch.addonName,
                                                AddonType.memoryPatch,
                                                addonProject.memoryPatch.addonCreator,
                                                addonProject.memoryPatch.addonVersion,
                                                addonProject.memoryPatch.addonDescription))
                                    {
                                        if (addonDetailsDialog.ShowDialog() == DialogResult.OK)
                                        {

                                            addonProject.memoryPatch.addonName = addonDetailsDialog.returnValues[0];
                                            addonProject.memoryPatch.addonCreator = addonDetailsDialog.returnValues[1];
                                            addonProject.memoryPatch.addonVersion = addonDetailsDialog.returnValues[2];
                                            addonProject.memoryPatch.addonDescription = addonDetailsDialog.returnValues[3];
                                        }
                                    }
                                }
                                break;
                        }
                        break;
                    }
                #endregion
                #region Create
                case "crea":
                    {
                        string fromTab = source.Name.Replace("create", string.Empty);
                        switch (fromTab)
                        {
                            case "Catalog":
                                if (productsListBox.CheckedItems.Count == productsListBox.Items.Count
                                        && categoriesListBox.CheckedItems.Count == categoriesListBox.Items.Count)
                                {
                                    createAddonDialog.FilterIndex = 1;
                                    createAddonDialog.FileName = addonProject.catalog.addonName;
                                    if (createAddonDialog.ShowDialog() == DialogResult.OK)
                                    {
                                        if (createAddonDialog.FileName.EndsWith(".serveraddon.catalogwithbasket"))
                                        {
                                            string targetAddon = createAddonDialog.FileName;
                                            saveAddonProperties(targetAddon, addonProject.catalog.addonName, AddonType.catalogWithBaskets,
                                                addonProject.catalog.addonCreator, addonProject.catalog.addonVersion,
                                                addonProject.catalog.addonDescription);
                                            if (targetAddon.saveAddonFile(AddonType.catalogWithBaskets,
                                                                        productsListBox.Items.Cast<string>().ToArray(),
                                                                        categoriesListBox.Items.Cast<string>().ToArray(),
                                                                        basketsListBox.Items.Cast<string>().ToArray()
                                                                     ))
                                            {
                                                MessageBox.Show("The catalog addon has been created successfully!",
                                                    "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else
                                            {
                                                if (File.Exists(targetAddon)) File.Delete(targetAddon);
                                                MessageBox.Show("Create catalog addon operation has been cancelled.",
                                                    "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please use the default extension '.serveraddon.catalogwithbasket' and retry.",
                                                "Hold your horses there, big guy!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please fill in the missing entries in the catalog section and retry.",
                                        "Hold your horses there, big guy!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                break;
                            case "Accent":
                                {
                                    try
                                    {
                                        if (String.IsNullOrWhiteSpace(avalonEditProxyAccent.textEditor.Text))
                                            return;

                                        var xElement = XElement.Parse(avalonEditProxyAccent.textEditor.Text);
                                        String docAccent = xElement.ToString();

                                        createAddonDialog.FilterIndex = 2;
                                        createAddonDialog.FileName = addonProject.accent.addonName;
                                        if (createAddonDialog.ShowDialog() == DialogResult.OK)
                                        {
                                            if (createAddonDialog.FileName.EndsWith(".serveraddon.accent"))
                                            {
                                                string targetAddon = createAddonDialog.FileName;
                                                saveAddonProperties(targetAddon, addonProject.accent.addonName, AddonType.accent,
                                                    addonProject.accent.addonCreator, addonProject.accent.addonVersion,
                                                    addonProject.accent.addonDescription);
                                                if (targetAddon.saveAddonFile(AddonType.accent, new string[] { docAccent }))
                                                {
                                                    MessageBox.Show("The accent addon has been created successfully!",
                                                        "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                else
                                                {
                                                    if (File.Exists(targetAddon)) File.Delete(targetAddon);
                                                    MessageBox.Show("Create accent addon operation has been cancelled.",
                                                        "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Please use the default extension '.serveraddon.accent' and retry.",
                                                    "Hold your horses there, big guy!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(String.Format("{0}\r\n\r\nPlease retry after fixing the error.", ex.Message),
                                            "ERROR: Not valid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;
                            case "Theme":
                                {
                                    try
                                    {
                                        if (String.IsNullOrWhiteSpace(avalonEditProxyTheme.textEditor.Text))
                                            return;

                                        var xElement = XElement.Parse(avalonEditProxyTheme.textEditor.Text);
                                        String docTheme = xElement.ToString();

                                        createAddonDialog.FilterIndex = 3;
                                        createAddonDialog.FileName = addonProject.theme.addonName;
                                        if (createAddonDialog.ShowDialog() == DialogResult.OK)
                                        {
                                            if (createAddonDialog.FileName.EndsWith(".serveraddon.theme"))
                                            {
                                                string targetAddon = createAddonDialog.FileName;
                                                saveAddonProperties(targetAddon, addonProject.theme.addonName, AddonType.theme,
                                                    addonProject.theme.addonCreator, addonProject.theme.addonVersion,
                                                    addonProject.theme.addonDescription);
                                                if (targetAddon.saveAddonFile(AddonType.theme, new string[] { docTheme }))
                                                {
                                                    MessageBox.Show("The theme addon has been created successfully!",
                                                        "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                else
                                                {
                                                    if (File.Exists(targetAddon)) File.Delete(targetAddon);
                                                    MessageBox.Show("Create theme addon operation has been cancelled.",
                                                        "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Please use the default extension '.serveraddon.theme' and retry.",
                                                    "Hold your horses there, big guy!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(String.Format("{0}\r\n\r\nPlease retry after fixing the error.", ex.Message),
                                            "ERROR: Not valid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;
                            case "Language":
                                {
                                    try
                                    {
                                        if (String.IsNullOrWhiteSpace(avalonEditProxyLanguage.textEditor.Text))
                                            return;

                                        var xElement = XElement.Parse(avalonEditProxyLanguage.textEditor.Text);
                                        String docLanguage = xElement.ToString();

                                        createAddonDialog.FilterIndex = 4;
                                        createAddonDialog.FileName = addonProject.language.addonName;
                                        if (createAddonDialog.ShowDialog() == DialogResult.OK)
                                        {
                                            if (createAddonDialog.FileName.EndsWith(".serveraddon.language"))
                                            {
                                                string targetAddon = createAddonDialog.FileName;
                                                saveAddonProperties(targetAddon, addonProject.language.addonName, AddonType.language,
                                                    addonProject.language.addonCreator, addonProject.language.addonVersion,
                                                    addonProject.language.addonDescription);
                                                if (targetAddon.saveAddonFile(AddonType.language, new string[] { docLanguage }))
                                                {
                                                    MessageBox.Show("The language addon has been created successfully!",
                                                        "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                else
                                                {
                                                    if (File.Exists(targetAddon)) File.Delete(targetAddon);
                                                    MessageBox.Show("Create language addon operation has been cancelled.",
                                                        "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Please use the default extension '.serveraddon.language' and retry.",
                                                    "Hold your horses there, big guy!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(String.Format("{0}\r\n\r\nPlease retry after fixing the error.", ex.Message),
                                            "ERROR: Not valid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;
                            case "MemoryPatch":
                                MessageBox.Show("codedom-jitcompile-dll-main-attach/detach");
                                break;
                        }
                        break;
                    }
                #endregion
                #region Discard
                case "disc":
                    {
                        string fromTab = source.Name.Replace("discard", string.Empty);
                        switch (fromTab)
                        {
                            case "Catalog":
                                {
                                    clearCatalogListBoxes();
                                    addonProject.catalog = new AddonProject.Catalog();
                                }
                                break;
                            case "Accent":
                                {
                                    addonProject.accent = new AddonProject.Accent();
                                    avalonEditProxyAccent.textEditor.Text = AddonProject.Accent.defaultAccentXaml;
                                }
                                break;
                            case "Theme":
                                {
                                    addonProject.theme = new AddonProject.Theme();
                                    avalonEditProxyTheme.textEditor.Text = AddonProject.Theme.defaultThemeXaml;
                                }
                                break;
                            case "Language":
                                {
                                    addonProject.language = new AddonProject.Language();
                                    avalonEditProxyLanguage.textEditor.Text = AddonProject.Language.defaultLanguageFileText;
                                }
                                break;
                            case "MemoryPatch":
                                {
                                    addonProject.memoryPatch = new AddonProject.MemoryPatch();
                                    avalonEditProxyMemoryPatch.textEditor.Text = "";
                                }
                                break;
                        }
                        break;
                    }
                    #endregion

            }
        }
        private void installAnAddonButton_Click(object sender, EventArgs e)
        {
            Button source = (Button)sender;
            switch (source.Name.Replace("button", string.Empty))
            {
                case "AddonBrowse":
                    {
                        if (addonLocationDialog.ShowDialog() == DialogResult.OK)
                        {
                            string targetAddon = addonLocationDialog.FileName;
                            readAddon(targetAddon);
                        }
                    }
                    break;
                case "AddonInstall":
                    {
                        buttonAddonInstall.Enabled = false;
                        buttonAddonInstall.Text = "Installing...";

                        string targetAddon = addonLocationDialog.FileName;
                        if (targetAddon.installAddon())
                        {
                            offlineServerTalk.notify(IPCPacketType.installedAddon, targetAddon.readAddonProperty(addonNameDef));
                            MessageBox.Show("The selected addon has been installed successfully.", "Just to let you know...",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("There was an error while installing the selected addon. Please double-check the addon and retry.", "Beep boop, I done goofed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        this.BringToFront();
                        buttonAddonInstall.Text = "Install Addon";
                        buttonAddonInstall.Enabled = true;
                    }
                    break;
            }
        }
        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem source = (ToolStripMenuItem)sender;
            switch (source.Name.Replace("toolStripMenuItem", string.Empty))
            {
                case "OpenProject":
                    loadAddonProject();
                    break;
                case "SaveProject":
                    saveAddonProject(addonProject.projectLocation);
                    break;
                case "SaveProjectAs":
                    saveAddonProject();
                    break;
                case "Exit":
                    Application.Exit();
                    break;
            }
        }
        private void toolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripButton source = (ToolStripButton)sender;
            switch (source.Name.Replace("toolStripButton", string.Empty))
            {
                case "About":
                    // will be changed later on with a dialog
                    MessageBox.Show(String.Format("AddonManager version: {0}\r\nLocal Offline Server version: {1}",
                        Application.ProductVersion, localOfflineServerVersion), "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
        #endregion
        #region General Control
        private void control_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        #endregion
        #region Install an Addon
        private void browseAddon_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (file.EndsWith(".serveraddon.catalogwithbasket")
                    || file.EndsWith(".serveraddon.accent")
                    || file.EndsWith(".serveraddon.theme")
                    || file.EndsWith(".serveraddon.language")
                    || file.EndsWith(".serveraddon.memorypatch"))
                {
                    readAddon(file);
                    return;
                }
            }
            MessageBox.Show("No valid addon was found in the dropped files, please note that drag & drop is extension-dependent.",
                "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion
        #region ListBox
        private void basketsListBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if (basketsListBox.SelectedIndex != -1)
                {
                    int oldIndex = basketsListBox.SelectedIndex;
                    basketsListBox.Items.RemoveAt(basketsListBox.SelectedIndex);
                    basketsListBox.SelectedIndex = Math.Min(0, oldIndex - 1);
                }
            }
            else if (e.KeyData == (Keys.Control | Keys.Delete))
            {
                if (basketsListBox.SelectedIndex != -1)
                {
                    string currentItem = basketsListBox.SelectedItem.ToString();
                    basketsListBox.ClearSelected();
                    basketsListBox.Items.Clear();
                    basketsListBox.Items.Add(currentItem);
                    basketsListBox.SelectedItem = currentItem;
                }
            }
            else if (e.KeyData == (Keys.Shift | Keys.Delete))
            {
                basketsListBox.ClearSelected();
                basketsListBox.Items.Clear();
            }

        }
        private void basketsListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int targetIndex = basketsListBox.IndexFromPoint(e.Location);
                if (targetIndex != -1)
                {
                    basketsListBox.SelectedIndex = targetIndex;
                    listBoxRemoveItemContextMenu.Show(Cursor.Position);
                    listBoxRemoveItemContextMenu.Visible = true;
                }
                else
                {
                    listBoxRemoveItemContextMenu.Visible = false;
                }
            }
        }
        private void removeListBoxEntryMenuItem_Click(object sender, EventArgs e)
        {
            string targetOption = ((ToolStripMenuItem)sender).Name.Substring(11);
            switch (targetOption)
            {
                case "RemoveOption1":
                    if (basketsListBox.SelectedIndex != -1)
                    {
                        int oldIndex = basketsListBox.SelectedIndex;
                        basketsListBox.Items.RemoveAt(basketsListBox.SelectedIndex);
                        basketsListBox.SelectedIndex = Math.Min(0, oldIndex - 1);
                    }
                    break;
                case "RemoveOption2":
                    if (basketsListBox.SelectedIndex != -1)
                    {
                        string currentItem = basketsListBox.SelectedItem.ToString();
                        basketsListBox.ClearSelected();
                        basketsListBox.Items.Clear();
                        basketsListBox.Items.Add(currentItem);
                        basketsListBox.SelectedItem = currentItem;
                    }
                    break;
                case "RemoveOption3":
                    basketsListBox.ClearSelected();
                    basketsListBox.Items.Clear();
                    break;
            }

        }

        private void listBox_DragDrop(object sender, DragEventArgs e)
        {
            ListBox targetListBox = (ListBox)sender;
            List<string> items = targetListBox.Items.Cast<String>().ToList();

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (!File.Exists(file))
                    continue;

                string fileName = Path.GetFileName(file);
                try
                {
                    int targetIndex = items.IndexOf(items
                                    .Where(itemText => itemText.StartsWith(fileName))
                                    .First());

                    items[targetIndex] = String.Format("{0} ({1})", fileName, file);
                    log.InfoFormat("Updated {0} on {1}.", fileName, targetListBox.Name);
                }
                catch (InvalidOperationException)
                {
                    items.Add(String.Format("{0} ({1})", fileName, file));
                    log.InfoFormat("Added file {0} to {1}.", file, targetListBox.Name);
                }
                catch (ArgumentNullException)
                {
                    items.Add(String.Format("{0} ({1})", fileName, file));
                    log.InfoFormat("Added file {0} to {1}.", file, targetListBox.Name);
                }
            }
            addItemsWithNaturalOrder(ref targetListBox, items);
        }
        private void checkedListBox_DragDrop(object sender, DragEventArgs e)
        {
            CheckedListBox targetListBox = (CheckedListBox)sender;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (!File.Exists(file))
                    continue;
                try
                {
                    string fileName = Path.GetFileName(file);
                    int targetIndex = targetListBox.Items.IndexOf(targetListBox.Items.Cast<string>()
                        .Where(itemText => itemText.StartsWith(fileName))
                        .First());

                    targetListBox.Items[targetIndex] = String.Format("{0} ({1})", fileName, file);
                    ActiveCheckedListBox.managingLists = true;
                    targetListBox.SetItemChecked(targetIndex, true);
                    ActiveCheckedListBox.managingLists = false;
                    log.InfoFormat("Updated {0} on {1}.", fileName, targetListBox.Name);
                }
                catch (InvalidOperationException)
                {
                    log.InfoFormat("The file {0} was discarded as it is invalid.", file);
                }
                catch (ArgumentNullException)
                {
                    log.InfoFormat("The file {0} was discarded as it is invalid.", file);
                }
            }
        }
        #endregion
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            log.Info("Shutting down AddonManager.");
            offlineServerTalk.notify(IPCPacketType.addonManagerClosing);
            offlineServerTalk.shutdown();
        }

        public MainForm(Boolean isFirstRun = false, String installAddonPath = null, Boolean setupIPCTalk = false, Int32 port = -1)
        {
            Logger.Setup();

            #region Culture Independency
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
            Properties.Resources.Culture = new CultureInfo("en-GB");
            log.Info("Culture independency achieved.");
            #endregion

            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            InitializeComponent();

            offlineServerTalk = new OfflineServerTalk();

            addonProject = new AddonProject();

            htmlPanel = new HtmlPanel();
            htmlPanel.AutoSize = false;
            htmlPanel.BorderStyle = BorderStyle.Fixed3D;
            htmlPanel.Location = new Point(186, 38);
            htmlPanel.Size = new Size(210, 299);
            htmlPanel.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            installAddonGroupBox.Controls.Add(htmlPanel);

            avalonEditProxyAccent.textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("XML");
            avalonEditProxyTheme.textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("XML");
            avalonEditProxyLanguage.textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("XML");
            avalonEditProxyMemoryPatch.textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("C#");

            avalonEditProxyAccent.textEditor.Text = AddonProject.Accent.defaultAccentXaml;
            avalonEditProxyTheme.textEditor.Text = AddonProject.Theme.defaultThemeXaml;
            avalonEditProxyLanguage.textEditor.Text = AddonProject.Language.defaultLanguageFileText;

            if (!String.IsNullOrWhiteSpace(installAddonPath))
            {
                log.Info("/installAddon was specified, executing run-once installation.");
                // handle auto install
            }
            else
            {
                if (setupIPCTalk && port != -1)
                    offlineServerTalk.initialize(port);
                if (isFirstRun)
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        Hide();
                        FirstRunForm frForm = new FirstRunForm(this);
                        frForm.Show();
                    }));
                }
            }
        }
    }
}