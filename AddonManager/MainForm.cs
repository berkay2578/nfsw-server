using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.WinForms;
using static AddonManager.Addon;
using static AddonManager.CustomControls;
using static AddonManager.FunctionsEx;

namespace AddonManager
{
    public partial class MainForm : Form
    {
        private Boolean firstRun = false;
        private HtmlPanel htmlPanel;
        private AddonProject addonProject;
        public static String localOfflineServerVersion
        {
            get
            {
#if !DEBUG
                if (!File.Exists("OfflineServer.exe"))
                {
                    MessageBox.Show("It seems like you are running this manager standalone, you need to place this manager next to your 'OfflineServer.exe'!", "Hold your horses there, big guy!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show("AddonManager will now close, please place it next to the offline server and then run it again.", "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    return null;
                }
                else
                {
                    return FileVersionInfo.GetVersionInfo(Path.Combine(Environment.CurrentDirectory, "OfflineServer.exe")).ProductVersion;
                }
#else
                return "DEVELOPER PREVIEW";
#endif
            }
        }

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
                if (openProjectDialog.FileName.EndsWith(".addonmanager_project"))
                {
                    addonProject = File.ReadAllText(openProjectDialog.FileName, Encoding.UTF8).DeserializeObject<AddonProject>();

                    #region Catalog and Basket
                    // Products
                    clearProductsListBox();
                    ActiveCheckedListBox.managingLists = true;
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
                    ActiveCheckedListBox.managingLists = false;

                    // Categories
                    clearCategoriesListBox();
                    ActiveCheckedListBox.managingLists = true;
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

                    MessageBox.Show("The selected project was loaded successfully!", "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a file with the default extension '.addonmanager_project' and retry.",
                                "Hold your horses there, big guy!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        internal void saveAddonProject()
        {
            #region Catalog and Basket
            addonProject.catalog.catalog_products = productsListBox.Items.Cast<String>().ToList();
            addonProject.catalog.catalog_categories = categoriesListBox.Items.Cast<String>().ToList();
            addonProject.catalog.basket_definitions = basketsListBox.Items.Cast<String>().ToList();
            #endregion


            if (saveProjectDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveProjectDialog.FileName.EndsWith(".addonmanager_project"))
                {
                    File.WriteAllText(saveProjectDialog.FileName, DerivedFunctions.serializeObject(addonProject), new UTF8Encoding(false, false));
                    MessageBox.Show("The project has been saved successfully!", "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please use the default extension '.addonmanager_project' and retry.",
                                "Hold your horses there, big guy!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion
        #endregion

        private void tabButton_Click(object sender, EventArgs e)
        {
            Button source = (Button)sender;
            switch (source.Name.Substring(0, 4))
            {
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
                                    break;
                                }
                            default:
                                break;
                        }
                        break;
                    }
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
                                    if (createAddonDialog.ShowDialog() == DialogResult.OK)
                                    {
                                        if (createAddonDialog.FileName.EndsWith(".serveraddon_catalogwithbasket"))
                                        {
                                            string targetAddon = createAddonDialog.FileName;
                                            targetAddon.saveAddonProperty(Addon.addonNameDef, addonProject.catalog.addonName, true);
                                            targetAddon.saveAddonProperty(Addon.addonTypeDef, AddonType.catalogWithBaskets);
                                            targetAddon.saveAddonProperty(Addon.addonCreatorDef, addonProject.catalog.addonCreator);
                                            targetAddon.saveAddonProperty(Addon.addonDateDef, DateTime.Now.ToShortDateString());
                                            targetAddon.saveAddonProperty(Addon.addonVersionDef, addonProject.catalog.addonVersion);
                                            targetAddon.saveAddonProperty(Addon.addonForVersionDef, localOfflineServerVersion);
                                            targetAddon.saveAddonProperty(Addon.addonResDef, "RESERVED FOR LATER USE");
                                            targetAddon.saveAddonProperty(Addon.addonDescriptionDef, addonProject.catalog.addonDescription);
                                            targetAddon.saveAddonFile(AddonType.catalogWithBaskets,
                                                                        productsListBox.Items.Cast<string>().ToArray(),
                                                                        categoriesListBox.Items.Cast<string>().ToArray(),
                                                                        basketsListBox.Items.Cast<string>().ToArray()
                                                                     );
                                            MessageBox.Show("The catalog addon has been created successfully!",
                                                "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please use the default extension '.serveraddon_catalogwithbasket' and retry.",
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
                            default:
                                break;
                        }
                        break;
                    }
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
                            default:
                                break;
                        }
                        break;
                    }
                case "save":
                    {

                        string fromTab = source.Name.Replace("save", string.Empty);
                        switch (fromTab)
                        {
                            case "Project":
                                saveAddonProject();
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                case "load":
                    {

                        string fromTab = source.Name.Replace("load", string.Empty);
                        switch (fromTab)
                        {
                            case "Project":
                                loadAddonProject();
                                break;
                            default:
                                break;
                        }
                        break;
                    }
            }
        }

        #region UI Events
        #region ListBox
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
            if (basketsListBox.SelectedIndex != -1) basketsListBox.Items.RemoveAt(basketsListBox.SelectedIndex);
        }

        private void listBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        private void listBox_DragDrop(object sender, DragEventArgs e)
        {
            ListBox targetListBox = (ListBox)sender;
            List<string> items = targetListBox.Items.Cast<String>().ToList();
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                string targetString = items.Where(itemText => itemText.StartsWith(Path.GetFileName(file)))
                    .FirstOrDefault();
                int targetIndex = targetString == null ? -1 : items.IndexOf(targetString);

                if (targetIndex != -1 && targetString != null)
                    items[targetIndex] = Path.GetFileName(file) + " (" + file + ")";
                else
                    items.Add(Path.GetFileName(file) + " (" + file + ")");

                addItemsWithNaturalOrder(ref targetListBox, items);
            }
        }
        private void checkedListBox_DragDrop(object sender, DragEventArgs e)
        {
            CheckedListBox targetListBox = (CheckedListBox)sender;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                int targetIndex = targetListBox.Items.IndexOf(targetListBox.Items.Cast<string>()
                    .Where(itemText => itemText.StartsWith(Path.GetFileName(file)))
                    .First());
                if (targetIndex != -1)
                {
                    targetListBox.Items[targetIndex] = Path.GetFileName(file) + " (" + file + ")";
                    ActiveCheckedListBox.managingLists = true;
                    targetListBox.SetItemChecked(targetIndex, true);
                    ActiveCheckedListBox.managingLists = false;
                } /*else
                {
                    new ToolTip() { Active = true, ToolTipIcon = ToolTipIcon.Warning, ToolTipTitle = "Invalid File", ShowAlways = false }
                            .Show(file + " was discarded.", targetListBox, 1000);
                }*/
            }
        }
        #endregion
        #endregion

        #region Install an Addon
        private void addonLocationButton_Click(object sender, EventArgs e)
        {
            if (addonLocationDialog.ShowDialog() == DialogResult.OK)
            {
                string targetAddon = addonLocationDialog.FileName;

                addonLocationLabel.Text = targetAddon;
                addonInformationLabel.Text = String.Format(CultureInfo.InvariantCulture,
                                "- Name: {0}\r\n- Type: {1}\r\n- Created by: {2}\r\n- Created on: {3}\r\n- Version: {4}\r\n- Made for offline server version: {5}",
                                                            targetAddon.readAddonProperty(Addon.addonNameDef),
                                                            targetAddon.readAddonProperty(Addon.addonTypeDef),
                                                            targetAddon.readAddonProperty(Addon.addonCreatorDef),
                                                            targetAddon.readAddonProperty(Addon.addonDateDef),
                                                            targetAddon.readAddonProperty(Addon.addonVersionDef),
                                                            targetAddon.readAddonProperty(Addon.addonForVersionDef)
                                                           );
                htmlPanel.Text = targetAddon.readAddonProperty(Addon.addonDescriptionDef);
            }
        }

        private void addonInstallButton_Click(object sender, EventArgs e)
        {

        }
        #endregion

        public MainForm(Boolean isFirstRun = false)
        {
            firstRun = isFirstRun;
            InitializeComponent();
            serverVersionLabel.Text = String.Format(serverVersionLabel.Text, localOfflineServerVersion);
            addonProject = new AddonProject();

            htmlPanel = new HtmlPanel();
            htmlPanel.AutoSize = false;
            htmlPanel.BorderStyle = BorderStyle.FixedSingle;
            htmlPanel.Location = new Point(187, 38);
            htmlPanel.Size = new Size(210, 299);
            htmlPanel.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            installAddonGroupBox.Controls.Add(htmlPanel);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (firstRun)
            {
                Application.Exit();
            }
        }
    }
}