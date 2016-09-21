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
        public OfflineServerTalk offlineServerTalk;
        public static String localOfflineServerVersion
        {
            get
            {
#if !DEBUG
                string offlineVersionLocation = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "OfflineServer.exe");
                if (!File.Exists(offlineVersionLocation))
                {
                    MessageBox.Show("It seems like you are running this manager standalone, you need to place this manager next to your 'OfflineServer.exe'!", "Hold your horses there, big guy!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (openProjectDialog.FileName.EndsWith(".addonmanager_project"))
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

                    MessageBox.Show("The selected project was loaded successfully!", "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a file with the default extension '.addonmanager_project' and retry.",
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

            if (String.IsNullOrWhiteSpace(projectLocation))
            {
                if (saveProjectDialog.ShowDialog() == DialogResult.OK)
                {
                    if (saveProjectDialog.FileName.EndsWith(".addonmanager_project"))
                    {
                        File.WriteAllText(saveProjectDialog.FileName, DerivedFunctions.serializeObject(addonProject), new UTF8Encoding(false, false));
                        addonProject.projectLocation = saveProjectDialog.FileName;
                        MessageBox.Show("The project has been saved successfully!", "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Please use the default extension '.addonmanager_project' and retry.",
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
        #endregion

        #region UI Events
        #region Button Handlers
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
                                    createAddonDialog.FileName = addonProject.catalog.addonName;
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

                            buttonAddonInstall.Enabled = true;
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

            if (!String.IsNullOrWhiteSpace(installAddonPath))
            {
                log.Info("/installAddon was specified, executing run-once installation.");
                // handle auto install
            }
            else
            {
                if (isFirstRun)
                {
                    if (setupIPCTalk && port != -1)
                        offlineServerTalk.initialize(port);

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