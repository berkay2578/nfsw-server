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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.catalogDescriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.catalogCreaterTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.basketsListBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.categoriesListBox = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.productsListBox = new System.Windows.Forms.CheckedListBox();
            this.createCatalog = new System.Windows.Forms.Button();
            this.discardCatalog = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.createAccent = new System.Windows.Forms.Button();
            this.discardAccent = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.createTheme = new System.Windows.Forms.Button();
            this.discardTheme = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.createLanguage = new System.Windows.Forms.Button();
            this.discardLanguage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addonInformationLabel = new System.Windows.Forms.Label();
            this.addonInstallButton = new System.Windows.Forms.Button();
            this.addonLocationLabel = new System.Windows.Forms.Label();
            this.addonDescriptionLabel = new System.Windows.Forms.Label();
            this.addonLocationButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addonLocationDialog = new System.Windows.Forms.OpenFileDialog();
            this.serverVersionLabel = new System.Windows.Forms.Label();
            this.saveProject = new System.Windows.Forms.Button();
            this.loadProject = new System.Windows.Forms.Button();
            this.saveProjectDialog = new System.Windows.Forms.SaveFileDialog();
            this.openProjectDialog = new System.Windows.Forms.OpenFileDialog();
            this.createAddonDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(467, 373);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.catalogDescriptionTextBox);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.catalogCreaterTextBox);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.createCatalog);
            this.tabPage2.Controls.Add(this.discardCatalog);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(459, 347);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Catalog and Basket Packs";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // catalogDescriptionTextBox
            // 
            this.catalogDescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.catalogDescriptionTextBox.Location = new System.Drawing.Point(236, 261);
            this.catalogDescriptionTextBox.MaxLength = 255;
            this.catalogDescriptionTextBox.Name = "catalogDescriptionTextBox";
            this.catalogDescriptionTextBox.Size = new System.Drawing.Size(217, 51);
            this.catalogDescriptionTextBox.TabIndex = 13;
            this.catalogDescriptionTextBox.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(236, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Description: (max 255 chars)";
            // 
            // catalogCreaterTextBox
            // 
            this.catalogCreaterTextBox.Location = new System.Drawing.Point(236, 220);
            this.catalogCreaterTextBox.MaxLength = 255;
            this.catalogCreaterTextBox.Name = "catalogCreaterTextBox";
            this.catalogCreaterTextBox.Size = new System.Drawing.Size(217, 20);
            this.catalogCreaterTextBox.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(236, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Created by: (max 255 chars)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.basketsListBox);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(230, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 191);
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
            this.basketsListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.basketsListBox.Size = new System.Drawing.Size(211, 147);
            this.basketsListBox.TabIndex = 4;
            this.basketsListBox.TabStop = false;
            this.basketsListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_DragDrop);
            this.basketsListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
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
            this.categoriesListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.categoriesListBox.Size = new System.Drawing.Size(206, 124);
            this.categoriesListBox.TabIndex = 2;
            this.categoriesListBox.TabStop = false;
            this.categoriesListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.checkedListBox_DragDrop);
            this.categoriesListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
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
            this.productsListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.productsListBox.Size = new System.Drawing.Size(206, 139);
            this.productsListBox.TabIndex = 0;
            this.productsListBox.TabStop = false;
            this.productsListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.checkedListBox_DragDrop);
            this.productsListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_DragEnter);
            // 
            // createCatalog
            // 
            this.createCatalog.Location = new System.Drawing.Point(378, 318);
            this.createCatalog.Name = "createCatalog";
            this.createCatalog.Size = new System.Drawing.Size(75, 23);
            this.createCatalog.TabIndex = 5;
            this.createCatalog.Text = "Create";
            this.createCatalog.UseVisualStyleBackColor = true;
            this.createCatalog.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // discardCatalog
            // 
            this.discardCatalog.Location = new System.Drawing.Point(300, 318);
            this.discardCatalog.Name = "discardCatalog";
            this.discardCatalog.Size = new System.Drawing.Size(75, 23);
            this.discardCatalog.TabIndex = 6;
            this.discardCatalog.Text = "Discard";
            this.discardCatalog.UseVisualStyleBackColor = true;
            this.discardCatalog.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.createAccent);
            this.tabPage3.Controls.Add(this.discardAccent);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(459, 347);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Accent";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // createAccent
            // 
            this.createAccent.Location = new System.Drawing.Point(381, 303);
            this.createAccent.Name = "createAccent";
            this.createAccent.Size = new System.Drawing.Size(75, 23);
            this.createAccent.TabIndex = 5;
            this.createAccent.Text = "Create";
            this.createAccent.UseVisualStyleBackColor = true;
            this.createAccent.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // discardAccent
            // 
            this.discardAccent.Location = new System.Drawing.Point(300, 303);
            this.discardAccent.Name = "discardAccent";
            this.discardAccent.Size = new System.Drawing.Size(75, 23);
            this.discardAccent.TabIndex = 6;
            this.discardAccent.Text = "Discard";
            this.discardAccent.UseVisualStyleBackColor = true;
            this.discardAccent.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.createTheme);
            this.tabPage4.Controls.Add(this.discardTheme);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(459, 347);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Theme";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // createTheme
            // 
            this.createTheme.Location = new System.Drawing.Point(381, 303);
            this.createTheme.Name = "createTheme";
            this.createTheme.Size = new System.Drawing.Size(75, 23);
            this.createTheme.TabIndex = 5;
            this.createTheme.Text = "Create";
            this.createTheme.UseVisualStyleBackColor = true;
            this.createTheme.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // discardTheme
            // 
            this.discardTheme.Location = new System.Drawing.Point(300, 303);
            this.discardTheme.Name = "discardTheme";
            this.discardTheme.Size = new System.Drawing.Size(75, 23);
            this.discardTheme.TabIndex = 6;
            this.discardTheme.Text = "Discard";
            this.discardTheme.UseVisualStyleBackColor = true;
            this.discardTheme.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.createLanguage);
            this.tabPage5.Controls.Add(this.discardLanguage);
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(459, 347);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Language";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // createLanguage
            // 
            this.createLanguage.Location = new System.Drawing.Point(381, 303);
            this.createLanguage.Name = "createLanguage";
            this.createLanguage.Size = new System.Drawing.Size(75, 23);
            this.createLanguage.TabIndex = 5;
            this.createLanguage.Text = "Create";
            this.createLanguage.UseVisualStyleBackColor = true;
            this.createLanguage.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // discardLanguage
            // 
            this.discardLanguage.Location = new System.Drawing.Point(300, 303);
            this.discardLanguage.Name = "discardLanguage";
            this.discardLanguage.Size = new System.Drawing.Size(75, 23);
            this.discardLanguage.TabIndex = 6;
            this.discardLanguage.Text = "Discard";
            this.discardLanguage.UseVisualStyleBackColor = true;
            this.discardLanguage.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.addonInformationLabel);
            this.groupBox1.Controls.Add(this.addonInstallButton);
            this.groupBox1.Controls.Add(this.addonLocationLabel);
            this.groupBox1.Controls.Add(this.addonDescriptionLabel);
            this.groupBox1.Controls.Add(this.addonLocationButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(485, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 371);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Install an addon";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(9, 227);
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
            this.addonInformationLabel.Size = new System.Drawing.Size(240, 123);
            this.addonInformationLabel.TabIndex = 5;
            this.addonInformationLabel.Text = "- Type: (null)\r\n- Created by: (null)\r\n- Created on: (null)\r\n- Made for version:\r\n" +
    "(null)\r\n";
            // 
            // addonInstallButton
            // 
            this.addonInstallButton.Enabled = false;
            this.addonInstallButton.Location = new System.Drawing.Point(132, 342);
            this.addonInstallButton.Name = "addonInstallButton";
            this.addonInstallButton.Size = new System.Drawing.Size(117, 23);
            this.addonInstallButton.TabIndex = 4;
            this.addonInstallButton.Text = "Install Addon";
            this.addonInstallButton.UseVisualStyleBackColor = true;
            this.addonInstallButton.Click += new System.EventHandler(this.addonInstallButton_Click);
            // 
            // addonLocationLabel
            // 
            this.addonLocationLabel.AutoEllipsis = true;
            this.addonLocationLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.addonLocationLabel.Enabled = false;
            this.addonLocationLabel.Location = new System.Drawing.Point(12, 42);
            this.addonLocationLabel.Name = "addonLocationLabel";
            this.addonLocationLabel.Size = new System.Drawing.Size(237, 15);
            this.addonLocationLabel.TabIndex = 3;
            this.addonLocationLabel.Text = "(empty)";
            // 
            // addonDescriptionLabel
            // 
            this.addonDescriptionLabel.Location = new System.Drawing.Point(9, 241);
            this.addonDescriptionLabel.Name = "addonDescriptionLabel";
            this.addonDescriptionLabel.Size = new System.Drawing.Size(240, 98);
            this.addonDescriptionLabel.TabIndex = 2;
            this.addonDescriptionLabel.Text = "(empty)";
            // 
            // addonLocationButton
            // 
            this.addonLocationButton.Location = new System.Drawing.Point(12, 61);
            this.addonLocationButton.Name = "addonLocationButton";
            this.addonLocationButton.Size = new System.Drawing.Size(75, 23);
            this.addonLocationButton.TabIndex = 1;
            this.addonLocationButton.Text = "Browse...";
            this.addonLocationButton.UseVisualStyleBackColor = true;
            this.addonLocationButton.Click += new System.EventHandler(this.addonLocationButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Addon location:";
            // 
            // addonLocationDialog
            // 
            this.addonLocationDialog.AddExtension = false;
            this.addonLocationDialog.Filter = "Catalog and basket packs|*.serveraddon_catalogwithbasket|Accent|*.serveraddon_acc" +
    "ent|Theme|*.serveraddon_theme|Language|*.serveraddon_language";
            this.addonLocationDialog.Title = "Select an addon...";
            // 
            // serverVersionLabel
            // 
            this.serverVersionLabel.Location = new System.Drawing.Point(494, 386);
            this.serverVersionLabel.Name = "serverVersionLabel";
            this.serverVersionLabel.Size = new System.Drawing.Size(237, 28);
            this.serverVersionLabel.TabIndex = 4;
            this.serverVersionLabel.Text = "Your Offline Server version is\r\n{0}";
            this.serverVersionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // saveProject
            // 
            this.saveProject.Location = new System.Drawing.Point(12, 391);
            this.saveProject.Name = "saveProject";
            this.saveProject.Size = new System.Drawing.Size(91, 23);
            this.saveProject.TabIndex = 5;
            this.saveProject.Text = "Save Project";
            this.saveProject.UseVisualStyleBackColor = true;
            this.saveProject.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // loadProject
            // 
            this.loadProject.Location = new System.Drawing.Point(109, 391);
            this.loadProject.Name = "loadProject";
            this.loadProject.Size = new System.Drawing.Size(91, 23);
            this.loadProject.TabIndex = 6;
            this.loadProject.Text = "Load Project";
            this.loadProject.UseVisualStyleBackColor = true;
            this.loadProject.Click += new System.EventHandler(this.tabButton_Click);
            // 
            // saveProjectDialog
            // 
            this.saveProjectDialog.DefaultExt = "addonmanager_project";
            this.saveProjectDialog.FileName = "MyNewAddonProject";
            this.saveProjectDialog.Filter = "Project files|*.addonmanager_project";
            this.saveProjectDialog.Title = "Save addon manager project file";
            // 
            // openProjectDialog
            // 
            this.openProjectDialog.DefaultExt = "addonmanager_project";
            this.openProjectDialog.FileName = "MyAddonProject";
            this.openProjectDialog.Filter = "Project files|*.addonmanager_project";
            this.openProjectDialog.Title = "Select an addon manager project file...";
            // 
            // createAddonDialog
            // 
            this.createAddonDialog.FileName = "MyNewAddon";
            this.createAddonDialog.Filter = "Catalog and basket packs|*.serveraddon_catalogwithbasket|Accent|*.serveraddon_acc" +
    "ent|Theme|*.serveraddon_theme|Language|*.serveraddon_language";
            this.createAddonDialog.Title = "Create an addon";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 423);
            this.Controls.Add(this.loadProject);
            this.Controls.Add(this.saveProject);
            this.Controls.Add(this.serverVersionLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Offline Server: Addon Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button createCatalog;
        private System.Windows.Forms.Button discardCatalog;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button createAccent;
        private System.Windows.Forms.Button discardAccent;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button createTheme;
        private System.Windows.Forms.Button discardTheme;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button createLanguage;
        private System.Windows.Forms.Button discardLanguage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addonInstallButton;
        private System.Windows.Forms.Label addonLocationLabel;
        private System.Windows.Forms.Label addonDescriptionLabel;
        private System.Windows.Forms.Button addonLocationButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label addonInformationLabel;
        internal System.Windows.Forms.OpenFileDialog addonLocationDialog;
        private System.Windows.Forms.Label serverVersionLabel;
        private System.Windows.Forms.Button saveProject;
        private System.Windows.Forms.Button loadProject;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox categoriesListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox basketsListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox catalogDescriptionTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox catalogCreaterTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SaveFileDialog saveProjectDialog;
        private System.Windows.Forms.CheckedListBox productsListBox;
        private System.Windows.Forms.OpenFileDialog openProjectDialog;
        private System.Windows.Forms.SaveFileDialog createAddonDialog;
    }
}