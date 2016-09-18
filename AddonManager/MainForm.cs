using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AddonManager
{
    public partial class MainForm : Form
    {
        private Boolean firstRun = false;
        private AddonProject addonProject;

        #region Functions and the necessities
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
                    foreach (string product in addonProject.catalog.catalog_products)
                        if (product.Trim().IndexOf('(') != -1)
                        {
                            int targetIndex = productsListBox.Items.IndexOf(productsListBox.Items.Cast<string>()
                                .Where(itemText => itemText.Contains(AddonProject.Catalog.getListBoxEntryText(product)))
                                .First());
                            productsListBox.Items[targetIndex] = product;
                            productsListBox.SetItemChecked(targetIndex, true);
                        }

                    // Categories
                    foreach (string category in addonProject.catalog.catalog_categories)
                        if (category.Trim().IndexOf('(') != -1)
                        {
                            int targetIndex = categoriesListBox.Items.IndexOf(categoriesListBox.Items.Cast<string>()
                                .Where(itemText => itemText.Contains(AddonProject.Catalog.getListBoxEntryText(category)))
                                .First());
                            categoriesListBox.Items[targetIndex] = category;
                            categoriesListBox.SetItemChecked(targetIndex, true);
                        }

                    // Basket Files
                    foreach (string basket in addonProject.catalog.basket_definitions)
                        basketsListBox.Items.Add(basket.Trim());

                    // Others
                    catalogCreaterTextBox.Text = addonProject.catalog.addonCreater
                                                        .Substring(0, Math.Min(addonProject.catalog.addonCreater.Length, 255));
                    catalogDescriptionTextBox.Text = addonProject.catalog.addonDescription
                                                        .Substring(0, Math.Min(addonProject.catalog.addonDescription.Length, 255));
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
            addonProject.catalog.addonCreater = catalogCreaterTextBox.Text.Trim();
            addonProject.catalog.addonDescription = catalogDescriptionTextBox.Text.Trim();
            #endregion
            

            if (saveProjectDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveProjectDialog.FileName.EndsWith(".addonmanager_project"))
                    File.WriteAllText(saveProjectDialog.FileName, DerivedFunctions.serializeObject(addonProject));
                else
                    MessageBox.Show("Please use the default extension '.addonmanager_project' and retry.", 
                                "Hold your horses there, big guy!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region AddonType & AddonProperty
        internal enum AddonType
        {
            CatalogAndBasket = 0,
            Accent = 1,
            Theme = 2,
            Language = 3
        }

        /// <summary>
        /// Each property other than the AddonFile is a string with the length of 255, and is encoded with UTF8.
        /// </summary>
        internal enum AddonProperty
        {
            Type = 0,
            CreatedBy = 1,
            DateCreated = 2,
            MadeForVersion = 3,
            SimpleDescription = 4,
            ReservedForLater = 5,
            ReserverForLater2 = 6,
            ReservedForLater3 = 7,
            AddonFile = 8
        }

        internal dynamic readAddonProperty(String filePath, AddonProperty property)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    int bytesToRead = property != AddonProperty.AddonFile ? 1020 : (int)fileStream.Length - 8160;
                    int bytesRead = 0;
                    int count = 0;
                    byte[] buffer = new byte[bytesToRead];
                    fileStream.Position = (int)property * 1020;

                    do
                    {
                        bytesRead += count;
                        bytesToRead -= count;
                        count = fileStream.Read(buffer, bytesRead, bytesToRead);
                    } while (count > 0);
                    if (property != AddonProperty.AddonFile)
                        return Encoding.UTF8.GetString(buffer).TrimEnd('\0');
                    return buffer;
                }
                catch (Exception ex)
                {
                    Debug.Print("Something isn't quite right...");
                    Debug.Print(ex.ToString());
                    return null;
                }
            }
        }
        internal void saveAddonProperty(String[] listProperties)
        {
            if (listProperties.Length < 9)
            {
                int arrayLength = listProperties.Length;
                Array.Resize<String>(ref listProperties, 9);
                for (int l = arrayLength; l < 9; l++)
                    listProperties[l] = "";
            }
            using (FileStream fileStream = new FileStream(createAddonDialog.FileName, FileMode.Create, FileAccess.Write))
            {
                for (int i = 0; i < 8; i++)
                {
                    byte[] propertyType = Encoding.UTF8.GetBytes(listProperties[i].Substring(0, Math.Min(listProperties[i].Length, 255)) + '\0');
                    fileStream.Position = i * 1020;
                    fileStream.Write(propertyType, 0, propertyType.Length);
                }
            }
        }
        internal void saveAddonFile(AddonType addonType)
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "addonmanager");
            string zipFile = Path.Combine(Path.GetTempPath(), "addon.zip");
            if (Directory.Exists(tempDir)) Directory.Delete(tempDir, true);
            if (File.Exists(zipFile)) File.Delete(zipFile);
            Directory.CreateDirectory(tempDir);

            switch (addonType)
            {
                case AddonType.CatalogAndBasket:
                    var productsTemp = Directory.CreateDirectory(Path.Combine(tempDir, OfflineServer.Data.DataEx.dir_HttpServerCatalogs, Path.GetFileNameWithoutExtension(createAddonDialog.FileName), "Products"));
                    var categoriesTemp = Directory.CreateDirectory(Path.Combine(tempDir, OfflineServer.Data.DataEx.dir_HttpServerCatalogs, Path.GetFileNameWithoutExtension(createAddonDialog.FileName), "Categories"));
                    var basketsTemp = Directory.CreateDirectory(Path.Combine(tempDir, OfflineServer.Data.DataEx.dir_HttpServerBaskets));

                    foreach (string product in productsListBox.Items)
                        File.Copy(AddonProject.Catalog.getFileLocation(product), Path.Combine(productsTemp.FullName,
                            AddonProject.Catalog.getListBoxEntryText(product)), true);
                    foreach (string category in categoriesListBox.Items)
                        File.Copy(AddonProject.Catalog.getFileLocation(category), Path.Combine(categoriesTemp.FullName,
                            AddonProject.Catalog.getListBoxEntryText(category)), true);
                    foreach (string basket in basketsListBox.Items)
                        File.Copy(AddonProject.Catalog.getFileLocation(basket), Path.Combine(basketsTemp.FullName,
                            AddonProject.Catalog.getListBoxEntryText(basket)), true);

                    FastZip fz = new FastZip();
                    fz.CreateEmptyDirectories = true;
                    fz.CreateZip(zipFile,
                                tempDir,
                                true,
                                null);
                    break;
                case AddonType.Accent:
                    break;
                case AddonType.Theme:
                    break;
                case AddonType.Language:
                    break;
            }
        }
        internal void saveAddon()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "addonmanager");
            string zipFile = Path.Combine(Path.GetTempPath(), "addon.zip");
            using (FileStream fileStream = new FileStream(createAddonDialog.FileName, FileMode.Open, FileAccess.Write))
            {
                byte[] addonFileBytes = File.ReadAllBytes(zipFile);
                fileStream.Position = 8160;
                fileStream.Write(addonFileBytes, 0, addonFileBytes.Length);
            }
            if (Directory.Exists(tempDir)) Directory.Delete(tempDir, true);
            if (File.Exists(zipFile)) File.Delete(zipFile);
        }
        #endregion
        #endregion

        private void tabButton_Click(object sender, EventArgs e)
        {
            Button source = (Button)sender;
            switch (source.Name.Substring(0, 4))
            {
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
                                            saveAddonProperty(new string[] { "Catalog and Basket Pack",
                                                    catalogCreaterTextBox.Text,
                                                    DateTime.Now.ToShortDateString(),
                                                    "berkay2578-!5155b22c45050da4dff2ee6fb7d898da5d482c14-2016.09.08",
                                                    catalogDescriptionTextBox.Text }
                                                            );
                                            saveAddonFile(AddonType.CatalogAndBasket);
                                            saveAddon();
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
        #region Catalog listBox drag&drops
        private void listBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        private void listBox_DragDrop(object sender, DragEventArgs e)
        {
            ListBox targetListBox = (ListBox)sender;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
                targetListBox.Items.Add(Path.GetFileName(file) + " (" + file + ")");
        }
        private void checkedListBox_DragDrop(object sender, DragEventArgs e)
        {
            CheckedListBox targetListBox = (CheckedListBox)sender;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                int targetIndex = targetListBox.Items.IndexOf(Path.GetFileName(file));
                if (targetIndex != -1)
                {
                    targetListBox.Items[targetIndex] = targetListBox.Items[targetIndex] + " (" + file + ")";
                    targetListBox.SetItemChecked(targetIndex, true);
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
                                "- Type: {0}\r\n- Created by: {1}\r\n- Created on: {2}\r\n- Made for version:\r\n{3}",
                                                                readAddonProperty(targetAddon, AddonProperty.Type),
                                                                readAddonProperty(targetAddon, AddonProperty.CreatedBy),
                                                                readAddonProperty(targetAddon, AddonProperty.DateCreated),
                                                                readAddonProperty(targetAddon, AddonProperty.MadeForVersion)
                                                           );
                addonDescriptionLabel.Text = readAddonProperty(targetAddon, AddonProperty.SimpleDescription);
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
#if !DEBUG
            if (!File.Exists("OfflineServer.exe"))
            {
                MessageBox.Show("It seems like you are running this manager standalone, you need to place this manager next to your 'OfflineServer.exe'!", "Hold your horses there, big guy!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("AddonManager will now close, please place it next to the offline server and then run it again.", "Just to let you know...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            } else {
                serverVersionLabel.Text =  String.Format(serverVersionLabel.Text, FileVersionInfo.GetVersionInfo(Path.Combine(Environment.CurrentDirectory, "OfflineServer.exe")).ProductVersion);
            }
#else
            serverVersionLabel.Text = String.Format(serverVersionLabel.Text, "DEVELOPER PREVIEW");
#endif
            addonProject = new AddonProject();
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
