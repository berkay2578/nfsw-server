namespace AddonManager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCatalog = new System.Windows.Forms.TabPage();
            this.openCatalogAddonDetails = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.basketsListBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.categoriesListBox = new AddonManager.CustomControls.ActiveCheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.productsListBox = new AddonManager.CustomControls.ActiveCheckedListBox();
            this.createCatalog = new System.Windows.Forms.Button();
            this.discardCatalog = new System.Windows.Forms.Button();
            this.tabPageAccent = new System.Windows.Forms.TabPage();
            this.elementHostAccent = new System.Windows.Forms.Integration.ElementHost();
            this.avalonEditProxyAccent = new AddonManager.AvalonEditProxy();
            this.openAccentAddonDetails = new System.Windows.Forms.Button();
            this.createAccent = new System.Windows.Forms.Button();
            this.discardAccent = new System.Windows.Forms.Button();
            this.tabPageTheme = new System.Windows.Forms.TabPage();
            this.elementHostTheme = new System.Windows.Forms.Integration.ElementHost();
            this.avalonEditProxyTheme = new AddonManager.AvalonEditProxy();
            this.openThemeAddonDetails = new System.Windows.Forms.Button();
            this.createTheme = new System.Windows.Forms.Button();
            this.discardTheme = new System.Windows.Forms.Button();
            this.tabPageLanguage = new System.Windows.Forms.TabPage();
            this.openLanguageDefault = new System.Windows.Forms.Button();
            this.elementHostLanguage = new System.Windows.Forms.Integration.ElementHost();
            this.avalonEditProxyLanguage = new AddonManager.AvalonEditProxy();
            this.openLanguageAddonDetails = new System.Windows.Forms.Button();
            this.createLanguage = new System.Windows.Forms.Button();
            this.discardLanguage = new System.Windows.Forms.Button();
            this.tabPageMemoryPatch = new System.Windows.Forms.TabPage();
            this.elementHostMemoryPatch = new System.Windows.Forms.Integration.ElementHost();
            this.avalonEditProxyMemoryPatch = new AddonManager.AvalonEditProxy();
            this.comboBoxMemoryPatchTargetModule = new System.Windows.Forms.ComboBox();
            this.openMemoryPatchAddonDetails = new System.Windows.Forms.Button();
            this.createMemoryPatch = new System.Windows.Forms.Button();
            this.discardMemoryPatch = new System.Windows.Forms.Button();
            this.installAddonGroupBox = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addonInformationLabel = new System.Windows.Forms.Label();
            this.buttonAddonInstall = new System.Windows.Forms.Button();
            this.addonLocationLabel = new System.Windows.Forms.Label();
            this.buttonAddonBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addonLocationDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveProjectDialog = new System.Windows.Forms.SaveFileDialog();
            this.openProjectDialog = new System.Windows.Forms.OpenFileDialog();
            this.createAddonDialog = new System.Windows.Forms.SaveFileDialog();
            this.listBoxRemoveItemContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuRemoveOption1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuRemoveOption2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuRemoveOption3 = new System.Windows.Forms.ToolStripMenuItem();
            this.addonManagerToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripItemFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveProjectAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonAbout = new System.Windows.Forms.ToolStripButton();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageCatalog.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPageAccent.SuspendLayout();
            this.tabPageTheme.SuspendLayout();
            this.tabPageLanguage.SuspendLayout();
            this.tabPageMemoryPatch.SuspendLayout();
            this.installAddonGroupBox.SuspendLayout();
            this.listBoxRemoveItemContextMenu.SuspendLayout();
            this.addonManagerToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPageCatalog);
            this.tabControl1.Controls.Add(this.tabPageAccent);
            this.tabControl1.Controls.Add(this.tabPageTheme);
            this.tabControl1.Controls.Add(this.tabPageLanguage);
            this.tabControl1.Controls.Add(this.tabPageMemoryPatch);
            this.tabControl1.Location = new System.Drawing.Point(12, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(467, 373);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.TabStop = false;
            // 
            // tabPageCatalog
            // 
            this.tabPageCatalog.Controls.Add(this.openCatalogAddonDetails);
            this.tabPageCatalog.Controls.Add(this.groupBox3);
            this.tabPageCatalog.Controls.Add(this.groupBox2);
            this.tabPageCatalog.Controls.Add(this.createCatalog);
            this.tabPageCatalog.Controls.Add(this.discardCatalog);
            this.tabPageCatalog.Location = new System.Drawing.Point(4, 4);
            this.tabPageCatalog.Name = "tabPageCatalog";
            this.tabPageCatalog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCatalog.Size = new System.Drawing.Size(459, 347);
            this.tabPageCatalog.TabIndex = 1;
            this.tabPageCatalog.Text = "Catalog and Basket Pack";
            this.tabPageCatalog.UseVisualStyleBackColor = true;
            // 
            // openCatalogAddonDetails
            // 
            this.openCatalogAddonDetails.Location = new System.Drawing.Point(230, 289);
            this.openCatalogAddonDetails.Name = "openCatalogAddonDetails";
            this.openCatalogAddonDetails.Size = new System.Drawing.Size(223, 23);
            this.openCatalogAddonDetails.TabIndex = 10;
            this.openCatalogAddonDetails.Text = "Addon Details";
            this.openCatalogAddonDetails.UseVisualStyleBackColor = true;
            this.openCatalogAddonDetails.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.basketsListBox);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(230, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 271);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Basket";
            // 
            // basketsListBox
            // 
            this.basketsListBox.AllowDrop = true;
            this.basketsListBox.FormattingEnabled = true;
            this.basketsListBox.Location = new System.Drawing.Point(6, 35);
            this.basketsListBox.Name = "basketsListBox";
            this.basketsListBox.ScrollAlwaysVisible = true;
            this.basketsListBox.Size = new System.Drawing.Size(211, 225);
            this.basketsListBox.TabIndex = 4;
            this.basketsListBox.TabStop = false;
            this.basketsListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.basketsListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.control_DragEnter);
            this.basketsListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.basketsListBox_KeyUp);
            this.basketsListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.basketsListBox_MouseDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Drag and drop basket files here:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.categoriesListBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.productsListBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 335);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Catalog";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Drag and drop categories here:";
            // 
            // categoriesListBox
            // 
            this.categoriesListBox.AllowDrop = true;
            this.categoriesListBox.FormattingEnabled = true;
            this.categoriesListBox.Items.AddRange(new object[] {
            "NFSW_NA_EP_VINYLS_Category.xml"});
            this.categoriesListBox.Location = new System.Drawing.Point(6, 203);
            this.categoriesListBox.Name = "categoriesListBox";
            this.categoriesListBox.ScrollAlwaysVisible = true;
            this.categoriesListBox.Size = new System.Drawing.Size(206, 124);
            this.categoriesListBox.TabIndex = 2;
            this.categoriesListBox.TabStop = false;
            this.categoriesListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.checkedListBox_DragDrop);
            this.categoriesListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.control_DragEnter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Drag and drop products here:";
            // 
            // productsListBox
            // 
            this.productsListBox.AllowDrop = true;
            this.productsListBox.CausesValidation = false;
            this.productsListBox.FormattingEnabled = true;
            this.productsListBox.Items.AddRange(new object[] {
            "BoosterPacks.xml",
            "NFSW_NA_EP_CARSLOTS.xml",
            "NFSW_NA_EP_PAINTS_BODY_Category.xml",
            "NFSW_NA_EP_PAINTS_WHEEL_Category.xml",
            "NFSW_NA_EP_PERFORMANCEPARTS.xml",
            "NFSW_NA_EP_PRESET_RIDES_ALL_Category.xml",
            "NFSW_NA_EP_REPAIRS.xml",
            "NFSW_NA_EP_SKILLMODPARTS.xml",
            "NFSW_NA_EP_VISUALPARTS_BODYKIT.xml",
            "NFSW_NA_EP_VISUALPARTS_HOOD.xml",
            "NFSW_NA_EP_VISUALPARTS_LICENSEPLATES.xml",
            "NFSW_NA_EP_VISUALPARTS_LOWERINGKIT.xml",
            "NFSW_NA_EP_VISUALPARTS_NEONS.xml",
            "NFSW_NA_EP_VISUALPARTS_SPOILER.xml",
            "NFSW_NA_EP_VISUALPARTS_WHEELS.xml",
            "NFSW_NA_EP_VISUALPARTS_WINDOWTINTS.xml",
            "Starting_Cars.xml",
            "STORE_AFTERMARKETSHOP_CARDPACK.xml",
            "STORE_AMPLIFIERS.xml",
            "STORE_BOOSTERPACKS.xml",
            "STORE_CARS.xml",
            "STORE_OWNEDCARS.xml",
            "STORE_PERFORMANCESHOP_CARDPACK.xml",
            "STORE_POWERUPS.xml",
            "STORE_SKILLMODPARTS.xml",
            "STORE_SKILLMODSHOP_CARDPACK.xml",
            "STORE_STREAK_RECOVERY.xml",
            "STORE_VANITY_BODYKIT.xml",
            "STORE_VANITY_HOOD.xml",
            "STORE_VANITY_LICENSE_PLATE.xml",
            "STORE_VANITY_LOWERING_KIT.xml",
            "STORE_VANITY_NEON.xml",
            "STORE_VANITY_SPOILER.xml",
            "STORE_VANITY_WHEEL.xml",
            "STORE_VANITY_WINDOW.xml",
            "STORE_VINYLCATEGORIES.xml"});
            this.productsListBox.Location = new System.Drawing.Point(6, 35);
            this.productsListBox.Name = "productsListBox";
            this.productsListBox.ScrollAlwaysVisible = true;
            this.productsListBox.Size = new System.Drawing.Size(206, 139);
            this.productsListBox.TabIndex = 0;
            this.productsListBox.TabStop = false;
            this.productsListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.checkedListBox_DragDrop);
            this.productsListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.control_DragEnter);
            // 
            // createCatalog
            // 
            this.createCatalog.Location = new System.Drawing.Point(344, 318);
            this.createCatalog.Name = "createCatalog";
            this.createCatalog.Size = new System.Drawing.Size(109, 23);
            this.createCatalog.TabIndex = 5;
            this.createCatalog.Text = "Create";
            this.createCatalog.UseVisualStyleBackColor = true;
            this.createCatalog.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // discardCatalog
            // 
            this.discardCatalog.Location = new System.Drawing.Point(230, 318);
            this.discardCatalog.Name = "discardCatalog";
            this.discardCatalog.Size = new System.Drawing.Size(108, 23);
            this.discardCatalog.TabIndex = 6;
            this.discardCatalog.Text = "Discard";
            this.discardCatalog.UseVisualStyleBackColor = true;
            this.discardCatalog.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // tabPageAccent
            // 
            this.tabPageAccent.Controls.Add(this.elementHostAccent);
            this.tabPageAccent.Controls.Add(this.openAccentAddonDetails);
            this.tabPageAccent.Controls.Add(this.createAccent);
            this.tabPageAccent.Controls.Add(this.discardAccent);
            this.tabPageAccent.Location = new System.Drawing.Point(4, 4);
            this.tabPageAccent.Name = "tabPageAccent";
            this.tabPageAccent.Size = new System.Drawing.Size(459, 347);
            this.tabPageAccent.TabIndex = 2;
            this.tabPageAccent.Text = "Accent";
            this.tabPageAccent.UseVisualStyleBackColor = true;
            // 
            // elementHostAccent
            // 
            this.elementHostAccent.Location = new System.Drawing.Point(5, 5);
            this.elementHostAccent.Name = "elementHostAccent";
            this.elementHostAccent.Size = new System.Drawing.Size(448, 307);
            this.elementHostAccent.TabIndex = 24;
            this.elementHostAccent.Child = this.avalonEditProxyAccent;
            // 
            // openAccentAddonDetails
            // 
            this.openAccentAddonDetails.Location = new System.Drawing.Point(119, 318);
            this.openAccentAddonDetails.Name = "openAccentAddonDetails";
            this.openAccentAddonDetails.Size = new System.Drawing.Size(219, 23);
            this.openAccentAddonDetails.TabIndex = 23;
            this.openAccentAddonDetails.Text = "Addon Details";
            this.openAccentAddonDetails.UseVisualStyleBackColor = true;
            this.openAccentAddonDetails.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // createAccent
            // 
            this.createAccent.Location = new System.Drawing.Point(344, 318);
            this.createAccent.Name = "createAccent";
            this.createAccent.Size = new System.Drawing.Size(109, 23);
            this.createAccent.TabIndex = 21;
            this.createAccent.Text = "Create";
            this.createAccent.UseVisualStyleBackColor = true;
            this.createAccent.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // discardAccent
            // 
            this.discardAccent.Location = new System.Drawing.Point(5, 318);
            this.discardAccent.Name = "discardAccent";
            this.discardAccent.Size = new System.Drawing.Size(108, 23);
            this.discardAccent.TabIndex = 22;
            this.discardAccent.Text = "Discard";
            this.discardAccent.UseVisualStyleBackColor = true;
            this.discardAccent.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // tabPageTheme
            // 
            this.tabPageTheme.Controls.Add(this.elementHostTheme);
            this.tabPageTheme.Controls.Add(this.openThemeAddonDetails);
            this.tabPageTheme.Controls.Add(this.createTheme);
            this.tabPageTheme.Controls.Add(this.discardTheme);
            this.tabPageTheme.Location = new System.Drawing.Point(4, 4);
            this.tabPageTheme.Name = "tabPageTheme";
            this.tabPageTheme.Size = new System.Drawing.Size(459, 347);
            this.tabPageTheme.TabIndex = 3;
            this.tabPageTheme.Text = "Theme";
            this.tabPageTheme.UseVisualStyleBackColor = true;
            // 
            // elementHostTheme
            // 
            this.elementHostTheme.Location = new System.Drawing.Point(5, 5);
            this.elementHostTheme.Name = "elementHostTheme";
            this.elementHostTheme.Size = new System.Drawing.Size(448, 307);
            this.elementHostTheme.TabIndex = 24;
            this.elementHostTheme.Child = this.avalonEditProxyTheme;
            // 
            // openThemeAddonDetails
            // 
            this.openThemeAddonDetails.Location = new System.Drawing.Point(119, 318);
            this.openThemeAddonDetails.Name = "openThemeAddonDetails";
            this.openThemeAddonDetails.Size = new System.Drawing.Size(219, 23);
            this.openThemeAddonDetails.TabIndex = 23;
            this.openThemeAddonDetails.Text = "Addon Details";
            this.openThemeAddonDetails.UseVisualStyleBackColor = true;
            this.openThemeAddonDetails.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // createTheme
            // 
            this.createTheme.Location = new System.Drawing.Point(344, 318);
            this.createTheme.Name = "createTheme";
            this.createTheme.Size = new System.Drawing.Size(109, 23);
            this.createTheme.TabIndex = 21;
            this.createTheme.Text = "Create";
            this.createTheme.UseVisualStyleBackColor = true;
            this.createTheme.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // discardTheme
            // 
            this.discardTheme.Location = new System.Drawing.Point(5, 318);
            this.discardTheme.Name = "discardTheme";
            this.discardTheme.Size = new System.Drawing.Size(108, 23);
            this.discardTheme.TabIndex = 22;
            this.discardTheme.Text = "Discard";
            this.discardTheme.UseVisualStyleBackColor = true;
            this.discardTheme.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // tabPageLanguage
            // 
            this.tabPageLanguage.Controls.Add(this.label8);
            this.tabPageLanguage.Controls.Add(this.openLanguageDefault);
            this.tabPageLanguage.Controls.Add(this.elementHostLanguage);
            this.tabPageLanguage.Controls.Add(this.openLanguageAddonDetails);
            this.tabPageLanguage.Controls.Add(this.createLanguage);
            this.tabPageLanguage.Controls.Add(this.discardLanguage);
            this.tabPageLanguage.Location = new System.Drawing.Point(4, 4);
            this.tabPageLanguage.Name = "tabPageLanguage";
            this.tabPageLanguage.Size = new System.Drawing.Size(459, 347);
            this.tabPageLanguage.TabIndex = 4;
            this.tabPageLanguage.Text = "Language";
            this.tabPageLanguage.UseVisualStyleBackColor = true;
            // 
            // openLanguageDefault
            // 
            this.openLanguageDefault.Location = new System.Drawing.Point(133, 289);
            this.openLanguageDefault.Name = "openLanguageDefault";
            this.openLanguageDefault.Size = new System.Drawing.Size(91, 52);
            this.openLanguageDefault.TabIndex = 21;
            this.openLanguageDefault.Text = "Show Default (English) Language File";
            this.openLanguageDefault.UseVisualStyleBackColor = true;
            this.openLanguageDefault.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // elementHostLanguage
            // 
            this.elementHostLanguage.Location = new System.Drawing.Point(5, 5);
            this.elementHostLanguage.Name = "elementHostLanguage";
            this.elementHostLanguage.Size = new System.Drawing.Size(448, 278);
            this.elementHostLanguage.TabIndex = 20;
            this.elementHostLanguage.Child = this.avalonEditProxyLanguage;
            // 
            // openLanguageAddonDetails
            // 
            this.openLanguageAddonDetails.Location = new System.Drawing.Point(230, 289);
            this.openLanguageAddonDetails.Name = "openLanguageAddonDetails";
            this.openLanguageAddonDetails.Size = new System.Drawing.Size(223, 23);
            this.openLanguageAddonDetails.TabIndex = 18;
            this.openLanguageAddonDetails.Text = "Addon Details";
            this.openLanguageAddonDetails.UseVisualStyleBackColor = true;
            this.openLanguageAddonDetails.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // createLanguage
            // 
            this.createLanguage.Location = new System.Drawing.Point(344, 318);
            this.createLanguage.Name = "createLanguage";
            this.createLanguage.Size = new System.Drawing.Size(109, 23);
            this.createLanguage.TabIndex = 16;
            this.createLanguage.Text = "Create";
            this.createLanguage.UseVisualStyleBackColor = true;
            this.createLanguage.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // discardLanguage
            // 
            this.discardLanguage.Location = new System.Drawing.Point(230, 318);
            this.discardLanguage.Name = "discardLanguage";
            this.discardLanguage.Size = new System.Drawing.Size(108, 23);
            this.discardLanguage.TabIndex = 17;
            this.discardLanguage.Text = "Discard";
            this.discardLanguage.UseVisualStyleBackColor = true;
            this.discardLanguage.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // tabPageMemoryPatch
            // 
            this.tabPageMemoryPatch.Controls.Add(this.elementHostMemoryPatch);
            this.tabPageMemoryPatch.Controls.Add(this.comboBoxMemoryPatchTargetModule);
            this.tabPageMemoryPatch.Controls.Add(this.openMemoryPatchAddonDetails);
            this.tabPageMemoryPatch.Controls.Add(this.createMemoryPatch);
            this.tabPageMemoryPatch.Controls.Add(this.discardMemoryPatch);
            this.tabPageMemoryPatch.Location = new System.Drawing.Point(4, 4);
            this.tabPageMemoryPatch.Name = "tabPageMemoryPatch";
            this.tabPageMemoryPatch.Size = new System.Drawing.Size(459, 347);
            this.tabPageMemoryPatch.TabIndex = 5;
            this.tabPageMemoryPatch.Text = "Memory Patch";
            this.tabPageMemoryPatch.UseVisualStyleBackColor = true;
            // 
            // elementHostMemoryPatch
            // 
            this.elementHostMemoryPatch.Location = new System.Drawing.Point(5, 5);
            this.elementHostMemoryPatch.Name = "elementHostMemoryPatch";
            this.elementHostMemoryPatch.Size = new System.Drawing.Size(448, 251);
            this.elementHostMemoryPatch.TabIndex = 15;
            this.elementHostMemoryPatch.Child = this.avalonEditProxyMemoryPatch;
            // 
            // comboBoxMemoryPatchTargetModule
            // 
            this.comboBoxMemoryPatchTargetModule.FormattingEnabled = true;
            this.comboBoxMemoryPatchTargetModule.Items.AddRange(new object[] {
            "nfsw.exe",
            "gameplay.dll",
            "gameplay.native.dll",
            "eawebkit.dll"});
            this.comboBoxMemoryPatchTargetModule.Location = new System.Drawing.Point(230, 262);
            this.comboBoxMemoryPatchTargetModule.Name = "comboBoxMemoryPatchTargetModule";
            this.comboBoxMemoryPatchTargetModule.Size = new System.Drawing.Size(223, 21);
            this.comboBoxMemoryPatchTargetModule.TabIndex = 14;
            this.comboBoxMemoryPatchTargetModule.Text = "Target Module";
            // 
            // openMemoryPatchAddonDetails
            // 
            this.openMemoryPatchAddonDetails.Location = new System.Drawing.Point(230, 289);
            this.openMemoryPatchAddonDetails.Name = "openMemoryPatchAddonDetails";
            this.openMemoryPatchAddonDetails.Size = new System.Drawing.Size(223, 23);
            this.openMemoryPatchAddonDetails.TabIndex = 13;
            this.openMemoryPatchAddonDetails.Text = "Addon Details";
            this.openMemoryPatchAddonDetails.UseVisualStyleBackColor = true;
            this.openMemoryPatchAddonDetails.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // createMemoryPatch
            // 
            this.createMemoryPatch.Location = new System.Drawing.Point(344, 318);
            this.createMemoryPatch.Name = "createMemoryPatch";
            this.createMemoryPatch.Size = new System.Drawing.Size(109, 23);
            this.createMemoryPatch.TabIndex = 11;
            this.createMemoryPatch.Text = "Create";
            this.createMemoryPatch.UseVisualStyleBackColor = true;
            this.createMemoryPatch.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // discardMemoryPatch
            // 
            this.discardMemoryPatch.Location = new System.Drawing.Point(230, 318);
            this.discardMemoryPatch.Name = "discardMemoryPatch";
            this.discardMemoryPatch.Size = new System.Drawing.Size(108, 23);
            this.discardMemoryPatch.TabIndex = 12;
            this.discardMemoryPatch.Text = "Discard";
            this.discardMemoryPatch.UseVisualStyleBackColor = true;
            this.discardMemoryPatch.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // installAddonGroupBox
            // 
            this.installAddonGroupBox.Controls.Add(this.label7);
            this.installAddonGroupBox.Controls.Add(this.label3);
            this.installAddonGroupBox.Controls.Add(this.label2);
            this.installAddonGroupBox.Controls.Add(this.addonInformationLabel);
            this.installAddonGroupBox.Controls.Add(this.buttonAddonInstall);
            this.installAddonGroupBox.Controls.Add(this.addonLocationLabel);
            this.installAddonGroupBox.Controls.Add(this.buttonAddonBrowse);
            this.installAddonGroupBox.Controls.Add(this.label1);
            this.installAddonGroupBox.Location = new System.Drawing.Point(485, 28);
            this.installAddonGroupBox.Name = "installAddonGroupBox";
            this.installAddonGroupBox.Size = new System.Drawing.Size(403, 371);
            this.installAddonGroupBox.TabIndex = 3;
            this.installAddonGroupBox.TabStop = false;
            this.installAddonGroupBox.Text = "Install an addon";
            // 
            // label7
            // 
            this.label7.AllowDrop = true;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "or drop here";
            this.label7.DragDrop += new System.Windows.Forms.DragEventHandler(this.browseAddon_DragDrop);
            this.label7.DragEnter += new System.Windows.Forms.DragEventHandler(this.control_DragEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(187, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Addon Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(9, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Addon Information:";
            // 
            // addonInformationLabel
            // 
            this.addonInformationLabel.Location = new System.Drawing.Point(9, 104);
            this.addonInformationLabel.Name = "addonInformationLabel";
            this.addonInformationLabel.Size = new System.Drawing.Size(172, 253);
            this.addonInformationLabel.TabIndex = 5;
            this.addonInformationLabel.Text = "- Name: (null)\r\n- Type: (null)\r\n- Created by: (null)\r\n- Created on: (null)\r\n- Ver" +
    "sion: (null)\r\n- Made for offline server version: (null)\r\n";
            // 
            // buttonAddonInstall
            // 
            this.buttonAddonInstall.Enabled = false;
            this.buttonAddonInstall.Location = new System.Drawing.Point(280, 342);
            this.buttonAddonInstall.Name = "buttonAddonInstall";
            this.buttonAddonInstall.Size = new System.Drawing.Size(117, 23);
            this.buttonAddonInstall.TabIndex = 4;
            this.buttonAddonInstall.Text = "Install Addon";
            this.buttonAddonInstall.UseVisualStyleBackColor = true;
            this.buttonAddonInstall.Click += new System.EventHandler(this.installAnAddonButton_Click);
            // 
            // addonLocationLabel
            // 
            this.addonLocationLabel.AllowDrop = true;
            this.addonLocationLabel.AutoEllipsis = true;
            this.addonLocationLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.addonLocationLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.addonLocationLabel.Location = new System.Drawing.Point(12, 42);
            this.addonLocationLabel.Name = "addonLocationLabel";
            this.addonLocationLabel.Size = new System.Drawing.Size(151, 15);
            this.addonLocationLabel.TabIndex = 3;
            this.addonLocationLabel.Text = "(empty)";
            this.addonLocationLabel.DragDrop += new System.Windows.Forms.DragEventHandler(this.browseAddon_DragDrop);
            this.addonLocationLabel.DragEnter += new System.Windows.Forms.DragEventHandler(this.control_DragEnter);
            // 
            // buttonAddonBrowse
            // 
            this.buttonAddonBrowse.AllowDrop = true;
            this.buttonAddonBrowse.Location = new System.Drawing.Point(12, 61);
            this.buttonAddonBrowse.Name = "buttonAddonBrowse";
            this.buttonAddonBrowse.Size = new System.Drawing.Size(67, 23);
            this.buttonAddonBrowse.TabIndex = 1;
            this.buttonAddonBrowse.Text = "Browse...";
            this.buttonAddonBrowse.UseVisualStyleBackColor = true;
            this.buttonAddonBrowse.Click += new System.EventHandler(this.installAnAddonButton_Click);
            this.buttonAddonBrowse.DragDrop += new System.Windows.Forms.DragEventHandler(this.browseAddon_DragDrop);
            this.buttonAddonBrowse.DragEnter += new System.Windows.Forms.DragEventHandler(this.control_DragEnter);
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Addon location:";
            this.label1.DragDrop += new System.Windows.Forms.DragEventHandler(this.browseAddon_DragDrop);
            this.label1.DragEnter += new System.Windows.Forms.DragEventHandler(this.control_DragEnter);
            // 
            // addonLocationDialog
            // 
            this.addonLocationDialog.AddExtension = false;
            this.addonLocationDialog.Filter = "Catalog and basket pack|*.serveraddon.catalogwithbasket|Accent|*.serveraddon.acce" +
    "nt|Theme|*.serveraddon.theme|Language|*.serveraddon.language|Memory Patch|*.serv" +
    "eraddon.memorypatch";
            this.addonLocationDialog.SupportMultiDottedExtensions = true;
            this.addonLocationDialog.Title = "Select an addon...";
            // 
            // saveProjectDialog
            // 
            this.saveProjectDialog.DefaultExt = "addonmanager.project";
            this.saveProjectDialog.FileName = "MyNewAddonProject";
            this.saveProjectDialog.Filter = "Project files|*.addonmanager.project";
            this.saveProjectDialog.SupportMultiDottedExtensions = true;
            this.saveProjectDialog.Title = "Save addon manager project file";
            // 
            // openProjectDialog
            // 
            this.openProjectDialog.DefaultExt = "addonmanager.project";
            this.openProjectDialog.FileName = "MyAddonProject";
            this.openProjectDialog.Filter = "Project files|*.addonmanager.project";
            this.openProjectDialog.SupportMultiDottedExtensions = true;
            this.openProjectDialog.Title = "Select an addon manager project file...";
            // 
            // createAddonDialog
            // 
            this.createAddonDialog.FileName = "MyNewAddon";
            this.createAddonDialog.Filter = "Catalog and basket pack|*.serveraddon.catalogwithbasket|Accent|*.serveraddon.acce" +
    "nt|Theme|*.serveraddon.theme|Language|*.serveraddon.language|Memory Patch|*.serv" +
    "eraddon.memorypatch";
            this.createAddonDialog.SupportMultiDottedExtensions = true;
            this.createAddonDialog.Title = "Create an addon";
            // 
            // listBoxRemoveItemContextMenu
            // 
            this.listBoxRemoveItemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuRemove});
            this.listBoxRemoveItemContextMenu.Name = "listBoxRemoveItemContextMenu";
            this.listBoxRemoveItemContextMenu.Size = new System.Drawing.Size(118, 26);
            // 
            // contextMenuRemove
            // 
            this.contextMenuRemove.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuRemoveOption1,
            this.contextMenuRemoveOption2,
            this.contextMenuRemoveOption3});
            this.contextMenuRemove.Name = "contextMenuRemove";
            this.contextMenuRemove.Size = new System.Drawing.Size(117, 22);
            this.contextMenuRemove.Text = "Remove";
            this.contextMenuRemove.ToolTipText = "Removes the selected item from the listbox.";
            // 
            // contextMenuRemoveOption1
            // 
            this.contextMenuRemoveOption1.Name = "contextMenuRemoveOption1";
            this.contextMenuRemoveOption1.Size = new System.Drawing.Size(342, 22);
            this.contextMenuRemoveOption1.Text = "Remove selected item (del)";
            this.contextMenuRemoveOption1.Click += new System.EventHandler(this.removeListBoxEntryMenuItem_Click);
            // 
            // contextMenuRemoveOption2
            // 
            this.contextMenuRemoveOption2.Name = "contextMenuRemoveOption2";
            this.contextMenuRemoveOption2.Size = new System.Drawing.Size(342, 22);
            this.contextMenuRemoveOption2.Text = "Remove everything but the selected item (ctrl+del)";
            this.contextMenuRemoveOption2.Click += new System.EventHandler(this.removeListBoxEntryMenuItem_Click);
            // 
            // contextMenuRemoveOption3
            // 
            this.contextMenuRemoveOption3.Name = "contextMenuRemoveOption3";
            this.contextMenuRemoveOption3.Size = new System.Drawing.Size(342, 22);
            this.contextMenuRemoveOption3.Text = "Remove everything (shift+del)";
            this.contextMenuRemoveOption3.Click += new System.EventHandler(this.removeListBoxEntryMenuItem_Click);
            // 
            // addonManagerToolStrip
            // 
            this.addonManagerToolStrip.CanOverflow = false;
            this.addonManagerToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.addonManagerToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripItemFile,
            this.toolStripButtonAbout});
            this.addonManagerToolStrip.Location = new System.Drawing.Point(0, 0);
            this.addonManagerToolStrip.Name = "addonManagerToolStrip";
            this.addonManagerToolStrip.Size = new System.Drawing.Size(900, 25);
            this.addonManagerToolStrip.TabIndex = 7;
            // 
            // toolStripItemFile
            // 
            this.toolStripItemFile.AutoToolTip = false;
            this.toolStripItemFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenProject,
            this.toolStripMenuItemSaveProject,
            this.toolStripMenuItemSaveProjectAs,
            this.toolStripSeparator1,
            this.toolStripMenuItemExit});
            this.toolStripItemFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripItemFile.Image")));
            this.toolStripItemFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripItemFile.Name = "toolStripItemFile";
            this.toolStripItemFile.ShowDropDownArrow = false;
            this.toolStripItemFile.Size = new System.Drawing.Size(29, 22);
            this.toolStripItemFile.Text = "File";
            // 
            // toolStripMenuItemOpenProject
            // 
            this.toolStripMenuItemOpenProject.Name = "toolStripMenuItemOpenProject";
            this.toolStripMenuItemOpenProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItemOpenProject.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItemOpenProject.Text = "Open Project";
            this.toolStripMenuItemOpenProject.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItemSaveProject
            // 
            this.toolStripMenuItemSaveProject.Name = "toolStripMenuItemSaveProject";
            this.toolStripMenuItemSaveProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItemSaveProject.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItemSaveProject.Text = "Save Project";
            this.toolStripMenuItemSaveProject.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItemSaveProjectAs
            // 
            this.toolStripMenuItemSaveProjectAs.Name = "toolStripMenuItemSaveProjectAs";
            this.toolStripMenuItemSaveProjectAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItemSaveProjectAs.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItemSaveProjectAs.Text = "Save Project As...";
            this.toolStripMenuItemSaveProjectAs.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(232, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItemExit.Text = "Exit";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripButtonAbout
            // 
            this.toolStripButtonAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAbout.Image")));
            this.toolStripButtonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAbout.Name = "toolStripButtonAbout";
            this.toolStripButtonAbout.Size = new System.Drawing.Size(44, 22);
            this.toolStripButtonAbout.Text = "About";
            this.toolStripButtonAbout.Click += new System.EventHandler(this.toolStripButton_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(5, 289);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 52);
            this.label8.TabIndex = 22;
            this.label8.Text = "Please do not ONLY translate language file. Add yourself into the mix, make it yo" +
    "urs.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(900, 413);
            this.Controls.Add(this.addonManagerToolStrip);
            this.Controls.Add(this.installAddonGroupBox);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Offline Server: Addon Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPageCatalog.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPageAccent.ResumeLayout(false);
            this.tabPageTheme.ResumeLayout(false);
            this.tabPageLanguage.ResumeLayout(false);
            this.tabPageMemoryPatch.ResumeLayout(false);
            this.installAddonGroupBox.ResumeLayout(false);
            this.installAddonGroupBox.PerformLayout();
            this.listBoxRemoveItemContextMenu.ResumeLayout(false);
            this.addonManagerToolStrip.ResumeLayout(false);
            this.addonManagerToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCatalog;
        private System.Windows.Forms.Button createCatalog;
        private System.Windows.Forms.Button discardCatalog;
        private System.Windows.Forms.TabPage tabPageAccent;
        private System.Windows.Forms.TabPage tabPageTheme;
        private System.Windows.Forms.TabPage tabPageLanguage;
        private System.Windows.Forms.GroupBox installAddonGroupBox;
        private System.Windows.Forms.Button buttonAddonInstall;
        private System.Windows.Forms.Label addonLocationLabel;
        private System.Windows.Forms.Button buttonAddonBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label addonInformationLabel;
        internal System.Windows.Forms.OpenFileDialog addonLocationDialog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private CustomControls.ActiveCheckedListBox categoriesListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox basketsListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SaveFileDialog saveProjectDialog;
        private CustomControls.ActiveCheckedListBox productsListBox;
        private System.Windows.Forms.OpenFileDialog openProjectDialog;
        private System.Windows.Forms.SaveFileDialog createAddonDialog;
        private System.Windows.Forms.Button openCatalogAddonDetails;
        private System.Windows.Forms.TabPage tabPageMemoryPatch;
        private System.Windows.Forms.ContextMenuStrip listBoxRemoveItemContextMenu;
        private System.Windows.Forms.ToolStripMenuItem contextMenuRemove;
        private System.Windows.Forms.ToolStripMenuItem contextMenuRemoveOption1;
        private System.Windows.Forms.ToolStripMenuItem contextMenuRemoveOption2;
        private System.Windows.Forms.ToolStripMenuItem contextMenuRemoveOption3;
        private System.Windows.Forms.ToolStrip addonManagerToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenProject;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveProject;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveProjectAs;
        private System.Windows.Forms.ToolStripButton toolStripButtonAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ComboBox comboBoxMemoryPatchTargetModule;
        private System.Windows.Forms.Button openMemoryPatchAddonDetails;
        private System.Windows.Forms.Button createMemoryPatch;
        private System.Windows.Forms.Button discardMemoryPatch;
        private System.Windows.Forms.Integration.ElementHost elementHostMemoryPatch;
        private AvalonEditProxy avalonEditProxyMemoryPatch;
        private System.Windows.Forms.Integration.ElementHost elementHostAccent;
        private System.Windows.Forms.Button openAccentAddonDetails;
        private System.Windows.Forms.Button createAccent;
        private System.Windows.Forms.Button discardAccent;
        private System.Windows.Forms.Integration.ElementHost elementHostTheme;
        private System.Windows.Forms.Button openThemeAddonDetails;
        private System.Windows.Forms.Button createTheme;
        private System.Windows.Forms.Button discardTheme;
        private System.Windows.Forms.Integration.ElementHost elementHostLanguage;
        private System.Windows.Forms.Button openLanguageAddonDetails;
        private System.Windows.Forms.Button createLanguage;
        private System.Windows.Forms.Button discardLanguage;
        private AvalonEditProxy avalonEditProxyAccent;
        private System.Windows.Forms.Button openLanguageDefault;
        private AvalonEditProxy avalonEditProxyTheme;
        private AvalonEditProxy avalonEditProxyLanguage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}